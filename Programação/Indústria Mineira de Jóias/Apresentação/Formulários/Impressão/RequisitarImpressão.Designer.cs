namespace Apresentação.Formulários.Impressão
{
    partial class RequisitarImpressão
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Máquinas disponíveis", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Máquinas em uso leve", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Máquinas em uso pesado", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequisitarImpressão));
            this.label1 = new System.Windows.Forms.Label();
            this.lstImpressoras = new System.Windows.Forms.ListView();
            this.colImpressora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMáquina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tmrRecuperarCandidatos = new System.Windows.Forms.Timer(this.components);
            this.lblImprimirPaginasDe = new System.Windows.Forms.Label();
            this.txtInício = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.Label();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.painelMaisOpções = new System.Windows.Forms.Panel();
            this.btnMaisCópias = new System.Windows.Forms.Button();
            this.txtNúmeroCópias = new System.Windows.Forms.TextBox();
            this.lblCópias = new System.Windows.Forms.Label();
            this.lnkMaisOpções = new System.Windows.Forms.LinkLabel();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.imageListBotão = new System.Windows.Forms.ImageList(this.components);
            this.lnkImprimirRemotamente = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.painelMaisOpções.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(178, 20);
            this.lblTítulo.Text = "Requisitar impressão";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Escolha como você deseja imprimir o(s) documento(s).";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.impressora__altura_58_;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Impressoras disponíveis:";
            // 
            // lstImpressoras
            // 
            this.lstImpressoras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImpressora,
            this.colMáquina});
            this.lstImpressoras.FullRowSelect = true;
            listViewGroup1.Header = "Máquinas disponíveis";
            listViewGroup1.Name = "grpDisponível";
            listViewGroup2.Header = "Máquinas em uso leve";
            listViewGroup2.Name = "grpLeve";
            listViewGroup3.Header = "Máquinas em uso pesado";
            listViewGroup3.Name = "grpPesado";
            this.lstImpressoras.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lstImpressoras.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstImpressoras.LargeImageList = this.imageList;
            this.lstImpressoras.Location = new System.Drawing.Point(15, 119);
            this.lstImpressoras.Name = "lstImpressoras";
            this.lstImpressoras.Size = new System.Drawing.Size(365, 156);
            this.lstImpressoras.SmallImageList = this.imageList;
            this.lstImpressoras.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstImpressoras.TabIndex = 4;
            this.lstImpressoras.UseCompatibleStateImageBehavior = false;
            this.lstImpressoras.View = System.Windows.Forms.View.Details;
            this.lstImpressoras.SelectedIndexChanged += new System.EventHandler(this.lstImpressoras_SelectedIndexChanged);
            this.lstImpressoras.Move += new System.EventHandler(this.lstImpressoras_Move);
            // 
            // colImpressora
            // 
            this.colImpressora.Text = "Impressora";
            this.colImpressora.Width = 263;
            // 
            // colMáquina
            // 
            this.colMáquina.Text = "Máquina";
            this.colMáquina.Width = 79;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Ruim");
            this.imageList.Images.SetKeyName(1, "Bom");
            this.imageList.Images.SetKeyName(2, "Perfeito");
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(224, 329);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 329);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tmrRecuperarCandidatos
            // 
            this.tmrRecuperarCandidatos.Enabled = true;
            this.tmrRecuperarCandidatos.Interval = 1000;
            this.tmrRecuperarCandidatos.Tick += new System.EventHandler(this.tmrRecuperarCandidatos_Tick);
            // 
            // lblImprimirPaginasDe
            // 
            this.lblImprimirPaginasDe.AutoSize = true;
            this.lblImprimirPaginasDe.Enabled = false;
            this.lblImprimirPaginasDe.Location = new System.Drawing.Point(2, 3);
            this.lblImprimirPaginasDe.Name = "lblImprimirPaginasDe";
            this.lblImprimirPaginasDe.Size = new System.Drawing.Size(97, 13);
            this.lblImprimirPaginasDe.TabIndex = 7;
            this.lblImprimirPaginasDe.Text = "Imprimir páginas de";
            // 
            // txtInício
            // 
            this.txtInício.Enabled = false;
            this.txtInício.Location = new System.Drawing.Point(105, 0);
            this.txtInício.Name = "txtInício";
            this.txtInício.Size = new System.Drawing.Size(33, 20);
            this.txtInício.TabIndex = 8;
            this.txtInício.Text = "1";
            this.txtInício.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtA
            // 
            this.txtA.AutoSize = true;
            this.txtA.Enabled = false;
            this.txtA.Location = new System.Drawing.Point(144, 3);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(13, 13);
            this.txtA.TabIndex = 9;
            this.txtA.Text = "a";
            // 
            // txtFinal
            // 
            this.txtFinal.Enabled = false;
            this.txtFinal.Location = new System.Drawing.Point(163, 0);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(33, 20);
            this.txtFinal.TabIndex = 10;
            this.txtFinal.Text = "final";
            this.txtFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // painelMaisOpções
            // 
            this.painelMaisOpções.Controls.Add(this.btnMaisCópias);
            this.painelMaisOpções.Controls.Add(this.txtNúmeroCópias);
            this.painelMaisOpções.Controls.Add(this.lblCópias);
            this.painelMaisOpções.Controls.Add(this.txtFinal);
            this.painelMaisOpções.Controls.Add(this.lblImprimirPaginasDe);
            this.painelMaisOpções.Controls.Add(this.txtA);
            this.painelMaisOpções.Controls.Add(this.txtInício);
            this.painelMaisOpções.Location = new System.Drawing.Point(12, 281);
            this.painelMaisOpções.Name = "painelMaisOpções";
            this.painelMaisOpções.Size = new System.Drawing.Size(368, 45);
            this.painelMaisOpções.TabIndex = 11;
            this.painelMaisOpções.Visible = false;
            // 
            // btnMaisCópias
            // 
            this.btnMaisCópias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaisCópias.Location = new System.Drawing.Point(144, 22);
            this.btnMaisCópias.Name = "btnMaisCópias";
            this.btnMaisCópias.Size = new System.Drawing.Size(23, 20);
            this.btnMaisCópias.TabIndex = 13;
            this.btnMaisCópias.Text = "+";
            this.btnMaisCópias.UseVisualStyleBackColor = true;
            this.btnMaisCópias.Click += new System.EventHandler(this.btnMaisCópias_Click);
            // 
            // txtNúmeroCópias
            // 
            this.txtNúmeroCópias.Location = new System.Drawing.Point(105, 20);
            this.txtNúmeroCópias.Name = "txtNúmeroCópias";
            this.txtNúmeroCópias.Size = new System.Drawing.Size(33, 20);
            this.txtNúmeroCópias.TabIndex = 12;
            this.txtNúmeroCópias.Text = "1";
            this.txtNúmeroCópias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNúmeroCópias.Validating += new System.ComponentModel.CancelEventHandler(this.txtNúmeroCópias_Validating);
            // 
            // lblCópias
            // 
            this.lblCópias.AutoSize = true;
            this.lblCópias.Location = new System.Drawing.Point(3, 23);
            this.lblCópias.Name = "lblCópias";
            this.lblCópias.Size = new System.Drawing.Size(96, 13);
            this.lblCópias.TabIndex = 11;
            this.lblCópias.Text = "Número de cópias:";
            // 
            // lnkMaisOpções
            // 
            this.lnkMaisOpções.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkMaisOpções.AutoSize = true;
            this.lnkMaisOpções.Location = new System.Drawing.Point(12, 342);
            this.lnkMaisOpções.Name = "lnkMaisOpções";
            this.lnkMaisOpções.Size = new System.Drawing.Size(76, 13);
            this.lnkMaisOpções.TabIndex = 12;
            this.lnkMaisOpções.TabStop = true;
            this.lnkMaisOpções.Text = "Mais opções...";
            this.lnkMaisOpções.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMaisOpções_LinkClicked);
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenar.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrdenar.ImageIndex = 0;
            this.btnOrdenar.ImageList = this.imageListBotão;
            this.btnOrdenar.Location = new System.Drawing.Point(356, 92);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(24, 24);
            this.btnOrdenar.TabIndex = 13;
            this.btnOrdenar.UseVisualStyleBackColor = false;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // imageListBotão
            // 
            this.imageListBotão.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBotão.ImageStream")));
            this.imageListBotão.TransparentColor = System.Drawing.Color.Silver;
            this.imageListBotão.Images.SetKeyName(0, "SORTASC.BMP");
            // 
            // lnkImprimirRemotamente
            // 
            this.lnkImprimirRemotamente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkImprimirRemotamente.AutoSize = true;
            this.lnkImprimirRemotamente.Location = new System.Drawing.Point(106, 342);
            this.lnkImprimirRemotamente.Name = "lnkImprimirRemotamente";
            this.lnkImprimirRemotamente.Size = new System.Drawing.Size(106, 13);
            this.lnkImprimirRemotamente.TabIndex = 14;
            this.lnkImprimirRemotamente.TabStop = true;
            this.lnkImprimirRemotamente.Text = "Imprimir remotamente";
            this.lnkImprimirRemotamente.Visible = false;
            this.lnkImprimirRemotamente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkImprimirRemotamente_LinkClicked);
            // 
            // RequisitarImpressão
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 364);
            this.Controls.Add(this.lnkImprimirRemotamente);
            this.Controls.Add(this.btnOrdenar);
            this.Controls.Add(this.lnkMaisOpções);
            this.Controls.Add(this.painelMaisOpções);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstImpressoras);
            this.Name = "RequisitarImpressão";
            this.Text = "Impressão";
            this.Shown += new System.EventHandler(this.RequisitarImpressão_Shown);
            this.Controls.SetChildIndex(this.lstImpressoras, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.painelMaisOpções, 0);
            this.Controls.SetChildIndex(this.lnkMaisOpções, 0);
            this.Controls.SetChildIndex(this.btnOrdenar, 0);
            this.Controls.SetChildIndex(this.lnkImprimirRemotamente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.painelMaisOpções.ResumeLayout(false);
            this.painelMaisOpções.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstImpressoras;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Timer tmrRecuperarCandidatos;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader colImpressora;
        private System.Windows.Forms.ColumnHeader colMáquina;
        private System.Windows.Forms.Label lblImprimirPaginasDe;
        private System.Windows.Forms.TextBox txtInício;
        private System.Windows.Forms.Label txtA;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Panel painelMaisOpções;
        private System.Windows.Forms.LinkLabel lnkMaisOpções;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.ImageList imageListBotão;
        private System.Windows.Forms.LinkLabel lnkImprimirRemotamente;
        private System.Windows.Forms.Button btnMaisCópias;
        private System.Windows.Forms.TextBox txtNúmeroCópias;
        private System.Windows.Forms.Label lblCópias;
    }
}