using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Faturamento;
using Entidades.Estatística;

namespace Apresentação.Financeiro.Indicadores
{
    public partial class GráficoFaturamentoMercadoria : UserControl
    {
        public GráficoFaturamentoMercadoria()
        {
            InitializeComponent();
        }

        private void GráficoFaturamentoMercadoria_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                bgRecuperação.RunWorkerAsync();
        }

        private void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            FaturamentoMercadorias dados;
            int i = 0;

            SinalizaçãoCarga sinalização = SinalizaçãoCarga.Sinalizar(quadro1, "Carregando dados...", "Aguarde enquanto carrega-se os dados estatísticos do banco de dados...");

            dados = new FaturamentoMercadorias(0.1f, DateTime.Now.Subtract(TimeSpan.FromDays(365)), DateTime.MaxValue);

            List<IPlotávelRotulado> lista = new List<IPlotávelRotulado>();

            foreach (FaturamentoMercadorias.InfoMercadoria info in dados.Itens)
            {
                if (i++ == 10)
                    break;

                lista.Add(info);
            }

            e.Result = new object[] { dados, lista, sinalização };
        }

        private void bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<IPlotávelRotulado> dados;
            FaturamentoMercadorias faturamento;
            SinalizaçãoCarga sinalização;
            int i = 1;

            faturamento = (FaturamentoMercadorias)(((object[])e.Result)[0]);
            dados = (List<IPlotávelRotulado>)(((object[])e.Result)[1]);
            sinalização = (SinalizaçãoCarga)(((object[])e.Result)[2]);

            gráfico.Mostrar(dados);
            gráfico.RótulosX = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            lst.Items.Clear();

            foreach (FaturamentoMercadorias.InfoMercadoria item in faturamento.Itens)
            {
                ListViewItem linha;

                linha = lst.Items.Add(string.Format("{0}", i++));
                linha.SubItems.Add(item.Mercadoria.ReferênciaNumérica);
                linha.SubItems.Add(string.Format("{0:###,##0.00} g", item.Mercadoria.Peso));
                linha.SubItems.Add(string.Format("{0:##0.0000}%", item.Faturamento));
                linha.SubItems.Add(item.Quantidade.ToString());
            }

            SinalizaçãoCarga.Dessinalizar(sinalização);

            gráfico.Visible = true;
            lst.Visible = true;
        }
    }
}
