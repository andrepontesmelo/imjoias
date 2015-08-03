using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Entidades.Pessoa;
using Entidades;

namespace Apresenta��o.Atendimento.Atendente
{
	/// <summary>
	/// Item da lista de pessoas para funcion�rio
	/// </summary>
	[Serializable]
	public class ListaFuncion�rioItem : Apresenta��o.Atendimento.Comum.ListaPessoasItem
	{
        private Funcion�rio funcion�rio;

		// Componentes
		private System.ComponentModel.IContainer components = null;

		public ListaFuncion�rioItem()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Constr�i o item atribuindo o funcion�rio.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio a constar no item.</param>
		public ListaFuncion�rioItem(Funcion�rio funcion�rio) : this()
		{
			Funcion�rio = funcion�rio;
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
		/// Funcion�rio
		/// </summary>
		[Browsable(false), DefaultValue(null)]
		public Funcion�rio Funcion�rio
		{
			get { return funcion�rio; }
			set
			{
				funcion�rio = value;

				// Recupera dados do funcion�rio
				lblPrim�ria.Text = funcion�rio.Nome;

                if (funcion�rio.Setor != null)
                    lblSecund�ria.Text = funcion�rio.Setor.Nome;
                else
                    lblSecund�ria.Text = "";
				
				ObterDescri��o();
			}
		}

		
		/// <summary>
		/// Obt�m descri��o para exibi��o do funcion�rio.
		/// </summary>
		private void ObterDescri��o()
		{
            switch (funcion�rio.Situa��o)
            {
                case EstadoFuncion�rio.Atendendo:
                    lblDescri��o.Text = "Atendendo " + Visita.ExtrairNomes(Visita.ObterAtendimentos(funcion�rio));
                    break;

                case EstadoFuncion�rio.Ausente:
                    lblDescri��o.Text = "Ausente";
                    break;

                case EstadoFuncion�rio.Dispon�vel:
                    lblDescri��o.Text = "";
                    break;

                case EstadoFuncion�rio.Ocupado:
                    lblDescri��o.Text = "Ocupado";
                    break;

                default:
                    lblDescri��o.Text = "";
                    break;
            }
		}
	}
}

