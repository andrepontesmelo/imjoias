using System;
using System.Collections;
using Acesso.Comum;
using Negócio.Fachada;

namespace Apresentação.Álbum
{
	/// <summary>
	/// Trata-se de uma lista de ItemFoto associada a uma ListaFoto.
	/// Na construtora, define-se a qual lista deseja-se associar.
	/// 
	/// Porque precisa ser associada a uma lista ? 
	/// a coleção adiciona o item no controle da lista.
	///
	/// Adicionar Itens:
	/// ======================
	/// .Add		pode-se adicionar um ItemFoto (Controle)
	/// .Add		ou alternativamente, uma entidade de album (Foto)
	/// .AddRange	pode-se adicionar uma coleção de ItemFoto.
	/// 
	/// O método de adicionar é alterado de forma a já adicionar
	/// o novo item à lista.
	/// 
	/// Obtenção de Itens:
	/// ======================
	/// .ObterItemFoto(int código)  obtém um item através do código da foto
	/// </summary>
	public class ColeçãoItemFoto : ArrayList
	{
		// Atributos
		private ListaFoto	controleLista;
		private Hashtable	itemFotoCód = new Hashtable();
		
		// Eventos

		/// <summary>
		/// O item está em uma posição fora da area de visibilidade,
		/// provavelmente porque o usuário realizou um scroll.
		/// </summary>
		public event EventHandler ItemEscondeu;
		public event EventHandler ItemClicado;
		public event EventHandler ItemApareceu;

		// Construtora
		public ColeçãoItemFoto(ListaFoto controleLista)
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
			itemFotoCód[item.Entidade.Código] = item;
		}

		public void Add(Entidades.Álbum.Foto entidade)
		{
			this.Add(new ItemFoto(entidade));
		}

		/// <summary>
		/// Adiciona uma coleção de ItemFoto
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
				itemFotoCód[item.Entidade.Código] = item;
			}

		
			base.AddRange(c);
			base.Sort();

			controleLista.Reorganizar();
			controleLista.ResumeLayout();
			controleLista.Visible = true;
		}
		
		/// <summary>
		/// É possível obter externamente o controle ItemFoto
		/// através do código
		/// </summary>
		/// <param name="código">chave primaria do album</param>
		public ItemFoto ObterItemFoto(int código)
		{
			return itemFotoCód[código] as ItemFoto;
		}

		#region Re-transmissão dos eventos dos Itens

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
