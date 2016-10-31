using Apresentação.Formulários;
using Entidades.Moedas;
using System;
using System.Windows.Forms;

[assembly: ExporBotão(0, "Cotações", true, typeof(Apresentação.Financeiro.Cotação.BaseCotações))]
namespace Apresentação.Financeiro.Cotação
{
    public partial class BaseCotações : BaseInferior
    {
        public BaseCotações()
        {
            InitializeComponent();
        }

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

                foreach (Moeda moeda in Moeda.ObterMoedas())
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
    }
}
