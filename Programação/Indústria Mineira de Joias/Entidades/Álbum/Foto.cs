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

namespace Entidades.�lbum
{
	/// <summary>
	/// Foto de mercadorias
	/// </summary>
	[Serializable]
    [Cache�vel("ObterMiniaturaSemCache"), N�oCopiarCache]
    [DbTransa��o]
	public class Foto : DbManipula��oAutom�tica, IComparable<Foto>, IDisposable
	{
        private static LinkedList<Foto> fotosCarregadas = new LinkedList<Foto>();
        private const int limiteFotos = 30;
        private const int limiteTempoUso = 600; // Segundos
        private static Timer tmrVerificarFotos = null;

        [DbAtributo(TipoAtributo.Ignorar)]
        public const int tamanho�cone = 32;

		// Constantes
		[DbAtributo(TipoAtributo.Ignorar)]
		public static readonly int tamanhoMaiorLadoMiniatura = 90;

		// Atributos
		[DbChavePrim�ria(true)]
		private uint			codigo = 0;

		private string		    mercadoria;			// Refer�ncia num�rica

		private string			descricao;
		
		private DateTime?		data;
		
		/// <summary>
		/// Foto original da mercadoria
		/// </summary>
		private DbFoto			foto = null;

        [DbColuna("icone")]
        private DbFoto �cone = null;
		
        /// <summary>
        /// Lista de �lbuns em que esta foto est� inserida.
        /// </summary>
        /// <remarks>
        /// Quando o valor � nulo, indica que n�o foi carregado
        /// ainda do banco de dados. Quando nenhum �lbum est�
        /// vinculado, a lista � instanciada, por�m vazia.
        /// </remarks>
        [DbAtributo(TipoAtributo.Ignorar)]
        private Lista�lbuns     �lbuns;

        /// <summary>
        /// �ltimo uso da foto na execu��o do sistema.
        /// </summary>
        [DbAtributo(TipoAtributo.Ignorar)]
        private DateTime �ltimoUso = DateTime.Now;

        /// <summary>
        /// Constru��o padr�o
        /// </summary>
        public Foto()
        {
            mercadoria = descricao = null;
            data = DateTime.Now;
            �lbuns = new Lista�lbuns(this);
        }

        public Foto(uint c�digo, string refer�nciaNum�rica)
        {
            this.codigo = c�digo;
            this.Refer�nciaNum�rica = refer�nciaNum�rica;
        }

        #region Propriedades
		
		/// <summary>
		/// Refer�ncia num�rica
		/// </summary>
		public string Refer�nciaNum�rica
		{ 
			get { return mercadoria; }
			set
            {
                mercadoria = value;

                DefinirDesatualizado();
            }
		}

        [DbAtributo(TipoAtributo.Ignorar)]
		private string refer�nciaFormatadaCache = null;

		public string Refer�nciaFormatada
		{
			get
			{
				if (refer�nciaFormatadaCache == null && Refer�nciaNum�rica != null)
				    refer�nciaFormatadaCache = Entidades.Mercadoria.Mercadoria.MascararRefer�ncia(Refer�nciaNum�rica);

                return refer�nciaFormatadaCache;
			}
		}

		public string Descri��o
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
		/// Pega ou Atribui imagem � foto.
		/// Aqu� o �cone da foto � criado.
		/// </summary>
		public Image Imagem
		{
			get 
			{
                lock (this)
                {
                    if (foto == null || foto.Imagem == null)
                        foto = ObterFoto();

                    �ltimoUso = DateTime.Now;

                    return foto;
                }
			}
			set
			{
                lock (this)
                {
                    foto = value;

                    Refaz�cone();

                    DefinirDesatualizado();
                }
			}
		}

        public void Refaz�cone()
        {
            if (Imagem == null)
                �cone = null;
            else
                �cone = Redesenhar(Imagem, tamanho�cone, tamanho�cone);

            DefinirDesatualizado();
        }

        /// <summary>
        /// Indica se a foto j� est� preparada para exibi��o.
        /// </summary>
        public bool Preparada
        {
            get { return foto != null; }
        }

        public Image �cone
        {
            get
            {
                lock (this)
                {
                    if (�cone == null)
                        �cone = Obter�cone();

                    return �cone;
                }
            }
        }

		public uint C�digo
		{
			get { return codigo; }
		}

		public DbFoto Miniatura
		{
			get
			{
                return CacheMiniaturas.Inst�ncia.Obter(this);
			}
		}

        /// <summary>
        /// Lista de �lbuns.
        /// </summary>
        public Lista�lbuns �lbuns
        {
            get { return �lbuns; }
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

        //            �ltimoUso = DateTime.Now;

        //            return fotoOriginal;
        //        }
        //    }
        //    set
        //    {
        //        lock (this)
        //        {
        //            if (value == null)
        //                throw new Exception("Foto Original n�o pode ser nula");

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
		/// o C�digoFoto � o mesmo que C�digo. � informa��o repetida.
		/// </remarks>
		private enum Ordem { Mercadoria, D�gito, Descri��o, Icone, Data, 
			C�digo, C�digoFoto, Album }

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
            Console.WriteLine("Liberando foto " + Refer�nciaFormatada);
#endif
            lock (this)
            {
                if (foto != null)
                {
                    foto.Dispose();
                    foto = null;
                }

                if (�cone != null)
                {
                    �cone.Dispose();
                    �cone = null;
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
        /// Obt�m a foto da mercadoria.
        /// </summary>
        /// <returns>Foto obtida do banco de dados.</returns>
		public DbFoto ObterFoto()
		{
			IDbConnection conex�o = Conex�o;
            object obj;

			lock (conex�o)
			{
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                try
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = "SELECT foto from foto where codigo=" + this.C�digo;

                        obj = cmd.ExecuteScalar();
                    }
                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }
			}

            MarcarObten��o(this);

            return new DbFoto((byte[])obj);
        }

        /// <summary>
        /// Obt�m �cone do banco de dados.
        /// </summary>
        /// <returns>�cone.</returns>
        private DbFoto Obter�cone()
        {
            IDbConnection conex�o = Conex�o;
            object obj;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                
                try
                {

                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = "SELECT icone FROM foto WHERE codigo=" + this.C�digo;

                        obj = cmd.ExecuteScalar();
                    }
                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }
            }

            return new DbFoto((byte[])obj);
        }

		/// <summary>
		/// Redimensiona uma imagem, de forma que possa ser colocada dentro 
		/// de um ret�ngulo de dimens�es larguraM�xima x alturaM�xima
		/// sem que hajam cortes na imagem nem que ela perca sua propor��o.
		/// </summary>
		/// <remarks>
		/// Apesar do m�todo estar no �lbum\Foto,
		/// ela n�o est� diretamente relacionada com a tabela Foto.
		/// Por�m, em v�rias partes do programa em que � util fazer um 
		/// redimensionamento, este m�todo � usado. 
		/// </remarks>
		/// <param name="imagem"> Imagem a ser redimensionada </param>
		/// <param name="larguraM�xima"> pode ser a largura do ret�ngulo</param>
		/// <param name="alturaM�xima">altura do ret�ngulo</param>
		/// <returns></returns>
        [Obsolete("Utilize redesenhar")]
		public static Image Redimensionar(Image imagem, int larguraM�xima, int alturaM�xima)
		{
			int novaLargura, novaAltura;

			if (imagem == null) 
				throw new Exception("N�o � poss�vel Redimensionar uma imagem nula!");

			// magreza = altura / largura
			float magrezaFigura = Convert.ToSingle(imagem.Height) / Convert.ToSingle(imagem.Width);
			float magrezaPapel  = Convert.ToSingle(alturaM�xima) / Convert.ToSingle(larguraM�xima);

			// Se figura mais magra que a folha
			if (magrezaFigura > magrezaPapel)
			{
				// Nova altura = altura da folha
				novaAltura = alturaM�xima;
				novaLargura = Convert.ToInt32(novaAltura / magrezaFigura);
			} 
			else
			{
				// Nova largura = largura da folha
				novaLargura = larguraM�xima;
				novaAltura = Convert.ToInt32(novaLargura * magrezaFigura);
			}

			return 	imagem.GetThumbnailImage(novaLargura, novaAltura, null, IntPtr.Zero);
		}

        /// <summary>
        /// Redesenha uma imagem nas dimens�es especificadas, mantendo
        /// a propor��o da figura.
        /// </summary>
        /// <param name="imagem"> Imagem a ser redimensionada </param>
        /// <param name="largura"> pode ser a largura do ret�ngulo</param>
        /// <param name="altura">altura do ret�ngulo</param>
        /// <returns></returns>
        public static Bitmap Redesenhar(Image imagem, int largura, int altura)
        {
            int novaLargura, novaAltura;
            Bitmap nova;

            if (imagem == null)
                throw new Exception("N�o � poss�vel Redimensionar uma imagem nula!");

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

            if (�lbuns != null)
                �lbuns.Gravar(cmd);
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (!Atualizado)
            {
                if (Imagem == null)
                {
                    // Caso o usu�\rio obtenha uma foto, altere um atributo e a salve,
                    // a foto � descadastrada do banco, uma vez que � carregada via lazy-load.
                    // Obtemos ent�o a foto aqui para evitar que isto ocorra.

                    ObterFoto();
                }

                base.Atualizar(cmd);

                if (�lbuns != null)
                    �lbuns.Gravar(cmd);
            }
        }

        public override void Descadastrar()
        {
            base.Descadastrar();
    
            �lbuns = null;
        }

        /// <summary>
        /// Obt�m fotos de uma mercadoria.
        /// </summary>
        /// <param name="refer�ncia">Refer�ncia num�rica.</param>
        /// <returns>Foto da mercadoria.</returns>
        public static Foto[] ObterFotos(string refer�ncia)
        {
            return Mapear<Foto>(
                "SELECT codigo,mercadoria,descricao,data FROM foto WHERE mercadoria = " + DbTransformar(refer�ncia)).ToArray();
        }

        public static Image ObterPrimeiraFoto(Mercadoria.Mercadoria mercadoria)
        {
            IDataReader leitor = null;
            byte[] fotoVetor = null;
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT foto FROM foto WHERE mercadoria={0} limit 1",
                        DbTransformar(mercadoria.Refer�nciaNum�rica));

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

                            Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                        }
                    }
                }
            }

            if (fotoVetor == null)
                return null;

            return (Image) new DbFoto(fotoVetor);
        }


        /// <summary>
        /// Obt�m fotos de um �lbum.
        /// </summary>
        public static Foto[] ObterFotos(�lbum �lbum)
        {
            return Mapear<Foto>(
                "SELECT codigo,mercadoria,descricao,data FROM foto WHERE codigo IN (SELECT foto FROM vinculofotoalbum WHERE album = "
                + DbTransformar(�lbum.C�digo) + ") AND mercadoria in (select referencia from mercadoria where foradelinha=0) ").ToArray();
        }

        /// <summary>
        /// Obt�m uma determinada foto.
        /// </summary>
        /// <returns>Foto de mercadoria.</returns>
        public static Foto ObterFoto(uint c�digo)
        {
            return Mapear�nicaLinha<Foto>(
                "SELECT codigo,mercadoria,descricao,data FROM foto WHERE codigo = " + DbTransformar(c�digo));
        }

        /// <summary>
        /// Obt�m fotos de uma mercadoria.
        /// </summary>
        /// <returns>Foto da mercadoria.</returns>
        public static Foto[] ObterFotos(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            string consulta;

            consulta = "SELECT codigo,mercadoria,descricao,data FROM foto WHERE mercadoria = " + DbTransformar(mercadoria.Refer�nciaNum�rica);

            return Mapear<Foto>(consulta).ToArray();
        }

        /// <summary>
        /// Obt�m todas as fotos do banco de dados.
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
            IDbConnection cn = Conex�o;

            lock (cn)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(cn);
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

                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(cn);
                }
            }
            
            return fotos.ToArray();
        }

        /// <summary>
        /// Conta quantas fotos existem para uma determinada refer�ncia.
        /// </summary>
        /// <param name="refer�ncia">Refer�ncia num�rica.</param>
        /// <returns>N�mero de fotos encontradas.</returns>
        public static uint ContarFotos(string refer�ncia)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM foto WHERE mercadoria = " + DbTransformar(refer�ncia);

                    return Convert.ToUInt32(cmd.ExecuteScalar());
                }
            }
        }

        public override string ToString()
        {
            return Refer�nciaFormatada;
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
                // Mercadoria � nula; outra n�o �.
                return -1;
            }
        }

        #endregion

        /// <summary>
        /// Obt�m mercadorias aleat�rios na linha com foto para exibi��o.
        /// </summary>
        public static Foto[] ObterFotosAleat�rias(int quantidade)
        {
            string cmd = "SELECT f.codigo, f.mercadoria, f.descricao FROM mercadoria m, foto f WHERE m.foradelinha = 0 AND m.referencia = f.mercadoria ORDER BY RAND() LIMIT " + quantidade.ToString();

            return Mapear<Foto>(cmd).ToArray();
        }

        /// <summary>
        /// Obt�m mercadorias aleat�rios na linha com foto para exibi��o.
        /// </summary>
        public static Foto[] Obter�conesAleat�rios(int quantidade)
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
        /// <returns>N�mero de fotos.</returns>
        public static int ContarFotos()
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM foto";
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
        }

        /// <summary>
        /// Inclui foto obtida na lista para controle
        /// de fotos carregadas. As fotos carregadas h� mais
        /// tempo s�o descarregadas caso n�o modificadas.
        /// </summary>
        /// <param name="foto">Foto rec�m obtida.</param>
        private static void MarcarObten��o(Foto foto)
        {
#if DEBUG
            Console.WriteLine("Obtida foto " + foto.Refer�nciaFormatada);
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
        /// Verifica o momento de �ltimo uso da foto,
        /// descarregando da mem�ria aquelas fotos cujo
        /// tempo tenha ultrapassado o limite definido
        /// na constante "limiteTempoUso".
        /// </summary>
        /// <remarks>
        /// Fotos desatualizadas n�o s�o descarregadas.
        /// </remarks>
        private static void VerificarUsoFotos(object estado)
        {
            List<Foto> remo��o = new List<Foto>();

            lock (fotosCarregadas)
                foreach (Foto foto in fotosCarregadas)
                {
                    TimeSpan ts = DateTime.Now - foto.�ltimoUso;

                    if (ts.TotalSeconds > limiteTempoUso)
                        remo��o.Add(foto);
                }

            foreach (Foto foto in remo��o)
            {
                lock (fotosCarregadas)
                    fotosCarregadas.Remove(foto);

                if (foto.Atualizado)
                    foto.LiberarFoto();
            }
        }

        public Mercadoria.Mercadoria ObterMercadoria()
        {
            if (this.Refer�nciaNum�rica != null)
                return Mercadoria.Mercadoria.ObterMercadoriaSemD�gito(this.Refer�nciaNum�rica, Entidades.Tabela.TabelaPadr�o);
            else 
                return null;
        }

        public static Foto[] ObterFotosSem�cone()
        {
            string cmd = "SELECT f.codigo, f.mercadoria, f.descricao, f.icone FROM foto f WHERE f.icone is null or length(f.icone) = 0";

            return Mapear<Foto>(cmd).ToArray();
        }
    }
}
