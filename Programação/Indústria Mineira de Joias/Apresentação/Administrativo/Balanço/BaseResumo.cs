using Apresentação.Formulários;
using System;
using System.Collections;
using System.Collections.Generic;
using Apresentação.Impressão.Relatórios.Balanço;

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

        public BaseResumo(List<long> saídas, List<long> retornos, List<long> vendas, List<long> sedex)
        {
            InitializeComponent();

            balanço = new Negócio.ControleBalanço(saídas, retornos, vendas, sedex);
            bandeja.AdicionarVários(new ArrayList(balanço.ColeçãoSaquinhos));
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            using (JanelaImpressão dlg = new JanelaImpressão())
            {
                RelatórioBalanço relatório = new RelatórioBalanço();
                relatório.SetDataSource(balanço.ObterImpressão());
                
                dlg.InserirDocumento(relatório, "Balanço");

                dlg.Título = "Balanço";
                dlg.Descrição = "Verifique abaixo o relatório de balanço a ser impresso.";

                dlg.ShowDialog(this.ParentForm);
            }
        }
    }
}
