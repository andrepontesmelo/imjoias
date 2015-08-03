using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
	/// <summary>
	/// Summary description for Funcionário.
	/// </summary>
	public class DadosFuncionário : System.Windows.Forms.UserControl
	{
		private Entidades.Pessoa.Funcionário funcionário;
        private Dictionary<string, Entidades.Setor> hashNomeSetor = new Dictionary<string, Entidades.Setor>(StringComparer.Ordinal);

		// Designer
		private System.Windows.Forms.Label lblFicha;
		private System.Windows.Forms.Label lblAdmissão;
		private AMS.TextBox.DateTextBox txtDataAdmissão;
		private System.Windows.Forms.Label lblSalário;
		private AMS.TextBox.CurrencyTextBox txtSalário;
		private AMS.TextBox.IntegerTextBox txtFicha;
		private System.Windows.Forms.GroupBox grpDadosEmpresa;
		private System.Windows.Forms.GroupBox grpLocalTrabalho;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox txtSetor;
		private AMS.TextBox.IntegerTextBox txtRamal;
		private System.Windows.Forms.GroupBox grpInformações;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCarteiraProfissional;
		private System.Windows.Forms.Label lblSérie;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblReservista;
		private System.Windows.Forms.TextBox txtReservista;
		private System.Windows.Forms.Label lblTítulo;
		private System.Windows.Forms.TextBox txtCarteiraProfissionalSérie;
		private System.Windows.Forms.TextBox txtTítuloEleitor;
		private System.Windows.Forms.TextBox txtCBO;
		private System.Windows.Forms.TextBox txtPIS;
		private System.Windows.Forms.Label label7;
		private AMS.TextBox.DateTextBox txtDataDemissão;
		private System.Windows.Forms.TextBox txtReservistaSérie;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtReservistaCategoria;
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblCargo;
		private System.Windows.Forms.ComboBox txtCargo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox txtEmpresa;
		private System.Windows.Forms.Label lblBeneficiário;
		private System.Windows.Forms.TextBox txtBeneficiário;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox txtParentesco;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DadosFuncionário()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.grpDadosEmpresa = new System.Windows.Forms.GroupBox();
            this.txtEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.ComboBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtDataDemissão = new AMS.TextBox.DateTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFicha = new AMS.TextBox.IntegerTextBox();
            this.txtSalário = new AMS.TextBox.CurrencyTextBox();
            this.lblSalário = new System.Windows.Forms.Label();
            this.txtDataAdmissão = new AMS.TextBox.DateTextBox();
            this.lblAdmissão = new System.Windows.Forms.Label();
            this.lblFicha = new System.Windows.Forms.Label();
            this.grpLocalTrabalho = new System.Windows.Forms.GroupBox();
            this.txtRamal = new AMS.TextBox.IntegerTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSetor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpInformações = new System.Windows.Forms.GroupBox();
            this.txtParentesco = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBeneficiário = new System.Windows.Forms.TextBox();
            this.lblBeneficiário = new System.Windows.Forms.Label();
            this.txtReservistaCategoria = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReservistaSérie = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTítuloEleitor = new System.Windows.Forms.TextBox();
            this.lblTítulo = new System.Windows.Forms.Label();
            this.txtReservista = new System.Windows.Forms.TextBox();
            this.lblReservista = new System.Windows.Forms.Label();
            this.txtCBO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPIS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarteiraProfissionalSérie = new System.Windows.Forms.TextBox();
            this.lblSérie = new System.Windows.Forms.Label();
            this.txtCarteiraProfissional = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpDadosEmpresa.SuspendLayout();
            this.grpLocalTrabalho.SuspendLayout();
            this.grpInformações.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDadosEmpresa
            // 
            this.grpDadosEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDadosEmpresa.Controls.Add(this.txtEmpresa);
            this.grpDadosEmpresa.Controls.Add(this.label1);
            this.grpDadosEmpresa.Controls.Add(this.txtCargo);
            this.grpDadosEmpresa.Controls.Add(this.lblCargo);
            this.grpDadosEmpresa.Controls.Add(this.txtDataDemissão);
            this.grpDadosEmpresa.Controls.Add(this.label7);
            this.grpDadosEmpresa.Controls.Add(this.txtFicha);
            this.grpDadosEmpresa.Controls.Add(this.txtSalário);
            this.grpDadosEmpresa.Controls.Add(this.lblSalário);
            this.grpDadosEmpresa.Controls.Add(this.txtDataAdmissão);
            this.grpDadosEmpresa.Controls.Add(this.lblAdmissão);
            this.grpDadosEmpresa.Controls.Add(this.lblFicha);
            this.grpDadosEmpresa.Location = new System.Drawing.Point(0, 0);
            this.grpDadosEmpresa.Name = "grpDadosEmpresa";
            this.grpDadosEmpresa.Size = new System.Drawing.Size(392, 112);
            this.grpDadosEmpresa.TabIndex = 0;
            this.grpDadosEmpresa.TabStop = false;
            this.grpDadosEmpresa.Text = "Dados da empresa";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtEmpresa.Location = new System.Drawing.Point(264, 16);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(112, 21);
            this.txtEmpresa.Sorted = true;
            this.txtEmpresa.TabIndex = 12;
            this.txtEmpresa.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this.txtEmpresa.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Empresa:";
            // 
            // txtCargo
            // 
            this.txtCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCargo.Location = new System.Drawing.Point(264, 80);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(112, 21);
            this.txtCargo.TabIndex = 10;
            this.txtCargo.Leave += new System.EventHandler(this.txtCargo_Leave);
            // 
            // lblCargo
            // 
            this.lblCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(200, 82);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(38, 13);
            this.lblCargo.TabIndex = 9;
            this.lblCargo.Text = "Cargo:";
            // 
            // txtDataDemissão
            // 
            this.txtDataDemissão.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataDemissão.Flags = 65536;
            this.txtDataDemissão.Location = new System.Drawing.Point(264, 48);
            this.txtDataDemissão.Name = "txtDataDemissão";
            this.txtDataDemissão.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtDataDemissão.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDataDemissão.Size = new System.Drawing.Size(112, 20);
            this.txtDataDemissão.TabIndex = 6;
            this.txtDataDemissão.Leave += new System.EventHandler(this.txtDataDemissão_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(200, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 32);
            this.label7.TabIndex = 5;
            this.label7.Text = "Data de &demissão:";
            // 
            // txtFicha
            // 
            this.txtFicha.AllowNegative = false;
            this.txtFicha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFicha.DigitsInGroup = 0;
            this.txtFicha.Flags = 65536;
            this.txtFicha.Location = new System.Drawing.Point(72, 16);
            this.txtFicha.MaxDecimalPlaces = 0;
            this.txtFicha.MaxWholeDigits = 9;
            this.txtFicha.Name = "txtFicha";
            this.txtFicha.Prefix = "";
            this.txtFicha.RangeMax = 1.7976931348623157E+308;
            this.txtFicha.RangeMin = -1.7976931348623157E+308;
            this.txtFicha.Size = new System.Drawing.Size(120, 20);
            this.txtFicha.TabIndex = 2;
            this.txtFicha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFicha.Leave += new System.EventHandler(this.txtFicha_Leave);
            // 
            // txtSalário
            // 
            this.txtSalário.AllowNegative = false;
            this.txtSalário.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalário.Flags = 73216;
            this.txtSalário.Location = new System.Drawing.Point(72, 80);
            this.txtSalário.MaxWholeDigits = 9;
            this.txtSalário.Name = "txtSalário";
            this.txtSalário.RangeMax = 1.7976931348623157E+308;
            this.txtSalário.RangeMin = -1.7976931348623157E+308;
            this.txtSalário.Size = new System.Drawing.Size(120, 20);
            this.txtSalário.TabIndex = 8;
            this.txtSalário.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalário.Leave += new System.EventHandler(this.txtSalário_Leave);
            // 
            // lblSalário
            // 
            this.lblSalário.AutoSize = true;
            this.lblSalário.Location = new System.Drawing.Point(8, 82);
            this.lblSalário.Name = "lblSalário";
            this.lblSalário.Size = new System.Drawing.Size(42, 13);
            this.lblSalário.TabIndex = 7;
            this.lblSalário.Text = "&Salário:";
            // 
            // txtDataAdmissão
            // 
            this.txtDataAdmissão.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataAdmissão.Flags = 65536;
            this.txtDataAdmissão.Location = new System.Drawing.Point(72, 48);
            this.txtDataAdmissão.Name = "txtDataAdmissão";
            this.txtDataAdmissão.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtDataAdmissão.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDataAdmissão.Size = new System.Drawing.Size(120, 20);
            this.txtDataAdmissão.TabIndex = 4;
            this.txtDataAdmissão.Leave += new System.EventHandler(this.txtDataAdmissão_Leave);
            // 
            // lblAdmissão
            // 
            this.lblAdmissão.Location = new System.Drawing.Point(8, 48);
            this.lblAdmissão.Name = "lblAdmissão";
            this.lblAdmissão.Size = new System.Drawing.Size(56, 32);
            this.lblAdmissão.TabIndex = 3;
            this.lblAdmissão.Text = "Data de &admissão:";
            // 
            // lblFicha
            // 
            this.lblFicha.AutoSize = true;
            this.lblFicha.Location = new System.Drawing.Point(8, 16);
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Size = new System.Drawing.Size(36, 13);
            this.lblFicha.TabIndex = 1;
            this.lblFicha.Text = "&Ficha:";
            // 
            // grpLocalTrabalho
            // 
            this.grpLocalTrabalho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLocalTrabalho.Controls.Add(this.txtRamal);
            this.grpLocalTrabalho.Controls.Add(this.label3);
            this.grpLocalTrabalho.Controls.Add(this.txtSetor);
            this.grpLocalTrabalho.Controls.Add(this.label2);
            this.grpLocalTrabalho.Location = new System.Drawing.Point(0, 112);
            this.grpLocalTrabalho.Name = "grpLocalTrabalho";
            this.grpLocalTrabalho.Size = new System.Drawing.Size(392, 48);
            this.grpLocalTrabalho.TabIndex = 11;
            this.grpLocalTrabalho.TabStop = false;
            this.grpLocalTrabalho.Text = "Local de trabalho";
            // 
            // txtRamal
            // 
            this.txtRamal.AllowNegative = false;
            this.txtRamal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRamal.DigitsInGroup = 0;
            this.txtRamal.Flags = 65536;
            this.txtRamal.Location = new System.Drawing.Point(304, 16);
            this.txtRamal.MaxDecimalPlaces = 0;
            this.txtRamal.MaxWholeDigits = 9;
            this.txtRamal.Name = "txtRamal";
            this.txtRamal.Prefix = "";
            this.txtRamal.RangeMax = 1.7976931348623157E+308;
            this.txtRamal.RangeMin = -1.7976931348623157E+308;
            this.txtRamal.Size = new System.Drawing.Size(72, 20);
            this.txtRamal.TabIndex = 15;
            this.txtRamal.Leave += new System.EventHandler(this.txtRamal_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "&Ramal:";
            // 
            // txtSetor
            // 
            this.txtSetor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSetor.Location = new System.Drawing.Point(72, 16);
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.Size = new System.Drawing.Size(176, 21);
            this.txtSetor.Sorted = true;
            this.txtSetor.TabIndex = 13;
            this.txtSetor.Leave += new System.EventHandler(this.txtSetor_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "S&etor:";
            // 
            // grpInformações
            // 
            this.grpInformações.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInformações.Controls.Add(this.txtParentesco);
            this.grpInformações.Controls.Add(this.label12);
            this.grpInformações.Controls.Add(this.txtBeneficiário);
            this.grpInformações.Controls.Add(this.lblBeneficiário);
            this.grpInformações.Controls.Add(this.txtReservistaCategoria);
            this.grpInformações.Controls.Add(this.label9);
            this.grpInformações.Controls.Add(this.txtReservistaSérie);
            this.grpInformações.Controls.Add(this.label8);
            this.grpInformações.Controls.Add(this.txtTítuloEleitor);
            this.grpInformações.Controls.Add(this.lblTítulo);
            this.grpInformações.Controls.Add(this.txtReservista);
            this.grpInformações.Controls.Add(this.lblReservista);
            this.grpInformações.Controls.Add(this.txtCBO);
            this.grpInformações.Controls.Add(this.label6);
            this.grpInformações.Controls.Add(this.txtPIS);
            this.grpInformações.Controls.Add(this.label5);
            this.grpInformações.Controls.Add(this.txtCarteiraProfissionalSérie);
            this.grpInformações.Controls.Add(this.lblSérie);
            this.grpInformações.Controls.Add(this.txtCarteiraProfissional);
            this.grpInformações.Controls.Add(this.label4);
            this.grpInformações.Location = new System.Drawing.Point(0, 160);
            this.grpInformações.Name = "grpInformações";
            this.grpInformações.Size = new System.Drawing.Size(392, 184);
            this.grpInformações.TabIndex = 16;
            this.grpInformações.TabStop = false;
            this.grpInformações.Text = "Documentos";
            // 
            // txtParentesco
            // 
            this.txtParentesco.Items.AddRange(new object[] {
            "Esposa",
            "Marido",
            "Pai",
            "Mãe",
            "Irmão",
            "Irmã",
            "Filho",
            "Filha",
            "Sobrinho",
            "Sobrinha",
            "Tio",
            "Tia",
            "Avó",
            "Avô"});
            this.txtParentesco.Location = new System.Drawing.Point(272, 152);
            this.txtParentesco.Name = "txtParentesco";
            this.txtParentesco.Size = new System.Drawing.Size(104, 21);
            this.txtParentesco.TabIndex = 36;
            this.txtParentesco.Leave += new System.EventHandler(this.txtParentesco_Leave);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(200, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Parentesco:";
            // 
            // txtBeneficiário
            // 
            this.txtBeneficiário.Location = new System.Drawing.Point(72, 152);
            this.txtBeneficiário.Name = "txtBeneficiário";
            this.txtBeneficiário.Size = new System.Drawing.Size(120, 20);
            this.txtBeneficiário.TabIndex = 34;
            this.txtBeneficiário.Leave += new System.EventHandler(this.txtBeneficiário_Leave);
            // 
            // lblBeneficiário
            // 
            this.lblBeneficiário.AutoSize = true;
            this.lblBeneficiário.Location = new System.Drawing.Point(8, 154);
            this.lblBeneficiário.Name = "lblBeneficiário";
            this.lblBeneficiário.Size = new System.Drawing.Size(65, 13);
            this.lblBeneficiário.TabIndex = 33;
            this.lblBeneficiário.Text = "Beneficiário:";
            // 
            // txtReservistaCategoria
            // 
            this.txtReservistaCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReservistaCategoria.Location = new System.Drawing.Point(312, 88);
            this.txtReservistaCategoria.Name = "txtReservistaCategoria";
            this.txtReservistaCategoria.Size = new System.Drawing.Size(64, 20);
            this.txtReservistaCategoria.TabIndex = 30;
            this.txtReservistaCategoria.Leave += new System.EventHandler(this.txtReservistaCategoria_Leave);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Categoria:";
            // 
            // txtReservistaSérie
            // 
            this.txtReservistaSérie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReservistaSérie.Location = new System.Drawing.Point(192, 88);
            this.txtReservistaSérie.Name = "txtReservistaSérie";
            this.txtReservistaSérie.Size = new System.Drawing.Size(56, 20);
            this.txtReservistaSérie.TabIndex = 28;
            this.txtReservistaSérie.Leave += new System.EventHandler(this.txtReservistaSérie_Leave);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(160, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Série:";
            // 
            // txtTítuloEleitor
            // 
            this.txtTítuloEleitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTítuloEleitor.Location = new System.Drawing.Point(72, 120);
            this.txtTítuloEleitor.Name = "txtTítuloEleitor";
            this.txtTítuloEleitor.Size = new System.Drawing.Size(120, 20);
            this.txtTítuloEleitor.TabIndex = 32;
            this.txtTítuloEleitor.Leave += new System.EventHandler(this.txtTíuloEleitor_Leave);
            // 
            // lblTítulo
            // 
            this.lblTítulo.Location = new System.Drawing.Point(8, 120);
            this.lblTítulo.Name = "lblTítulo";
            this.lblTítulo.Size = new System.Drawing.Size(64, 29);
            this.lblTítulo.TabIndex = 31;
            this.lblTítulo.Text = "&Título de eleitor:";
            // 
            // txtReservista
            // 
            this.txtReservista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReservista.Location = new System.Drawing.Point(72, 88);
            this.txtReservista.Name = "txtReservista";
            this.txtReservista.Size = new System.Drawing.Size(80, 20);
            this.txtReservista.TabIndex = 26;
            this.txtReservista.Leave += new System.EventHandler(this.txtReservista_Leave);
            // 
            // lblReservista
            // 
            this.lblReservista.Location = new System.Drawing.Point(8, 86);
            this.lblReservista.Name = "lblReservista";
            this.lblReservista.Size = new System.Drawing.Size(64, 34);
            this.lblReservista.TabIndex = 25;
            this.lblReservista.Text = "Carteira reservista:";
            // 
            // txtCBO
            // 
            this.txtCBO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCBO.Location = new System.Drawing.Point(256, 56);
            this.txtCBO.Name = "txtCBO";
            this.txtCBO.Size = new System.Drawing.Size(120, 20);
            this.txtCBO.TabIndex = 24;
            this.txtCBO.Leave += new System.EventHandler(this.txtCBO_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "&CBO:";
            // 
            // txtPIS
            // 
            this.txtPIS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPIS.Location = new System.Drawing.Point(72, 56);
            this.txtPIS.Name = "txtPIS";
            this.txtPIS.Size = new System.Drawing.Size(120, 20);
            this.txtPIS.TabIndex = 22;
            this.txtPIS.Leave += new System.EventHandler(this.txtPIS_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "P&IS:";
            // 
            // txtCarteiraProfissionalSérie
            // 
            this.txtCarteiraProfissionalSérie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarteiraProfissionalSérie.Location = new System.Drawing.Point(256, 24);
            this.txtCarteiraProfissionalSérie.Name = "txtCarteiraProfissionalSérie";
            this.txtCarteiraProfissionalSérie.Size = new System.Drawing.Size(120, 20);
            this.txtCarteiraProfissionalSérie.TabIndex = 20;
            this.txtCarteiraProfissionalSérie.Leave += new System.EventHandler(this.txtCarteiraProfissionalSérie_Leave);
            // 
            // lblSérie
            // 
            this.lblSérie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSérie.AutoSize = true;
            this.lblSérie.Location = new System.Drawing.Point(200, 26);
            this.lblSérie.Name = "lblSérie";
            this.lblSérie.Size = new System.Drawing.Size(34, 13);
            this.lblSérie.TabIndex = 19;
            this.lblSérie.Text = "Série:";
            // 
            // txtCarteiraProfissional
            // 
            this.txtCarteiraProfissional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarteiraProfissional.Location = new System.Drawing.Point(72, 24);
            this.txtCarteiraProfissional.Name = "txtCarteiraProfissional";
            this.txtCarteiraProfissional.Size = new System.Drawing.Size(120, 20);
            this.txtCarteiraProfissional.TabIndex = 18;
            this.txtCarteiraProfissional.Leave += new System.EventHandler(this.txtCarteiraProfissional_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 32);
            this.label4.TabIndex = 17;
            this.label4.Text = "Carteira &profissional:";
            // 
            // DadosFuncionário
            // 
            this.Controls.Add(this.grpInformações);
            this.Controls.Add(this.grpLocalTrabalho);
            this.Controls.Add(this.grpDadosEmpresa);
            this.Name = "DadosFuncionário";
            this.Size = new System.Drawing.Size(392, 347);
            this.Load += new System.EventHandler(this.Funcionário_Load);
            this.grpDadosEmpresa.ResumeLayout(false);
            this.grpDadosEmpresa.PerformLayout();
            this.grpLocalTrabalho.ResumeLayout(false);
            this.grpLocalTrabalho.PerformLayout();
            this.grpInformações.ResumeLayout(false);
            this.grpInformações.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        [Browsable(false), DefaultValue(null), ReadOnly(true)]
		public Entidades.Pessoa.Funcionário Pessoa
		{
			set
			{
				if (this.DesignMode || value == null)
					return;

				funcionário					= value;

                if (value.Ficha.HasValue)
                    txtFicha.Long = value.Ficha.Value;
                else
                    txtFicha.Text = "";
				
				if (value.DataAdmissão > DateTime.MinValue)
					txtDataAdmissão.Text		= value.DataAdmissão.ToShortDateString();

				if (value.DataSaída.HasValue)
					txtDataDemissão.Text    = value.DataSaída.Value.ToShortDateString();

				txtSalário.Double			= value.Salário;

                if (value.Setor != null)
				    txtSetor.SelectedText		= value.Setor.Nome;

				txtRamal.Int				= value.Ramal;

				txtCarteiraProfissional.Text= value.CarteiraProfissional;
				txtCarteiraProfissionalSérie.Text=value.CarteiraProfissionalSérie;
				txtPIS.Text					= value.PIS;
				txtCBO.Text					= value.CBO;
				txtReservista.Text			= value.Reservista;
				txtReservistaSérie.Text		= value.ReservistaSérie;
				txtReservistaCategoria.Text = value.ReservistaCategoria;
				txtTítuloEleitor.Text		= value.TítuloEleitor;
				txtCargo.Text				= value.Cargo;
				txtBeneficiário.Text		= value.Beneficiário;
				txtParentesco.Text			= value.BeneficiárioParentesco;

                // Value nunca pode ser nulo aqui.
                if (value.Setor != null)
				    txtSetor.Text = value.Setor.Nome;

                txtEmpresa.SelectedIndex = -1;

				foreach (PessoaJurídica empresa in txtEmpresa.Items)
					if (empresa.Código == value.Empresa)
					{
						txtEmpresa.SelectedItem = empresa;
						break;
					}
			}
		}

		public void AdicionarSetor(string nome, long código)
		{
            hashNomeSetor[nome] = (Entidades.Setor) código;

			txtSetor.Items.Add(nome);
		}

		public void AdicionarEmpresa(PessoaJurídica empresa)
		{
			txtEmpresa.Items.Add(empresa);
			
			if (txtEmpresa.Items.Count == 1)
				txtEmpresa.SelectedIndex = 0;
		}

        private void Funcionário_Load(object sender, EventArgs e)
        {
            if (funcionário == null)
                funcionário = new Entidades.Pessoa.Funcionário();

            foreach (Control controle in Controls)
                controle.Enabled = this.Enabled;
        }

        private void txtFicha_Leave(object sender, EventArgs e)
        {
            funcionário.Ficha = txtFicha.Long;
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            if (txtEmpresa.SelectedItem != null)
                funcionário.Empresa = ((PessoaJurídica)txtEmpresa.SelectedItem).Código;
        }

        private void txtDataAdmissão_Leave(object sender, EventArgs e)
        {
            try
            {
                funcionário.DataAdmissão = new DateTime(txtDataAdmissão.Year, txtDataAdmissão.Month, txtDataAdmissão.Day);
            }
            catch
            {
                Apresentação.Formulários.NotificaçãoSimples.Mostrar(
                    "Cadastro de funcionário",
                    "A data de admissão não foi registrada ou encontra-se incorreta!");
            }
        }

        private void txtDataDemissão_Leave(object sender, EventArgs e)
        {
            try
            {
                funcionário.DataSaída = new DateTime(txtDataDemissão.Year, txtDataDemissão.Month, txtDataDemissão.Day);
            }
            catch
            {
                txtDataDemissão.Text = "";
                funcionário.DataSaída = null;
            }
        }

        private void txtSalário_Leave(object sender, EventArgs e)
        {
            funcionário.Salário = txtSalário.Double;
        }

        private void txtCargo_Leave(object sender, EventArgs e)
        {
            funcionário.Cargo = txtCargo.Text;
        }

        private void txtSetor_Leave(object sender, EventArgs e)
        {
            Entidades.Setor s = null;

            if (hashNomeSetor.TryGetValue(txtSetor.Text, out s))
            {
                funcionário.Setor = s;
            } else
            {
                Apresentação.Formulários.NotificaçãoSimples.Mostrar(
                    "Cadastro de funcionário",
                    "Setor não especificado ou incorreto!");
            }
        }

        private void txtRamal_Leave(object sender, EventArgs e)
        {
            funcionário.Ramal = txtRamal.Int;
        }

        private void txtCarteiraProfissional_Leave(object sender, EventArgs e)
        {
            funcionário.CarteiraProfissional = txtCarteiraProfissional.Text;
        }

        private void txtCarteiraProfissionalSérie_Leave(object sender, EventArgs e)
        {
            funcionário.CarteiraProfissionalSérie = txtCarteiraProfissionalSérie.Text;
        }

        private void txtPIS_Leave(object sender, EventArgs e)
        {
            funcionário.PIS = txtPIS.Text;
        }

        private void txtCBO_Leave(object sender, EventArgs e)
        {
            funcionário.CBO = txtCBO.Text;
        }

        private void txtReservista_Leave(object sender, EventArgs e)
        {
            funcionário.Reservista = txtReservista.Text;
        }

        private void txtReservistaSérie_Leave(object sender, EventArgs e)
        {
            funcionário.ReservistaSérie = txtReservistaSérie.Text;
        }

        private void txtReservistaCategoria_Leave(object sender, EventArgs e)
        {
            funcionário.ReservistaCategoria = txtReservistaCategoria.Text;
        }

        private void txtTíuloEleitor_Leave(object sender, EventArgs e)
        {
            funcionário.TítuloEleitor = txtTítuloEleitor.Text;
        }

        private void txtBeneficiário_Leave(object sender, EventArgs e)
        {
            funcionário.Beneficiário = txtBeneficiário.Text;
        }

        private void txtParentesco_Leave(object sender, EventArgs e)
        {
            funcionário.BeneficiárioParentesco = txtParentesco.Text;
        }

        private void txtEmpresa_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show(
                    ParentForm,
                    "Escolha uma empresa para o funcionário.",
                    "Edição de funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        internal void FocarEmpresa()
        {
            txtEmpresa.Focus();
        }

        internal void FocarSetor()
        {
            txtSetor.Focus();
        }
    }
}
