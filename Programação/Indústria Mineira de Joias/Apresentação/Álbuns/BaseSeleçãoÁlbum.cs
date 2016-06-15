using Apresentação.Álbum.Edição.Álbuns.Desenhista;
using Apresentação.Álbum.Edição.Fotos;
using Apresentação.Álbum.Edição.Impressão;
using Apresentação.Formulários;
using Entidades.Álbum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

[assembly: ExporBotão(Entidades.Privilégio.Permissão.Álbum, 1, "Fotografias", true, typeof(Apresentação.Álbum.Edição.Álbuns.BaseSeleçãoÁlbum))]
namespace Apresentação.Álbum.Edição.Álbuns
{
    public partial class BaseSeleçãoÁlbum : BaseInferior
    {
        public BaseSeleçãoÁlbum()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre ao selecionar um álbum.
        /// </summary>
        private void lst_AoSelecionarÁlbum(object sender, EventArgs e)
        {
            quadroÁlbum.Visible = lst.Seleção != null;
        }

        /// <summary>
        /// Cria um novo álbum.
        /// </summary>
        private void opçãoNovo_Click(object sender, EventArgs e)
        {
            Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.Álbum);

            Entidades.Álbum.Álbum álbum;

            using (CadastroÁlbum janela = new CadastroÁlbum())
            {
                if (janela.ShowDialog() == DialogResult.OK)
                {
                    álbum = janela.Álbum;

                    SubstituirBase(new BaseEditarÁlbum(álbum));
                }
            }
        }

        /// <summary>
        /// Remove um álbum.
        /// </summary>
        private void opçãoRemover_Click(object sender, EventArgs e)
        {
            if (!ExisteÁlbumSelecionado())
                return;

            Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.Álbum);

            Entidades.Álbum.Álbum álbum = lst.Seleção;

            if (MessageBox.Show(
                ParentForm,
                "Você deseja mesmo excluir o álbum \""
                + álbum.Nome + "\"?\n\n"
                + "Saiba que as fotos não serão excluídas.",
                "Excluir álbum",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (MessageBox.Show(
                    ParentForm,
                    "Você tem certeza que deseja excluir o álbum \""
                    + álbum.Nome + "\"?\n\n"
                    + "ATENÇÃO! ESTA OPERAÇÃO NÃO PODERÁ SER DESFEITA!",
                    "Excluir álbum",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    AguardeDB.Mostrar();

                    álbum.Descadastrar();
                    lst.Remover(álbum);

                    AguardeDB.Fechar();
                }
            }
        }

        /// <summary>
        /// Ocorre quando usuário requisita impressão do álbum selecionado.
        /// </summary>
        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            if (ExisteÁlbumSelecionado())
            {
                using (JanelaOpçõesImpressão dlg = new JanelaOpçõesImpressão())
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        ControleImpressão.Imprimir(lst.Seleção, dlg.Itens);
                }
            }
        }

        /// <summary>
        /// Ocorre quando usuário requisita edição do álbum selecionado.
        /// </summary>
        private void opçãoEditar_Click(object sender, EventArgs e)
        {
            if (ExisteÁlbumSelecionado())
            {
                Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.Álbum);
                BaseEditarÁlbum novaBase = new BaseEditarÁlbum(lst.Seleção);

                Controlador.InserirBaseInferior(novaBase);
                SubstituirBase(novaBase);
            }
        }

        private bool ExisteÁlbumSelecionado()
        {
            bool existe = lst.Seleção != null;
            quadroÁlbum.Visible = existe;

            return existe;
        }

        private void opçãoExtrairFotos_Click(object sender, EventArgs e)
        {
            if (lst.Seleção == null)
            {
                MessageBox.Show(this,
                    "Favor selecionar um álbum.",
                    "Escolha do álbum",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            folderBrowserDialog.Description = "Escolha o diretório destino";

            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                Entidades.Álbum.Álbum album = lst.Seleção;
                List<Foto> fotos = album.Fotos.ExtrairElementos();

                Aguarde aguarde = new Aguarde("Extraíndo fotos", fotos.Count);

                aguarde.Abrir();
                string path = folderBrowserDialog.SelectedPath;

                if (!path.EndsWith(@"\"))
                    path = path + @"\";

                foreach (Foto f in fotos)
                {
                    Image imagem = f.Imagem;

                    Entidades.Mercadoria.Mercadoria m = f.ObterMercadoria();

                    if (imagem != null)
                        imagem.Save(path + f.ReferênciaFormatada + " - " + m.Descrição + (m.DePeso ? "" : " - " + m.PesoFormatado) + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                    aguarde.Passo();
                }

                aguarde.Close();

                MessageBox.Show("As fotos foram extraídas", "Fim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(path);
            }
        }

        public override void AoCarregarCompletamente(Splash splash)
        {
            CacheMiniaturas cache =
                Entidades.Álbum.CacheMiniaturas.Instância;

            CacheÍcones cacheÍcones = Entidades.Álbum.CacheÍcones.Instância;

            base.AoCarregarCompletamente(splash);
        }
        private void opçãoTodasFotos_Click(object sender, EventArgs e)
        {
            BaseTodasFotos controle = new BaseTodasFotos();
            SubstituirBase(controle);
        }

        private void opçãoImportarFoto_Click(object sender, EventArgs e)
        {
            Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.Álbum);

            SubstituirBase(new Fotógrafo());
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.Álbum);

            BaseEditarÁlbum baseEdição = new BaseEditarÁlbum(lst.Seleção);
            Controlador.InserirBaseInferior(baseEdição);
            SubstituirBase(baseEdição);
        }
    }
}
