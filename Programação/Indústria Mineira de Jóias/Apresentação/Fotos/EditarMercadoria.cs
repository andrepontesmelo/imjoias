using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Álbum.Edição.Fotos
{
    public partial class EditarMercadoria : Apresentação.Formulários.BaseInferior
    {
        private Entidades.Mercadoria.Mercadoria mercadoria;

        public EditarMercadoria(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            InitializeComponent();

            this.mercadoria = mercadoria;

            títuloBaseInferior.Descrição = "Mercadoria " + mercadoria.Referência;
        }

        /// <summary>
        /// Ocorre ao carregar completamente
        /// </summary>
        public override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            listaFotos.Fotos = new List<Entidades.Álbum.Foto>(mercadoria.ObterFotos());
        }

        #region Tratamento de ações do usuário

        /// <summary>
        /// Ocorre ao clicar em procurar por mercadoria.
        /// </summary>
        private void opçãoProcurar_Click(object sender, EventArgs e)
        {
            using (ProcurarMercadoria dlg = new ProcurarMercadoria())
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                {
                    SubstituirBase(new EditarMercadoria(dlg.Mercadoria));
                }
            }
        }

        /// <summary>
        /// Ocorre ao selecionar um item na lista de fotos.
        /// </summary>
        /// <param name="foto">Foto selecionada.</param>
        private void listaFotos_AoSelecionar(Entidades.Álbum.Foto foto)
        {
            quadroItem.Visible = foto != null;
        }

        /// <summary>
        /// Usuário requisita edição de foto.
        /// </summary>
        private void opçãoEditar_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();

            Fotógrafo f = new Fotógrafo();
            Controlador.InserirBaseInferior(f);
            f.Editar(listaFotos.Seleção);
            AguardeDB.Fechar();

            UseWaitCursor = false;
        }

        /// <summary>
        /// Exclui foto do banco de dados.
        /// </summary>
        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                this.ParentForm,
                "Deseja mesmo excluir a foto selecionada?",
                "Excluir foto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                AguardeDB.Mostrar();

                try
                {
                    listaFotos.Seleção.Descadastrar();
                }
                finally
                {
                    AguardeDB.Fechar();
                }
            }
        }

        private void opçãoExportar_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = listaFotos.Seleção.ReferênciaFormatada + ".jpg";

            if (saveFileDialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                listaFotos.Seleção.Imagem.Save(saveFileDialog.FileName);
            }
        }

        #endregion
    }
}

