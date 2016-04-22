using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Pessoa.Endere�o;
using System.Text.RegularExpressions;


namespace Apresenta��o.Pessoa.Cadastro
{
	/// <summary>
	/// Summary description for Endere�o.
	/// </summary>
	public class DadosEndere�o : System.Windows.Forms.UserControl, Apresenta��o.Formul�rios.IEditorItem<Entidades.Pessoa.Endere�o.Endere�o>
	{
        private Entidades.Pessoa.Endere�o.Endere�o endere�o;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtLogradouro;
		private System.Windows.Forms.TextBox txtN�mero;
        private System.Windows.Forms.TextBox txtBairro;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtComplemento;
        private Apresenta��o.Pessoa.Endere�o.TextBoxLocalidade txtLocalidade;
        private Apresenta��o.Pessoa.Endere�o.TextBoxEstado txtEstado;
        private Apresenta��o.Pessoa.Endere�o.TextBoxPa�s txtPa�s;
        private FormatadorNome formatadorNome;
        private GroupBox grp;
        private TextBox txtDescri��o;
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

		public DadosEndere�o()
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
        public Entidades.Pessoa.Endere�o.Endere�o Item
        {
            get { return endere�o; }
            set
            {
                endere�o = value;

                grp.Text = "Endere�o: " + value.Descri��o;

                if (value.Descri��o == null || value.Descri��o.Length == 0)
                {
                    txtDescri��o.Text = "< descri��o (ex.: residencial) >";
                    txtDescri��o.SelectAll();
                    txtDescri��o.Visible = true;
                    txtDescri��o.Focus();
                }
                else
                {
                    this.txtDescri��o.Text = value.Descri��o;
                    txtDescri��o.Visible = false;
                }

                this.txtLogradouro.Text = value.Logradouro;
                this.txtN�mero.Text = value.N�mero;

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
                this.txtObs.Text = value.Observa��es;
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
            this.txtN�mero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtLocalidade = new Apresenta��o.Pessoa.Endere�o.TextBoxLocalidade();
            this.txtEstado = new Apresenta��o.Pessoa.Endere�o.TextBoxEstado();
            this.txtPa�s = new Apresenta��o.Pessoa.Endere�o.TextBoxPa�s();
            this.formatadorNome = new Apresenta��o.Pessoa.FormatadorNome(this.components);
            this.txtDescri��o = new System.Windows.Forms.TextBox();
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
            this.label2.Text = "N�mero:";
            // 
            // txtN�mero
            // 
            this.txtN�mero.Location = new System.Drawing.Point(70, 70);
            this.txtN�mero.Name = "txtN�mero";
            this.txtN�mero.Size = new System.Drawing.Size(40, 20);
            this.txtN�mero.TabIndex = 6;
            this.txtN�mero.Validated += new System.EventHandler(this.txtN�mero_Validated);
            this.txtN�mero.Enter += new System.EventHandler(this.AoFocarControle);
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
            this.label7.Text = "Pa�s:";
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
            this.txtLocalidade.TxtPa�s = this.txtPa�s;
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
            this.txtEstado.TxtPa�s = this.txtPa�s;
            this.txtEstado.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // txtPa�s
            // 
            this.txtPa�s.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPa�s.Location = new System.Drawing.Point(70, 123);
            this.txtPa�s.Name = "txtPa�s";
            this.txtPa�s.Size = new System.Drawing.Size(289, 20);
            this.txtPa�s.TabIndex = 17;
            this.txtPa�s.TxtEstado = this.txtEstado;
            this.txtPa�s.TxtLocalidade = this.txtLocalidade;
            this.txtPa�s.TxtPa�s = this.txtPa�s;
            this.txtPa�s.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // txtDescri��o
            // 
            this.txtDescri��o.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescri��o.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formatadorNome.SetFormatarNome(this.txtDescri��o, true);
            this.txtDescri��o.Location = new System.Drawing.Point(9, 0);
            this.txtDescri��o.Name = "txtDescri��o";
            this.txtDescri��o.Size = new System.Drawing.Size(350, 13);
            this.txtDescri��o.TabIndex = 0;
            this.txtDescri��o.Validated += new System.EventHandler(this.txtDescri��o_Validated);
            this.txtDescri��o.Leave += new System.EventHandler(this.txtDescri��o_Leave);
            this.txtDescri��o.Enter += new System.EventHandler(this.AoFocarControle);
            this.txtDescri��o.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescri��o_Validating);
            // 
            // grp
            // 
            this.grp.Controls.Add(this.txtCEP);
            this.grp.Controls.Add(this.lblComplemento);
            this.grp.Controls.Add(this.txtObs);
            this.grp.Controls.Add(this.label9);
            this.grp.Controls.Add(this.lnkAlterar);
            this.grp.Controls.Add(this.txtDescri��o);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.txtPa�s);
            this.grp.Controls.Add(this.txtLogradouro);
            this.grp.Controls.Add(this.txtEstado);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.txtLocalidade);
            this.grp.Controls.Add(this.txtN�mero);
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
            this.grp.Text = "Endere�o";
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
            this.lnkAlterar.Text = "Alterar descri��o";
            this.lnkAlterar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAlterar_LinkClicked);
            this.lnkAlterar.Enter += new System.EventHandler(this.AoFocarControle);
            // 
            // DadosEndere�o
            // 
            this.AutoSize = true;
            this.Controls.Add(this.grp);
            this.MaximumSize = new System.Drawing.Size(640, 238);
            this.MinimumSize = new System.Drawing.Size(365, 200);
            this.Name = "DadosEndere�o";
            this.Size = new System.Drawing.Size(365, 200);
            this.Load += new System.EventHandler(this.DadosEndere�o_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.DadosEndere�o_Validating);
            this.EnabledChanged += new System.EventHandler(this.Endere�o_EnabledChanged);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void Endere�o_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control controle in Controls)
                controle.Enabled = this.Enabled;
        }

        private void txtDescri��o_Validated(object sender, EventArgs e)
        {
            endere�o.Descri��o = txtDescri��o.Text.Trim();
        }

        private void txtDescri��o_Leave(object sender, EventArgs e)
        {
            grp.Text = "Endere�o: " + txtDescri��o.Text;
            txtDescri��o.Visible = false;
        }

        private void lnkAlterar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDescri��o.Visible = true;
            txtDescri��o.Focus();
        }

        private void txtDescri��o_Enter(object sender, EventArgs e)
        {
            txtDescri��o.SelectAll();
        }

        private void txtDescri��o_Validating(object sender, CancelEventArgs e)
        {
            bool ok;

            string strDescri��o = txtDescri��o.Text.Trim();

            ok = strDescri��o.Length > 0;

            if (ok && endere�o.Pessoa != null)
                foreach (Entidades.Pessoa.Endere�o.Endere�o outro in endere�o.Pessoa.Endere�os)
                    if (outro != endere�o && string.Compare(outro.Descri��o, strDescri��o, true) == 0)
                    {
                        MessageBox.Show(
                            ParentForm,
                            "A descri��o do endere�o n�o pode se repetir. Por favor, altere a descri��o.",
                            "Edi��o de endere�o",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        ok = false;

                        txtDescri��o.Visible = true;
                        txtDescri��o.SelectAll();
                        txtDescri��o.Focus();

                        break;
                    }

            e.Cancel = !ok;
        }

        private void txtCEP_Validated(object sender, EventArgs e)
        {
        }

        private void txtLogradouro_Validated(object sender, EventArgs e)
        {
            endere�o.Logradouro = txtLogradouro.Text;
        }

        private void txtN�mero_Validated(object sender, EventArgs e)
        {
            endere�o.N�mero = txtN�mero.Text;
        }

        private void txtComplemento_Validated(object sender, EventArgs e)
        {
            string str = txtComplemento.Text.Trim();

            if (str.Length > 0)
            {
                endere�o.Complemento = txtComplemento.Text;

                if (txtComplemento.Text != endere�o.Complemento)
                    txtComplemento.Text = endere�o.Complemento;
            }
            else
                endere�o.Complemento = null;
        }

        private void txtBairro_Validated(object sender, EventArgs e)
        {
            string str = txtBairro.Text.Trim();

            if (str.Length > 0)
                endere�o.Bairro = txtBairro.Text;
            else
                endere�o.Bairro = null;
        }

        private void txtLocalidade_Validated(object sender, EventArgs e)
        {
            endere�o.Localidade = txtLocalidade.Localidade;
        }

        private void txtObs_Validated(object sender, EventArgs e)
        {
            if (txtObs.Text.Trim().Length > 0)
                endere�o.Observa��es = txtObs.Text;
            else
                endere�o.Observa��es = null;
        }

        private void DadosEndere�o_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                txtDescri��o.Visible = false;
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

        private void DadosEndere�o_Validating(object sender, CancelEventArgs e)
        {
            if (endere�o != null)
            {
                if (endere�o.Localidade == null)
                {
                    MessageBox.Show(
                        ParentForm,
                        "A localidade do endere�o " + endere�o.Descri��o + " deve ser preenchida.",
                        "Edi��o de endere�o", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true;
                }
            }
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            endere�o.CEP = RegexCEP.Replace(txtCEP.Text, "${prefixo}-${sufixo}");
            txtCEP.Text = endere�o.CEP;

            CEP cep = CEP.ObterCEP(endere�o.CEP);

            if (cep != null)
            {
                endere�o.Localidade = cep.Localidade;

                if (cep.Logradouro != null)
                    endere�o.Logradouro = cep.Logradouro;

                endere�o.Bairro = cep.Bairro;

                this.txtLogradouro.Text = endere�o.Logradouro;
                this.txtBairro.Text = endere�o.Bairro;
                this.txtLocalidade.Localidade = endere�o.Localidade;
                this.txtN�mero.Focus();
            }

        }
    }
}
