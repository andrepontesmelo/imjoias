using System;
using System.Collections.Generic;
using System.Text;
using Report.Layout;
using Entidades.Configuração;
using Entidades.Pessoa.Endereço;
using System.Drawing.Printing;

namespace Apresentação.Impressão.Controles
{
    /// <summary>
    /// Controle para impressão da mala-direta.
    /// </summary>
    public class MalaDireta
    {
        private LabelLayout etiqueta;

        public MalaDireta()
        {
            ConfiguraçãoGlobal<string> xml = new ConfiguraçãoGlobal<string>("Mala-Direta - Formato", null);

            etiqueta = new LabelLayout();
            etiqueta.LoadFromXml(xml.Valor, false);
        }

        public void Imprimir(PrintDocument documento, Endereço endereço)
        {
            etiqueta.Document = documento;
            etiqueta.Objects.Add(endereço);
            documento.Print();
        }
    }
}
