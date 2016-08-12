using Apresentação.Formulários;
using Entidades.Moedas;
using System;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Indicadores
{
    public partial class JanelaHistóricoCotação : JanelaExplicativa
    {
        Moeda moeda;

        public JanelaHistóricoCotação(Moeda moeda)
        {
            InitializeComponent();
            this.moeda = moeda;

            Recarregar();
        }

        private void Recarregar()
        {
            Text = string.Format("{0} - Histórico de Cotação", moeda.Nome);

            gráficoCotação.Moeda = moeda;
            gráficoCotação.PeríodoFinal = DateTime.MaxValue;
            gráficoCotação.PeríodoInicial = DateTime.Now.Subtract(new TimeSpan(182, 0, 0, 0));
            gráficoCotação.Lista = listaCotação;

            listaCotação.AutoAlimentação = false;
            listaCotação.Moeda = moeda;
            listaCotação.PeríodoFinal = DateTime.MaxValue;
            listaCotação.PeríodoInicial = gráficoCotação.PeríodoInicial;

            data.Value = gráficoCotação.PeríodoInicial;

            lblTítulo.Text = string.Format("{0} - Cotação", moeda.Nome);

            if (moeda.Ícone != null)
                picÍcone.Image = moeda.Ícone;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void data_ValueChanged(object sender, EventArgs e)
        {
            gráficoCotação.PeríodoInicial = data.Value;
            listaCotação.PeríodoInicial = gráficoCotação.PeríodoInicial;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cotação.RegistrarCotação janela = new Apresentação.Financeiro.Cotação.RegistrarCotação();
            janela.Moeda = moeda;
            janela.ShowDialog(this);
            Recarregar();   
        }

        private void btnExcluír_Click(object sender, EventArgs e)
        {
            if (listaCotação.Selecionado != null)
            {
                listaCotação.Selecionado.Descadastrar();
                MessageBox.Show("Cotação foi removida", "Fim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Recarregar();
            }
        }
    }
}