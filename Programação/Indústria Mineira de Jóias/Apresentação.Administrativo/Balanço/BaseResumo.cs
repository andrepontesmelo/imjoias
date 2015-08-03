using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Impressão.Relatórios;
using Apresentação.Formulários;
using System.Collections;

namespace Apresentação.Administrativo.Balanço
{
    public partial class BaseResumo : Apresentação.Formulários.BaseInferior
    {
        private Negócio.ControleBalanço balanço;

        public BaseResumo()
        {
            InitializeComponent();

            balanço = new Negócio.ControleBalanço();
            bandeja.AdicionarVários(new ArrayList(balanço.ColeçãoSaquinhos));
        }

        public BaseResumo(List<long> saídas, List<long> retornos, List<long> vendas)
        {
            InitializeComponent();

            balanço = new Negócio.ControleBalanço(saídas, retornos, vendas);
            bandeja.AdicionarVários(new ArrayList(balanço.ColeçãoSaquinhos));
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            using (JanelaImpressão dlg = new JanelaImpressão())
            {
                RelatórioBalanço relatório = new Apresentação.Impressão.Relatórios.RelatórioBalanço();
                relatório.SetDataSource(balanço.ObterImpressão());
                //relatório.PrintOptions.PrinterName = impressora;
                dlg.InserirDocumento(relatório, "Balanço");

                dlg.Título = "Balanço";
                dlg.Descrição = "Verifique abaixo o relatório de balanço a ser impresso.";

                dlg.ShowDialog(this.ParentForm);
            }
        }
    }
}
