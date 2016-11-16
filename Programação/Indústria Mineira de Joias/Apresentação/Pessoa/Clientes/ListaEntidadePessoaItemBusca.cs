using Apresenta��o.Atendimento.Comum;
using Entidades.Pessoa;
using System.Collections.Generic;
using System.ComponentModel;

namespace Apresenta��o.Atendimento.Clientes
{
    public class ListaEntidadePessoaItemBusca : ListaPessoasItemBusca
	{
		/// <summary>
		/// Pessoa que ser� mostrada.
		/// </summary>
		private Entidades.Pessoa.Pessoa pessoa;
		
		private delegate void DAtrPes(Entidades.Pessoa.Pessoa pessoa);
		private delegate void DAtrPesF�s(PessoaF�sica pessoa);
		private delegate void DAtrPesJur(PessoaJur�dica pessoa);

        private readonly int TAMANHO_M�XIMO_CARACTERES_REGI�O = 22; 
		private IContainer components = null;

		/// <summary>
		/// Constr�i um item de lista com uma entidade pessoa.
		/// </summary>
		private ListaEntidadePessoaItemBusca()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Constr�i um item de lista com uma entidade pessoa.
		/// </summary>
		/// <param name="pessoa">Pessoa</param>
		public ListaEntidadePessoaItemBusca(Entidades.Pessoa.Pessoa pessoa) : this()
		{
			this.pessoa = pessoa;		// Necess�rio para compara��o ass�ncrona
			this.Pessoa = pessoa;		// Realmente atribui os dados
		}

		/// <summary>
		/// Pessoa.
		/// </summary>
		public Entidades.Pessoa.Pessoa Pessoa
		{
			get { return pessoa; }
			set
			{
				lock (this)
				{
                    AtribuirPessoa(value);
				}
			}
		}

		private void AtribuirPessoa(Entidades.Pessoa.Pessoa pessoa)
		{
			lock (this)
			{
                Prim�ria = pessoa.Nome;

                if (pessoa.Regi�o != null)
                    AlterarTextoFonte(lblMeio, pessoa.Regi�o.Nome, TAMANHO_M�XIMO_CARACTERES_REGI�O);

                List<Entidades.Pessoa.Endere�o.Endere�o> endere�os
                   = pessoa.Endere�os.ExtrairElementos();

                if (endere�os.Count != 0
                    && (endere�os[0].Localidade != null)
                    && (endere�os[0].Localidade.Estado != null))
                {
                    Secund�ria = endere�os[0].Localidade.Nome + " / " + endere�os[0].Localidade.Estado.Sigla;
                }
			
                this.pessoa = pessoa;

                pnl�cone.BackgroundImage = Controlador�conePessoa.Obter�coneComFundoEC�digo(pessoa);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}

			base.Dispose(disposing);
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

		public override int CompareTo(object obj)
		{
			if (typeof(ListaEntidadePessoaItemBusca).IsInstanceOfType(obj))
				return Pessoa.CompareTo(((ListaEntidadePessoaItemBusca) obj).Pessoa);
			else
				return base.CompareTo(obj);
		}
	}
}

