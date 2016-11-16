using Apresentação.Atendimento.Comum;
using Entidades.Pessoa;
using System.Collections.Generic;
using System.ComponentModel;

namespace Apresentação.Atendimento.Clientes
{
    public class ListaEntidadePessoaItemBusca : ListaPessoasItemBusca
	{
		/// <summary>
		/// Pessoa que será mostrada.
		/// </summary>
		private Entidades.Pessoa.Pessoa pessoa;
		
		private delegate void DAtrPes(Entidades.Pessoa.Pessoa pessoa);
		private delegate void DAtrPesFís(PessoaFísica pessoa);
		private delegate void DAtrPesJur(PessoaJurídica pessoa);

        private readonly int TAMANHO_MÁXIMO_CARACTERES_REGIÃO = 22; 
		private IContainer components = null;

		/// <summary>
		/// Constrói um item de lista com uma entidade pessoa.
		/// </summary>
		private ListaEntidadePessoaItemBusca()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Constrói um item de lista com uma entidade pessoa.
		/// </summary>
		/// <param name="pessoa">Pessoa</param>
		public ListaEntidadePessoaItemBusca(Entidades.Pessoa.Pessoa pessoa) : this()
		{
			this.pessoa = pessoa;		// Necessário para comparação assíncrona
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
                Primária = pessoa.Nome;

                if (pessoa.Região != null)
                    AlterarTextoFonte(lblMeio, pessoa.Região.Nome, TAMANHO_MÁXIMO_CARACTERES_REGIÃO);

                List<Entidades.Pessoa.Endereço.Endereço> endereços
                   = pessoa.Endereços.ExtrairElementos();

                if (endereços.Count != 0
                    && (endereços[0].Localidade != null)
                    && (endereços[0].Localidade.Estado != null))
                {
                    Secundária = endereços[0].Localidade.Nome + " / " + endereços[0].Localidade.Estado.Sigla;
                }
			
                this.pessoa = pessoa;

                pnlÍcone.BackgroundImage = ControladorÍconePessoa.ObterÍconeComFundoECódigo(pessoa);
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

