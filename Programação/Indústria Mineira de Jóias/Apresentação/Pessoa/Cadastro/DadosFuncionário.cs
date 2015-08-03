using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa.Cadastro
{
	/// <summary>
	/// Summary description for Funcion�rio.
	/// </summary>
	public class DadosFuncion�rio : System.Windows.Forms.UserControl
	{
		private Entidades.Pessoa.Funcion�rio funcion�rio;
        private Dictionary<string, Entidades.Setor> hashNomeSetor = new Dictionary<string, Entidades.Setor>(StringComparer.Ordinal);

		// Designer
		private System.Windows.Forms.Label lblFicha;
		private System.Windows.Forms.Label lblAdmiss�o;
		private AMS.TextBox.DateTextBox txtDataAdmiss�o;
		private System.Windows.Forms.Label lblSal�rio;
		private AMS.TextBox.CurrencyTextBox txtSal�rio;
		private AMS.TextBox.IntegerTextBox txtFicha;
		private System.Windows.Forms.GroupBox grpDadosEmpresa;
		private System.Windows.Forms.GroupBox grpLocalTrabalho;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox txtSetor;
		private AMS.TextBox.IntegerTextBox txtRamal;
		private System.Windows.Forms.GroupBox grpInforma��es;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCarteiraProfissional;
		private System.Windows.Forms.Label lblS�rie;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblReservista;
		private System.Windows.Forms.TextBox txtReservista;
		private System.Windows.Forms.Label lblT�tulo;
		private System.Windows.Forms.TextBox txtCarteiraProfissionalS�rie;
		private System.Windows.Forms.TextBox txtT�tuloEleitor;
		private System.Windows.Forms.TextBox txtCBO;
		private System.Windows.Forms.TextBox txtPIS;
		private System.Windows.Forms.Label label7;
		private AMS.TextBox.DateTextBox txtDataDemiss�o;
		private System.Windows.Forms.TextBox txtReservistaS�rie;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtReservistaCategoria;
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblCargo;
		private System.Windows.Forms.ComboBox txtCargo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox txtEmpresa;
		private System.Windows.Forms.Label lblBenefici�rio;
		private System.Windows.Forms.TextBox txtBenefici�rio;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox txtParentesco;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DadosFuncion�rio()
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
            this.txtDataDemiss�o = new AMS.TextBox.DateTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFicha = new AMS.TextBox.IntegerTextBox();
            this.txtSal�rio = new AMS.TextBox.CurrencyTextBox();
            this.lblSal�rio = new System.Windows.Forms.Label();
            this.txtDataAdmiss�o = new AMS.TextBox.DateTextBox();
            this.lblAdmiss�o = new System.Windows.Forms.Label();
            this.lblFicha = new System.Windows.Forms.Label();
            this.grpLocalTrabalho = new System.Windows.Forms.GroupBox();
            this.txtRamal = new AMS.TextBox.IntegerTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSetor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpInforma��es = new System.Windows.Forms.GroupBox();
            this.txtParentesco = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBenefici�rio = new System.Windows.Forms.TextBox();
            this.lblBenefici�rio = new System.Windows.Forms.Label();
            this.txtReservistaCategoria = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReservistaS�rie = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtT�tuloEleitor = new System.Windows.Forms.TextBox();
            this.lblT�tulo = new System.Windows.Forms.Label();
            this.txtReservista = new System.Windows.Forms.TextBox();
            this.lblReservista = new System.Windows.Forms.Label();
            this.txtCBO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPIS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarteiraProfissionalS�rie = new System.Windows.Forms.TextBox();
            this.lblS�rie = new System.Windows.Forms.Label();
            this.txtCarteiraProfissional = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpDadosEmpresa.SuspendLayout();
            this.grpLocalTrabalho.SuspendLayout();
            this.grpInforma��es.SuspendLayout();
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
            this.grpDadosEmpresa.Controls.Add(this.txtDataDemiss�o);
            this.grpDadosEmpresa.Controls.Add(this.label7);
            this.grpDadosEmpresa.Controls.Add(this.txtFicha);
            this.grpDadosEmpresa.Controls.Add(this.txtSal�rio);
            this.grpDadosEmpresa.Controls.Add(this.lblSal�rio);
            this.grpDadosEmpresa.Controls.Add(this.txtDataAdmiss�o);
            this.grpDadosEmpresa.Controls.Add(this.lblAdmiss�o);
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
            // txtDataDemiss�o
            // 
            this.txtDataDemiss�o.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataDemiss�o.Flags = 65536;
            this.txtDataDemiss�o.Location = new System.Drawing.Point(264, 48);
            this.txtDataDemiss�o.Name = "txtDataDemiss�o";
            this.txtDataDemiss�o.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtDataDemiss�o.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDataDemiss�o.Size = new System.Drawing.Size(112, 20);
            this.txtDataDemiss�o.TabIndex = 6;
            this.txtDataDemiss�o.Leave += new System.EventHandler(this.txtDataDemiss�o_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(200, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 32);
            this.label7.TabIndex = 5;
            this.label7.Text = "Data de &demiss�o:";
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
            // txtSal�rio
            // 
            this.txtSal�rio.AllowNegative = false;
            this.txtSal�rio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSal�rio.Flags = 73216;
            this.txtSal�rio.Location = new System.Drawing.Point(72, 80);
            this.txtSal�rio.MaxWholeDigits = 9;
            this.txtSal�rio.Name = "txtSal�rio";
            this.txtSal�rio.RangeMax = 1.7976931348623157E+308;
            this.txtSal�rio.RangeMin = -1.7976931348623157E+308;
            this.txtSal�rio.Size = new System.Drawing.Size(120, 20);
            this.txtSal�rio.TabIndex = 8;
            this.txtSal�rio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSal�rio.Leave += new System.EventHandler(this.txtSal�rio_Leave);
            // 
            // lblSal�rio
            // 
            this.lblSal�rio.AutoSize = true;
            this.lblSal�rio.Location = new System.Drawing.Point(8, 82);
            this.lblSal�rio.Name = "lblSal�rio";
            this.lblSal�rio.Size = new System.Drawing.Size(42, 13);
            this.lblSal�rio.TabIndex = 7;
            this.lblSal�rio.Text = "&Sal�rio:";
            // 
            // txtDataAdmiss�o
            // 
            this.txtDataAdmiss�o.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataAdmiss�o.Flags = 65536;
            this.txtDataAdmiss�o.Location = new System.Drawing.Point(72, 48);
            this.txtDataAdmiss�o.Name = "txtDataAdmiss�o";
            this.txtDataAdmiss�o.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtDataAdmiss�o.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDataAdmiss�o.Size = new System.Drawing.Size(120, 20);
            this.txtDataAdmiss�o.TabIndex = 4;
            this.txtDataAdmiss�o.Leave += new System.EventHandler(this.txtDataAdmiss�o_Leave);
            // 
            // lblAdmiss�o
            // 
            this.lblAdmiss�o.Location = new System.Drawing.Point(8, 48);
            this.lblAdmiss�o.Name = "lblAdmiss�o";
            this.lblAdmiss�o.Size = new System.Drawing.Size(56, 32);
            this.lblAdmiss�o.TabIndex = 3;
            this.lblAdmiss�o.Text = "Data de &admiss�o:";
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
            // grpInforma��es
            // 
            this.grpInforma��es.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInforma��es.Controls.Add(this.txtParentesco);
            this.grpInforma��es.Controls.Add(this.label12);
            this.grpInforma��es.Controls.Add(this.txtBenefici�rio);
            this.grpInforma��es.Controls.Add(this.lblBenefici�rio);
            this.grpInforma��es.Controls.Add(this.txtReservistaCategoria);
            this.grpInforma��es.Controls.Add(this.label9);
            this.grpInforma��es.Controls.Add(this.txtReservistaS�rie);
            this.grpInforma��es.Controls.Add(this.label8);
            this.grpInforma��es.Controls.Add(this.txtT�tuloEleitor);
            this.grpInforma��es.Controls.Add(this.lblT�tulo);
            this.grpInforma��es.Controls.Add(this.txtReservista);
            this.grpInforma��es.Controls.Add(this.lblReservista);
            this.grpInforma��es.Controls.Add(this.txtCBO);
            this.grpInforma��es.Controls.Add(this.label6);
            this.grpInforma��es.Controls.Add(this.txtPIS);
            this.grpInforma��es.Controls.Add(this.label5);
            this.grpInforma��es.Controls.Add(this.txtCarteiraProfissionalS�rie);
            this.grpInforma��es.Controls.Add(this.lblS�rie);
            this.grpInforma��es.Controls.Add(this.txtCarteiraProfissional);
            this.grpInforma��es.Controls.Add(this.label4);
            this.grpInforma��es.Location = new System.Drawing.Point(0, 160);
            this.grpInforma��es.Name = "grpInforma��es";
            this.grpInforma��es.Size = new System.Drawing.Size(392, 184);
            this.grpInforma��es.TabIndex = 16;
            this.grpInforma��es.TabStop = false;
            this.grpInforma��es.Text = "Documentos";
            // 
            // txtParentesco
            // 
            this.txtParentesco.Items.AddRange(new object[] {
            "Esposa",
            "Marido",
            "Pai",
            "M�e",
            "Irm�o",
            "Irm�",
            "Filho",
            "Filha",
            "Sobrinho",
            "Sobrinha",
            "Tio",
            "Tia",
            "Av�",
            "Av�"});
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
            // txtBenefici�rio
            // 
            this.txtBenefici�rio.Location = new System.Drawing.Point(72, 152);
            this.txtBenefici�rio.Name = "txtBenefici�rio";
            this.txtBenefici�rio.Size = new System.Drawing.Size(120, 20);
            this.txtBenefici�rio.TabIndex = 34;
            this.txtBenefici�rio.Leave += new System.EventHandler(this.txtBenefici�rio_Leave);
            // 
            // lblBenefici�rio
            // 
            this.lblBenefici�rio.AutoSize = true;
            this.lblBenefici�rio.Location = new System.Drawing.Point(8, 154);
            this.lblBenefici�rio.Name = "lblBenefici�rio";
            this.lblBenefici�rio.Size = new System.Drawing.Size(65, 13);
            this.lblBenefici�rio.TabIndex = 33;
            this.lblBenefici�rio.Text = "Benefici�rio:";
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
            // txtReservistaS�rie
            // 
            this.txtReservistaS�rie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReservistaS�rie.Location = new System.Drawing.Point(192, 88);
            this.txtReservistaS�rie.Name = "txtReservistaS�rie";
            this.txtReservistaS�rie.Size = new System.Drawing.Size(56, 20);
            this.txtReservistaS�rie.TabIndex = 28;
            this.txtReservistaS�rie.Leave += new System.EventHandler(this.txtReservistaS�rie_Leave);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(160, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "S�rie:";
            // 
            // txtT�tuloEleitor
            // 
            this.txtT�tuloEleitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtT�tuloEleitor.Location = new System.Drawing.Point(72, 120);
            this.txtT�tuloEleitor.Name = "txtT�tuloEleitor";
            this.txtT�tuloEleitor.Size = new System.Drawing.Size(120, 20);
            this.txtT�tuloEleitor.TabIndex = 32;
            this.txtT�tuloEleitor.Leave += new System.EventHandler(this.txtT�uloEleitor_Leave);
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Location = new System.Drawing.Point(8, 120);
            this.lblT�tulo.Name = "lblT�tulo";
            this.lblT�tulo.Size = new System.Drawing.Size(64, 29);
            this.lblT�tulo.TabIndex = 31;
            this.lblT�tulo.Text = "&T�tulo de eleitor:";
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
            // txtCarteiraProfissionalS�rie
            // 
            this.txtCarteiraProfissionalS�rie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarteiraProfissionalS�rie.Location = new System.Drawing.Point(256, 24);
            this.txtCarteiraProfissionalS�rie.Name = "txtCarteiraProfissionalS�rie";
            this.txtCarteiraProfissionalS�rie.Size = new System.Drawing.Size(120, 20);
            this.txtCarteiraProfissionalS�rie.TabIndex = 20;
            this.txtCarteiraProfissionalS�rie.Leave += new System.EventHandler(this.txtCarteiraProfissionalS�rie_Leave);
            // 
            // lblS�rie
            // 
            this.lblS�rie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblS�rie.AutoSize = true;
            this.lblS�rie.Location = new System.Drawing.Point(200, 26);
            this.lblS�rie.Name = "lblS�rie";
            this.lblS�rie.Size = new System.Drawing.Size(34, 13);
            this.lblS�rie.TabIndex = 19;
            this.lblS�rie.Text = "S�rie:";
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
            // DadosFuncion�rio
            // 
            this.Controls.Add(this.grpInforma��es);
            this.Controls.Add(this.grpLocalTrabalho);
            this.Controls.Add(this.grpDadosEmpresa);
            this.Name = "DadosFuncion�rio";
            this.Size = new System.Drawing.Size(392, 347);
            this.Load += new System.EventHandler(this.Funcion�rio_Load);
            this.grpDadosEmpresa.ResumeLayout(false);
            this.grpDadosEmpresa.PerformLayout();
            this.grpLocalTrabalho.ResumeLayout(false);
            this.grpLocalTrabalho.PerformLayout();
            this.grpInforma��es.ResumeLayout(false);
            this.grpInforma��es.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        [Browsable(false), DefaultValue(null), ReadOnly(true)]
		public Entidades.Pessoa.Funcion�rio Pessoa
		{
			set
			{
				if (this.DesignMode || value == null)
					return;

				funcion�rio					= value;

                if (value.Ficha.HasValue)
                    txtFicha.Long = value.Ficha.Value;
                else
                    txtFicha.Text = "";
				
				if (value.DataAdmiss�o > DateTime.MinValue)
					txtDataAdmiss�o.Text		= value.DataAdmiss�o.ToShortDateString();

				if (value.DataSa�da.HasValue)
					txtDataDemiss�o.Text    = value.DataSa�da.Value.ToShortDateString();

				txtSal�rio.Double			= value.Sal�rio;

                if (value.Setor != null)
				    txtSetor.SelectedText		= value.Setor.Nome;

				txtRamal.Int				= value.Ramal;

				txtCarteiraProfissional.Text= value.CarteiraProfissional;
				txtCarteiraProfissionalS�rie.Text=value.CarteiraProfissionalS�rie;
				txtPIS.Text					= value.PIS;
				txtCBO.Text					= value.CBO;
				txtReservista.Text			= value.Reservista;
				txtReservistaS�rie.Text		= value.ReservistaS�rie;
				txtReservistaCategoria.Text = value.ReservistaCategoria;
				txtT�tuloEleitor.Text		= value.T�tuloEleitor;
				txtCargo.Text				= value.Cargo;
				txtBenefici�rio.Text		= value.Benefici�rio;
				txtParentesco.Text			= value.Benefici�rioParentesco;

                // Value nunca pode ser nulo aqui.
                if (value.Setor != null)
				    txtSetor.Text = value.Setor.Nome;

                txtEmpresa.SelectedIndex = -1;

				foreach (PessoaJur�dica empresa in txtEmpresa.Items)
					if (empresa.C�digo == value.Empresa)
					{
						txtEmpresa.SelectedItem = empresa;
						break;
					}
			}
		}

		public void AdicionarSetor(string nome, long c�digo)
		{
            hashNomeSetor[nome] = (Entidades.Setor) c�digo;

			txtSetor.Items.Add(nome);
		}

		public void AdicionarEmpresa(PessoaJur�dica empresa)
		{
			txtEmpresa.Items.Add(empresa);
			
			if (txtEmpresa.Items.Count == 1)
				txtEmpresa.SelectedIndex = 0;
		}

        private void Funcion�rio_Load(object sender, EventArgs e)
        {
            if (funcion�rio == null)
                funcion�rio = new Entidades.Pessoa.Funcion�rio();

            foreach (Control controle in Controls)
                controle.Enabled = this.Enabled;
        }

        private void txtFicha_Leave(object sender, EventArgs e)
        {
            funcion�rio.Ficha = txtFicha.Long;
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            if (txtEmpresa.SelectedItem != null)
                funcion�rio.Empresa = ((PessoaJur�dica)txtEmpresa.SelectedItem).C�digo;
        }

        private void txtDataAdmiss�o_Leave(object sender, EventArgs e)
        {
            try
            {
                funcion�rio.DataAdmiss�o = new DateTime(txtDataAdmiss�o.Year, txtDataAdmiss�o.Month, txtDataAdmiss�o.Day);
            }
            catch
            {
                Apresenta��o.Formul�rios.Notifica��oSimples.Mostrar(
                    "Cadastro de funcion�rio",
                    "A data de admiss�o n�o foi registrada ou encontra-se incorreta!");
            }
        }

        private void txtDataDemiss�o_Leave(object sender, EventArgs e)
        {
            try
            {
                funcion�rio.DataSa�da = new DateTime(txtDataDemiss�o.Year, txtDataDemiss�o.Month, txtDataDemiss�o.Day);
            }
            catch
            {
                txtDataDemiss�o.Text = "";
                funcion�rio.DataSa�da = null;
            }
        }

        private void txtSal�rio_Leave(object sender, EventArgs e)
        {
            funcion�rio.Sal�rio = txtSal�rio.Double;
        }

        private void txtCargo_Leave(object sender, EventArgs e)
        {
            funcion�rio.Cargo = txtCargo.Text;
        }

        private void txtSetor_Leave(object sender, EventArgs e)
        {
            Entidades.Setor s = null;

            if (hashNomeSetor.TryGetValue(txtSetor.Text, out s))
            {
                funcion�rio.Setor = s;
            } else
            {
                Apresenta��o.Formul�rios.Notifica��oSimples.Mostrar(
                    "Cadastro de funcion�rio",
                    "Setor n�o especificado ou incorreto!");
            }
        }

        private void txtRamal_Leave(object sender, EventArgs e)
        {
            funcion�rio.Ramal = txtRamal.Int;
        }

        private void txtCarteiraProfissional_Leave(object sender, EventArgs e)
        {
            funcion�rio.CarteiraProfissional = txtCarteiraProfissional.Text;
        }

        private void txtCarteiraProfissionalS�rie_Leave(object sender, EventArgs e)
        {
            funcion�rio.CarteiraProfissionalS�rie = txtCarteiraProfissionalS�rie.Text;
        }

        private void txtPIS_Leave(object sender, EventArgs e)
        {
            funcion�rio.PIS = txtPIS.Text;
        }

        private void txtCBO_Leave(object sender, EventArgs e)
        {
            funcion�rio.CBO = txtCBO.Text;
        }

        private void txtReservista_Leave(object sender, EventArgs e)
        {
            funcion�rio.Reservista = txtReservista.Text;
        }

        private void txtReservistaS�rie_Leave(object sender, EventArgs e)
        {
            funcion�rio.ReservistaS�rie = txtReservistaS�rie.Text;
        }

        private void txtReservistaCategoria_Leave(object sender, EventArgs e)
        {
            funcion�rio.ReservistaCategoria = txtReservistaCategoria.Text;
        }

        private void txtT�uloEleitor_Leave(object sender, EventArgs e)
        {
            funcion�rio.T�tuloEleitor = txtT�tuloEleitor.Text;
        }

        private void txtBenefici�rio_Leave(object sender, EventArgs e)
        {
            funcion�rio.Benefici�rio = txtBenefici�rio.Text;
        }

        private void txtParentesco_Leave(object sender, EventArgs e)
        {
            funcion�rio.Benefici�rioParentesco = txtParentesco.Text;
        }

        private void txtEmpresa_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmpresa.SelectedIndex < 0)
            {
                MessageBox.Show(
                    ParentForm,
                    "Escolha uma empresa para o funcion�rio.",
                    "Edi��o de funcion�rio",
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
