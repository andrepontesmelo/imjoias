using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;
using System.Collections.Generic;

namespace Apresentação.Usuário.Visitantes
{
    public class NotificaçãoEntradaSaída : Apresentação.Formulários.Notificação
    {
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox picÍcone;
        private System.Windows.Forms.Label lblAtendimento;
        private System.Windows.Forms.Label lblNome;
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Constrói notificação de entrada e saída.
        /// </summary>
        /// <param name="visitante">Visitante</param>
        public NotificaçãoEntradaSaída(Visita visitante)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            PrepararNotificação(visitante);
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NotificaçãoEntradaSaída));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.picÍcone = new System.Windows.Forms.PictureBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblAtendimento = new System.Windows.Forms.Label();
            this.quadro.SuspendLayout();
            // 
            // quadro
            // 
            this.quadro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quadro.BackgroundImage")));
            this.quadro.Controls.Add(this.lblNome);
            this.quadro.Controls.Add(this.picÍcone);
            this.quadro.Controls.Add(this.lblAtendimento);
            this.quadro.Name = "quadro";
            this.quadro.Size = new System.Drawing.Size(256, 96);
            this.quadro.Controls.SetChildIndex(this.lblAtendimento, 0);
            this.quadro.Controls.SetChildIndex(this.picÍcone, 0);
            this.quadro.Controls.SetChildIndex(this.lblNome, 0);
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // picÍcone
            // 
            this.picÍcone.BackColor = System.Drawing.Color.Transparent;
            this.picÍcone.Location = new System.Drawing.Point(10, 32);
            this.picÍcone.Name = "picÍcone";
            this.picÍcone.Size = new System.Drawing.Size(16, 16);
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picÍcone.TabIndex = 2;
            this.picÍcone.TabStop = false;
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
            // NotificaçãoEntradaSaída
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 96);
            this.ImagemFundo = ((System.Drawing.Image)(resources.GetObject("$this.ImagemFundo")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NotificaçãoEntradaSaída";
            this.quadro.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Prepara notificação de entrada e saída
        /// </summary>
        /// <param name="visitante">Visitante que entrou ou saiu</param>
        /// <param name="ação">Ação do visitante</param>
        private void PrepararNotificação(Visita visita)
        {
            lblNome.Text = visita.ExtrairNomes();

            if (visita.Saída.HasValue)
            {
                if (visita.Atendente == null)
                    NotificarDesistência(visita);
                else
                    NotificarSaída(visita);
            }
            else
                NotificarEntrada(visita);
        }

        /// <summary>
        /// Notifica entrada de visitante
        /// </summary>
        private void NotificarEntrada(Visita visita)
        {
            picÍcone.Image = imageList.Images[0];

            Título = "Visitante adentrou na firma";

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
        /// Notifica saída de visitante
        /// </summary>
        /// <param name="visitante">Visitante que entrou</param>
        private void NotificarSaída(Visita visita)
        {
            TimeSpan tempo;

            picÍcone.Image = imageList.Images[1];
            Título = "Visitante saiu da firma";

            tempo = visita.Saída.Value - visita.Entrada;

            if (visita.Atendente != null)
                lblAtendimento.Text = "Atendimento: " + visita.Atendente.Nome;
            else
                lblAtendimento.Text = "";

            lblAtendimento.Text += "\nTempo de visita: " + Math.Round(tempo.TotalMinutes) + " minutos";
        }

        /// <summary>
        /// Notifica desistência de visitante
        /// </summary>
        /// <param name="visitante">Visitante que desistiu</param>
        private void NotificarDesistência(Visita visita)
        {
            TimeSpan tempo;

            picÍcone.Image = imageList.Images[4];
            Título = "Visitante desistiu de ser atendido!";
            quadro.BackColor = Color.Red;

            tempo = visita.Saída.Value - visita.Entrada;

            lblAtendimento.Text = "Cliente desistiu de ser atendido!";
            lblAtendimento.ForeColor = Color.Brown;
        }
    }
}

