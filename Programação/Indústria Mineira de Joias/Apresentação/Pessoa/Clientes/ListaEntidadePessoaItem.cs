using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresenta��o.Atendimento.Clientes
{
	public class ListaEntidadePessoaItem : Apresenta��o.Atendimento.Comum.ListaPessoasItem
	{
		/// <summary>
		/// Pessoa que ser� mostrada.
		/// </summary>
		private Entidades.Pessoa.Pessoa pessoa;
		
		private delegate void DAtrPes(Entidades.Pessoa.Pessoa pessoa);
		private delegate void DAtrPesF�s(PessoaF�sica pessoa);
		private delegate void DAtrPesJur(PessoaJur�dica pessoa);
		
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i um item de lista com uma entidade pessoa.
		/// </summary>
		private ListaEntidadePessoaItem()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Constr�i um item de lista com uma entidade pessoa-f�sica.
		/// </summary>
		/// <param name="pessoa">Pessoa-f�sica.</param>
		public ListaEntidadePessoaItem(PessoaF�sica pessoa) : this()
		{
            AtribuirPessoa(pessoa);
		}

		/// <summary>
		/// Constr�i um item de lista com uma entidade pessoa-f�sica.
		/// </summary>
		/// <param name="pessoa">Pessoa-f�sica.</param>
		public ListaEntidadePessoaItem(PessoaJur�dica pessoa) : this()
		{
            AtribuirPessoa(pessoa);
		}

		/// <summary>
		/// Constr�i um item de lista com uma entidade pessoa.
		/// </summary>
		/// <param name="pessoa">Pessoa</param>
		public ListaEntidadePessoaItem(Entidades.Pessoa.Pessoa pessoa) : this()
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
                    if (typeof(PessoaF�sica).IsInstanceOfType(value))
                        AtribuirPessoa((PessoaF�sica)value);

                    else if (typeof(PessoaJur�dica).IsInstanceOfType(value))
                        AtribuirPessoa((PessoaJur�dica)value);

                    else
                        AtribuirPessoa(value);
				}
			}
		}

		/// <summary>
		/// Atribui ao item uma pessoa-f�sica.
		/// </summary>
		/// <param name="pessoa">Pessoa-f�sica.</param>
		private void AtribuirPessoa(PessoaF�sica pessoa)
		{
			lock (this)
			{
				lblPrim�ria.Text   = pessoa.Nome;
				lblSecund�ria.Text = "CPF: " + pessoa.CPF
					+ "\nRG: " + pessoa.DI + " (" + pessoa.DIEmissor + ")";
				lblDescri��o.Text  = pessoa.Setor.Nome;
				this.pessoa        = pessoa;

                //if (pessoa.Foto != null)
                //    picFoto.Image = pessoa.Foto;
			}
		}

		/// <summary>
		/// Atribui ao item uma pessoa-jur�dica.
		/// </summary>
		/// <param name="pessoa">Pessoa-jur�dica.</param>
		private void AtribuirPessoa(PessoaJur�dica pessoa)
		{
			lock (this)
			{
				lblPrim�ria.Text   = pessoa.Nome;
				lblSecund�ria.Text = "CNPJ: " + pessoa.CNPJ;
				lblDescri��o.Text  = pessoa.Setor.Nome;
				this.pessoa        = pessoa;

                //if (pessoa.Foto != null)
                //    picFoto.Image = pessoa.Foto;
			}
		}

		/// <summary>
		/// Atribui ao item uma pessoa.
		/// </summary>
		/// <param name="pessoa">Pessoa</param>
		private void AtribuirPessoa(Entidades.Pessoa.Pessoa pessoa)
		{
			lock (this)
			{
				lblPrim�ria.Text   = pessoa.Nome;
				lblSecund�ria.Text = "";
				lblDescri��o.Text  = pessoa.Setor.Nome;
				this.pessoa        = pessoa;

                //if (pessoa.Foto != null)
                //    picFoto.Image  = pessoa.Foto;
			}
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

		public override int CompareTo(object obj)
		{
			if (typeof(ListaEntidadePessoaItem).IsInstanceOfType(obj))
				return Pessoa.CompareTo(((ListaEntidadePessoaItem) obj).Pessoa);
			else
				return base.CompareTo (obj);
		}
	}
}

