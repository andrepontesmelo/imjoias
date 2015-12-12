using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Álbum;
using Entidades;
using Acesso.Comum;

namespace Apresentação.Financeiro
{
    public partial class PesquisaMercadoriaResultado : Apresentação.Formulários.JanelaExplicativa
    {
        public PesquisaMercadoriaResultado(Entidades.Mercadoria.Mercadoria[] mercadorias, Tabela tabela, Entidades.Financeiro.Cotação cotação)
        {
            InitializeComponent();

            listaFotos.Ordenar = false;

            using (Apresentação.Formulários.Aguarde dlg = new Apresentação.Formulários.Aguarde("Carregando fotos...", mercadorias.Length))
            {
                dlg.Abrir();

                foreach (Entidades.Mercadoria.Mercadoria m in mercadorias)
                {
                    Foto foto = CacheMiniaturas.Instância.ObterFoto(m);

                    if (foto != null)
                    {
                        listaFotos.Adicionar(foto);
                    }

                    dlg.Passo();
                }
            }

            cmbTabela.Seleção = tabela;
            txtCotação.Cotação = cotação;
        }

        private void listaFotos_AoSelecionar(Entidades.Álbum.Foto foto)
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
