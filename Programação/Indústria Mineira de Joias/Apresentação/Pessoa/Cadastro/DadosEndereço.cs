using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Pessoa.Endereço;
using System.Text.RegularExpressions;


namespace Apresentação.Pessoa.Cadastro
{
	/// <summary>
	/// Summary description for Endereço.
	/// </summary>
	public class DadosEndereço : System.Windows.Forms.UserControl, Apresentação.Formulários.IEditorItem<Entidades.Pessoa.Endereço.Endereço>
	{
        private Entidades.Pessoa.Endereço.Endereço endereço;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtLogradouro;
		private System.Windows.Forms.TextBox txtNúmero;
        private System.Windows.Forms.TextBox txtBairro;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtComplemento;
        private Apresentação.Pessoa.Endereço.TextBoxLocalidade txtLocalidade;
        private Apresentação.Pessoa.Endereço.TextBoxEstado txtEstado;
        private Apresentação.Pessoa.Endereço.TextBoxPaís txtPaís;
        private FormatadorNome formatadorNome;
        private GroupBox grp;
        private TextBox txtDescrição;
        private LinkLabel lnkAlterar;
        private TextBox txtObs;
        private Label label9;
        private Label lblComplemento;
        private TextBox txtCEP;
        private IContainer components;

        private static Regex regexCEP;

        private static Regex RegexCEP
        {
            get
            {
                if (regexCEP == null)
                {
                    regexCEP = new Regex(
                        @"^(?<prefixo>\d{5})(-)?(?<sufixo>\d{3})$",
                        RegexOptions.IgnoreCase
                        | RegexOptions.ExplicitCapture
                        | RegexOptions.Compiled
                        );
                }

                return regexCEP;
            }
        }

		public DadosEndereço()
		{
            EventHandler aoFocarControle = new EventHandler(AoFocarControle);

			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
/*
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.Transparent;
*/

            foreach (Control controle in Controls)
                controle.GotFocus += aoFocarControle;
        }

        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public Entidades.Pessoa.Endereço.Endereço Item
        {
            get { return endereço; }
            set
            {
                endereço = value;

                grp.Text = "Endereço: " + value.Descrição;

                if (value.Descrição == null || value.Descrição.Length == 0)
                {
                    txtDescrição.Text = "< descrição (ex.: residencial) >";
                    txtDescrição.SelectAll();
                    txtDescrição.Visible = true;
                    txtDescrição.Focus();
                }
                else
                {
                    this.txtDescrição.Text = value.Descrição;
                    txtDescrição.Visible = false;
                }

                this.txtLogradouro.Text = value.Logradouro;
                this.txtNúmero.Text = value.Número;

                if (value.Complemento != null)
                {
                    this.txtComplemento.Text = value.Complemento;
                    lblComplemento.Visible = value.Complemento.Length == 0;
                }
                else
                    txtComplemento.Text = "";

                if (value.Bairro != null)
                    this.txtBairro.Text = value.Bairro;
                else
                    txtBairro.Text = "";

                this.txtCEP.Text = value.CEP;
                this.txtLocalidade.Localidade = value.Localidade;
                this.txtObs.Text = value.Observações;
            }
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNúmero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtLocalidade = new Apresentação.Pessoa.Endereço.TextBoxLocalidade();
            this.txtEstado = new Apresentação.Pessoa.Endereço.TextBoxEstado();
            this.txtPaís = new Apresentação.Pessoa.Endereço.TextBoxPaís();
            this.formatadorNome = new Apresentação.Pessoa.FormatadorNome(this.components);
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.grp = new System.Windows.Forms.GroupBox();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.lblComplemento = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lnkAlterar = new System.Windows.Forms.LinkLabel();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Logradouro:";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.formatadorNome.SetFormatarNome(this.txtLogradouro, true);
            this.txtLogradouro.Location = new System.Drawing.Point(70, 45);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(289, 20);
            this.txtLogradouro.TabIndex = 4;
            this.txtLogradouro.Validated += new System.EventHandler(this.txtLogradouro_Validated);
            this.txtLogradouro.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número:";
            // 
            // txtNúmero
            // 
            this.txtNúmero.Location = new System.Drawing.Point(70, 70);
            this.txtNúmero.Name = "txtNúmero";
            this.txtNúmero.Size = new System.Drawing.Size(40, 20);
            this.txtNúmero.TabIndex = 6;
            this.txtNúmero.Validated += new System.EventHandler(this.txtNúmero_Validated);
            this.txtNúmero.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Bairro:";
            // 
            // txtBairro
            // 
            this.txtBairro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.formatadorNome.SetFormatarNome(this.txtBairro, true);
            this.txtBairro.Location = new System.Drawing.Point(267, 71);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(92, 20);
            this.txtBairro.TabIndex = 11;
            this.txtBairro.Validated += new System.EventHandler(this.txtBairro_Validated);
            this.txtBairro.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "CEP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Localidade:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Estado:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "País:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "C.:";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(142, 70);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(76, 20);
            this.txtComplemento.TabIndex = 9;
            this.txtComplemento.Validated += new System.EventHandler(this.txtComplemento_Validated);
            this.txtComplemento.Enter += new System.EventHandler(this.AoFocarComplemento);
            // 
            // txtLocalidade
            // 
            this.txtLocalidade.Location = new System.Drawing.Point(70, 97);
            this.txtLocalidade.Name = "txtLocalidade";
            this.txtLocalidade.Size = new System.Drawing.Size(148, 20);
            this.txtLocalidade.TabIndex = 13;
            this.txtLocalidade.TxtEstado = this.txtEstado;
            this.txtLocalidade.TxtPaís = this.txtPaís;
            this.txtLocalidade.AoAlterar += new System.EventHandler(this.txtLocalidade_Validated);
            this.txtLocalidade.Validated += new System.EventHandler(this.txtLocalidade_Validated);
            this.txtLocalidade.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstado.Location = new System.Drawing.Point(267, 97);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(92, 20);
            this.txtEstado.TabIndex = 15;
            this.txtEstado.TxtLocalidade = this.txtLocalidade;
            this.txtEstado.TxtPaís = this.txtPaís;
            this.txtEstado.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // txtPaís
            // 
            this.txtPaís.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaís.Location = new System.Drawing.Point(70, 123);
            this.txtPaís.Name = "txtPaís";
            this.txtPaís.Size = new System.Drawing.Size(289, 20);
            this.txtPaís.TabIndex = 17;
            this.txtPaís.TxtEstado = this.txtEstado;
            this.txtPaís.TxtLocalidade = this.txtLocalidade;
            this.txtPaís.TxtPaís = this.txtPaís;
            this.txtPaís.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formatadorNome.SetFormatarNome(this.txtDescrição, true);
            this.txtDescrição.Location = new System.Drawing.Point(9, 0);
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(350, 13);
            this.txtDescrição.TabIndex = 0;
            this.txtDescrição.Validated += new System.EventHandler(this.txtDescrição_Validated);
            this.txtDescrição.Leave += new System.EventHandler(this.txtDescrição_Leave);
            this.txtDescrição.Enter += new System.EventHandler(this.AoFocarControle);
            this.txtDescrição.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescrição_Validating);
            // 
            // grp
            // 
            this.grp.Controls.Add(this.txtCEP);
            this.grp.Controls.Add(this.lblComplemento);
            this.grp.Controls.Add(this.txtObs);
            this.grp.Controls.Add(this.label9);
            this.grp.Controls.Add(this.lnkAlterar);
            this.grp.Controls.Add(this.txtDescrição);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.txtPaís);
            this.grp.Controls.Add(this.txtLogradouro);
            this.grp.Controls.Add(this.txtEstado);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.txtLocalidade);
            this.grp.Controls.Add(this.txtNúmero);
            this.grp.Controls.Add(this.txtComplemento);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.label8);
            this.grp.Controls.Add(this.txtBairro);
            this.grp.Controls.Add(this.label7);
            this.grp.Controls.Add(this.label6);
            this.grp.Controls.Add(this.label5);
            this.grp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(365, 200);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            this.grp.Text = "Endereço";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(70, 18);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(128, 20);
            this.txtCEP.TabIndex = 2;
            this.txtCEP.Validated += new System.EventHandler(this.txtCEP_Validated);
            this.txtCEP.Leave += new System.EventHandler(this.txtCEP_Leave);
            this.txtCEP.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // lblComplemento
            // 
            this.lblComplemento.BackColor = System.Drawing.SystemColors.Window;
            this.lblComplemento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblComplemento.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblComplemento.Location = new System.Drawing.Point(143, 73);
            this.lblComplemento.Name = "lblComplemento";
            this.lblComplemento.Size = new System.Drawing.Size(72, 15);
            this.lblComplemento.TabIndex = 8;
            this.lblComplemento.Text = "Complemento";
            this.lblComplemento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblComplemento.Click += new System.EventHandler(this.lblComplemento_Click);
            // 
            // txtObs
            // 
            this.txtObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObs.Location = new System.Drawing.Point(70, 149);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(288, 45);
            this.txtObs.TabIndex = 19;
            this.txtObs.Validated += new System.EventHandler(this.txtObs_Validated);
            this.txtObs.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Obs.:";
            // 
            // lnkAlterar
            // 
            this.lnkAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAlterar.AutoSize = true;
            this.lnkAlterar.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.lnkAlterar.Location = new System.Drawing.Point(273, 16);
            this.lnkAlterar.Name = "lnkAlterar";
            this.lnkAlterar.Size = new System.Drawing.Size(86, 13);
            this.lnkAlterar.TabIndex = 20;
            this.lnkAlterar.TabStop = true;
            this.lnkAlterar.Text = "Alterar descrição";
            this.lnkAlterar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAlterar_LinkClicked);
            this.lnkAlterar.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // DadosEndereço
            // 
            this.AutoSize = true;
            this.Controls.Add(this.grp);
            this.MaximumSize = new System.Drawing.Size(640, 238);
            this.MinimumSize = new System.Drawing.Size(365, 200);
            this.Name = "DadosEndereço";
            this.Size = new System.Drawing.Size(365, 200);
            this.Load += new System.EventHandler(this.DadosEndereço_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.DadosEndereço_Validating);
            this.EnabledChanged += new System.EventHandler(this.Endereço_EnabledChanged);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void Endereço_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control controle in Controls)
                controle.Enabled = this.Enabled;
        }

        private void txtDescrição_Validated(object sender, EventArgs e)
        {
            endereço.Descrição = txtDescrição.Text.Trim();
        }

        private void txtDescrição_Leave(object sender, EventArgs e)
        {
            grp.Text = "Endereço: " + txtDescrição.Text;
            txtDescrição.Visible = false;
        }

        private void lnkAlterar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDescrição.Visible = true;
            txtDescrição.Focus();
        }

        private void txtDescrição_Enter(object sender, EventArgs e)
        {
            txtDescrição.SelectAll();
        }

        private void txtDescrição_Validating(object sender, CancelEventArgs e)
        {
            bool ok;

            string strDescrição = txtDescrição.Text.Trim();

            ok = strDescrição.Length > 0;

            if (ok && endereço.Pessoa != null)
                foreach (Entidades.Pessoa.Endereço.Endereço outro in endereço.Pessoa.Endereços)
                    if (outro != endereço && string.Compare(outro.Descrição, strDescrição, true) == 0)
                    {
                        MessageBox.Show(
                            ParentForm,
                            "A descrição do endereço não pode se repetir. Por favor, altere a descrição.",
                            "Edição de endereço",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        ok = false;

                        txtDescrição.Visible = true;
                        txtDescrição.SelectAll();
                        txtDescrição.Focus();

                        break;
                    }

            e.Cancel = !ok;
        }

        private void txtCEP_Validated(object sender, EventArgs e)
        {
        }

        private void txtLogradouro_Validated(object sender, EventArgs e)
        {
            endereço.Logradouro = txtLogradouro.Text;
        }

        private void txtNúmero_Validated(object sender, EventArgs e)
        {
            endereço.Número = txtNúmero.Text;
        }

        private void txtComplemento_Validated(object sender, EventArgs e)
        {
            string str = txtComplemento.Text.Trim();

            if (str.Length > 0)
            {
                endereço.Complemento = txtComplemento.Text;

                if (txtComplemento.Text != endereço.Complemento)
                    txtComplemento.Text = endereço.Complemento;
            }
            else
                endereço.Complemento = null;
        }

        private void txtBairro_Validated(object sender, EventArgs e)
        {
            string str = txtBairro.Text.Trim();

            if (str.Length > 0)
                endereço.Bairro = txtBairro.Text;
            else
                endereço.Bairro = null;
        }

        private void txtLocalidade_Validated(object sender, EventArgs e)
        {
            endereço.Localidade = txtLocalidade.Localidade;
        }

        private void txtObs_Validated(object sender, EventArgs e)
        {
            if (txtObs.Text.Trim().Length > 0)
                endereço.Observações = txtObs.Text;
            else
                endereço.Observações = null;
        }

        private void DadosEndereço_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                txtDescrição.Visible = false;
        }

        private void AoFocarControle(object sender, EventArgs e)
        {
            OnGotFocus(e);
        }

        private void lblComplemento_Click(object sender, EventArgs e)
        {
            txtComplemento.Focus();
        }

        private void AoFocarComplemento(object sender, EventArgs e)
        {
            lblComplemento.Visible = false;
            AoFocarControle(sender, e);
        }

        private void DadosEndereço_Validating(object sender, CancelEventArgs e)
        {
            if (endereço != null)
            {
                if (endereço.Localidade == null)
                {
                    MessageBox.Show(
                        ParentForm,
                        "A localidade do endereço " + endereço.Descrição + " deve ser preenchida.",
                        "Edição de endereço", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true;
                }
            }
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            endereço.CEP = RegexCEP.Replace(txtCEP.Text, "${prefixo}-${sufixo}");
            txtCEP.Text = endereço.CEP;

            CEP cep = CEP.ObterCEP(endereço.CEP);

            if (cep != null)
            {
                endereço.Localidade = cep.Localidade;

                if (cep.Logradouro != null)
                    endereço.Logradouro = cep.Logradouro;

                endereço.Bairro = cep.Bairro;

                this.txtLogradouro.Text = endereço.Logradouro;
                this.txtBairro.Text = endereço.Bairro;
                this.txtLocalidade.Localidade = endereço.Localidade;
                this.txtNúmero.Focus();
            }

        }
    }
}
