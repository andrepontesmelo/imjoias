using Apresentação.Clientes.Importação;
namespace Apresentação.Atendimento.Clientes.Importação
{
    partial class EscolherClienteAntigo
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codNomeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.codNome = new CodNome();
            this.codNomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCódigo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codNomeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codNome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codNomeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(200, 20);
            this.lblTítulo.Text = "Importação de cadastro";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(419, 48);
            this.lblDescrição.Text = "Escolha o cadastro do sistema antigo a ser importado.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.teia1;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.nomeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.codNomeBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 93);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(481, 159);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn.Width = 300;
            // 
            // codNomeBindingSource1
            // 
            this.codNomeBindingSource1.DataMember = "CodNome";
            this.codNomeBindingSource1.DataSource = this.codNome;
            // 
            // codNome
            // 
            this.codNome.DataSetName = "CodNome";
            this.codNome.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // codNomeBindingSource
            // 
            this.codNomeBindingSource.DataSource = this.codNome;
            this.codNomeBindingSource.Position = 0;
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImportar.Location = new System.Drawing.Point(339, 258);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 4;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(420, 258);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código:";
            // 
            // txtCódigo
            // 
            this.txtCódigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCódigo.Location = new System.Drawing.Point(69, 261);
            this.txtCódigo.Name = "txtCódigo";
            this.txtCódigo.Size = new System.Drawing.Size(100, 20);
            this.txtCódigo.TabIndex = 8;
            // 
            // EscolherClienteAntigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 291);
            this.Controls.Add(this.txtCódigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "EscolherClienteAntigo";
            this.Text = "EscolherClienteAntigo";
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCódigo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codNomeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codNome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codNomeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
//        private System.Windows.Forms.DataGridViewTextBoxColumn códigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource codNomeBindingSource1;
        private CodNome codNome;
        private System.Windows.Forms.BindingSource codNomeBindingSource;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCódigo;

    }
}