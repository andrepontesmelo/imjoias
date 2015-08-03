using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Apresentação.Balanço
{
    [XmlRoot("Documentos")]
    public class PersistênciaDocumentosBalanço 
    { 
        private List<long> listaSaídas, listaRetornos, listaVendas, listaSedex;

        private PersistênciaDocumentosBalanço()
        {
            listaSaídas = new List<long>();
            listaRetornos = new List<long>();
            listaVendas = new List<long>();
            listaSedex = new List<long>();
        }

        [XmlElement("saida")]
        public List<long> ListaSaídas { get { return listaSaídas; } }
        
        [XmlElement("retorno")]
        public List<long> ListaRetornos { get { return listaRetornos; } }

        [XmlElement("venda")]
        public List<long> ListaVendas { get { return listaVendas; } }

        [XmlElement("sedex")]
        public List<long> ListaSedex { get { return listaSedex; } }


        private static PersistênciaDocumentosBalanço instância;

        public static PersistênciaDocumentosBalanço Instância
        {
            get
            {
                if (instância == null)
                {
                    if (System.IO.File.Exists(NomeArquivo))
                    {
                        // Carrega!
                        System.Xml.Serialization.XmlSerializer serializador = new System.Xml.Serialization.XmlSerializer(typeof(PersistênciaDocumentosBalanço));

                        StreamReader leitor = new System.IO.StreamReader(NomeArquivo);
                        instância = (PersistênciaDocumentosBalanço) serializador.Deserialize(leitor);
                        leitor.Close();
                    }
                    else
                        instância = new PersistênciaDocumentosBalanço();
                }

                return instância;
            }
        }

        private static string NomeArquivo
        {
            
            get
            {
                string nomeArquivoXml =
                System.IO.Path.Combine(
                new System.IO.FileInfo(System.Reflection.Assembly.GetAssembly(typeof(PersistênciaDocumentosBalanço)).Location).Directory.FullName,
                "balanço.xml");

                return nomeArquivoXml;
            }
        }

        /*

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement();
            string typeName = reader.ReadElementContentAsString();
//            this.Type = Type.GetType(typeName);
  //          reader.ReadEndElement();
    //        String x = reader.ReadElementString();

        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("saídas");
            foreach (int x in listaSaídas)
                writer.WriteElementString("codigo", x.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("retornos");
            foreach (int x in listaRetornos)
                writer.WriteElementString("codigo", x.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("vendas");
            foreach (int x in listaVendas)
                writer.WriteElementString("codigo", x.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("sedex");
            foreach (int x in listaSedex)
                writer.WriteElementString("codigo", x.ToString());
            writer.WriteEndElement();
        }
        */

        private void Persistir()
        {
            //lock (this)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(sb);
            //    System.Xml.Serialization.XmlSerializer serializer = new XmlSerializer(this.GetType());
            //    serializer.Serialize(writer, this);

            //    System.IO.File.WriteAllText(NomeArquivo, sb.ToString());
            //}

            System.IO.StreamWriter arq = new System.IO.StreamWriter(NomeArquivo, false, Encoding.Default);
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            x.Serialize(arq, this);
            arq.Close();
        }

        internal void MarcarSaídas(List<long> códigos)
        {
            listaSaídas = códigos;
            Persistir();
        }

        internal void MarcarSedex(List<long> códigos)
        {
            listaSedex = códigos;
            Persistir();
        }

        internal void MarcarVendas(List<long> códigos)
        {
            listaVendas = códigos;
            Persistir();
        }

        internal void MarcarRetornos(List<long> códigos)
        {
            listaRetornos = códigos;
            Persistir();
        }
    }
}
