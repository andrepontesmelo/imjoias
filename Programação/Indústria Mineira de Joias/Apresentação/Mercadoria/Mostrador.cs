using Entidades.Álbum;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
    public partial class Mostrador : PictureBox
    {
        public Mostrador()
        {
            InitializeComponent();

            this.SizeMode = PictureBoxSizeMode.Zoom;
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MostradorAnimação
            // 
            this.Image = global::Apresentação.Resource.logo;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public void Mostrar(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            MostrarImagem(mercadoria?.Foto);
        }

        public void MostrarImagem(Image foto)
        {
            if (foto != null)
            {
                this.Image = foto;
                BackColor = new Bitmap(Image).GetPixel(0, 0);
            }
            else 
            {
                this.Image = Resource.logo;
            }
        }
    }
}
