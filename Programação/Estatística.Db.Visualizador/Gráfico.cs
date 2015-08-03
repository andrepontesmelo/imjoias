using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Estatística.Db.Visualizador
{
	/// <summary>
	/// Summary description for Gráfico.
	/// </summary>
	public class Gráfico : System.Windows.Forms.Form
	{
		private Estatística.Gráfico gráfico1;
		private Estatística.Legenda legenda;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Gráfico(IDbConnection conexão, IDataParameterCollection parâmetros, Estatística.Db.Gráfico gráfico, string título)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Text = título;

			try
			{
				gráfico.ConfigurarGráfico(conexão, parâmetros, título, this.gráfico1);
			}
			catch (Estatística.Db.ExceçãoDefiniçãoIncorreta e)
			{
				MessageBox.Show("Ocorreu o seguinte erro de definição do gráfico " + título + "\n\n" + e.ToString());
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
			this.gráfico1 = new Estatística.Gráfico();
			this.legenda = new Estatística.Legenda();
			this.SuspendLayout();
			// 
			// gráfico1
			// 
			this.gráfico1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gráfico1.BackColor = System.Drawing.Color.White;
			this.gráfico1.Dados = null;
			this.gráfico1.EixoX = "Eixo X";
			this.gráfico1.EixoY = "Eixo Y";
			this.gráfico1.EstiloDesenho = Estatística.Estilo.Linhas;
			this.gráfico1.ForçarEscritaValoresX = false;
			this.gráfico1.FundoCor = System.Drawing.Color.White;
			this.gráfico1.GapHorizontal = 0;
			this.gráfico1.GapVertical = 20;
			this.gráfico1.GradeHorizontal = true;
			this.gráfico1.GradeVertical = true;
			this.gráfico1.Legendas = null;
			this.gráfico1.Location = new System.Drawing.Point(0, 0);
			this.gráfico1.MaxX = -1;
			this.gráfico1.MaxY = 0;
			this.gráfico1.MinX = 0;
			this.gráfico1.MinY = 0;
			this.gráfico1.Name = "gráfico1";
			this.gráfico1.Size = new System.Drawing.Size(480, 216);
			this.gráfico1.TabIndex = 0;
			this.gráfico1.ValoresX = true;
			this.gráfico1.ValoresY = true;
			this.gráfico1.VérticeTamanho = 5F;
			this.gráfico1.VetorÚnico = null;
			// 
			// legenda
			// 
			this.legenda.AutoSize = false;
			this.legenda.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legenda.BordaCor = System.Drawing.Color.LightSteelBlue;
			this.legenda.Colunas = 4;
			this.legenda.Distanciamento = 2;
			this.legenda.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.legenda.Espaçamento = 5;
			this.legenda.Fonte = new System.Drawing.Font("Arial", 10F);
			this.legenda.FundoCor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(240)), ((System.Byte)(248)), ((System.Byte)(255)));
			this.legenda.Gráfico = this.gráfico1;
			this.legenda.Location = new System.Drawing.Point(0, 222);
			this.legenda.Name = "legenda";
			this.legenda.QuadradoTamanho = 4;
			this.legenda.Size = new System.Drawing.Size(480, 120);
			this.legenda.TabIndex = 1;
			// 
			// Gráfico
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 342);
			this.Controls.Add(this.legenda);
			this.Controls.Add(this.gráfico1);
			this.Name = "Gráfico";
			this.Text = "Gráfico";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
