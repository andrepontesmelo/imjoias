using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Entidades.Pessoa;
using Entidades;

namespace Apresentação.Atendimento.Atendente
{
	/// <summary>
	/// Item da lista de pessoas para funcionário
	/// </summary>
	[Serializable]
	public class ListaFuncionárioItem : Apresentação.Atendimento.Comum.ListaPessoasItem
	{
        private Funcionário funcionário;

		// Componentes
		private System.ComponentModel.IContainer components = null;

		public ListaFuncionárioItem()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Constrói o item atribuindo o funcionário.
		/// </summary>
		/// <param name="funcionário">Funcionário a constar no item.</param>
		public ListaFuncionárioItem(Funcionário funcionário) : this()
		{
			Funcionário = funcionário;
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		/// <summary>
		/// Funcionário
		/// </summary>
		[Browsable(false), DefaultValue(null)]
		public Funcionário Funcionário
		{
			get { return funcionário; }
			set
			{
				funcionário = value;

				// Recupera dados do funcionário
				lblPrimária.Text = funcionário.Nome;

                if (funcionário.Setor != null)
                    lblSecundária.Text = funcionário.Setor.Nome;
                else
                    lblSecundária.Text = "";
				
				ObterDescrição();
			}
		}

		
		/// <summary>
		/// Obtém descrição para exibição do funcionário.
		/// </summary>
		private void ObterDescrição()
		{
            switch (funcionário.Situação)
            {
                case EstadoFuncionário.Atendendo:
                    lblDescrição.Text = "Atendendo " + Visita.ExtrairNomes(Visita.ObterAtendimentos(funcionário));
                    break;

                case EstadoFuncionário.Ausente:
                    lblDescrição.Text = "Ausente";
                    break;

                case EstadoFuncionário.Disponível:
                    lblDescrição.Text = "";
                    break;

                case EstadoFuncionário.Ocupado:
                    lblDescrição.Text = "Ocupado";
                    break;

                default:
                    lblDescrição.Text = "";
                    break;
            }
		}
	}
}

