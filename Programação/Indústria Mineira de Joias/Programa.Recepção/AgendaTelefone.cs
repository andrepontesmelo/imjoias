using System;
using System.Xml;
using System.Collections;

namespace Programa.Recepção
{
	/// <summary>
	/// Agenda particular de telefones
	/// </summary>
	public class AgendaTelefone : IEnumerable
	{
		public struct Registro
		{
			public string nome;
			public string telFixo;
			public string telCelular;
			public string telOutro;
			public string endCidade;
			public string endEstado;

			public Registro(string nome, string telFixo, string telCelular, string telOutro, string endCidade, string endEstado)
			{
				this.nome = nome;
				this.telFixo = telFixo;
				this.telCelular = telCelular;
				this.telOutro = telOutro;
				this.endCidade = endCidade;
				this.endEstado = endEstado;
			}

			public Registro(XmlNode nodo)
			{
				nome = nodo.Attributes["nome"].Value;

				telFixo = "";
				telCelular = "";
				telOutro = "";
				endCidade = "";
				endEstado = "";

				foreach (XmlNode filho in nodo.ChildNodes)
				{
					if (string.Compare(filho.Name, "telefone", true) == 0)
					{
						if (string.Compare(filho.Attributes["tipo"].Value, "fixo", true) == 0)
							telFixo = filho.FirstChild != null ?
								filho.FirstChild.Value : "";
						else if (string.Compare(filho.Attributes["tipo"].Value, "celular", true) == 0)
							telCelular = filho.FirstChild != null ? 
								filho.FirstChild.Value : "";
						else
							telOutro = filho.FirstChild != null ?
								filho.FirstChild.Value : "";
					}
					else if (string.Compare(filho.Name, "cidade", true) == 0)
						endCidade = filho.FirstChild != null ?
							filho.FirstChild.Value : "";
					else if (string.Compare(filho.Name, "estado", true) == 0)
						endEstado = filho.FirstChild != null ? 
							filho.FirstChild.Value : "";
				}
			}
		}

		private XmlDocument		doc;
		private const string	arquivo = "telefones.xml";

		public AgendaTelefone()
		{
			doc = new XmlDocument();

			// Abrir arquivo
			try
			{
				doc.Load(arquivo);
			}
			catch (System.IO.FileNotFoundException)
			{
				doc.LoadXml("<agenda></agenda>");
			}
		}

		#region IEnumerable Members

		/// <summary>
		/// Acessa lista de registros
		/// </summary>
		/// <returns>Iterador para lista de registros</returns>
		public IEnumerator GetEnumerator()
		{
			ArrayList dados = new ArrayList();

			// Carregar nomes
			XmlNodeList nodos;

			nodos = doc.GetElementsByTagName("pessoa");

			foreach (XmlNode nodo in nodos)
			{
				dados.Add(new Registro(nodo));
			}

			return dados.GetEnumerator();
		}

		#endregion

		public Registro this[string nome]
		{
			get
			{
				XmlNodeList nodos = doc.GetElementsByTagName("pessoa");

				foreach (XmlNode nodo in nodos)
					if (nodo.Attributes["nome"].Value == nome)
						return new Registro(nodo);

				return new Registro("", "", "", "", "", "");
			}
		}

		/// <summary>
		/// Insere um elemento na agenda
		/// </summary>
		public void Inserir(string sNome, string sTelFixo, string sTelCelular, string sTelOutro, string sEndCidade, string sEndEstado)
		{
			XmlElement pessoa = doc.CreateElement("pessoa");

			pessoa.SetAttribute("nome", sNome);
				
			// telFixo
			XmlElement telFixo = doc.CreateElement("telefone");
			telFixo.SetAttribute("tipo", "fixo");
			telFixo.AppendChild(doc.CreateTextNode(sTelFixo));
			pessoa.AppendChild(telFixo);

			// telCelular
			XmlElement telCelular = doc.CreateElement("telefone");
			telCelular.SetAttribute("tipo", "celular");
			telCelular.AppendChild(doc.CreateTextNode(sTelCelular));
			pessoa.AppendChild(telCelular);

			// TelOutro
			XmlElement telOutro = doc.CreateElement("telefone");
			telOutro.SetAttribute("tipo", "outro");
			telOutro.AppendChild(doc.CreateTextNode(sTelOutro));
			pessoa.AppendChild(telOutro);

			// endCidade
			XmlElement endCidade = doc.CreateElement("Cidade");
			endCidade.AppendChild(doc.CreateTextNode(sEndCidade));
			pessoa.AppendChild(endCidade);

			// endEstado
			XmlElement endEstado = doc.CreateElement("Estado");
			endEstado.AppendChild(doc.CreateTextNode(sEndEstado));
			pessoa.AppendChild(endEstado);

			doc.DocumentElement.AppendChild(pessoa);
			doc.Save(arquivo);
		}

		/// <summary>
		/// Altera dados da agenda
		/// </summary>
		public void Alterar(string antigoNome, string nome, string telFixo, string telCelular, string telOutro, string cidade, string estado)
		{
			Excluir(antigoNome);

			Inserir(nome, telFixo, telCelular, telOutro, cidade, estado);
		}

		/// <summary>
		/// Excluir dados da agenda
		/// </summary>
		public void Excluir(string nome)
		{
			XmlNodeList nodos = doc.GetElementsByTagName("pessoa");

			foreach (XmlNode nodo in nodos)
				if (nodo.Attributes["nome"].Value == nome)
				{
					nodo.ParentNode.RemoveChild(nodo);
					doc.Save(arquivo);
					break;
				}
		}
	}
}
