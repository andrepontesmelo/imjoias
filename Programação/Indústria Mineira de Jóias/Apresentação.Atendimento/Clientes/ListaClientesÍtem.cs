using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Negócio;
using Negócio.Observador;
using Observador;

namespace Apresentação.Atendimento.Clientes
{
	/// <summary>
	/// Ítem que será incluso a uma lista de clientes
	/// </summary>
	[Serializable]
	public class ListaClientesÍtem : System.Windows.Forms.UserControl, IComparable
	{
		// Atributos
		private IVisitante			visitante = null;
//		private EventoObservação	observaçãoVisitante;

		// Eventos
		public event EventHandler	Desistência;
		public event EventHandler	Fechar;

		// Visual
		private System.Windows.Forms.PictureBox picFoto;
		private System.Windows.Forms.Label lblAtendente;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.Label lblDescrição;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ListaClientesÍtem()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

//			observaçãoVisitante = new Observador.EventoObservação(visitante_Observação);

			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.StandardClick, true);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ListaClientesÍtem));
			this.picFoto = new System.Windows.Forms.PictureBox();
			this.lblAtendente = new System.Windows.Forms.Label();
			this.lblCliente = new System.Windows.Forms.Label();
			this.lblDescrição = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// picFoto
			// 
			this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
			this.picFoto.Location = new System.Drawing.Point(8, 8);
			this.picFoto.Name = "picFoto";
			this.picFoto.Size = new System.Drawing.Size(54, 72);
			this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picFoto.TabIndex = 0;
			this.picFoto.TabStop = false;
			this.picFoto.Click += new System.EventHandler(this.ClickInterno);
			this.picFoto.MouseEnter += new System.EventHandler(this.ListaClientesÍtem_MouseEnter);
			this.picFoto.MouseLeave += new System.EventHandler(this.ListaClientesÍtem_MouseLeave);
			// 
			// lblAtendente
			// 
			this.lblAtendente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblAtendente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblAtendente.ForeColor = System.Drawing.Color.Black;
			this.lblAtendente.Location = new System.Drawing.Point(72, 8);
			this.lblAtendente.Name = "lblAtendente";
			this.lblAtendente.Size = new System.Drawing.Size(232, 23);
			this.lblAtendente.TabIndex = 1;
			this.lblAtendente.Text = "?";
			this.lblAtendente.UseMnemonic = false;
			this.lblAtendente.Click += new System.EventHandler(this.ClickInterno);
			this.lblAtendente.MouseEnter += new System.EventHandler(this.ListaClientesÍtem_MouseEnter);
			this.lblAtendente.MouseLeave += new System.EventHandler(this.ListaClientesÍtem_MouseLeave);
			// 
			// lblCliente
			// 
			this.lblCliente.AutoSize = true;
			this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCliente.ForeColor = System.Drawing.Color.Black;
			this.lblCliente.Location = new System.Drawing.Point(72, 32);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(13, 19);
			this.lblCliente.TabIndex = 2;
			this.lblCliente.Text = "?";
			this.lblCliente.UseMnemonic = false;
			this.lblCliente.Click += new System.EventHandler(this.ClickInterno);
			this.lblCliente.MouseEnter += new System.EventHandler(this.ListaClientesÍtem_MouseEnter);
			this.lblCliente.MouseLeave += new System.EventHandler(this.ListaClientesÍtem_MouseLeave);
			// 
			// lblDescrição
			// 
			this.lblDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescrição.ForeColor = System.Drawing.Color.Blue;
			this.lblDescrição.Location = new System.Drawing.Point(72, 56);
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(232, 16);
			this.lblDescrição.TabIndex = 3;
			this.lblDescrição.Text = "Vazio";
			this.lblDescrição.UseMnemonic = false;
			this.lblDescrição.Click += new System.EventHandler(this.ClickInterno);
			this.lblDescrição.MouseEnter += new System.EventHandler(this.ListaClientesÍtem_MouseEnter);
			this.lblDescrição.MouseLeave += new System.EventHandler(this.ListaClientesÍtem_MouseLeave);
			// 
			// ListaClientesÍtem
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(235)), ((System.Byte)(235)), ((System.Byte)(218)));
			this.Controls.Add(this.lblDescrição);
			this.Controls.Add(this.lblCliente);
			this.Controls.Add(this.lblAtendente);
			this.Controls.Add(this.picFoto);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Name = "ListaClientesÍtem";
			this.Size = new System.Drawing.Size(312, 88);
			this.MouseEnter += new System.EventHandler(this.ListaClientesÍtem_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.ListaClientesÍtem_MouseLeave);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Visitante
		/// </summary>
		[Browsable(false), DefaultValue(null)]
		public IVisitante Visitante
		{
			get { return visitante; }
			set
			{
				visitante = value;

				// Recupera dados do cliente
				lblCliente.Text	= visitante.PessoaFísica.Nome;
				
				if (visitante.Acompanhantes.Count > 0)
					lblDescrição.Text = visitante.Acompanhantes.Count.ToString() + " acompanhante(s)\n";
				else
					lblDescrição.Text = "";

				lblDescrição.Text += "Motivo: " + visitante.MotivoTexto;

				// Recupera dados do atendente
				RecuperarDadosAtendente();

				// Prepara observação
//				visitante.Observação += observaçãoVisitante;
			}
		}

		/// <summary>
		/// Recupera dados do atendente e altera visualização
		/// </summary>
		private void RecuperarDadosAtendente()
		{
			if (visitante.Visita.Atendente == null)
				lblAtendente.Text = "Espera...";
			else
			{
				lblAtendente.Text = visitante.Visita.Atendente != null ?
					visitante.Visita.Atendente.Nome : "Espera...";

				if (visitante.Visita.Atendente.Foto != null)
					picFoto.Image = Image.FromStream(visitante.Visita.Atendente.Foto);
			}
		}

		/// <summary>
		/// Ocorre quando um visitante altera seu estado
		/// </summary>
		public void visitante_Observação(Observador.ISujeito sujeito, int ação, object dados)
		{
			switch ((AçãoVisitante) ação)
			{
				case AçãoVisitante.Atendimento:
					RecuperarDadosAtendente();
					break;

				case AçãoVisitante.Desistiu:
					MostrarDesistência();
					break;
			}
		}

		/// <summary>
		/// Ocorre quando visitante desiste de atendimento
		/// </summary>
		private void MostrarDesistência()
		{
			lblAtendente.Text = "DESISTÊNCIA";
			lblAtendente.ForeColor = Color.White;
			lblAtendente.BackColor = Color.Red;

			lblDescrição.Text = "Tempo de espera: " + visitante.Espera.ToString();

			if (Desistência != null)
				Desistência(this, null);
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			if (visitante == null)
				return this.GetHashCode().CompareTo(obj.GetHashCode());

			return visitante.CompareTo(obj);
		}

		#endregion

		private void ListaClientesÍtem_MouseLeave(object sender, System.EventArgs e)
		{
			lblAtendente.ForeColor = Color.Black;
			lblCliente.ForeColor = Color.Black;
			this.BackColor = Color.FromArgb(235, 235, 218);
		}

		private void ListaClientesÍtem_MouseEnter(object sender, System.EventArgs e)
		{
			lblAtendente.ForeColor = Color.Red;
			lblCliente.ForeColor = Color.Red;
			this.BackColor = Color.WhiteSmoke;
		}

		private void ClickInterno(object sender, System.EventArgs e)
		{
			this.OnClick(e);
		}
	}
}
