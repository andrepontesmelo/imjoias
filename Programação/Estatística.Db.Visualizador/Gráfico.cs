using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Estat�stica.Db.Visualizador
{
	/// <summary>
	/// Summary description for Gr�fico.
	/// </summary>
	public class Gr�fico : System.Windows.Forms.Form
	{
		private Estat�stica.Gr�fico gr�fico1;
		private Estat�stica.Legenda legenda;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Gr�fico(IDbConnection conex�o, IDataParameterCollection par�metros, Estat�stica.Db.Gr�fico gr�fico, string t�tulo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Text = t�tulo;

			try
			{
				gr�fico.ConfigurarGr�fico(conex�o, par�metros, t�tulo, this.gr�fico1);
			}
			catch (Estat�stica.Db.Exce��oDefini��oIncorreta e)
			{
				MessageBox.Show("Ocorreu o seguinte erro de defini��o do gr�fico " + t�tulo + "\n\n" + e.ToString());
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.gr�fico1 = new Estat�stica.Gr�fico();
			this.legenda = new Estat�stica.Legenda();
			this.SuspendLayout();
			// 
			// gr�fico1
			// 
			this.gr�fico1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gr�fico1.BackColor = System.Drawing.Color.White;
			this.gr�fico1.Dados = null;
			this.gr�fico1.EixoX = "Eixo X";
			this.gr�fico1.EixoY = "Eixo Y";
			this.gr�fico1.EstiloDesenho = Estat�stica.Estilo.Linhas;
			this.gr�fico1.For�arEscritaValoresX = false;
			this.gr�fico1.FundoCor = System.Drawing.Color.White;
			this.gr�fico1.GapHorizontal = 0;
			this.gr�fico1.GapVertical = 20;
			this.gr�fico1.GradeHorizontal = true;
			this.gr�fico1.GradeVertical = true;
			this.gr�fico1.Legendas = null;
			this.gr�fico1.Location = new System.Drawing.Point(0, 0);
			this.gr�fico1.MaxX = -1;
			this.gr�fico1.MaxY = 0;
			this.gr�fico1.MinX = 0;
			this.gr�fico1.MinY = 0;
			this.gr�fico1.Name = "gr�fico1";
			this.gr�fico1.Size = new System.Drawing.Size(480, 216);
			this.gr�fico1.TabIndex = 0;
			this.gr�fico1.ValoresX = true;
			this.gr�fico1.ValoresY = true;
			this.gr�fico1.V�rticeTamanho = 5F;
			this.gr�fico1.Vetor�nico = null;
			// 
			// legenda
			// 
			this.legenda.AutoSize = false;
			this.legenda.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legenda.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legenda.Colunas = 4;
			this.legenda.Distanciamento = 2;
			this.legenda.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.legenda.Espa�amento = 5;
			this.legenda.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legenda.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legenda.Gr�fico = this.gr�fico1;
			this.legenda.Location = new System.Drawing.Point(0, 222);
			this.legenda.Name = "legenda";
			this.legenda.QuadradoTamanho = 4;
			this.legenda.Size = new System.Drawing.Size(480, 120);
			this.legenda.TabIndex = 1;
			// 
			// Gr�fico
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 342);
			this.Controls.Add(this.legenda);
			this.Controls.Add(this.gr�fico1);
			this.Name = "Gr�fico";
			this.Text = "Gr�fico";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
