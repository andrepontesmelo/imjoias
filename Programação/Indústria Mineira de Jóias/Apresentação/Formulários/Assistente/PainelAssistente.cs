using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios.Assistente
{
	/// <summary>
	/// Painel do assistente
	/// </summary>
	public sealed class PainelAssistente : Panel
	{
		public event EventHandler			Exibido;
		public event CancelEventHandler		ValidandoTransi��o;
		
		/// <summary>
		/// Valida o painel
		/// </summary>
		/// <returns></returns>
		internal bool ValidarTransi��o()
		{
			if (ValidandoTransi��o == null)
				return true;

			CancelEventArgs e = new CancelEventArgs(false);

			ValidandoTransi��o(this, e);

			return !e.Cancel;
		}

		/// <summary>
		/// Ocorre ao mudar a exibi��o
		/// </summary>
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged (e);

			if (this.Visible && Exibido != null)
				Exibido(this, e);
		}
	}
}
