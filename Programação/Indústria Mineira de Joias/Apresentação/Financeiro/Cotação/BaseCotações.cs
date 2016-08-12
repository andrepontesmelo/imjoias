using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades;
using Entidades.Moedas;

[assembly: ExporBotão(0, "Cotações", true, typeof(Apresentação.Financeiro.Cotação.BaseCotações))]

namespace Apresentação.Financeiro.Cotação
{
    /// <summary>
    /// Base inferior para exibição e adição de cotações e moedas.
    /// </summary>
    public partial class BaseCotações : BaseInferior
    {
        public BaseCotações()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega as cotações.
        /// </summary>
        protected override void AoExibir()
        {
            base.AoExibir();

            CarregarCotações();
        }

        public void CarregarCotações()
        {
            AguardeDB.Mostrar();

            try
            {
                flowLayoutPanel.Controls.Clear();

                Moeda[] moedas = MoedaObtenção.Instância.ObterMoedas();

                foreach (Moeda moeda in moedas)
                    AdicionarMoeda(moeda);
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        private void AdicionarMoeda(Moeda moeda)
        {
            DadosCotação ui = new DadosCotação(this);
            
            ui.Moeda = moeda;
            ui.Name = moeda.Nome;
            ui.Margin = new Padding(15);

            flowLayoutPanel.Controls.Add(ui);
        }

        private void opçãoEditar_Click(object sender, EventArgs e)
        {
            EscolherEdiçãoMoeda.ExecutarManutenção(ParentForm);
            CarregarCotações();
        }

        //private void opção1_Click(object sender, EventArgs e)
        //{
        //    System.Xml.XmlDocument doc =  NotaFiscal.Criar();
        //    SaveFileDialog janela = new SaveFileDialog();
        //    if (janela.ShowDialog() == DialogResult.OK)
        //    {
        //        doc.Save(janela.FileName);
        //    }
        //}
    }
}
