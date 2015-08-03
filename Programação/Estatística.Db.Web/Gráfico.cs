using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Estat�stica.Db.Web
{
	/// <summary>
	/// Exibi��o de gr�fico
	/// </summary>
	[DefaultProperty("Text"),
	ToolboxData("<{0}:Gr�fico runat=server></{0}:Gr�fico>")]
	public class Gr�fico : System.Web.UI.WebControls.WebControl
	{
		#region Estruturas auxiliares

		public struct Requisito
		{
			private string chave;
			private string valor;

			public string Chave
			{
				get { return chave; }
				set { chave = value; }
			}

			public string Valor
			{
				get { return valor; }
				set { valor = value; }
			}

			public Requisito(string chave, string valor)
			{
				this.chave = chave;
				this.valor = valor;
			}
		}

		public class ListaRequisitos : ArrayList
		{
			public new Requisito this[int index]
			{
				get
				{
					return (Requisito) base[index];
				}
				set
				{
					base[index] = value;
				}
			}

			public void Add(string chave, string valor)
			{
				base.Add(new Requisito(chave, valor));
			}
		}

		#endregion

		private string			url;
		private string			refer�ncia;
		private ListaRequisitos requisitos = new ListaRequisitos();

		public Gr�fico() : base(HtmlTextWriterTag.Img)
		{
		}


		protected override void OnInit(EventArgs e)
		{
			Width = 480;
			Height = 240;

			base.OnInit (e);
		}

		/// <summary>
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{
			UriBuilder uri;

			uri = new UriBuilder(url);
			uri.Query = "ref=" + refer�ncia + ObterRequisitos();

			output.WriteBeginTag("IMG");
			output.WriteAttribute("src", uri.Uri.ToString());
			output.WriteAttribute("width", Width.ToString());
			output.WriteAttribute("height", Height.ToString());
			output.Write(">");
		}

		/// <summary>
		/// Obt�m lista de requisitos em formato string
		/// </summary>
		/// <returns>Lista de requisitos</returns>
		private string ObterRequisitos()
		{
			string sRequisitos = "";

			foreach (Requisito requisito in this.requisitos)
				sRequisitos += "&" + requisito.Chave + "=" + requisito.Valor;

			return sRequisitos;
		}

		public ListaRequisitos Requisitos
		{
			get { return requisitos; }
			set { requisitos = value; }
		}

		public string Url
		{
			get { return url; }
			set { url = value; }
		}

		public string Refer�ncia
		{
			get { return refer�ncia; }
			set { refer�ncia = value; }
		}
	}
}
