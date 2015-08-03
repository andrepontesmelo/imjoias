namespace Apresentação.Pessoa.Endereço
{
    partial class EditarLocalidade
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.formatadorNome = new Apresentação.Pessoa.FormatadorNome(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dsEstado = new Apresentação.Pessoa.Endereço.DsEstado();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPaís = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.optDesconhecido = new System.Windows.Forms.RadioButton();
            this.optMunicípio = new System.Windows.Forms.RadioButton();
            this.optDistrito = new System.Windows.Forms.RadioButton();
            this.optPovoado = new System.Windows.Forms.RadioButton();
            this.optRegião = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDDD = new AMS.TextBox.IntegerTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRegião = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblObs = new System.Windows.Forms.Label();
            this.btnAdicionarPaís = new System.Windows.Forms.Button();
            this.btnAdicionarEstado = new System.Windows.Forms.Button();
            this.btnAdicionarRegião = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEstado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(172, 20);
            this.lblTítulo.Text = "Dados da localidade";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Entre com os dados da localidade.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.globo;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Localidade:";
            // 
            // txtNome
            // 
            this.formatadorNome.SetFormatarNome(this.txtNome, true);
            this.txtNome.Location = new System.Drawing.Point(98, 110);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(258, 20);
            this.txtNome.TabIndex = 4;
            this.txtNome.Validated += new System.EventHandler(this.txtNome_Validated);
            this.txtNome.Validating += new System.ComponentModel.CancelEventHandler(this.txtNome_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dsEstado, "Estado.codigo", true));
            this.cmbEstado.DataSource = this.dsEstado;
            this.cmbEstado.DisplayMember = "País.FK_País_Estado.nome";
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(98, 163);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(232, 21);
            this.cmbEstado.TabIndex = 8;
            this.cmbEstado.ValueMember = "País.FK_País_Estado.codigo";
            this.cmbEstado.Validated += new System.EventHandler(this.cmbEstado_Validated);
            // 
            // dsEstado
            // 
            this.dsEstado.DataSetName = "Estado";
            this.dsEstado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "País:";
            // 
            // cmbPaís
            // 
            this.cmbPaís.DataSource = this.dsEstado;
            this.cmbPaís.DisplayMember = "País.nome";
            this.cmbPaís.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaís.FormattingEnabled = true;
            this.cmbPaís.Location = new System.Drawing.Point(98, 136);
            this.cmbPaís.Name = "cmbPaís";
            this.cmbPaís.Size = new System.Drawing.Size(232, 21);
            this.cmbPaís.TabIndex = 6;
            this.cmbPaís.ValueMember = "País.codigo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(33, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 74);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de localidade";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.optDesconhecido);
            this.flowLayoutPanel1.Controls.Add(this.optMunicípio);
            this.flowLayoutPanel1.Controls.Add(this.optDistrito);
            this.flowLayoutPanel1.Controls.Add(this.optPovoado);
            this.flowLayoutPanel1.Controls.Add(this.optRegião);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(312, 46);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // optDesconhecido
            // 
            this.optDesconhecido.AutoSize = true;
            this.optDesconhecido.Checked = true;
            this.optDesconhecido.Location = new System.Drawing.Point(3, 3);
            this.optDesconhecido.Name = "optDesconhecido";
            this.optDesconhecido.Size = new System.Drawing.Size(103, 17);
            this.optDesconhecido.TabIndex = 0;
            this.optDesconhecido.TabStop = true;
            this.optDesconhecido.Text = "Não classificado";
            this.optDesconhecido.UseVisualStyleBackColor = true;
            this.optDesconhecido.CheckedChanged += new System.EventHandler(this.optDesconhecido_CheckedChanged);
            // 
            // optMunicípio
            // 
            this.optMunicípio.AutoSize = true;
            this.optMunicípio.Location = new System.Drawing.Point(112, 3);
            this.optMunicípio.Name = "optMunicípio";
            this.optMunicípio.Size = new System.Drawing.Size(72, 17);
            this.optMunicípio.TabIndex = 1;
            this.optMunicípio.Text = "Município";
            this.optMunicípio.UseVisualStyleBackColor = true;
            this.optMunicípio.CheckedChanged += new System.EventHandler(this.optMunicípio_CheckedChanged);
            // 
            // optDistrito
            // 
            this.optDistrito.AutoSize = true;
            this.optDistrito.Location = new System.Drawing.Point(190, 3);
            this.optDistrito.Name = "optDistrito";
            this.optDistrito.Size = new System.Drawing.Size(57, 17);
            this.optDistrito.TabIndex = 2;
            this.optDistrito.TabStop = true;
            this.optDistrito.Text = "Distrito";
            this.optDistrito.UseVisualStyleBackColor = true;
            this.optDistrito.CheckedChanged += new System.EventHandler(this.optDistrito_CheckedChanged);
            // 
            // optPovoado
            // 
            this.optPovoado.AutoSize = true;
            this.optPovoado.Location = new System.Drawing.Point(3, 26);
            this.optPovoado.Name = "optPovoado";
            this.optPovoado.Size = new System.Drawing.Size(68, 17);
            this.optPovoado.TabIndex = 3;
            this.optPovoado.TabStop = true;
            this.optPovoado.Text = "Povoado";
            this.optPovoado.UseVisualStyleBackColor = true;
            this.optPovoado.CheckedChanged += new System.EventHandler(this.optPovoado_CheckedChanged);
            // 
            // optRegião
            // 
            this.optRegião.AutoSize = true;
            this.optRegião.Location = new System.Drawing.Point(77, 26);
            this.optRegião.Name = "optRegião";
            this.optRegião.Size = new System.Drawing.Size(127, 17);
            this.optRegião.TabIndex = 4;
            this.optRegião.TabStop = true;
            this.optRegião.Text = "Região Administrativa";
            this.optRegião.UseVisualStyleBackColor = true;
            this.optRegião.CheckedChanged += new System.EventHandler(this.optRegião_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "DDD:";
            // 
            // txtDDD
            // 
            this.txtDDD.AllowNegative = true;
            this.txtDDD.DigitsInGroup = 0;
            this.txtDDD.Flags = 0;
            this.txtDDD.Location = new System.Drawing.Point(98, 190);
            this.txtDDD.MaxDecimalPlaces = 0;
            this.txtDDD.MaxWholeDigits = 9;
            this.txtDDD.Name = "txtDDD";
            this.txtDDD.Prefix = "";
            this.txtDDD.RangeMax = 1.7976931348623157E+308;
            this.txtDDD.RangeMin = -1.7976931348623157E+308;
            this.txtDDD.Size = new System.Drawing.Size(100, 20);
            this.txtDDD.TabIndex = 11;
            this.txtDDD.Validated += new System.EventHandler(this.txtDDD_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Região*:";
            // 
            // cmbRegião
            // 
            this.cmbRegião.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegião.FormattingEnabled = true;
            this.cmbRegião.Location = new System.Drawing.Point(98, 216);
            this.cmbRegião.Name = "cmbRegião";
            this.cmbRegião.Size = new System.Drawing.Size(232, 21);
            this.cmbRegião.TabIndex = 13;
            this.cmbRegião.Validated += new System.EventHandler(this.cmbRegião_Validated);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(224, 327);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 327);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblObs
            // 
            this.lblObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObs.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblObs.Location = new System.Drawing.Point(2, 320);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(216, 43);
            this.lblObs.TabIndex = 16;
            this.lblObs.Text = "* A região não está vinculada a nenhum cliente, mas sim à localidade a ser cadast" +
                "rada. Não confunda com a região do cliente!";
            // 
            // btnAdicionarPaís
            // 
            this.btnAdicionarPaís.Location = new System.Drawing.Point(336, 136);
            this.btnAdicionarPaís.Name = "btnAdicionarPaís";
            this.btnAdicionarPaís.Size = new System.Drawing.Size(20, 21);
            this.btnAdicionarPaís.TabIndex = 17;
            this.btnAdicionarPaís.Text = "+";
            this.btnAdicionarPaís.UseVisualStyleBackColor = true;
            this.btnAdicionarPaís.Click += new System.EventHandler(this.btnAdicionarPaís_Click);
            // 
            // btnAdicionarEstado
            // 
            this.btnAdicionarEstado.Location = new System.Drawing.Point(336, 163);
            this.btnAdicionarEstado.Name = "btnAdicionarEstado";
            this.btnAdicionarEstado.Size = new System.Drawing.Size(20, 21);
            this.btnAdicionarEstado.TabIndex = 18;
            this.btnAdicionarEstado.Text = "+";
            this.btnAdicionarEstado.UseVisualStyleBackColor = true;
            this.btnAdicionarEstado.Click += new System.EventHandler(this.btnAdicionarEstado_Click);
            // 
            // btnAdicionarRegião
            // 
            this.btnAdicionarRegião.Location = new System.Drawing.Point(336, 215);
            this.btnAdicionarRegião.Name = "btnAdicionarRegião";
            this.btnAdicionarRegião.Size = new System.Drawing.Size(20, 21);
            this.btnAdicionarRegião.TabIndex = 19;
            this.btnAdicionarRegião.Text = "+";
            this.btnAdicionarRegião.UseVisualStyleBackColor = true;
            this.btnAdicionarRegião.Click += new System.EventHandler(this.btnAdicionarRegião_Click);
            // 
            // EditarLocalidade
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 362);
            this.Controls.Add(this.btnAdicionarRegião);
            this.Controls.Add(this.btnAdicionarEstado);
            this.Controls.Add(this.btnAdicionarPaís);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbRegião);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDDD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPaís);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Name = "EditarLocalidade";
            this.Text = "Editar localidade";
            this.Shown += new System.EventHandler(this.EditarLocalidade_Shown);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbPaís, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDDD, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbRegião, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblObs, 0);
            this.Controls.SetChildIndex(this.btnAdicionarPaís, 0);
            this.Controls.SetChildIndex(this.btnAdicionarEstado, 0);
            this.Controls.SetChildIndex(this.btnAdicionarRegião, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEstado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private FormatadorNome formatadorNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEstado;
        private DsEstado dsEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPaís;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton optDesconhecido;
        private System.Windows.Forms.RadioButton optMunicípio;
        private System.Windows.Forms.RadioButton optDistrito;
        private System.Windows.Forms.RadioButton optPovoado;
        private System.Windows.Forms.RadioButton optRegião;
        private System.Windows.Forms.Label label4;
        private AMS.TextBox.IntegerTextBox txtDDD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRegião;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.Button btnAdicionarPaís;
        private System.Windows.Forms.Button btnAdicionarEstado;
        private System.Windows.Forms.Button btnAdicionarRegião;
    }
}
