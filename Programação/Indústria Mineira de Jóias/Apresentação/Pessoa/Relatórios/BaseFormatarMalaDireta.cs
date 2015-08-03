using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Configuração;

namespace Apresentação.Pessoa.Relatórios
{
    /// <summary>
    /// Formata etiqueta para mala-direta.
    /// </summary>
    public partial class BaseFormatarMalaDireta : Apresentação.Formulários.Impressão.BaseFormatarEtiqueta
    {
        public BaseFormatarMalaDireta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Desmarca todos os botões com exceção do botão fornecido.
        /// </summary>
        /// <param name="exceção">Único botão que não será desmarcado.</param>
        private void DesselecionarDemais(ToolStripButton exceção)
        {
            foreach (ToolStripButton btn in toolStrip1.Items)
                if (btn != exceção)
                    btn.Checked = false;
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            ConfiguraçãoGlobal<string> xml = new ConfiguraçãoGlobal<string>("Mala-Direta - Formato", null);

            if (xml != null)
                labelLayout.LoadFromXml(xml.Valor, true);
        }

        private void btnPonteiro_Click(object sender, EventArgs e)
        {
            layoutDesign.SetPointer(true);
            DesselecionarDemais(btnPonteiro);
        }

        //private void layoutDesign_SelectedItemChanged(Report.Designer.LayoutDesign sender, Report.Layout.Complex.IPrintableItem selection)
        //{
        //    if (propriedades.Enabled)
        //    {
        //        if (selection != null)
        //            propriedades.SelectedObject = selection;
        //        else
        //            propriedades.SelectedObject = layoutEtiqueta;

        //        DesselecionarDemais(null);
        //    }
        //}

        private void btnNome_Click(object sender, EventArgs e)
        {
            layoutDesign.Insert(typeof(Apresentação.Impressão.Etiquetas.Leiaute.Nome));
            DesselecionarDemais(btnNome);
        }

        private void btnLogradouro_Click(object sender, EventArgs e)
        {
            layoutDesign.Insert(typeof(Apresentação.Impressão.Etiquetas.Leiaute.Endereço));
            DesselecionarDemais(btnNome);
        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            layoutDesign.Insert(typeof(Apresentação.Impressão.Etiquetas.Leiaute.CEP));
            DesselecionarDemais(btnNome);
        }

        private void btnCidade_Click(object sender, EventArgs e)
        {
            layoutDesign.Insert(typeof(Apresentação.Impressão.Etiquetas.Leiaute.Cidade));
            DesselecionarDemais(btnCidade);
        }
    }
}
