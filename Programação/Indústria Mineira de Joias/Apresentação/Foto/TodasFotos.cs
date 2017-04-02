using Apresentação.Álbum.Edição.Álbuns;
using Apresentação.Formulários;
using Apresentação.Mercadoria;
using System;
using System.Windows.Forms;

namespace Apresentação.Álbum.Edição.Fotos
{
    public partial class TodasFotos : UserControl
    {
        public TodasFotos()
        {
            InitializeComponent();
            listaFotosTodas.AoExcluído += new ListaFotos.FotoHandle(listaFotosTodas_AoExcluído);
        }

        void listaFotosTodas_AoExcluído(Entidades.Álbum.Foto foto)
        {
            listaFotosTodas.Carregar(chkForaDeLinha.Checked);
        }

        Entidades.Álbum.Foto Seleção
        {
            get
            {
                return listaFotosTodas.Seleção;
            }
        }


        Entidades.Álbum.Foto[] Seleções
        {
            get
            {
                return listaFotosTodas.Seleções;
            }
        }

        public void Carregar()
        {
            listaFotosTodas.Carregar(chkForaDeLinha.Checked);
            opçãoTodasFotos.Visible = !(Parent is BaseTodasFotos);
        }

        private void opçãoTodasFotos_Click(object sender, EventArgs e)
        {
            BaseTodasFotos novaBase = new BaseTodasFotos();
            (Parent as BaseInferior).Controlador.InserirBaseInferior(novaBase);
            (Parent as BaseInferior).SubstituirBase(novaBase);
        }

        private void chkForaDeLinha_CheckedChanged(object sender, EventArgs e)
        {
            listaFotosTodas.Carregar(chkForaDeLinha.Checked);
        }

        /// <summary>
        /// Ao alterar uma referência, procurá-la na lista de fotos.
        /// </summary>
        private void txtReferência_ReferênciaAlterada(object sender, EventArgs e)
        {
            if (txtReferência.Referência.Length > 0)
                try
                {
                    listaFotosTodas.Selecionar(txtReferência.Referência);
                }
                catch (Exception erro)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
                }
        }

        public ListaFotos ListaFotosTodas
        {
            get
            {
                return listaFotosTodas;
            }
        }

        private void listaFotosTodas_AoDuploClique(Entidades.Álbum.Foto foto)
        {
            JanelaInformaçõesMercadoriaResumo.Abrir(foto?.ReferênciaNumérica);
        }
    }
}
