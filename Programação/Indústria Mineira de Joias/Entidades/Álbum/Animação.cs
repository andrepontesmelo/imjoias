using Acesso.Comum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;

namespace Entidades.�lbum
{
    /// <summary>
    /// Uma anima��o � uma lista de imagens.
    /// Ela pode obter no banco de dados em uma s� consulta as v�rias imagens
    /// de uma refer�ncia.
    /// O tempo de passagem de um frame para outro n�o � definido na anima��o,
    /// mas sim no mostrador de anima��o. (ver Apresenta��o.Mercadoria.MostradorAnima��o)
    /// </summary>
    public class Anima��o : DbManipula��oSimples, IDisposable
	{
		// Atributos
		private List<Image> imagens;

		#region Propriedades
	
		/// <summary>
		/// Obt�m a lista de imagens
		/// </summary>
		public List<Image> Imagens
		{
			get { return imagens; }
		}

		/// <summary>
		/// Obt�m primeiro frame da anima��o. � nulo caso n�o exista.
		/// </summary>
		/// <example>
		/// Usada onde n�o � poss�vel mostrar anima��o. 
		/// Foto usada na bandeja.
		/// </example>
		/// <remarks> 
		/// pode-se futuramente mudar a implementa��o,
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
		public Anima��o()
		{
            imagens = new List<Image>();
		}

		/// <summary>
		/// Rediomensiona todos os frames da anima��o, um por um,
		/// de forma que caiba em um ret�ngulo de dimens�es
		/// larguraM�xima x alturaM�xima sem cortes e sem deforma��es.
		/// </summary>
		public void RedimensionarAnima��o(int larguraM�xima, int alturaM�xima)
		{
			for(int x = 0; x < imagens.Count; x++)
			{
				imagens[x] = Entidades.�lbum.Foto.Redesenhar
					((Image) imagens[x], larguraM�xima, alturaM�xima);

			}
		}

		/// <summary>
		/// Obt�m no banco de dados as v�rias imagems para refer�ncia informada
		/// e cria uma anima��o
		/// </summary>
		/// <param name="refer�nciaNum�rica"></param>
		/// <returns></returns>
		public static Anima��o ObterAnima��o(Mercadoria.Mercadoria mercadoria)
		{
            Console.WriteLine("Anima��o::ObterAnima��o()");

			IDataReader   leitor = null;
			ArrayList     dados = new ArrayList();
			Anima��o      anima��o;
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT foto FROM foto WHERE mercadoria = " + DbTransformar(mercadoria.Refer�nciaNum�rica);

                    using (leitor = cmd.ExecuteReader())
                    {

                        try
                        {
                            while (leitor.Read())
                            {
                                /* Para minimizar o tempo com a conex�o presa,
                                 * o processamento da imagem s� ser� feito
                                 * ap�s recuperar todos os dados do banco de dados,
                                 * liberando assim a conex�o.
                                 * -- J�lio, 18/11/2005
                                 */
                                dados.Add(leitor.GetValue(0));
                            }
                        }
                        finally
                        {
                            if (leitor != null)
                                leitor.Close();

                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                        }
                    }
                }
            }

			if (dados.Count == 0)
				return null;

			anima��o = new Anima��o();

            foreach (byte[] objFoto in dados)
            {
                Image imagem = (Image)new DbFoto(objFoto);

                if (imagem != null)
                    anima��o.Imagens.Add(imagem);
            }

            Console.WriteLine("Fim Anima��o::ObterAnima��o()");

			return anima��o;
		}


		/// <summary>
		/// Converte um vetor de bytes para uma imagem
		/// </summary>
		/// <param name="bytes">Bytes que representam a imagem codificada</param>
		/// <returns>Imagem</returns>
		private static Image ConverterParaImagem(byte [] bytes)
		{
            Console.WriteLine("Anima��o::ConverterParaImagem!()");
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
