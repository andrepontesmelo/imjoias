// Mostra os passos do processamento
#define MOSTRAR_PASSOS

// Tira o fundo da imagem
#define PROCESSAR_IMAGEM

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;

namespace ImportadorFotos
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Importador : System.Windows.Forms.Form
	{
		public delegate void ImportarDelegate(string caminho);

		// Constantes
        private const int totalThreads = 1;

		//private const float limiarBrilho		= 0.004f;		// Entre 0 e 1
		private const float limiarBrilho		= 0.004f;		// Entre 0 e 1
		private const float limiarProjeção		= 0.03f;		// Entre 0 e 1
		private const float	limiarÁrea			= 0.10f;		// Entre 0 e 1
		private const float	limiarReconstrução	= 0.003f;		// Entre 0 e 1
		private const float limiarTransparentes = 0.99f;		// Entre 0 e 1
		private const int   margem              = 10;			// Pixels

		// Atributos
		private Bitmap imagens;
        private Thread [] threads;
        private Stack arquivos = new Stack();

		// Formulário
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progresso;
		private System.Windows.Forms.PictureBox picFotos;
		private System.Windows.Forms.Label lblArquivo;
		private System.Windows.Forms.TextBox txtMensagens;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Importador()
		{
	
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			imagens = new Bitmap(picFotos.Width, picFotos.Height);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}

                for (int i = 0; i < totalThreads; i++)
                {
                    if (threads[i] != null)
                    {
                        threads[i].Abort();
                        threads[i] = null;
                    }
                }
				imagens.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.progresso = new System.Windows.Forms.ProgressBar();
            this.picFotos = new System.Windows.Forms.PictureBox();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.txtMensagens = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFotos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Importando as imagens para o banco de dados...";
            // 
            // progresso
            // 
            this.progresso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progresso.Location = new System.Drawing.Point(16, 64);
            this.progresso.Name = "progresso";
            this.progresso.Size = new System.Drawing.Size(434, 23);
            this.progresso.TabIndex = 1;
            // 
            // picFotos
            // 
            this.picFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picFotos.BackColor = System.Drawing.Color.White;
            this.picFotos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFotos.Location = new System.Drawing.Point(16, 96);
            this.picFotos.Name = "picFotos";
            this.picFotos.Size = new System.Drawing.Size(434, 70);
            this.picFotos.TabIndex = 3;
            this.picFotos.TabStop = false;
            this.picFotos.Paint += new System.Windows.Forms.PaintEventHandler(this.picFotos_Paint);
            // 
            // lblArquivo
            // 
            this.lblArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArquivo.Location = new System.Drawing.Point(16, 32);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(432, 32);
            this.lblArquivo.TabIndex = 4;
            this.lblArquivo.Text = "Lendo diretório...";
            this.lblArquivo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtMensagens
            // 
            this.txtMensagens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensagens.Location = new System.Drawing.Point(16, 174);
            this.txtMensagens.Multiline = true;
            this.txtMensagens.Name = "txtMensagens";
            this.txtMensagens.ReadOnly = true;
            this.txtMensagens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensagens.Size = new System.Drawing.Size(434, 212);
            this.txtMensagens.TabIndex = 5;
            // 
            // Importador
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(466, 398);
            this.Controls.Add(this.txtMensagens);
            this.Controls.Add(this.lblArquivo);
            this.Controls.Add(this.picFotos);
            this.Controls.Add(this.progresso);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Importador";
            this.Text = "Importação de fotos";
            this.Shown += new System.EventHandler(this.Importador_Shown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Importador_Closing);
            this.Load += new System.EventHandler(this.Importador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFotos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Importa arquivos contidos em um caminho
		/// </summary>
		/// <param name="caminho">Caminho contendo as imagens a serem importadas</param>
		public void Importar(string caminho)
		{
            string [] arquivosVetor  = Directory.GetFiles(caminho);
			foreach (string arq in arquivosVetor)
                arquivos.Push(arq);

            // Atribui informações para porcentagem
            progresso.Maximum = arquivosVetor.Length;

            threads = new Thread[totalThreads];

            for (int i = 0; i < totalThreads; i++)
            {
                threads[i] = new Thread(new ThreadStart(Importar));
                threads[i].Start();
            }
		}

        private delegate void AtualizarInterfaceCallBack(string arquivoAtual);

        private string ObterPróximoArquivo()
        {
            string arq;

            lock (arquivos)
            {
                if (arquivos.Count == 0)
                    return null;
                else
                {
                    arq = (string) arquivos.Pop();
                }
            }

            lock (progresso)
            {
                AtualizarInterfaceCallBack método = new AtualizarInterfaceCallBack(AtualizarInterface);
                progresso.Invoke(método, arq);
            }

            return arq;
        }

        private void AtualizarInterface(string arquivoAtual)
        {
            lblArquivo.Text = arquivoAtual;
            progresso.Increment(1);
        }

        private static MySqlConnection CriarConexão()
        {
            MySqlConnection conexão = new MySqlConnection();
            string host, bd, usuário, senha;

//            host = "imj.no-ip.com";
            host = "192.168.1.10";
#if DEBUG
            bd = "imjoias-desenv";
#else
            bd = "imjoias";
#endif

            MessageBox.Show("Trabalhando com banco de dados " + bd + ".");

            usuário = "imjoias";
            senha = "***REMOVED***";

            string strConexão;

            strConexão = "Data Source=" + host;
            strConexão += ";Database=" + bd;
            strConexão += ";User Id=" + usuário;
            strConexão += ";Password=" + senha;
            strConexão += ";Port=46033";

            //MessageBox.Show(strConexão);

            conexão = new MySqlConnection(strConexão);
            conexão.Open();

            return conexão;
        }

		/// <summary>
		/// Importa as imagens
		/// </summary>
        private void Importar()
        {
            // Cria a conexão
            MySqlConnection conexão = CriarConexão();

            // Apenas primeira vez.
            string arquivo = ObterPróximoArquivo();

            do
            {
                if (arquivo != null)
                {
                    Image imagem, imgProcessada;

                    try
                    {
                        imagem = Image.FromFile(arquivo);

                        MostrarMensagem("Carregando " + arquivo);

                        MostrarImagem(imagem);

#if PROCESSAR_IMAGEM
                        imgProcessada = ProcessarImagem(imagem);
#else
                        imgProcessada = imagem;
#endif
                        SalvarImagem(arquivo, imgProcessada, conexão);

                        imagem.Dispose();
                        imgProcessada.Dispose();

                        System.GC.Collect();
                    }
                    catch (Exception e)
                    {
                        MostrarMensagem("Não foi possível importar o arquivo " + arquivo + ": " + e.Message);
                    }
                }
                arquivo = ObterPróximoArquivo();

            } while (arquivo != null);
        }

		private void SalvarImagem(string arquivo, Image imagem, MySqlConnection conexão)
		{
            string arquivoOriginal = arquivo;

            using (MemoryStream streamFoto = new MemoryStream())
            {
                using (MemoryStream streamÍcone = new MemoryStream())
                {
                    string referência = "";
                    int últimaBarra;

                    // Constrói arquivo de saída
                    try
                    {
                        imagem.Save(streamFoto, ImageFormat.Png);
                    }
                    catch
                    {
                        try
                        {
                            imagem = new Bitmap(imagem);
                            imagem.Save(streamFoto, ImageFormat.Png);
                        }
                        catch
                        {
                            imagem.Save(streamFoto, imagem.RawFormat);
                        }
                    }

                    // Obtém nome do arquivo
                    últimaBarra = arquivo.LastIndexOf('\\') + 1;
                    arquivo = arquivo.Substring(0, arquivo.LastIndexOf('.') - 1);

                    for (int i = últimaBarra; i < arquivo.Length && arquivo[i] != 0; i++)
                    {
                        switch (arquivo[i])
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                referência += arquivo[i];
                                break;
                        }
                    }

                    MostrarMensagem("Salvando " + referência + " a arquivo partir do arquivo " + arquivo);

                    const int tamanhoIcone = 32;

                    Bitmap icone = new Bitmap(tamanhoIcone, tamanhoIcone);

                    using (Graphics g = Graphics.FromImage(icone))
                    {
                        float proporcao = ((float)tamanhoIcone) / Math.Max(imagem.Width, imagem.Height);
                        g.DrawImage(imagem, 0, 0, (int)(imagem.Width * proporcao), (int)(imagem.Height * proporcao));
                    }

                    try
                    {
                        try
                        {
                            icone.Save(streamÍcone, ImageFormat.Png);
                        }
                        catch
                        {
                            try
                            {
                                icone = new Bitmap(icone);
                                icone.Save(streamÍcone, ImageFormat.Png);
                            }
                            catch
                            {
                                icone.Save(streamÍcone, imagem.RawFormat);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        MostrarMensagem("Não foi possível criar ícone: " + e.Message);
                    }

                    //cmd.Connection = conexão;
                    //cmd.CommandText = "UPDATE foto SET icone = ?icone WHERE mercadoria = '" + referência + "'";
                    //cmd.Parameters.Add("?icone", streamÍcone.ToArray());

                    //try
                    //{
                    //    cmd.ExecuteNonQuery();
                    //}
                    //catch (Exception e)
                    //{
                    //    MostrarMensagem("Não foi possível gravar no banco de dados o ícone!\n\n" + e.ToString());
                    //}

                    using (FileStream streamOriginal = new FileStream(arquivoOriginal, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (MySqlCommand cmd = conexão.CreateCommand())
                        {
                            cmd.Connection = conexão;

                            cmd.CommandText = "INSERT INTO foto (mercadoria, foto, icone, original) VALUES ('" + referência + "', ?foto, ?icone, ?original)";
                            cmd.Parameters.Add("?foto", streamFoto.ToArray());
                            cmd.Parameters.Add("?icone", streamÍcone.ToArray());

                            using (BufferedStream a = new BufferedStream(streamOriginal))
                            {
                                byte[] original = new byte[a.Length];

                                a.Read(original, 0, (int)a.Length);

                                cmd.Parameters.Add("?original", original);
                            }

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                MostrarMensagem("Não foi possível inserir no banco de dados a foto+icone para a referência " + referência + ": " + e.Message);
                            }
                        }
                    }
                }
            }

		}

        private delegate void MIDelegate(Image imagem);
        private delegate void MIconDelegate(MemoryStream imagem);

        private void MostrarÍcone(MemoryStream imagem)
        {
            if (InvokeRequired)
            {
                MIDelegate método = new MIDelegate(MostrarImagem);

                Invoke(método, imagem);
            }
            else
            {
                this.Icon = new Icon(imagem);
            }
        }

        /// <summary>
		/// Mostra imagem
		/// </summary>
		/// <param name="imagem">Imagem a ser exibida</param>
		private void MostrarImagem(Image imagem)
		{
            if (InvokeRequired)
            {
                MIDelegate método = new MIDelegate(MostrarImagem);

                Invoke(método, imagem);
            }
            else
            {
                lock (imagens)
                {
                    using (Bitmap bmp = new Bitmap(imagens))
                    {
                        using (Graphics g = Graphics.FromImage(imagens))
                        {
                            float largura;

                            largura = ((float)imagens.Height / imagem.Height) * imagem.Width;

                            g.FillRectangle(Brushes.Violet, 0, 0, imagens.Width, imagens.Height);
                            g.DrawImageUnscaled(bmp, (int)-largura, 0, imagens.Width, imagens.Height);
                            //					g.FillRectangle(Brushes.White, (int) (imagem.Width - largura), 0, (int) largura, imagens.Height);
                            g.DrawImage(imagem, (float)(imagens.Width - largura), (float)0, (float)largura, (float)imagens.Height);
                            //g.DrawString("Thread 1", Font.
                        }
                    }
                }

                picFotos.Invalidate();
            }
		}

		/// <summary>
		/// Insere na pilha para o flood-fill
		/// </summary>
		/// <param name="pilha">Pilha contendo pontos e brilho</param>
		/// <param name="brilho">Brilho de referência</param>
		/// <param name="x">Posição X</param>
		/// <param name="y">Posição Y</param>
		private static void InserirPilha(Stack pilha, float brilho, int x, int y)
		{
			pilha.Push(brilho);
			pilha.Push(new Point(x, y));
		}

		/// <summary>
		/// Encontra cores de fundo em um bitmap
		/// </summary>
		/// <param name="origem">Imagem original</param>
		/// <returns>Dicionário de cores do fundo</returns>
		private static Hashtable EncontrarCoresFundo(Bitmap origem)
		{
			Hashtable cores = new Hashtable();	// Cores do fundo
			Stack	  pilha = new Stack();		// Pilha para flood-fill
			bool [,]  marcado;					// Pontos marcados no flood-fill

			marcado = new bool[origem.Width, origem.Height];

			/* A cor de fundo é encontrada realizando um flood-fill
				 * nas bordas da imagem. As cores encontradas cujo brilho
				 * se difere de um determinado limiar são consideradas como
				 * cores de fundos.
				 */
			InserirPilha(pilha, origem.GetPixel(0, 0).GetBrightness(), 0, 0);
			InserirPilha(pilha, origem.GetPixel(origem.Width - 1, 0).GetBrightness(), origem.Width - 1, 0);
			InserirPilha(pilha, origem.GetPixel(origem.Width - 1, origem.Height - 1).GetBrightness(), origem.Width - 1, 0);
			InserirPilha(pilha, origem.GetPixel(0, origem.Height - 1).GetBrightness(), 0, origem.Height - 1);
			
			while (pilha.Count > 0)
			{
				Point ponto;
				float brilhoAnterior;
				Color corAtual;

				ponto = (Point) pilha.Pop();
				brilhoAnterior = (float) pilha.Pop();

				if (ponto.X < 0 || ponto.X >= origem.Width
					|| ponto.Y < 0 || ponto.Y >= origem.Height
					|| marcado[ponto.X, ponto.Y])
					continue;

				corAtual = origem.GetPixel(ponto.X, ponto.Y);

				if (Math.Abs(corAtual.GetBrightness() - brilhoAnterior) < limiarBrilho)
				{
					float brilhoAtual = corAtual.GetBrightness();

					cores[corAtual] = Color.Black;
					marcado[ponto.X, ponto.Y] = true;
						
					InserirPilha(pilha, brilhoAtual, ponto.X - 1, ponto.Y - 1);
					InserirPilha(pilha, brilhoAtual, ponto.X - 1, ponto.Y - 1);
					InserirPilha(pilha, brilhoAtual, ponto.X, ponto.Y - 1);
					InserirPilha(pilha, brilhoAtual, ponto.X + 1, ponto.Y - 1);
					InserirPilha(pilha, brilhoAtual, ponto.X + 1, ponto.Y);
					InserirPilha(pilha, brilhoAtual, ponto.X + 1, ponto.Y + 1);
					InserirPilha(pilha, brilhoAtual, ponto.X, ponto.Y + 1);
					InserirPilha(pilha, brilhoAtual, ponto.X - 1, ponto.Y + 1);
					InserirPilha(pilha, brilhoAtual, ponto.X - 1, ponto.Y);
				}
			}

//			EncontrarIlhasCoresFundo(origem, cores, marcado);

			return cores;
		}

//		/// <summary>
//		/// Encontra cores de fundo em ilhas
//		/// </summary>
//		/// <param name="imagem">Imagem original</param>
//		/// <param name="coresFundo">Cores de fundo conhecidos</param>
//		/// <param name="marcaçãoOriginal">Pontos verificados</param>
//		private void EncontrarIlhasCoresFundo(Bitmap imagem, Hashtable coresFundo, bool [,] marcaçãoOriginal)
//		{
//			float limiarÁrea;
//
//			limiarÁrea = Importador.limiarÁrea * imagem.Width * imagem.Height;
//
//			for (int y = 0; y < imagem.Height; y++)
//				for (int x = 0; x < imagem.Width; x++)
//					if (!marcaçãoOriginal[x, y])
//					{
//						ArrayList pontos;
//						long      área;
//
//						área = CalcularÁrea(marcaçãoOriginal, x, y, out pontos);
//
//						// Adicionar cores da ilha
//						if (área < limiarÁrea)
//							foreach (Point p in pontos)
//								coresFundo[imagem.GetPixel(p.X, p.Y)] = Color.Red;
//					}
//		}

		/// <summary>
		/// Calcula a área de uma ilha
		/// </summary>
		/// <param name="marcação">Marcação de pontos preenchidos com fundo</param>
		/// <param name="x">Coordenada X</param>
		/// <param name="y">Coordenada Y</param>
		/// <param name="pontos">Pontos da ilha</param>
		/// <returns>Área da ilha</returns>
		private static long CalcularÁrea(bool [,] marcação, int x, int y, out ArrayList pontos)
		{
			Stack pilha = new Stack();
			long  área = 0;
			
			pontos = new ArrayList(100000);
			pilha.Push(new Point(x, y));

			while (pilha.Count > 0)
			{
				Point ponto = (Point) pilha.Pop();

				if (ponto.X >= 0 && ponto.X <= marcação.GetUpperBound(0)
					&& ponto.Y >= 0 && ponto.Y <= marcação.GetUpperBound(1)
					&& !marcação[ponto.X, ponto.Y])
				{
					área++;
//					pilha.Push(new Point(ponto.X - 1, ponto.Y - 1));
					pilha.Push(new Point(ponto.X, ponto.Y - 1));
//					pilha.Push(new Point(ponto.X + 1, ponto.Y - 1));
					pilha.Push(new Point(ponto.X + 1, ponto.Y));
//					pilha.Push(new Point(ponto.X + 1, ponto.Y + 1));
					pilha.Push(new Point(ponto.X, ponto.Y + 1));
//					pilha.Push(new Point(ponto.X - 1, ponto.Y + 1));
					pilha.Push(new Point(ponto.X - 1, ponto.Y));
					marcação[ponto.X, ponto.Y] = true;
					pontos.Add(ponto);
				}
			}

			return área;
		}

		/// <summary>
		/// Remove ilhas
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="marcaçãoOriginal">Pontos verificados</param>
		private void RemoverIlhas(Bitmap imagem, bool [,] marcaçãoOriginal)
		{
			float limiarÁrea;

			limiarÁrea = Importador.limiarÁrea * CalcularÁreaNãoTransparente(marcaçãoOriginal);

			for (int y = 0; y < imagem.Height; y++)
				for (int x = 0; x < imagem.Width; x++)
					if (!marcaçãoOriginal[x, y])
					{
						ArrayList pontos;
						long      área;

						área = CalcularÁrea(marcaçãoOriginal, x, y, out pontos);

						// Adicionar cores da ilha
						if (área < limiarÁrea)
							foreach (Point p in pontos)
								imagem.SetPixel(p.X, p.Y, Color.FromArgb(0, imagem.GetPixel(p.X, p.Y)));
					}
		}

		/// <summary>
		/// Calcula área não transparente
		/// </summary>
		/// <param name="transparentes">Pontos transparentes</param>
		/// <returns>Área não transparente</returns>
		private static long CalcularÁreaNãoTransparente(bool [,] transparentes)
		{
			long área = 0;

			foreach (bool b in transparentes)
				if (!b)
					área++;

			return área;
		}

		/// <summary>
		/// Delimita uma imagem conforme transparência
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <returns>Área contendo imagem</returns>
		private Rectangle Delimitar(Bitmap imagem)
		{
			int x1, x2, y1, y2;
			float limiarProjeçãoHorizontal, limiarProjeçãoVertical;

			x1 = 0;
			x2 = imagem.Width - 1;
			y1 = 0;
			y2 = imagem.Height - 1;

			limiarProjeçãoHorizontal = imagem.Width * limiarProjeção;
			limiarProjeçãoVertical = imagem.Height * limiarProjeção;

			/// Encontrar o topo
			while (CalcularProjeçãoHorizontal(imagem, y1) < limiarProjeçãoHorizontal && y1 < y2)
				y1++;

			// Encontrar o limite inferior
			while (CalcularProjeçãoHorizontal(imagem, y2) < limiarProjeçãoHorizontal && y2 > y1)
				y2--;

			// Encontrar a esquerda
			while (CalcularProjeçãoVertical(imagem, x1) < limiarProjeçãoVertical && x1 < x2)
				x1++;

			// Encontrar a direita
			while (CalcularProjeçãoVertical(imagem, x2) < limiarProjeçãoVertical && x2 > x1)
				x2--;

			if (x1 == x2)
			{
				x1 = 0;
				x2 = imagem.Width - 1;
			}
			
			if (y1 == y2)
			{
				y1 = 0;
				y2 = imagem.Height - 1;
			}

			/// Encontrar o topo
			while (CalcularProjeçãoHorizontal(imagem, y1) == 0 && y1 > 0)
				y1--;

			// Encontrar o limite inferior
			while (CalcularProjeçãoHorizontal(imagem, y2) == 0 && y2 < imagem.Height - 1)
				y2++;

			// Encontrar a esquerda
			while (CalcularProjeçãoVertical(imagem, x1) == 0 && x1 > 0)
				x1--;

			// Encontrar a direita
			while (CalcularProjeçãoVertical(imagem, x2) == 0 && x2 < imagem.Width - 1)
				x2++;

			return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		}

		/// <summary>
		/// Calcula a projeção horizontal
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="y">Linha onde será calculada a projeção horizontal</param>
		/// <returns>Projeção da linha</returns>
		private static long CalcularProjeçãoHorizontal(Bitmap imagem, int y)
		{
			long projeção = 0;

			for (int x = 0; x < imagem.Width; x++)
				if (imagem.GetPixel(x, y).A > 0)
					projeção++;

			return projeção;
		}

		/// <summary>
		/// Calcula a projeção vertical
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="x">Coluna onde será calculada a projeção vertical</param>
		/// <returns>Projeção da coluna</returns>
		private static long CalcularProjeçãoVertical(Bitmap imagem, int x)
		{
			long projeção = 0;

			for (int y = 0; y < imagem.Height; y++)
				if (imagem.GetPixel(x, y).A > 0)
					projeção++;

			return projeção;
		}

		/// <summary>
		/// Processa a imagem
		/// </summary>
		/// <param name="imagem">Imagem a ser processada</param>
		private Image ProcessarImagem(Image imagem)
		{
			Bitmap	  final;						// Imagens
			Hashtable cores;						// Cores do fundo
			Rectangle limites;
			bool [,]  transparente;
			long	  transparentes = 0;

			// Processar imagem
			using (Bitmap processamento = new Bitmap(imagem))
			{
				// Determinar cores de fundo
				cores = EncontrarCoresFundo(processamento);

				transparente = new bool[processamento.Width, processamento.Height];

				/* Verifica-se todos os pixels da imagem, eliminando
				* as cores de fundo
				*/
				for (int y = 0; y < processamento.Height; y++)
					for (int x = 0; x < processamento.Width; x++)
					{
						Color cor = processamento.GetPixel(x, y);

						if (!(transparente[x, y] = cores.Contains(cor)))
							processamento.SetPixel(x, y, cor);
						else
						{
							processamento.SetPixel(x, y, Color.FromArgb(0, cor));
							//processamento.SetPixel(x, y, (Color) cores[cor]);
							transparentes++;
						}
					}

#if MOSTRAR_PASSOS
				MostrarImagem(processamento);
#endif

				if (transparentes >= limiarTransparentes * imagem.Width * imagem.Height)
					final = new Bitmap(imagem);
				else
				{
//					ReconstruirImagem(processamento, transparente);
#if MOSTRAR_PASSOS
//                    MostrarImagem(processamento);
#endif
                    RemoverIlhas(processamento, transparente);
#if MOSTRAR_PASSOS
					MostrarImagem(processamento);
#endif

					// Suavizar transparência
					using (Bitmap suavização = SuavizarTransparência(processamento))
					{
						// Cortar foto
						limites = Delimitar(suavização);				
						final = new Bitmap(limites.Width, limites.Height);

						for (int y = 0; y < limites.Height; y++)
							for (int x = 0; x < limites.Width; x++)
								final.SetPixel(x, y, suavização.GetPixel(limites.Left + x, limites.Top + y));
					}
#if MOSTRAR_PASSOS
                    MostrarImagem(processamento);
#endif
                }
			}

#if MOSTRAR_PASSOS
			MostrarImagem(final);
#endif

			return final;
		}

		/// <summary>
		/// Reconstrói imagem processada, tentando remover áreas transparentes
		/// que são jóias
		/// </summary>
		/// <param name="bmp">Imagem processada</param>
		/// <param name="transparente">Pontos transparentes</param>
		private void ReconstruirImagem(Bitmap bmp, bool [,] transparente)
		{
			bool [,] marcas = new bool[bmp.Width, bmp.Height];
			float limiarReconstrução;

			limiarReconstrução = Importador.limiarReconstrução * bmp.Width * bmp.Height;

			for (int i = 0; i < bmp.Width; i++)
				for (int j = 0; j < bmp.Height; j++)
					marcas[i, j] = !transparente[i, j];

			for (int y = 0; y < bmp.Height; y++)
				for (int x = 0; x < bmp.Width; x++)
					if (transparente[x, y] && !marcas[x, y])
					{
						long área;
						ArrayList pontos;

						área = CalcularÁrea(marcas, x, y, out pontos);

						if (área < limiarReconstrução)
						{
							foreach (Point p in pontos)
							{
								Color cor = bmp.GetPixel(p.X, p.Y);
								bmp.SetPixel(p.X, p.Y, Color.FromArgb(255, cor.R, cor.G, cor.B));
							}
						}
					}
		}

		/// <summary>
		/// Suaviza a transparência
		/// </summary>
		/// <param name="bmp">Imagem a ter sua transparência suavizada</param>
		/// <returns>Imagem com transparência suavizada</returns>
		private static Bitmap SuavizarTransparência(Bitmap bmp)
		{
			Bitmap suavização = new Bitmap(bmp);

			for (int y = 1; y < bmp.Height - 2; y++)
				for (int x = 1; x < bmp.Width - 2; x++)
				{
					Color pixel = bmp.GetPixel(x, y);
					float a = pixel.A;

					a += bmp.GetPixel(x - 1, y - 1).A;
					a += bmp.GetPixel(x, y - 1).A;
					a += bmp.GetPixel(x + 1, y - 1).A;
					a += bmp.GetPixel(x + 1, y).A;
					a += bmp.GetPixel(x + 1, y + 1).A;
					a += bmp.GetPixel(x, y + 1).A;
					a += bmp.GetPixel(x - 1, y + 1).A;
					a += bmp.GetPixel(x - 1, y).A;

					a /= 9f;

					a = Math.Min(pixel.A, a);

					suavização.SetPixel(x, y, Color.FromArgb((int) Math.Round(a), pixel));
				}

			return suavização;
		}

		/*
		/// <summary>
		/// Dilata uma imagem
		/// </summary>
		/// <param name="origem">Imagem original</param>
		/// <returns>Imagem dilatada</returns>
		private Bitmap Dilatar(Image imgOrigem)
		{
			Bitmap final, original;

			final = new Bitmap(imgOrigem.Width, imgOrigem.Height);

			using (original = new Bitmap(imgOrigem))
			{
				for (int y = 0; y < original.Height; y++)
					for (int x = 0; x < original.Width; x++)
						final.SetPixel(x, y, ObterMáximo(original, x, y));
			}

			return final;
		}

		/// <summary>
		/// Obtém a cor máxima
		/// </summary>
		private Color ObterMáximo(Bitmap img, int x, int y)
		{
			int r = 0, g = 0, b = 0;

			ObterMáximo(img, x, y, ref r, ref g, ref b);
			ObterMáximo(img, x - 1, y - 1, ref r, ref g, ref b);
			ObterMáximo(img, x - 1, y + 1, ref r, ref g, ref b);
			ObterMáximo(img, x - 1, y, ref r, ref g, ref b);
			ObterMáximo(img, x, y - 1, ref r, ref g, ref b);
			ObterMáximo(img, x + 1, y - 1, ref r, ref g, ref b);
			ObterMáximo(img, x + 1, y, ref r, ref g, ref b);
			ObterMáximo(img, x + 1, y + 1, ref r, ref g, ref b);
			ObterMáximo(img, x, y + 1, ref r, ref g, ref b);

			return Color.FromArgb(r, g, b);
		}
			
		/// <summary>
		/// Obtém a cor máxima
		/// </summary>
		private void ObterMáximo(Bitmap img, int x, int y, ref int r, ref int g, ref int b)
		{
			if (x < 0 || x >= img.Width || y < 0 || y >= img.Height)
				return;

			Color pixel = img.GetPixel(x, y);

			r = Math.Max(r, pixel.R);
			g = Math.Max(g, pixel.G);
			b = Math.Max(b, pixel.B);
		}
		*/

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Importador importador;
			importador = new Importador();
            importador.Show();
            Application.Run(importador);
		}

		/// <summary>
		/// Ocorre ao desenhar picFotos
		/// </summary>
		private void picFotos_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			lock (imagens)
			{
				e.Graphics.DrawImageUnscaled(imagens, 0, 0);
			}
		}

		private void Importador_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            for (int i = 0; i < totalThreads; i++)
            {
                if (threads[i] != null)
                {
                    threads[i].Abort();
                    threads[i] = null;
                }
            }
		}

        private delegate void MostrarMensagemCallBack(string msg);

		private void MostrarMensagem(string msg)
		{
            if (txtMensagens.InvokeRequired)
            {
                MostrarMensagemCallBack método = new MostrarMensagemCallBack(MostrarMensagem);
                txtMensagens.Invoke(método, msg);
            }
            else
            {
                txtMensagens.Text += msg + "\r\n";
                txtMensagens.SelectionStart = txtMensagens.Text.Length;
                txtMensagens.ScrollToCaret();
            }
		}

        private void Importador_Load(object sender, EventArgs e)
        {
        }

        private void Importador_Shown(object sender, EventArgs e)
        {
            string caminho;


            // Obter diretório contendo as fotos
            using (FolderBrowserDialog pastas = new FolderBrowserDialog())
            {
                //pastas.RootFolder = System.Environment.SpecialFolder.MyPictures;
                pastas.ShowNewFolderButton = false;

                if (pastas.ShowDialog() == DialogResult.OK)
                    caminho = pastas.SelectedPath;
                else
                    return;
            }

            Importar(caminho);
        }
	}
}
