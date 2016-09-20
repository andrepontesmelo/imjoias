using Entidades;
using Entidades.Álbum;

namespace Apresentação.Financeiro
{
    public partial class PesquisaMercadoriaResultado : Formulários.JanelaExplicativa
    {
        public PesquisaMercadoriaResultado(Entidades.Mercadoria.Mercadoria[] mercadorias, Tabela tabela, Entidades.Financeiro.Cotação cotação)
        {
            InitializeComponent();

            listaFotos.Ordenar = false;

            using (Formulários.Aguarde dlg = new Formulários.Aguarde("Carregando fotos...", mercadorias.Length))
            {
                dlg.Abrir();

                foreach (Entidades.Mercadoria.Mercadoria m in mercadorias)
                {
                    Foto foto = CacheMiniaturas.Instância.ObterFoto(m);

                    if (foto != null)
                        listaFotos.Adicionar(foto);

                    dlg.Passo();
                }
            }

            cmbTabela.Seleção = tabela;
            txtCotação.Carregar();
            txtCotação.Cotação = cotação;
        }

        private void listaFotos_AoSelecionar(Foto foto)
        {
            if (foto != null)
            {
                Entidades.Mercadoria.Mercadoria m = foto.ObterMercadoria();

                picFoto.Image = foto.Imagem;
                lblReferência.Text = m.Referência;
                lblPeso.Text = m.PesoFormatado;

                try
                {
                    lblPreço.Text = m.CalcularPreço(txtCotação.Cotação);
                }
                catch
                {
                    lblPreço.Text = "N/D";
                }
            }
        }

        private void txtCotação_EscolheuCotação(Entidades.Financeiro.Cotação escolha)
        {
            try
            {
                listaFotos_AoSelecionar(listaFotos.Seleção);
            }
            catch
            {
                lblPreço.Text = "N/D";
            }
        }
    }
}
