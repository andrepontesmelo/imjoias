using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
//using DirectX.Capture;
using System.Drawing.Imaging;

namespace Apresentação.Álbum.Edição.Fotos
{
    /// <summary>
    /// Base para remoção de fundo.
    /// </summary>
    public partial class BaseRemoverFundo : BaseInferior
    {
        private Fotógrafo fotógrafo;
        private TratamentoRemoverFundoComparando tratamento = new TratamentoRemoverFundoComparando();
        private Bitmap imagemTratada;
        private SinalizaçãoCarga sinalização = null;
        private Bitmap últimaImagemSolicitadaáRemoção = null;

        public event EventHandler AoProsseguirRemoçãoFundo;

        public Bitmap Fundo
        {
            get
            {
                return tratamento.Fundo;
            }

            set
            {
                tratamento.Fundo = value;
            }
        }

        public Bitmap ImagemTratada
        {
            get { return imagemTratada; }
        }

        public BaseRemoverFundo(Fotógrafo fotógrafo)
        {
            InitializeComponent();

            this.fotógrafo = fotógrafo;

            EsconderQuadroNavegação();

            //tratamento.AoTerminarTratamento += new TratamentoBase.TratamentoCallback(AoTerminarTratamento);

            // trackBar.Value = (int)(tratamento.Tolerância * 100);
            trackBar.Value = (int)(tratamento.Tolerância);
        }


        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (últimaImagemSolicitadaáRemoção != null)
            {
                tratamento.Tolerância = trackBar.Value;
                RemoverFundo(últimaImagemSolicitadaáRemoção);
            }
        }

        /// <summary>
        /// Inicia o tratamento de remoção de fundo
        /// e sinaliza operação.
        /// </summary>
        public void RemoverFundo(Bitmap imagem)
        {
            if (tratamento.Fundo == null)
                ObterFundo();

            lock (this)
            {
                if (tratamento.Fundo.Height != imagem.Height
                    || tratamento.Fundo.Width != imagem.Width)
                {
                    tratamento.Fundo = Entidades.Álbum.Foto.Redesenhar(tratamento.Fundo, imagem.Width, imagem.Height);
                }
                    
                últimaImagemSolicitadaáRemoção = imagem;

                if (sinalização == null)
                {
                    sinalização = SinalizaçãoCarga.Sinalizar(
                        picFoto,
                        "Removendo fundo",
                        "Aguarde enquanto o sistema remove o fundo.");

                    btnProsseguir.Enabled = false;
                }

                imagemTratada = tratamento.RealizarTrabalho((Bitmap) (imagem.Clone()));

                {
                    float[][] matrixItems = { 
                   new float[] {1, 0, 0, 0, 0},
                   new float[] {0, 1, 0, 0, 0},
                   new float[] {0, 0, 1, 0, 0},
                   new float[] {0, 0, 0, 0.5f, 0}, 
                   new float[] {0, 0, 0, 0, 1}};
                    ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                    using (ImageAttributes imageAtt = new ImageAttributes())
                    {
                        imageAtt.SetColorMatrix(
                           colorMatrix,
                           ColorMatrixFlag.Default,
                           ColorAdjustType.Bitmap);

                        picFoto.Image = new Bitmap(imagem.Width, imagem.Height);

                        using (Graphics g = Graphics.FromImage(picFoto.Image))
                        {
                            g.DrawImage(
                                imagem,
                                new Rectangle(0, 0, imagem.Width, imagem.Height),
                                0, 0, imagem.Width, imagem.Height,
                                GraphicsUnit.Pixel,
                                imageAtt);

                            g.DrawImageUnscaled(
                                imagemTratada,
                                0, 0);
                        }
                    }

                    SinalizaçãoCarga.Dessinalizar(sinalização);
                    sinalização = null;

                    btnProsseguir.Enabled = true;
                }
            }
        }

        private void ObterFundo()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Title = "Abrir imagem só com o fundo para comparação";
            abrir.ShowDialog(this);

            tratamento.Fundo = (Bitmap) Bitmap.FromFile(abrir.FileName);
        }

        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            //SubstituirBase(fotógrafo);

            //fotógrafo.AoTratarFoto(TratamentoBase.Cortar(imagemTratada));
            //fotógrafo.AoTratarFoto(imagemTratada);
            SubstituirBaseParaAnterior();

            if (AoProsseguirRemoçãoFundo != null)
                AoProsseguirRemoçãoFundo(this, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SubstituirBaseParaAnterior();
        }
    }
}