using Acesso.Comum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;

namespace Entidades.Álbum
{
    /// <summary>
    /// Uma animação é uma lista de imagens.
    /// Ela pode obter no banco de dados em uma só consulta as várias imagens
    /// de uma referência.
    /// O tempo de passagem de um frame para outro não é definido na animação,
    /// mas sim no mostrador de animação. (ver Apresentação.Mercadoria.MostradorAnimação)
    /// </summary>
    public class Animação : DbManipulaçãoSimples, IDisposable
	{
		// Atributos
		private List<Image> imagens;

		#region Propriedades
	
		/// <summary>
		/// Obtém a lista de imagens
		/// </summary>
		public List<Image> Imagens
		{
			get { return imagens; }
		}

		/// <summary>
		/// Obtém primeiro frame da animação. É nulo caso não exista.
		/// </summary>
		/// <example>
		/// Usada onde não é possível mostrar animação. 
		/// Foto usada na bandeja.
		/// </example>
		/// <remarks> 
		/// pode-se futuramente mudar a implementação,
		/// criando uma imagem com todas as imagens juntas, uma ao lado da outra.
		/// </remarks>
		public Image Foto
		{
			get 
			{
				if (imagens.Count == 0) return null;
				return imagens[0];
			}
		}

		#endregion
		public Animação()
		{
            imagens = new List<Image>();
		}

		/// <summary>
		/// Rediomensiona todos os frames da animação, um por um,
		/// de forma que caiba em um retângulo de dimensões
		/// larguraMáxima x alturaMáxima sem cortes e sem deformações.
		/// </summary>
		public void RedimensionarAnimação(int larguraMáxima, int alturaMáxima)
		{
			for(int x = 0; x < imagens.Count; x++)
			{
				imagens[x] = Entidades.Álbum.Foto.Redesenhar
					((Image) imagens[x], larguraMáxima, alturaMáxima);

			}
		}

		/// <summary>
		/// Obtém no banco de dados as várias imagems para referência informada
		/// e cria uma animação
		/// </summary>
		/// <param name="referênciaNumérica"></param>
		/// <returns></returns>
		public static Animação ObterAnimação(Mercadoria.Mercadoria mercadoria)
		{
            Console.WriteLine("Animação::ObterAnimação()");

			IDataReader   leitor = null;
			ArrayList     dados = new ArrayList();
			Animação      animação;
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT foto FROM foto WHERE mercadoria = " + DbTransformar(mercadoria.ReferênciaNumérica);

                    using (leitor = cmd.ExecuteReader())
                    {

                        try
                        {
                            while (leitor.Read())
                            {
                                /* Para minimizar o tempo com a conexão presa,
                                 * o processamento da imagem só será feito
                                 * após recuperar todos os dados do banco de dados,
                                 * liberando assim a conexão.
                                 * -- Júlio, 18/11/2005
                                 */
                                dados.Add(leitor.GetValue(0));
                            }
                        }
                        finally
                        {
                            if (leitor != null)
                                leitor.Close();

                            Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                        }
                    }
                }
            }

			if (dados.Count == 0)
				return null;

			animação = new Animação();

            foreach (byte[] objFoto in dados)
            {
                Image imagem = (Image)new DbFoto(objFoto);

                if (imagem != null)
                    animação.Imagens.Add(imagem);
            }

            Console.WriteLine("Fim Animação::ObterAnimação()");

			return animação;
		}


		/// <summary>
		/// Converte um vetor de bytes para uma imagem
		/// </summary>
		/// <param name="bytes">Bytes que representam a imagem codificada</param>
		/// <returns>Imagem</returns>
		private static Image ConverterParaImagem(byte [] bytes)
		{
            Console.WriteLine("Animação::ConverterParaImagem!()");
			if (bytes != null)
			{
				Image		 imagem;
				MemoryStream memStream;

				memStream = new MemoryStream(bytes);

				try
				{
					imagem = Image.FromStream(memStream);
				} 
				catch
				{
					imagem = null;
				}
				finally
				{
					memStream.Close();
				}

				return imagem;
			}
			else
				return null;
		}

        public void Dispose()
        {
            foreach (Image imagem in imagens)
                imagem.Dispose();

            imagens.Clear();
        }

        public virtual bool Carregado
        {
            get { return true; }
        }
    }
}
