using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Pessoa;
using System.Collections.Generic;
using Entidades;
using Apresentação.Atendimento.Comum;

namespace Apresentação.Atendimento.Clientes
{
	public class ListaEntidadePessoaItemBusca : Apresentação.Atendimento.Comum.ListaPessoasItemBusca
	{
		/// <summary>
		/// Pessoa que será mostrada.
		/// </summary>
		private Entidades.Pessoa.Pessoa pessoa;
		
		private delegate void DAtrPes(Entidades.Pessoa.Pessoa pessoa);
		private delegate void DAtrPesFís(PessoaFísica pessoa);
		private delegate void DAtrPesJur(PessoaJurídica pessoa);
		
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói um item de lista com uma entidade pessoa.
		/// </summary>
		private ListaEntidadePessoaItemBusca()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
        ///// <summary>
        ///// Constrói um item de lista com uma entidade pessoa-física.
        ///// </summary>
        ///// <param name="pessoa">Pessoa-física.</param>
        //public ListaEntidadePessoaItemBusca(PessoaFísica pessoa) : this()
        //{
        //    AtribuirPessoa(pessoa);
        //}

        ///// <summary>
        ///// Constrói um item de lista com uma entidade pessoa-física.
        ///// </summary>
        ///// <param name="pessoa">Pessoa-física.</param>
        //public ListaEntidadePessoaItemBusca(PessoaJurídica pessoa) : this()
        //{
        //    AtribuirPessoa(pessoa);
        //}

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
                    //if (typeof(PessoaFísica).IsInstanceOfType(value))
                    //    AtribuirPessoa((PessoaFísica)value);

                    //else if (typeof(PessoaJurídica).IsInstanceOfType(value))
                    //    AtribuirPessoa((PessoaJurídica)value);

                    //else
                    
                    AtribuirPessoa(value);
				}
			}
		}

		private void AtribuirPessoa(Entidades.Pessoa.Pessoa pessoa)
		{
			lock (this)
			{
                Primária = pessoa.Nome;

                //lblDescrição.Text = pessoa.Código.ToString();

                
                if (pessoa.Região != null)
                    lblMeio.Text = pessoa.Região.Nome;

                List<Entidades.Pessoa.Endereço.Endereço> endereços
                   = pessoa.Endereços.ExtrairElementos();

                if (endereços.Count != 0
                    && (endereços[0].Localidade != null)
                    && (endereços[0].Localidade.Estado != null))
                {
                    //if (pessoa.Região != null)
                    //    lblSecundária.Text += ", ";

                    Secundária = endereços[0].Localidade.Nome + " / " + endereços[0].Localidade.Estado.Sigla;
                }
			
                this.pessoa        = pessoa;

                pnlÍcone.BackgroundImage = ControladorÍconePessoa.ObterÍconeComFundoECódigo(pessoa);
			}
		}

        ///// <summary>
        ///// Atribui ao item uma pessoa-jurídica.
        ///// </summary>
        ///// <param name="pessoa">Pessoa-jurídica.</param>
        //private void AtribuirPessoa(PessoaJurídica pessoa)
        //{
        //    lock (this)
        //    {
        //        lblPrimária.Text   = pessoa.Nome;
        //        lblSecundária.Text = "CNPJ: " + pessoa.CNPJ;
        //        lblDescrição.Text  = pessoa.Setor.Nome;
        //        this.pessoa        = pessoa;

        //        if (pessoa.Foto != null)
        //            picFoto.Image = pessoa.Foto;
        //    }
        //}

        ///// <summary>
        ///// Atribui ao item uma pessoa.
        ///// </summary>
        ///// <param name="pessoa">Pessoa</param>
        //private void AtribuirPessoa(Entidades.Pessoa.Pessoa pessoa)
        //{
        //    lock (this)
        //    {
        //        lblPrimária.Text   = pessoa.Nome;
        //        lblSecundária.Text = "";
        //        lblDescrição.Text  = pessoa.Setor.Nome;
        //        this.pessoa        = pessoa;

        //        if (pessoa.Foto != null)
        //            picFoto.Image  = pessoa.Foto;
        //    }
        //}
		
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

		public override int CompareTo(object obj)
		{
			if (typeof(ListaEntidadePessoaItemBusca).IsInstanceOfType(obj))
				return Pessoa.CompareTo(((ListaEntidadePessoaItemBusca) obj).Pessoa);
			else
				return base.CompareTo (obj);
		}
	}
}

