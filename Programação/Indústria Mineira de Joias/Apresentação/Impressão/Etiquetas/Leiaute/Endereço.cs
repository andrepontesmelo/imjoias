using System;
using System.Collections.Generic;
using System.Text;
using Report.Layout.Complex;
using Entidades.Pessoa.Endereço;
using System.ComponentModel;

namespace Apresentação.Impressão.Etiquetas.Leiaute
{
    public class Nome : TextMapped
    {
        public Nome()
            : base(typeof(Entidades.Pessoa.Endereço.Endereço), "Nome")
        {
        }
    }

    public class Endereço : Label
    {
        public override string GetText(object obj)
        {
            Entidades.Pessoa.Endereço.Endereço endereço = obj as Entidades.Pessoa.Endereço.Endereço;

            if (endereço == null)
                return "";

            if (endereço.Complemento != null && endereço.Complemento.Length > 0)
                return string.Format("{0}, {1}, {2}", endereço.Logradouro, endereço.Número, endereço.Complemento);
            else if (endereço.Número != null && endereço.Número.Length > 0)
                return string.Format("{0}, {1}", endereço.Logradouro, endereço.Número);
            else
                return endereço.Logradouro;
        }
    }

    public class Bairro : TextMapped
    {
        public Bairro()
            : base(typeof(Entidades.Pessoa.Endereço.Endereço), "Bairro")
        {
        }
    }

    public class CEP : TextMapped
    {
        public CEP()
            : base(typeof(Entidades.Pessoa.Endereço.Endereço), "CEP")
        {
        }
    }

    public class Cidade : Label
    {
        bool sigla = true;
        bool omitirBrasil = true;

        [DisplayName("Usar sigla"),
        Description("Determina se deve ser utilizada a sigla para estado."),
        DefaultValue(true)]
        public bool Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }

        [DisplayName("Omitir Brasil"),
        Description("Determina se deve omitir o país caso seja Brasil."),
        DefaultValue(true)]
        public bool OmitirBrasil
        {
            get { return omitirBrasil; }
            set { omitirBrasil = value; }
        }

        public override string GetText(object obj)
        {
            Entidades.Pessoa.Endereço.Endereço endereço = obj as Entidades.Pessoa.Endereço.Endereço;
            string estado;


            if (endereço == null)
                return "";

            if (sigla && endereço.Localidade.Estado.Sigla != null && endereço.Localidade.Estado.Sigla.Length > 0)
                estado = endereço.Localidade.Estado.Sigla;
            else
                estado = endereço.Localidade.Estado.Nome;

            if (omitirBrasil && endereço.Localidade.Estado.País.Nome.ToLower() == "brasil")
                return string.Format("{0}, {1}", endereço.Localidade.Nome, estado);
            else
                return string.Format("{0}, {1}, {2}", endereço.Localidade.Nome, estado, endereço.Localidade.Estado.País.Nome);
        }

        public override void SaveXml(System.Xml.XmlDocument doc, System.Xml.XmlElement element)
        {
            base.SaveXml(doc, element);

            element.SetAttribute("usarSigla", sigla.ToString());
            element.SetAttribute("omitirBrasil", omitirBrasil.ToString());
        }

        public override void FromXml(System.Xml.XmlElement element, System.Collections.IDictionary typeDictionary)
        {
            base.FromXml(element, typeDictionary);

            sigla = bool.Parse(element.GetAttribute("usarSigla"));
            omitirBrasil = bool.Parse(element.GetAttribute("omitirBrasil"));
        }
    }
}
