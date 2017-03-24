using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Acesso.Comum;
using Acesso.Comum.Cache;
using System.Data;
using System.Threading;
using System.Text;

namespace Entidades.Álbum
{
	/// <summary>
	/// Foto de mercadorias
	/// </summary>
	[Serializable]
    [Cacheável("ObterMiniaturaSemCache"), NãoCopiarCache]
    [DbTransação]
	public class Foto : DbManipulaçãoAutomática, IComparable<Foto>, IDisposable
	{
        private static LinkedList<Foto> fotosCarregadas = new LinkedList<Foto>();
        private const int limiteFotos = 30;
        private const int limiteTempoUso = 600; // Segundos
        private static Timer tmrVerificarFotos = null;

        [DbAtributo(TipoAtributo.Ignorar)]
        public const int tamanhoÍcone = 32;

		// Constantes
		[DbAtributo(TipoAtributo.Ignorar)]
		public static readonly int tamanhoMaiorLadoMiniatura = 90;

		// Atributos
		[DbChavePrimária(true)]
		private uint			codigo = 0;

		private string		    mercadoria;			// Referência numérica

		private string			descricao;
		
		private DateTime?		data;
		
		/// <summary>
		/// Foto original da mercadoria
		/// </summary>
		private DbFoto			foto = null;

        [DbColuna("icone")]
        private DbFoto ícone = null;
		
        /// <summary>
        /// Lista de álbuns em que esta foto está inserida.
        /// </summary>
        /// <remarks>
        /// Quando o valor é nulo, indica que não foi carregado
        /// ainda do banco de dados. Quando nenhum álbum está
        /// vinculado, a lista é instanciada, porém vazia.
        /// </remarks>
        [DbAtributo(TipoAtributo.Ignorar)]
        private ListaÁlbuns     álbuns;

        /// <summary>
        /// Último uso da foto na execução do sistema.
        /// </summary>
        [DbAtributo(TipoAtributo.Ignorar)]
        private DateTime últimoUso = DateTime.Now;

        /// <summary>
        /// Construção padrão
        /// </summary>
        public Foto()
        {
            mercadoria = descricao = null;
            data = DateTime.Now;
            álbuns = new ListaÁlbuns(this);
        }

        public Foto(uint código, string referênciaNumérica)
        {
            this.codigo = código;
            this.ReferênciaNumérica = referênciaNumérica;
        }

        #region Propriedades
		
		/// <summary>
		/// Referência numérica
		/// </summary>
		public string ReferênciaNumérica
		{ 
			get { return mercadoria; }
			set
            {
                mercadoria = value;

                DefinirDesatualizado();
            }
		}

        [DbAtributo(TipoAtributo.Ignorar)]
		private string referênciaFormatadaCache = null;

		public string ReferênciaFormatada
		{
			get
			{
				if (referênciaFormatadaCache == null && ReferênciaNumérica != null)
				    referênciaFormatadaCache = Entidades.Mercadoria.Mercadoria.MascararReferência(ReferênciaNumérica);

                return referênciaFormatadaCache;
			}
		}

		public string Descrição
		{
			get { return descricao; }
			set
            {
                descricao = value;
                DefinirDesatualizado();
            }
		}


		public DateTime? Data
		{
			get { return data; }
			set
            {
                data = value;
                DefinirDesatualizado();
            }
		}

		/// <summary>
		/// Pega ou Atribui imagem à foto.
		/// Aquí o ícone da foto é criado.
		/// </summary>
		public Image Imagem
		{
			get 
			{
                lock (this)
                {
                    if (foto == null || foto.Imagem == null)
                        foto = ObterFoto();

                    últimoUso = DateTime.Now;

                    return foto;
                }
			}
			set
			{
                lock (this)
                {
                    foto = value;

                    RefazÍcone();

                    DefinirDesatualizado();
                }
			}
		}

        public void RefazÍcone()
        {
            if (Imagem == null)
                ícone = null;
            else
                ícone = Redesenhar(Imagem, tamanhoÍcone, tamanhoÍcone);

            DefinirDesatualizado();
        }

        /// <summary>
        /// Indica se a foto já está preparada para exibição.
        /// </summary>
        public bool Preparada
        {
            get { return foto != null; }
        }

        public Image Ícone
        {
            get
            {
                lock (this)
                {
                    if (ícone == null)
                        ícone = ObterÍcone();

                    return ícone;
                }
            }
        }

		public uint Código
		{
			get { return codigo; }
		}

		public DbFoto Miniatura
		{
			get
			{
                return CacheMiniaturas.Instância.Obter(this);
			}
		}

        /// <summary>
        /// Lista de álbuns.
        /// </summary>
        public ListaÁlbuns Álbuns
        {
            get { return álbuns; }
        }

        ///// <summary>
        ///// Foto original, sem qualquer tipo de processamento de imagem.
        ///// </summary>
        //public Image FotoOriginal
        //{
        //    get
        //    {
        //        lock (this)
        //        {
        //            if (fotoOriginal == null)
        //                fotoOriginal = ObterFotoOriginal();

        //            últimoUso = DateTime.Now;

        //            return fotoOriginal;
        //        }
        //    }
        //    set
        //    {
        //        lock (this)
        //        {
        //            if (value == null)
        //                throw new Exception("Foto Original não pode ser nula");

        //            fotoOriginal = value;
        //            gravarOriginal = true;
        //            DefinirDesatualizado();
        //        }
        //    }
        //}

		#endregion

		/// <summary>
		/// Consulta ObterFotos()
		/// </summary>
		/// <remarks>
		/// o CódigoFoto é o mesmo que Código. É informação repetida.
		/// </remarks>
		private enum Ordem { Mercadoria, Dígito, Descrição, Icone, Data, 
			Código, CódigoFoto, Album }

        /// <summary>
        /// Assegura que a foto fora carregado do banco de dados.
        /// </summary>
        public void PrepararFoto()
        {
            lock (this)
            {
                if (foto == null)
                    foto = ObterFoto();
            }
        }

        public void LiberarFoto()
        {
#if DEBUG
            Console.WriteLine("Liberando foto " + ReferênciaFormatada);
#endif
            lock (this)
            {
                if (foto != null)
                {
                    foto.Dispose();
                    foto = null;
                }

                if (ícone != null)
                {
                    ícone.Dispose();
                    ícone = null;
                }

                //if (miniatura != null)
                //{
                //    miniatura.Dispose();
                //    miniatura = null;
                //    miniaturaObtida = false;
                //}
            }
        }

        /// <summary>
        /// Obtém a foto da mercadoria.
        /// </summary>
        /// <returns>Foto obtida do banco de dados.</returns>
		public DbFoto ObterFoto()
		{
			IDbConnection conexão = Conexão;
            object obj;

			lock (conexão)
			{
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "SELECT foto from foto where codigo=" + this.Código;

                        obj = cmd.ExecuteScalar();
                    }
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
			}

            MarcarObtenção(this);

            return new DbFoto((byte[])obj);
        }

        /// <summary>
        /// Obtém ícone do banco de dados.
        /// </summary>
        /// <returns>Ícone.</returns>
        private DbFoto ObterÍcone()
        {
            IDbConnection conexão = Conexão;
            object obj;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                
                try
                {

                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "SELECT icone FROM foto WHERE codigo=" + this.Código;

                        obj = cmd.ExecuteScalar();
                    }
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }

            return new DbFoto((byte[])obj);
        }

		/// <summary>
		/// Redimensiona uma imagem, de forma que possa ser colocada dentro 
		/// de um retângulo de dimensões larguraMáxima x alturaMáxima
		/// sem que hajam cortes na imagem nem que ela perca sua proporção.
		/// </summary>
		/// <remarks>
		/// Apesar do método estar no Álbum\Foto,
		/// ela não está diretamente relacionada com a tabela Foto.
		/// Porém, em várias partes do programa em que é util fazer um 
		/// redimensionamento, este método é usado. 
		/// </remarks>
		/// <param name="imagem"> Imagem a ser redimensionada </param>
		/// <param name="larguraMáxima"> pode ser a largura do retângulo</param>
		/// <param name="alturaMáxima">altura do retângulo</param>
		/// <returns></returns>
        [Obsolete("Utilize redesenhar")]
		public static Image Redimensionar(Image imagem, int larguraMáxima, int alturaMáxima)
		{
			int novaLargura, novaAltura;

			if (imagem == null) 
				throw new Exception("Não é possível Redimensionar uma imagem nula!");

			// magreza = altura / largura
			float magrezaFigura = Convert.ToSingle(imagem.Height) / Convert.ToSingle(imagem.Width);
			float magrezaPapel  = Convert.ToSingle(alturaMáxima) / Convert.ToSingle(larguraMáxima);

			// Se figura mais magra que a folha
			if (magrezaFigura > magrezaPapel)
			{
				// Nova altura = altura da folha
				novaAltura = alturaMáxima;
				novaLargura = Convert.ToInt32(novaAltura / magrezaFigura);
			} 
			else
			{
				// Nova largura = largura da folha
				novaLargura = larguraMáxima;
				novaAltura = Convert.ToInt32(novaLargura * magrezaFigura);
			}

			return 	imagem.GetThumbnailImage(novaLargura, novaAltura, null, IntPtr.Zero);
		}

        /// <summary>
        /// Redesenha uma imagem nas dimensões especificadas, mantendo
        /// a proporção da figura.
        /// </summary>
        /// <param name="imagem"> Imagem a ser redimensionada </param>
        /// <param name="largura"> pode ser a largura do retângulo</param>
        /// <param name="altura">altura do retângulo</param>
        /// <returns></returns>
        public static Bitmap Redesenhar(Image imagem, int largura, int altura)
        {
            int novaLargura, novaAltura;
            Bitmap nova;

            if (imagem == null)
                throw new Exception("Não é possível Redimensionar uma imagem nula!");

            // magreza = altura / largura
            double magrezaFigura = imagem.Height / (double)imagem.Width;
            double magrezaPapel = altura / (double)largura;

            // Se figura mais magra que a folha
            if (magrezaFigura > magrezaPapel)
            {
                // Nova altura = altura da folha
                novaAltura = altura;
                novaLargura = Convert.ToInt32(novaAltura / magrezaFigura);
            }
            else
            {
                // Nova largura = largura da folha
                novaLargura = largura;
                novaAltura = Convert.ToInt32(novaLargura * magrezaFigura);
            }

            nova = new Bitmap(largura, altura);

            using (Graphics g = Graphics.FromImage(nova))
            {
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, largura, altura);

                g.DrawImage(
                    imagem,
                    (largura - novaLargura) / 2f,
                    (altura - novaAltura) / 2f,
                    novaLargura,
                    novaAltura);
            }

            return nova;
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            base.Cadastrar(cmd);

            if (álbuns != null)
                álbuns.Gravar(cmd);
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (!Atualizado)
            {
                if (Imagem == null)
                {
                    // Caso o usuá\rio obtenha uma foto, altere um atributo e a salve,
                    // a foto é descadastrada do banco, uma vez que é carregada via lazy-load.
                    // Obtemos então a foto aqui para evitar que isto ocorra.

                    ObterFoto();
                }

                base.Atualizar(cmd);

                if (álbuns != null)
                    álbuns.Gravar(cmd);
            }
        }

        public override void Descadastrar()
        {
            base.Descadastrar();
    
            álbuns = null;
        }

        /// <summary>
        /// Obtém fotos de uma mercadoria.
        /// </summary>
        /// <param name="referência">Referência numérica.</param>
        /// <returns>Foto da mercadoria.</returns>
        public static Foto[] ObterFotos(string referência)
        {
            return Mapear<Foto>(
                "SELECT codigo,mercadoria,descricao,data FROM foto WHERE mercadoria = " + DbTransformar(referência)).ToArray();
        }

        public static Image ObterPrimeiraFoto(Mercadoria.Mercadoria mercadoria)
        {
            IDataReader leitor = null;
            byte[] fotoVetor = null;
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT foto FROM foto WHERE mercadoria={0} limit 1",
                        DbTransformar(mercadoria.ReferênciaNumérica));

                    using (leitor = cmd.ExecuteReader())
                    {

                        try
                        {
                            if (leitor.Read())
                            {
                                fotoVetor = (byte[])leitor.GetValue(0);
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

            if (fotoVetor == null)
                return null;

            return (Image) new DbFoto(fotoVetor);
        }


        /// <summary>
        /// Obtém fotos de um álbum.
        /// </summary>
        public static Foto[] ObterFotos(Álbum álbum)
        {
            return Mapear<Foto>(
                "SELECT codigo,mercadoria,descricao,data FROM foto WHERE codigo IN (SELECT foto FROM vinculofotoalbum WHERE album = "
                + DbTransformar(álbum.Código) + ") AND mercadoria in (select referencia from mercadoria where foradelinha=0) ").ToArray();
        }

        /// <summary>
        /// Obtém uma determinada foto.
        /// </summary>
        /// <returns>Foto de mercadoria.</returns>
        public static Foto ObterFoto(uint código)
        {
            return MapearÚnicaLinha<Foto>(
                "SELECT codigo,mercadoria,descricao,data FROM foto WHERE codigo = " + DbTransformar(código));
        }

        /// <summary>
        /// Obtém fotos de uma mercadoria.
        /// </summary>
        /// <returns>Foto da mercadoria.</returns>
        public static Foto[] ObterFotos(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            string consulta;

            consulta = "SELECT codigo,mercadoria,descricao,data FROM foto WHERE mercadoria = " + DbTransformar(mercadoria.ReferênciaNumérica);

            return Mapear<Foto>(consulta).ToArray();
        }

        /// <summary>
        /// Obtém todas as fotos do banco de dados.
        /// Mapear: 30 segundos.
        /// Implementado direto: 0.3 segundos.
        /// </summary>
        /// <returns>Fotos do banco de dados.</returns>
        public static Foto[] ObterFotos(bool incluirForaDeLinha)
        {
            IDataReader leitor = null;

            string consulta;

            if (incluirForaDeLinha)
                consulta = "SELECT codigo,mercadoria,descricao,data FROM foto ORDER BY mercadoria";
            else
                consulta = "SELECT f.codigo,f.mercadoria,f.descricao, f.data FROM foto" +
                    " f JOIN mercadoria m ON f.mercadoria = m.referencia" +
                    " WHERE m.foradelinha = 0" +
                    " ORDER BY mercadoria";


            List<Foto> fotos = new List<Foto>();
            IDbConnection cn = Conexão;

            lock (cn)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(cn);
                try
                {
                    using (IDbCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = consulta;

                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                Foto f = new Foto();
                                f.DefinirCadastrado();
                                f.DefinirAtualizado();

                                f.codigo = (uint)leitor["codigo"];
                                f.mercadoria = leitor.GetString(1);

                                if (leitor["descricao"] == DBNull.Value)
                                    f.descricao = "";
                                else
                                    f.descricao = (string)leitor["descricao"];


                                f.Data = (DateTime)leitor["data"];

                                fotos.Add(f);
                            }
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();

                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(cn);
                }
            }
            
            return fotos.ToArray();
        }

        /// <summary>
        /// Conta quantas fotos existem para uma determinada referência.
        /// </summary>
        /// <param name="referência">Referência numérica.</param>
        /// <returns>Número de fotos encontradas.</returns>
        public static uint ContarFotos(string referência)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM foto WHERE mercadoria = " + DbTransformar(referência);

                    return Convert.ToUInt32(cmd.ExecuteScalar());
                }
            }
        }

        public override string ToString()
        {
            return ReferênciaFormatada;
        }

        #region IComparable<Foto> Members

        public int CompareTo(Foto other)
        {
            if (mercadoria != null)
                return mercadoria.CompareTo(other.mercadoria);
            else if (mercadoria == null && other == null)
                return 0;
            else
            {
                // Mercadoria é nula; outra não é.
                return -1;
            }
        }

        #endregion

        /// <summary>
        /// Obtém mercadorias aleatórios na linha com foto para exibição.
        /// </summary>
        public static Foto[] ObterFotosAleatórias(int quantidade)
        {
            string cmd = "SELECT f.codigo, f.mercadoria, f.descricao FROM mercadoria m, foto f WHERE m.foradelinha = 0 AND m.referencia = f.mercadoria ORDER BY RAND() LIMIT " + quantidade.ToString();

            return Mapear<Foto>(cmd).ToArray();
        }

        /// <summary>
        /// Obtém mercadorias aleatórios na linha com foto para exibição.
        /// </summary>
        public static Foto[] ObterÍconesAleatórios(int quantidade)
        {
            string cmd = "SELECT f.codigo, f.mercadoria, f.descricao, f.icone FROM mercadoria m, foto f WHERE m.foradelinha = 0 AND m.referencia = f.mercadoria ORDER BY RAND() LIMIT " + quantidade.ToString();

            return Mapear<Foto>(cmd).ToArray();
        }

        #region IDisposable Members

        public void Dispose()
        {
            LiberarFoto();
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Foto)
                return codigo.Equals(((Foto)obj).codigo);
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return codigo.GetHashCode();
        }

        /// <summary>
        /// Conta a quantidade de fotos existentes no banco
        /// de dados.
        /// </summary>
        /// <returns>Número de fotos.</returns>
        public static int ContarFotos()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM foto";
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
        }

        /// <summary>
        /// Inclui foto obtida na lista para controle
        /// de fotos carregadas. As fotos carregadas há mais
        /// tempo são descarregadas caso não modificadas.
        /// </summary>
        /// <param name="foto">Foto recém obtida.</param>
        private static void MarcarObtenção(Foto foto)
        {
#if DEBUG
            Console.WriteLine("Obtida foto " + foto.ReferênciaFormatada);
#endif
            lock (fotosCarregadas)
            {
                while (fotosCarregadas.Count > limiteFotos)
                {
                    Foto aux = fotosCarregadas.First.Value;

                    if (aux.Atualizado && aux != foto)
                        aux.LiberarFoto();

                    fotosCarregadas.RemoveFirst();
                }

                if (!fotosCarregadas.Contains(foto))
                    fotosCarregadas.AddLast(foto);

                if (tmrVerificarFotos == null)
                    tmrVerificarFotos = new Timer(new TimerCallback(VerificarUsoFotos), null, 10000, 10000);
            }
        }

        /// <summary>
        /// Verifica o momento de último uso da foto,
        /// descarregando da memória aquelas fotos cujo
        /// tempo tenha ultrapassado o limite definido
        /// na constante "limiteTempoUso".
        /// </summary>
        /// <remarks>
        /// Fotos desatualizadas não são descarregadas.
        /// </remarks>
        private static void VerificarUsoFotos(object estado)
        {
            List<Foto> remoção = new List<Foto>();

            lock (fotosCarregadas)
                foreach (Foto foto in fotosCarregadas)
                {
                    TimeSpan ts = DateTime.Now - foto.últimoUso;

                    if (ts.TotalSeconds > limiteTempoUso)
                        remoção.Add(foto);
                }

            foreach (Foto foto in remoção)
            {
                lock (fotosCarregadas)
                    fotosCarregadas.Remove(foto);

                if (foto.Atualizado)
                    foto.LiberarFoto();
            }
        }

        public Mercadoria.Mercadoria ObterMercadoria()
        {
            if (this.ReferênciaNumérica != null)
                return Mercadoria.Mercadoria.ObterMercadoriaSemDígito(this.ReferênciaNumérica, Entidades.Tabela.TabelaPadrão);
            else 
                return null;
        }

        public static Foto[] ObterFotosSemÍcone()
        {
            string cmd = "SELECT f.codigo, f.mercadoria, f.descricao, f.icone FROM foto f WHERE f.icone is null or length(f.icone) = 0";

            return Mapear<Foto>(cmd).ToArray();
        }
    }
}
