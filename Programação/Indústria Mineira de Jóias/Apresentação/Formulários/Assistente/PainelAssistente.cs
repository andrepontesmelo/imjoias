using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Formulários.Assistente
{
	/// <summary>
	/// Painel do assistente
	/// </summary>
	public sealed class PainelAssistente : Panel
	{
		public event EventHandler			Exibido;
		public event CancelEventHandler		ValidandoTransição;
		
		/// <summary>
		/// Valida o painel
		/// </summary>
		/// <returns></returns>
		internal bool ValidarTransição()
		{
			if (ValidandoTransição == null)
				return true;

			CancelEventArgs e = new CancelEventArgs(false);

			ValidandoTransição(this, e);

			return !e.Cancel;
		}

		/// <summary>
		/// Ocorre ao mudar a exibição
		/// </summary>
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged (e);

			if (this.Visible && Exibido != null)
				Exibido(this, e);
		}
	}
}
