using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;
using System.Collections.Generic;

namespace Apresenta��o.Usu�rio.Visitantes
{
    public class Notifica��oEntradaSa�da : Apresenta��o.Formul�rios.Notifica��o
    {
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox pic�cone;
        private System.Windows.Forms.Label lblAtendimento;
        private System.Windows.Forms.Label lblNome;
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Constr�i notifica��o de entrada e sa�da.
        /// </summary>
        /// <param name="visitante">Visitante</param>
        public Notifica��oEntradaSa�da(Visita visitante)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            PrepararNotifica��o(visitante);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Notifica��oEntradaSa�da));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pic�cone = new System.Windows.Forms.PictureBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblAtendimento = new System.Windows.Forms.Label();
            this.quadro.SuspendLayout();
            // 
            // quadro
            // 
            this.quadro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quadro.BackgroundImage")));
            this.quadro.Controls.Add(this.lblNome);
            this.quadro.Controls.Add(this.pic�cone);
            this.quadro.Controls.Add(this.lblAtendimento);
            this.quadro.Name = "quadro";
            this.quadro.Size = new System.Drawing.Size(256, 96);
            this.quadro.Controls.SetChildIndex(this.lblAtendimento, 0);
            this.quadro.Controls.SetChildIndex(this.pic�cone, 0);
            this.quadro.Controls.SetChildIndex(this.lblNome, 0);
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pic�cone
            // 
            this.pic�cone.BackColor = System.Drawing.Color.Transparent;
            this.pic�cone.Location = new System.Drawing.Point(10, 32);
            this.pic�cone.Name = "pic�cone";
            this.pic�cone.Size = new System.Drawing.Size(16, 16);
            this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic�cone.TabIndex = 2;
            this.pic�cone.TabStop = false;
            // 
            // lblNome
            // 
            this.lblNome.BackColor = System.Drawing.Color.Transparent;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(32, 32);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(216, 24);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Fulano de tal";
            // 
            // lblAtendimento
            // 
            this.lblAtendimento.BackColor = System.Drawing.Color.Transparent;
            this.lblAtendimento.Location = new System.Drawing.Point(32, 56);
            this.lblAtendimento.Name = "lblAtendimento";
            this.lblAtendimento.Size = new System.Drawing.Size(216, 40);
            this.lblAtendimento.TabIndex = 4;
            this.lblAtendimento.Text = "Atendimento";
            // 
            // Notifica��oEntradaSa�da
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 96);
            this.ImagemFundo = ((System.Drawing.Image)(resources.GetObject("$this.ImagemFundo")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Notifica��oEntradaSa�da";
            this.quadro.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Prepara notifica��o de entrada e sa�da
        /// </summary>
        /// <param name="visitante">Visitante que entrou ou saiu</param>
        /// <param name="a��o">A��o do visitante</param>
        private void PrepararNotifica��o(Visita visita)
        {
            lblNome.Text = visita.ExtrairNomes();

            if (visita.Sa�da.HasValue)
            {
                if (visita.Atendente == null)
                    NotificarDesist�ncia(visita);
                else
                    NotificarSa�da(visita);
            }
            else
                NotificarEntrada(visita);
        }

        /// <summary>
        /// Notifica entrada de visitante
        /// </summary>
        private void NotificarEntrada(Visita visita)
        {
            pic�cone.Image = imageList.Images[0];

            T�tulo = "Visitante adentrou na firma";

            if (visita.Atendente == null)
            {
                if (visita.Setor != null)
                    lblAtendimento.Text = "Aguardando atendimento no " + visita.Setor.Nome;
                else
                    lblAtendimento.Text = "";
            }
            else
            {
                lblAtendimento.Text = "Atendimento: " + visita.Atendente.Nome;
            }
        }

        /// <summary>
        /// Notifica sa�da de visitante
        /// </summary>
        /// <param name="visitante">Visitante que entrou</param>
        private void NotificarSa�da(Visita visita)
        {
            TimeSpan tempo;

            pic�cone.Image = imageList.Images[1];
            T�tulo = "Visitante saiu da firma";

            tempo = visita.Sa�da.Value - visita.Entrada;

            if (visita.Atendente != null)
                lblAtendimento.Text = "Atendimento: " + visita.Atendente.Nome;
            else
                lblAtendimento.Text = "";

            lblAtendimento.Text += "\nTempo de visita: " + Math.Round(tempo.TotalMinutes) + " minutos";
        }

        /// <summary>
        /// Notifica desist�ncia de visitante
        /// </summary>
        /// <param name="visitante">Visitante que desistiu</param>
        private void NotificarDesist�ncia(Visita visita)
        {
            TimeSpan tempo;

            pic�cone.Image = imageList.Images[4];
            T�tulo = "Visitante desistiu de ser atendido!";
            quadro.BackColor = Color.Red;

            tempo = visita.Sa�da.Value - visita.Entrada;

            lblAtendimento.Text = "Cliente desistiu de ser atendido!";
            lblAtendimento.ForeColor = Color.Brown;
        }
    }
}

