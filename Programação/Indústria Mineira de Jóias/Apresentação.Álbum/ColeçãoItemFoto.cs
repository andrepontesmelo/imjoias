using System;
using System.Collections;
using Acesso.Comum;
using Neg�cio.Fachada;

namespace Apresenta��o.�lbum
{
	/// <summary>
	/// Trata-se de uma lista de ItemFoto associada a uma ListaFoto.
	/// Na construtora, define-se a qual lista deseja-se associar.
	/// 
	/// Porque precisa ser associada a uma lista ? 
	/// a cole��o adiciona o item no controle da lista.
	///
	/// Adicionar Itens:
	/// ======================
	/// .Add		pode-se adicionar um ItemFoto (Controle)
	/// .Add		ou alternativamente, uma entidade de album (Foto)
	/// .AddRange	pode-se adicionar uma cole��o de ItemFoto.
	/// 
	/// O m�todo de adicionar � alterado de forma a j� adicionar
	/// o novo item � lista.
	/// 
	/// Obten��o de Itens:
	/// ======================
	/// .ObterItemFoto(int c�digo)  obt�m um item atrav�s do c�digo da foto
	/// </summary>
	public class Cole��oItemFoto : ArrayList
	{
		// Atributos
		private ListaFoto	controleLista;
		private Hashtable	itemFotoC�d = new Hashtable();
		
		// Eventos

		/// <summary>
		/// O item est� em uma posi��o fora da area de visibilidade,
		/// provavelmente porque o usu�rio realizou um scroll.
		/// </summary>
		public event EventHandler ItemEscondeu;
		public event EventHandler ItemClicado;
		public event EventHandler ItemApareceu;

		// Construtora
		public Cole��oItemFoto(ListaFoto controleLista)
		{
			this.controleLista = controleLista;
		}

		public void Add(ItemFoto item)
		{
			// Insere na lista
			base.Add(item);
			base.Sort();

			// Insere no visual da lista
			controleLista.Controls.Add(item);
			
			// Reorganiza dono
			controleLista.Reorganizar();

			// Trata eventos
			//item.Selecionado += new EventHandler(item_Selecionado);
			item.Click += new EventHandler(item_Click);
			item.Escondeu += new EventHandler(item_Escondeu);

			// Adiciona na hash
			itemFotoC�d[item.Entidade.C�digo] = item;
		}

		public void Add(Entidades.�lbum.Foto entidade)
		{
			this.Add(new ItemFoto(entidade));
		}

		/// <summary>
		/// Adiciona uma cole��o de ItemFoto
		/// </summary>
		/// <param name="c">ItemFoto.</param>
		public override void AddRange(ICollection c)
		{
			controleLista.Visible = false;
			controleLista.SuspendLayout();

			foreach (ItemFoto item in c)
			{
				// Adiciona no controle
				controleLista.Controls.Add(item);
				
				// Cadastra eventos
				//item.Selecionado += new EventHandler(item_Selecionado);
				item.Escondeu += new EventHandler(item_Escondeu);
				item.Apareceu +=new EventHandler(item_Apareceu);
				item.Click += new EventHandler(item_Click);
				
				// Adiciona na hash
				itemFotoC�d[item.Entidade.C�digo] = item;
			}

		
			base.AddRange(c);
			base.Sort();

			controleLista.Reorganizar();
			controleLista.ResumeLayout();
			controleLista.Visible = true;
		}
		
		/// <summary>
		/// � poss�vel obter externamente o controle ItemFoto
		/// atrav�s do c�digo
		/// </summary>
		/// <param name="c�digo">chave primaria do album</param>
		public ItemFoto ObterItemFoto(int c�digo)
		{
			return itemFotoC�d[c�digo] as ItemFoto;
		}

		#region Re-transmiss�o dos eventos dos Itens

		private void item_Escondeu(object sender, EventArgs e)
		{
			ItemEscondeu(this, e);	
		}

		private void item_Click(object sender, EventArgs e)
		{
			ItemClicado(sender, e);
		}
		
		private void item_Apareceu(object sender, EventArgs e)
		{
			ItemApareceu(sender, e);
		}
		
		#endregion
	}
}
