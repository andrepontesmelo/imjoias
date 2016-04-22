using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Programa.ProtetorTela.UI;
using Programa.ProtetorTela.Rss;
using System.Threading;
using Entidades;
using Entidades.Álbum;

namespace Programa.ProtetorTela
{
    partial class ScreenSaverForm : Form
    {
        public enum Modo
        {
            Logotipo,
            Mercadoria,
            Notícia,
            Transição
        }

        private Modo modo = Modo.Logotipo;

        private delegate void Método();

        public Modo ModoAtual
        {
            get { return modo; }
            set
            {
                //LoadTransição();
                //transição.PróximoModo = value;
                //modo = Modo.Transição;
                modo = value;
            }
        }

        // The RssFeed to display articles from
        private RssFeed rssFeed;

        // Objects for displaying RSS contents
        private ItemListView<RssItem> rssView;
        private ItemDescriptionView<RssItem> rssDescriptionView;

        // The images to display in the background
        private List<Image> backgroundImages;
        private int currentImageIndex;
        
        // Fotos para serem disponibilizadas
        private Foto[] fMercadorias;
        private int mercadoriaAtual;
        private InfoMercadoria infoMercadoria;
        //private Transição transição;

        // Keep track of whether the screensaver has become active.
        private bool isActive = false;

        // Keep track of the location of the mouse
        private Point mouseLocation;

        private List<string> imageExtensions = new List<string>(new string[] { "*.bmp", "*.gif", "*.png", "*.jpg", "*.jpeg" });

        private int switchCount = 0;

        private Point mainLocation, secondaryLocation;
        private Size mainSize, secondarySize;

        private int deltaMY = 1;
        private int deltaMX = 1;
        private int deltaSY = 1;
        private int deltaSX = 1;

        private System.Windows.Forms.Timer tmrMovimentoM, tmrMovimentoS;

        private Thread carregar;

        public ScreenSaverForm()
        {
            InitializeComponent();

            SetupScreenSaver();

            LoadBackgroundImage();

            mainLocation = new Point(Width / 10, Height / 10);
            mainSize = new Size(Width / 2, 3 * Height / 5);
            secondaryLocation = new Point(3 * Width / 4, Height / 3);
            secondarySize = new Size(Width / 4, Height / 2);

            try
            {
                Acesso.MySQL.MySQLUsuários usuários = new Acesso.MySQL.MySQLUsuários();
                usuários.EfetuarLogin("imjoias", "b9r8hukl3");
            }
            catch { }

            Carregar();

            // Prepara temporizador para movimentar quadros
            if (Properties.Settings.Default.MoverQuadros)
            {
                tmrMovimentoM = new System.Windows.Forms.Timer();
                tmrMovimentoM.Interval = 5000;
                tmrMovimentoM.Enabled = true;
                tmrMovimentoM.Tick += new EventHandler(tmrMovimentoM_Tick);
                tmrMovimentoM.Start();

                tmrMovimentoS = new System.Windows.Forms.Timer();
                tmrMovimentoS.Interval = 10000;
                tmrMovimentoS.Enabled = true;
                tmrMovimentoS.Tick += new EventHandler(tmrMovimentoS_Tick);
                tmrMovimentoS.Start();
            }
        }

        private void Carregar()
        {
            if (carregar == null)
            {
                carregar = new Thread(new ThreadStart(LoadAll));
                carregar.IsBackground = true;
                carregar.Start();
            }
        }

        void tmrMovimentoM_Tick(object sender, EventArgs e)
        {
            const int margem = 15;

            if ((deltaMX < 0 && mainLocation.X + deltaMX < margem)
                || (deltaMX > 0 && mainLocation.X + deltaMX + mainSize.Width > secondaryLocation.X))
                deltaMX *= -1;

            if ((deltaMY < 0 && mainLocation.Y + deltaMY < margem)
                || (deltaMY > 0 && mainLocation.Y + deltaMY + mainSize.Height > Size.Height - margem))
                deltaMY *= -1;

            mainLocation.Offset(deltaMX, deltaMY);

            switch (modo)
            {
                case Modo.Notícia:
                    if (rssView != null)
                        rssView.Location = mainLocation;
                    break;

                case Modo.Mercadoria:
                    if (infoMercadoria != null)
                        infoMercadoria.Location = mainLocation;
                    break;
            }

            Refresh();
        }

        void tmrMovimentoS_Tick(object sender, EventArgs e)
        {
            const int margem = 15;

            if ((deltaSX < 0 && secondaryLocation.X + deltaSX < mainLocation.X + mainSize.Width)
                || (deltaSX > 0 && secondaryLocation.X + deltaSX + secondarySize.Width > Size.Width - margem))
                deltaSX *= -1;

            if ((deltaSY < 0 && secondaryLocation.Y + deltaSY < margem)
                || (deltaSY > 0 && secondaryLocation.Y + deltaSY + secondarySize.Height > Size.Height - margem))
                deltaSY *= -1;

            secondaryLocation.Offset(deltaSX, deltaSY);

            switch (modo)
            {
                case Modo.Notícia:
                    if (rssDescriptionView != null)
                        rssDescriptionView.Location = secondaryLocation;
                    break;

                case Modo.Mercadoria:
                    if (infoMercadoria != null)
                        infoMercadoria.DescriptionLocation = secondaryLocation;
                    break;
            }

            Refresh();
        }

        private void LoadAll()
        {
            try
            {
                LoadRssFeed();

                if (ModoAtual == Modo.Logotipo)
                    ModoAtual = Modo.Notícia;

                LoadPhotos();
            }
            finally
            {
                carregar = null;
            }
        }

        private void MostrarFoto()
        {
            try
            {
                if (InvokeRequired)
                {
                    MétodoCallback método = new MétodoCallback(MostrarFoto);
                    BeginInvoke(método);
                }
                else
                {
                    Foto foto = fMercadorias[mercadoriaAtual];

                    if (!foto.Preparada)
                    {
                        MostrarNotícias();

                        if (carregar == null)
                        {
                            carregar = new Thread(new ThreadStart(CarregarPróximasFotos));
                            carregar.IsBackground = true;
                            carregar.Start();
                        }
                    }
                    else
                    {
                        if (infoMercadoria != null)
                            infoMercadoria.Dispose();

                        infoMercadoria = new InfoMercadoria(foto);
                        InitializeMercadoriaView();

                        ModoAtual = Modo.Mercadoria;
                    }
                }
            }
            catch
            {
                ModoAtual = Modo.Notícia;
            }
        }

        private delegate void MétodoCallback();

        private void MostrarNotícias()
        {
            if (InvokeRequired)
            {
                MétodoCallback método = new MétodoCallback(MostrarNotícias);
                BeginInvoke(método);
            }
            else
            {
                if (rssView == null)
                {
                    // Initialize the ItemListView to display the list of items in the 
                    // RssItem.  It is placed on the left side of the screen.            
                    rssView = new ItemListView<RssItem>(rssFeed.MainChannel.Title, rssFeed.MainChannel.Items);
                    InitializeRssView();
                }

                if (rssDescriptionView == null)
                {
                    // Initialize the ItemDescriptionView to display the description of the 
                    // RssItem.  It is placed on the right side of the screen.
                    rssDescriptionView = new ItemDescriptionView<RssItem>();
                    InitializeRssDescriptionView();
                }
            }
        }

        /// <summary>
        /// Set up the main form as a full screen screensaver.
        /// </summary>
        private void SetupScreenSaver()
        {
            // Use double buffering to improve drawing performance
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

#if DEBUG
            TopMost = false;
#endif

            // Capture the mouse
            this.Capture = true;

            // Set the application to full screen mode and hide the mouse
            Cursor.Hide();

            Bounds = Screen.PrimaryScreen.Bounds;
            WindowState = FormWindowState.Maximized;
            ShowInTaskbar = false;

            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

//        private void LoadTransição()
//        {
//            if (transição != null)
//                transição.Dispose();

//            transição = new Transição();
//            transição.Size = Size;
//            transição.Location = new Point(0, 0);
//            transição.Atualizado += new EventHandler(FadeTimer_Tick);
//            transição.Concluído += new EventHandler(transição_Concluído);
//        }

//        void transição_Concluído(object sender, EventArgs e)
//        {
//#if DEBUG
//            if (transição.PróximoModo == Modo.Transição)
//                throw new Exception("Próximo modo não pode ser outra transição.");
//#endif

//            modo = transição.PróximoModo;
//            transição.Dispose();
//            transição = null;
//        }

        private void LoadPhotos()
        {
            try
            {
                Foto[] fMercadorias;

                mercadoriaAtual = 0;
                fMercadorias = Foto.ObterFotosAleatórias(12);

                for (int i = 0; i < 3 && i < fMercadorias.Length; i++)
                    fMercadorias[i].PrepararFoto();

                this.fMercadorias = fMercadorias;
            }
            catch { }
        }

        private void LoadBackgroundImage()
        {
            // Initialize the background images.
            backgroundImages = new List<Image>();
            currentImageIndex = 0;

            if (Directory.Exists(Properties.Settings.Default.BackgroundImagePath))
            {
                try
                {
                    // Try to load the images given by the users.
                    LoadImagesFromFolder();
                }
                catch
                {
                    // If this fails, load the default images.
                    LoadDefaultBackgroundImages();
                }
            }

            // If no images were loaded, load the defaults
            if (backgroundImages.Count == 0)
            {
                LoadDefaultBackgroundImages();
            }
        }

        private void LoadImagesFromFolder()
        {
            DirectoryInfo backgroundImageDir = new DirectoryInfo(Properties.Settings.Default.BackgroundImagePath);
            // For each image extension (.jpg, .bmp, etc.)
            foreach (string imageExtension in imageExtensions)
            {
                // For each file in the directory provided by the user
                foreach (FileInfo file in backgroundImageDir.GetFiles(imageExtension))
                {
                    // Try to load the image
                    try
                    {
                        Image image = Image.FromFile(file.FullName);
                        backgroundImages.Add(image);
                    }
                    catch (OutOfMemoryException)
                    {
                        // If the image can't be loaded, move on.
                        continue;
                    }
                }
            }
        }


        private void LoadDefaultBackgroundImages()
        {
            // If the background images could not be loaded for any reason
            // use the image stored in the resources 
            backgroundImages.Add(Properties.Resources.FundoLiene);
            backgroundImages.Add(Properties.Resources.SSaverBackground);
            backgroundImages.Add(Properties.Resources.SSaverBackground2);
            backgroundImages.Add(Properties.Resources.FundoSítio1);
            backgroundImages.Add(Properties.Resources.FundoTrem);
            backgroundImages.Add(Properties.Resources.FundoMar);
            backgroundImages.Add(Properties.Resources.FundoDuds1);
        }

        private void LoadRssFeed()
        {
            try
            {
                // Try to get it from the users settings
                rssFeed = RssFeed.FromUri(Properties.Settings.Default.RssFeedUri);
            }
            catch
            {
                // If there is any problem loading the RSS load an error message RSS feed
                rssFeed = RssFeed.FromText(Properties.Resources.DefaultRSSText);
            }
        }

        /// <summary>
        /// Initialize display properties of the rssView.
        /// </summary>
        private void InitializeRssView()
        {
            rssView.BackColor = Color.FromArgb(120, 240, 234, 232);
            rssView.BorderColor = Color.White;
            rssView.ForeColor = Color.FromArgb(255, 40, 40, 40);
            rssView.SelectedBackColor = Color.FromArgb(200, 105, 61, 76);
            rssView.SelectedForeColor = Color.FromArgb(255, 204, 184, 163);
            rssView.TitleBackColor = Color.Empty;
            rssView.TitleForeColor = Color.FromArgb(255, 240, 234, 232);
            rssView.MaxItemsToShow = 20;
            rssView.MinItemsToShow = 15;
            rssView.Location = mainLocation;
            rssView.Size = mainSize;
        }

        private void InitializeMercadoriaView()
        {
            infoMercadoria.BackColor = Color.FromArgb(120, 240, 234, 232);
            infoMercadoria.BorderColor = Color.White;
            infoMercadoria.ForeColor = Color.FromArgb(255, 40, 40, 40);
            //infoMercadoria.TitleBackColor = Color.Empty;
            //infoMercadoria.TitleForeColor = Color.FromArgb(255, 240, 234, 232);
            infoMercadoria.Location = mainLocation;
            infoMercadoria.Size = mainSize;
            //infoMercadoria.FadingComplete += new EventHandler(infoMercadoria_FadingComplete);
            //infoMercadoria.FadeTimer.Tick += new EventHandler(FadeTimer_Tick);
            //infoMercadoria.FadeTimer.Interval = 1000;
            infoMercadoria.DescriptionLocation = secondaryLocation;
            infoMercadoria.DescriptionSize = secondarySize;
            infoMercadoria.DescriptionForeColor = Color.FromArgb(255, 240, 234, 232);
            infoMercadoria.LineColor = Color.FromArgb(120, 240, 234, 232);
            infoMercadoria.LineWidth = 2f;
        }

        /// <summary>
        /// Initialize display properties of the rssDescriptionView.
        /// </summary>
        private void InitializeRssDescriptionView()
        {
            rssDescriptionView.DisplayItem = rssView.SelectedItem;
            rssDescriptionView.ForeColor = Color.FromArgb(255, 240, 234, 232);
            rssDescriptionView.TitleFont = rssView.TitleFont;
            rssDescriptionView.LineColor = Color.FromArgb(120, 240, 234, 232);
            rssDescriptionView.LineWidth = 2f;
            //rssDescriptionView.FadeTimer.Tick += new EventHandler(FadeTimer_Tick);
            //rssDescriptionView.FadeTimer.Interval= 1000;
            rssDescriptionView.Location = secondaryLocation;
            rssDescriptionView.Size = secondarySize;
            rssDescriptionView.FadingComplete += new EventHandler(rssItemView_FadingComplete);
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Set IsActive and MouseLocation only the first time this event is called.
            if (!isActive)
            {
                mouseLocation = MousePosition;
                isActive = true;
            }
            else
            {
#if !DEBUG
                // If the mouse has moved significantly since first call, close.
                if ((Math.Abs(MousePosition.X - mouseLocation.X) > 10) ||
                    (Math.Abs(MousePosition.Y - mouseLocation.Y) > 10))
                {
                    Close();
                }
#endif
            }
        }

        private void ScreenSaverForm_KeyDown(object sender, KeyEventArgs e)
        {
#if DEBUG
            if (e.KeyCode == Keys.Escape)
                Close();
#else
            Close();
#endif
        }

        private void ScreenSaverForm_MouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            switch (modo)
            {
                case Modo.Transição:
                case Modo.Logotipo:
                    e.Graphics.FillRectangle(Brushes.White, 0, 0, Size.Width, Size.Height);
                    e.Graphics.DrawImageUnscaled(Properties.Resources.Logo, (Size.Width - Properties.Resources.Logo.Width) / 2, (Size.Height - Properties.Resources.Logo.Height) / 2);
                    break;

                case Modo.Mercadoria:
                case Modo.Notícia:
                    // Draw the current background image stretched to fill the full screen
                    e.Graphics.DrawImage(backgroundImages[currentImageIndex], 0, 0, Size.Width, Size.Height);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            switch (modo)
            {
                case Modo.Notícia:
                    if (rssDescriptionView == null)
                        MostrarNotícias();
                    else
                    {
                        rssView.Paint(e);
                        rssDescriptionView.Paint(e);
                    }
                    break;

                case Modo.Mercadoria:
                    if (infoMercadoria == null)
                        MostrarFoto();
                    else
                        infoMercadoria.Paint(e);
                    break;

                case Modo.Transição:
                    throw new NotSupportedException();
                //    transição.Desenhar(e);
                //    break;
            }
        }

        private void backgroundChangeTimerTick(object sender, EventArgs e)
        {
            // Change the background image to the next image.
            currentImageIndex = (currentImageIndex + 1) % backgroundImages.Count;

            // Forçando aqui.
            rssItemView_FadingComplete(sender, e);
        }

        void FadeTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        void rssItemView_FadingComplete(object sender, EventArgs e)
        {
            try
            {
                switch (modo)
                {
                    case Modo.Notícia:
                        rssView.NextArticle();
                        rssDescriptionView.DisplayItem = rssView.SelectedItem;

                        if (switchCount++ > 2 && fMercadorias != null)
                        {
                            switchCount = 3;
                            ModoAtual = Modo.Mercadoria;
                            rssDescriptionView.Dispose();
                            rssDescriptionView = null;
                        }
                        break;

                    case Modo.Mercadoria:
                        infoMercadoria.Dispose();
                        infoMercadoria = null;

                        fMercadorias[mercadoriaAtual].LiberarFoto();

                        mercadoriaAtual = (mercadoriaAtual + 1) % fMercadorias.Length;

                        if (mercadoriaAtual == 0)
                            Carregar();

                        if (switchCount-- < 1 && rssView != null)
                        {
                            ModoAtual = Modo.Notícia;
                            switchCount = 0;
                        }
                        else
                            MostrarFoto();

                        if (mercadoriaAtual + 3 < fMercadorias.Length && !fMercadorias[mercadoriaAtual + 3].Preparada && carregar == null)
                        {
                            carregar = new Thread(CarregarPróximasFotos);
                            carregar.Start();
                        }
                        break;
                }
            }
            catch
            {
                Carregar();
            }
        }

        void infoMercadoria_FadingComplete(object sender, EventArgs e)
        {
            if (modo == Modo.Mercadoria)
            {
                infoMercadoria.Dispose();
                infoMercadoria = null;

                fMercadorias[mercadoriaAtual].LiberarFoto();

                mercadoriaAtual = (mercadoriaAtual + 1) % fMercadorias.Length;

                if (mercadoriaAtual == 0)
                    Carregar();

                if (switchCount-- < 1 && rssView != null)
                {
                    ModoAtual = Modo.Notícia;
                    switchCount = 0;
                }
                else
                    MostrarFoto();

                if (mercadoriaAtual + 3 < fMercadorias.Length && !fMercadorias[mercadoriaAtual + 3].Preparada && carregar == null)
                {
                    carregar = new Thread(CarregarPróximasFotos);
                    carregar.Start();
                }
            }
        }

        private void CarregarPróximasFotos()
        {
            try
            {
                for (int i = mercadoriaAtual; i < Math.Min(mercadoriaAtual + 3, fMercadorias.Length); i++)
                    fMercadorias[i].PrepararFoto();
            }
            finally
            {
                carregar = null;
            }
        }
    }
}
