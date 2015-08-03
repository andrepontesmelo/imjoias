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
		private const float limiarProje��o		= 0.03f;		// Entre 0 e 1
		private const float	limiar�rea			= 0.10f;		// Entre 0 e 1
		private const float	limiarReconstru��o	= 0.003f;		// Entre 0 e 1
		private const float limiarTransparentes = 0.99f;		// Entre 0 e 1
		private const int   margem              = 10;			// Pixels

		// Atributos
		private Bitmap imagens;
        private Thread [] threads;
        private Stack arquivos = new Stack();

		// Formul�rio
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
            this.lblArquivo.Text = "Lendo diret�rio...";
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
            this.Text = "Importa��o de fotos";
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

            // Atribui informa��es para porcentagem
            progresso.Maximum = arquivosVetor.Length;

            threads = new Thread[totalThreads];

            for (int i = 0; i < totalThreads; i++)
            {
                threads[i] = new Thread(new ThreadStart(Importar));
                threads[i].Start();
            }
		}

        private delegate void AtualizarInterfaceCallBack(string arquivoAtual);

        private string ObterPr�ximoArquivo()
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
                AtualizarInterfaceCallBack m�todo = new AtualizarInterfaceCallBack(AtualizarInterface);
                progresso.Invoke(m�todo, arq);
            }

            return arq;
        }

        private void AtualizarInterface(string arquivoAtual)
        {
            lblArquivo.Text = arquivoAtual;
            progresso.Increment(1);
        }

        private static MySqlConnection CriarConex�o()
        {
            MySqlConnection conex�o = new MySqlConnection();
            string host, bd, usu�rio, senha;

//            host = "imj.no-ip.com";
            host = "192.168.1.10";
#if DEBUG
            bd = "imjoias-desenv";
#else
            bd = "imjoias";
#endif

            MessageBox.Show("Trabalhando com banco de dados " + bd + ".");

            usu�rio = "imjoias";
            senha = "***REMOVED***";

            string strConex�o;

            strConex�o = "Data Source=" + host;
            strConex�o += ";Database=" + bd;
            strConex�o += ";User Id=" + usu�rio;
            strConex�o += ";Password=" + senha;
            strConex�o += ";Port=46033";

            //MessageBox.Show(strConex�o);

            conex�o = new MySqlConnection(strConex�o);
            conex�o.Open();

            return conex�o;
        }

		/// <summary>
		/// Importa as imagens
		/// </summary>
        private void Importar()
        {
            // Cria a conex�o
            MySqlConnection conex�o = CriarConex�o();

            // Apenas primeira vez.
            string arquivo = ObterPr�ximoArquivo();

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
                        SalvarImagem(arquivo, imgProcessada, conex�o);

                        imagem.Dispose();
                        imgProcessada.Dispose();

                        System.GC.Collect();
                    }
                    catch (Exception e)
                    {
                        MostrarMensagem("N�o foi poss�vel importar o arquivo " + arquivo + ": " + e.Message);
                    }
                }
                arquivo = ObterPr�ximoArquivo();

            } while (arquivo != null);
        }

		private void SalvarImagem(string arquivo, Image imagem, MySqlConnection conex�o)
		{
            string arquivoOriginal = arquivo;

            using (MemoryStream streamFoto = new MemoryStream())
            {
                using (MemoryStream stream�cone = new MemoryStream())
                {
                    string refer�ncia = "";
                    int �ltimaBarra;

                    // Constr�i arquivo de sa�da
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

                    // Obt�m nome do arquivo
                    �ltimaBarra = arquivo.LastIndexOf('\\') + 1;
                    arquivo = arquivo.Substring(0, arquivo.LastIndexOf('.') - 1);

                    for (int i = �ltimaBarra; i < arquivo.Length && arquivo[i] != 0; i++)
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
                                refer�ncia += arquivo[i];
                                break;
                        }
                    }

                    MostrarMensagem("Salvando " + refer�ncia + " a arquivo partir do arquivo " + arquivo);

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
                            icone.Save(stream�cone, ImageFormat.Png);
                        }
                        catch
                        {
                            try
                            {
                                icone = new Bitmap(icone);
                                icone.Save(stream�cone, ImageFormat.Png);
                            }
                            catch
                            {
                                icone.Save(stream�cone, imagem.RawFormat);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        MostrarMensagem("N�o foi poss�vel criar �cone: " + e.Message);
                    }

                    //cmd.Connection = conex�o;
                    //cmd.CommandText = "UPDATE foto SET icone = ?icone WHERE mercadoria = '" + refer�ncia + "'";
                    //cmd.Parameters.Add("?icone", stream�cone.ToArray());

                    //try
                    //{
                    //    cmd.ExecuteNonQuery();
                    //}
                    //catch (Exception e)
                    //{
                    //    MostrarMensagem("N�o foi poss�vel gravar no banco de dados o �cone!\n\n" + e.ToString());
                    //}

                    using (FileStream streamOriginal = new FileStream(arquivoOriginal, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (MySqlCommand cmd = conex�o.CreateCommand())
                        {
                            cmd.Connection = conex�o;

                            cmd.CommandText = "INSERT INTO foto (mercadoria, foto, icone, original) VALUES ('" + refer�ncia + "', ?foto, ?icone, ?original)";
                            cmd.Parameters.Add("?foto", streamFoto.ToArray());
                            cmd.Parameters.Add("?icone", stream�cone.ToArray());

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
                                MostrarMensagem("N�o foi poss�vel inserir no banco de dados a foto+icone para a refer�ncia " + refer�ncia + ": " + e.Message);
                            }
                        }
                    }
                }
            }

		}

        private delegate void MIDelegate(Image imagem);
        private delegate void MIconDelegate(MemoryStream imagem);

        private void Mostrar�cone(MemoryStream imagem)
        {
            if (InvokeRequired)
            {
                MIDelegate m�todo = new MIDelegate(MostrarImagem);

                Invoke(m�todo, imagem);
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
                MIDelegate m�todo = new MIDelegate(MostrarImagem);

                Invoke(m�todo, imagem);
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
		/// <param name="brilho">Brilho de refer�ncia</param>
		/// <param name="x">Posi��o X</param>
		/// <param name="y">Posi��o Y</param>
		private static void InserirPilha(Stack pilha, float brilho, int x, int y)
		{
			pilha.Push(brilho);
			pilha.Push(new Point(x, y));
		}

		/// <summary>
		/// Encontra cores de fundo em um bitmap
		/// </summary>
		/// <param name="origem">Imagem original</param>
		/// <returns>Dicion�rio de cores do fundo</returns>
		private static Hashtable EncontrarCoresFundo(Bitmap origem)
		{
			Hashtable cores = new Hashtable();	// Cores do fundo
			Stack	  pilha = new Stack();		// Pilha para flood-fill
			bool [,]  marcado;					// Pontos marcados no flood-fill

			marcado = new bool[origem.Width, origem.Height];

			/* A cor de fundo � encontrada realizando um flood-fill
				 * nas bordas da imagem. As cores encontradas cujo brilho
				 * se difere de um determinado limiar s�o consideradas como
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
//		/// <param name="marca��oOriginal">Pontos verificados</param>
//		private void EncontrarIlhasCoresFundo(Bitmap imagem, Hashtable coresFundo, bool [,] marca��oOriginal)
//		{
//			float limiar�rea;
//
//			limiar�rea = Importador.limiar�rea * imagem.Width * imagem.Height;
//
//			for (int y = 0; y < imagem.Height; y++)
//				for (int x = 0; x < imagem.Width; x++)
//					if (!marca��oOriginal[x, y])
//					{
//						ArrayList pontos;
//						long      �rea;
//
//						�rea = Calcular�rea(marca��oOriginal, x, y, out pontos);
//
//						// Adicionar cores da ilha
//						if (�rea < limiar�rea)
//							foreach (Point p in pontos)
//								coresFundo[imagem.GetPixel(p.X, p.Y)] = Color.Red;
//					}
//		}

		/// <summary>
		/// Calcula a �rea de uma ilha
		/// </summary>
		/// <param name="marca��o">Marca��o de pontos preenchidos com fundo</param>
		/// <param name="x">Coordenada X</param>
		/// <param name="y">Coordenada Y</param>
		/// <param name="pontos">Pontos da ilha</param>
		/// <returns>�rea da ilha</returns>
		private static long Calcular�rea(bool [,] marca��o, int x, int y, out ArrayList pontos)
		{
			Stack pilha = new Stack();
			long  �rea = 0;
			
			pontos = new ArrayList(100000);
			pilha.Push(new Point(x, y));

			while (pilha.Count > 0)
			{
				Point ponto = (Point) pilha.Pop();

				if (ponto.X >= 0 && ponto.X <= marca��o.GetUpperBound(0)
					&& ponto.Y >= 0 && ponto.Y <= marca��o.GetUpperBound(1)
					&& !marca��o[ponto.X, ponto.Y])
				{
					�rea++;
//					pilha.Push(new Point(ponto.X - 1, ponto.Y - 1));
					pilha.Push(new Point(ponto.X, ponto.Y - 1));
//					pilha.Push(new Point(ponto.X + 1, ponto.Y - 1));
					pilha.Push(new Point(ponto.X + 1, ponto.Y));
//					pilha.Push(new Point(ponto.X + 1, ponto.Y + 1));
					pilha.Push(new Point(ponto.X, ponto.Y + 1));
//					pilha.Push(new Point(ponto.X - 1, ponto.Y + 1));
					pilha.Push(new Point(ponto.X - 1, ponto.Y));
					marca��o[ponto.X, ponto.Y] = true;
					pontos.Add(ponto);
				}
			}

			return �rea;
		}

		/// <summary>
		/// Remove ilhas
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="marca��oOriginal">Pontos verificados</param>
		private void RemoverIlhas(Bitmap imagem, bool [,] marca��oOriginal)
		{
			float limiar�rea;

			limiar�rea = Importador.limiar�rea * Calcular�reaN�oTransparente(marca��oOriginal);

			for (int y = 0; y < imagem.Height; y++)
				for (int x = 0; x < imagem.Width; x++)
					if (!marca��oOriginal[x, y])
					{
						ArrayList pontos;
						long      �rea;

						�rea = Calcular�rea(marca��oOriginal, x, y, out pontos);

						// Adicionar cores da ilha
						if (�rea < limiar�rea)
							foreach (Point p in pontos)
								imagem.SetPixel(p.X, p.Y, Color.FromArgb(0, imagem.GetPixel(p.X, p.Y)));
					}
		}

		/// <summary>
		/// Calcula �rea n�o transparente
		/// </summary>
		/// <param name="transparentes">Pontos transparentes</param>
		/// <returns>�rea n�o transparente</returns>
		private static long Calcular�reaN�oTransparente(bool [,] transparentes)
		{
			long �rea = 0;

			foreach (bool b in transparentes)
				if (!b)
					�rea++;

			return �rea;
		}

		/// <summary>
		/// Delimita uma imagem conforme transpar�ncia
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <returns>�rea contendo imagem</returns>
		private Rectangle Delimitar(Bitmap imagem)
		{
			int x1, x2, y1, y2;
			float limiarProje��oHorizontal, limiarProje��oVertical;

			x1 = 0;
			x2 = imagem.Width - 1;
			y1 = 0;
			y2 = imagem.Height - 1;

			limiarProje��oHorizontal = imagem.Width * limiarProje��o;
			limiarProje��oVertical = imagem.Height * limiarProje��o;

			/// Encontrar o topo
			while (CalcularProje��oHorizontal(imagem, y1) < limiarProje��oHorizontal && y1 < y2)
				y1++;

			// Encontrar o limite inferior
			while (CalcularProje��oHorizontal(imagem, y2) < limiarProje��oHorizontal && y2 > y1)
				y2--;

			// Encontrar a esquerda
			while (CalcularProje��oVertical(imagem, x1) < limiarProje��oVertical && x1 < x2)
				x1++;

			// Encontrar a direita
			while (CalcularProje��oVertical(imagem, x2) < limiarProje��oVertical && x2 > x1)
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
			while (CalcularProje��oHorizontal(imagem, y1) == 0 && y1 > 0)
				y1--;

			// Encontrar o limite inferior
			while (CalcularProje��oHorizontal(imagem, y2) == 0 && y2 < imagem.Height - 1)
				y2++;

			// Encontrar a esquerda
			while (CalcularProje��oVertical(imagem, x1) == 0 && x1 > 0)
				x1--;

			// Encontrar a direita
			while (CalcularProje��oVertical(imagem, x2) == 0 && x2 < imagem.Width - 1)
				x2++;

			return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		}

		/// <summary>
		/// Calcula a proje��o horizontal
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="y">Linha onde ser� calculada a proje��o horizontal</param>
		/// <returns>Proje��o da linha</returns>
		private static long CalcularProje��oHorizontal(Bitmap imagem, int y)
		{
			long proje��o = 0;

			for (int x = 0; x < imagem.Width; x++)
				if (imagem.GetPixel(x, y).A > 0)
					proje��o++;

			return proje��o;
		}

		/// <summary>
		/// Calcula a proje��o vertical
		/// </summary>
		/// <param name="imagem">Imagem original</param>
		/// <param name="x">Coluna onde ser� calculada a proje��o vertical</param>
		/// <returns>Proje��o da coluna</returns>
		private static long CalcularProje��oVertical(Bitmap imagem, int x)
		{
			long proje��o = 0;

			for (int y = 0; y < imagem.Height; y++)
				if (imagem.GetPixel(x, y).A > 0)
					proje��o++;

			return proje��o;
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

					// Suavizar transpar�ncia
					using (Bitmap suaviza��o = SuavizarTranspar�ncia(processamento))
					{
						// Cortar foto
						limites = Delimitar(suaviza��o);				
						final = new Bitmap(limites.Width, limites.Height);

						for (int y = 0; y < limites.Height; y++)
							for (int x = 0; x < limites.Width; x++)
								final.SetPixel(x, y, suaviza��o.GetPixel(limites.Left + x, limites.Top + y));
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
		/// Reconstr�i imagem processada, tentando remover �reas transparentes
		/// que s�o j�ias
		/// </summary>
		/// <param name="bmp">Imagem processada</param>
		/// <param name="transparente">Pontos transparentes</param>
		private void ReconstruirImagem(Bitmap bmp, bool [,] transparente)
		{
			bool [,] marcas = new bool[bmp.Width, bmp.Height];
			float limiarReconstru��o;

			limiarReconstru��o = Importador.limiarReconstru��o * bmp.Width * bmp.Height;

			for (int i = 0; i < bmp.Width; i++)
				for (int j = 0; j < bmp.Height; j++)
					marcas[i, j] = !transparente[i, j];

			for (int y = 0; y < bmp.Height; y++)
				for (int x = 0; x < bmp.Width; x++)
					if (transparente[x, y] && !marcas[x, y])
					{
						long �rea;
						ArrayList pontos;

						�rea = Calcular�rea(marcas, x, y, out pontos);

						if (�rea < limiarReconstru��o)
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
		/// Suaviza a transpar�ncia
		/// </summary>
		/// <param name="bmp">Imagem a ter sua transpar�ncia suavizada</param>
		/// <returns>Imagem com transpar�ncia suavizada</returns>
		private static Bitmap SuavizarTranspar�ncia(Bitmap bmp)
		{
			Bitmap suaviza��o = new Bitmap(bmp);

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

					suaviza��o.SetPixel(x, y, Color.FromArgb((int) Math.Round(a), pixel));
				}

			return suaviza��o;
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
						final.SetPixel(x, y, ObterM�ximo(original, x, y));
			}

			return final;
		}

		/// <summary>
		/// Obt�m a cor m�xima
		/// </summary>
		private Color ObterM�ximo(Bitmap img, int x, int y)
		{
			int r = 0, g = 0, b = 0;

			ObterM�ximo(img, x, y, ref r, ref g, ref b);
			ObterM�ximo(img, x - 1, y - 1, ref r, ref g, ref b);
			ObterM�ximo(img, x - 1, y + 1, ref r, ref g, ref b);
			ObterM�ximo(img, x - 1, y, ref r, ref g, ref b);
			ObterM�ximo(img, x, y - 1, ref r, ref g, ref b);
			ObterM�ximo(img, x + 1, y - 1, ref r, ref g, ref b);
			ObterM�ximo(img, x + 1, y, ref r, ref g, ref b);
			ObterM�ximo(img, x + 1, y + 1, ref r, ref g, ref b);
			ObterM�ximo(img, x, y + 1, ref r, ref g, ref b);

			return Color.FromArgb(r, g, b);
		}
			
		/// <summary>
		/// Obt�m a cor m�xima
		/// </summary>
		private void ObterM�ximo(Bitmap img, int x, int y, ref int r, ref int g, ref int b)
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
                MostrarMensagemCallBack m�todo = new MostrarMensagemCallBack(MostrarMensagem);
                txtMensagens.Invoke(m�todo, msg);
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


            // Obter diret�rio contendo as fotos
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
