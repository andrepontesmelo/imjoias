namespace Apresentação.Pessoa.Horário
{
    partial class TabelaHorário
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabela = new System.Windows.Forms.TableLayoutPanel();
            this.domingo = new Apresentação.Pessoa.Horário.Dia();
            this.segunda = new Apresentação.Pessoa.Horário.Dia();
            this.terça = new Apresentação.Pessoa.Horário.Dia();
            this.quarta = new Apresentação.Pessoa.Horário.Dia();
            this.quinta = new Apresentação.Pessoa.Horário.Dia();
            this.sexta = new Apresentação.Pessoa.Horário.Dia();
            this.sábado = new Apresentação.Pessoa.Horário.Dia();
            this.marcaçãoHorário1 = new Apresentação.Pessoa.Horário.MarcaçãoHorário();
            this.tabela.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabela
            // 
            this.tabela.ColumnCount = 8;
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tabela.Controls.Add(this.domingo, 1, 0);
            this.tabela.Controls.Add(this.segunda, 2, 0);
            this.tabela.Controls.Add(this.terça, 3, 0);
            this.tabela.Controls.Add(this.quarta, 4, 0);
            this.tabela.Controls.Add(this.quinta, 5, 0);
            this.tabela.Controls.Add(this.sexta, 6, 0);
            this.tabela.Controls.Add(this.sábado, 7, 0);
            this.tabela.Controls.Add(this.marcaçãoHorário1, 0, 0);
            this.tabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabela.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tabela.Location = new System.Drawing.Point(0, 0);
            this.tabela.Name = "tabela";
            this.tabela.RowCount = 1;
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabela.Size = new System.Drawing.Size(511, 277);
            this.tabela.TabIndex = 0;
            // 
            // domingo
            // 
            this.domingo.DiaSemana = System.DayOfWeek.Sunday;
            this.domingo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.domingo.Location = new System.Drawing.Point(31, 1);
            this.domingo.Margin = new System.Windows.Forms.Padding(1);
            this.domingo.Name = "domingo";
            this.domingo.Size = new System.Drawing.Size(66, 275);
            this.domingo.TabIndex = 0;
            // 
            // segunda
            // 
            this.segunda.DiaSemana = System.DayOfWeek.Monday;
            this.segunda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segunda.Location = new System.Drawing.Point(99, 1);
            this.segunda.Margin = new System.Windows.Forms.Padding(1);
            this.segunda.Name = "segunda";
            this.segunda.Size = new System.Drawing.Size(66, 275);
            this.segunda.TabIndex = 1;
            // 
            // terça
            // 
            this.terça.DiaSemana = System.DayOfWeek.Tuesday;
            this.terça.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terça.Location = new System.Drawing.Point(167, 1);
            this.terça.Margin = new System.Windows.Forms.Padding(1);
            this.terça.Name = "terça";
            this.terça.Size = new System.Drawing.Size(66, 275);
            this.terça.TabIndex = 2;
            // 
            // quarta
            // 
            this.quarta.DiaSemana = System.DayOfWeek.Wednesday;
            this.quarta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quarta.Location = new System.Drawing.Point(235, 1);
            this.quarta.Margin = new System.Windows.Forms.Padding(1);
            this.quarta.Name = "quarta";
            this.quarta.Size = new System.Drawing.Size(66, 275);
            this.quarta.TabIndex = 3;
            // 
            // quinta
            // 
            this.quinta.DiaSemana = System.DayOfWeek.Thursday;
            this.quinta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quinta.Location = new System.Drawing.Point(303, 1);
            this.quinta.Margin = new System.Windows.Forms.Padding(1);
            this.quinta.Name = "quinta";
            this.quinta.Size = new System.Drawing.Size(66, 275);
            this.quinta.TabIndex = 4;
            // 
            // sexta
            // 
            this.sexta.DiaSemana = System.DayOfWeek.Friday;
            this.sexta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sexta.Location = new System.Drawing.Point(371, 1);
            this.sexta.Margin = new System.Windows.Forms.Padding(1);
            this.sexta.Name = "sexta";
            this.sexta.Size = new System.Drawing.Size(66, 275);
            this.sexta.TabIndex = 5;
            // 
            // sábado
            // 
            this.sábado.DiaSemana = System.DayOfWeek.Saturday;
            this.sábado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sábado.Location = new System.Drawing.Point(439, 1);
            this.sábado.Margin = new System.Windows.Forms.Padding(1);
            this.sábado.Name = "sábado";
            this.sábado.Size = new System.Drawing.Size(71, 275);
            this.sábado.TabIndex = 6;
            // 
            // marcaçãoHorário1
            // 
            this.marcaçãoHorário1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marcaçãoHorário1.HoraFinal = ((ushort)(19));
            this.marcaçãoHorário1.HoraInicial = ((ushort)(7));
            this.marcaçãoHorário1.Location = new System.Drawing.Point(1, 1);
            this.marcaçãoHorário1.Margin = new System.Windows.Forms.Padding(1);
            this.marcaçãoHorário1.Name = "marcaçãoHorário1";
            this.marcaçãoHorário1.Size = new System.Drawing.Size(28, 275);
            this.marcaçãoHorário1.TabIndex = 7;
            // 
            // TabelaHorário
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabela);
            this.Name = "TabelaHorário";
            this.Size = new System.Drawing.Size(511, 277);
            this.tabela.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabela;
        private Dia domingo;
        private Dia segunda;
        private Dia terça;
        private Dia quarta;
        private Dia quinta;
        private Dia sexta;
        private Dia sábado;
        private MarcaçãoHorário marcaçãoHorário1;

    }
}
