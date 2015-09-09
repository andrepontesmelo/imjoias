using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.�lbum.Edi��o.Fotos
{
    public partial class EditarMercadoria : Apresenta��o.Formul�rios.BaseInferior
    {
        private Entidades.Mercadoria.Mercadoria mercadoria;

        public EditarMercadoria(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            InitializeComponent();

            this.mercadoria = mercadoria;

            t�tuloBaseInferior.Descri��o = "Mercadoria " + mercadoria.Refer�ncia;
        }

        /// <summary>
        /// Ocorre ao carregar completamente
        /// </summary>
        public override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            listaFotos.Fotos = new List<Entidades.�lbum.Foto>(mercadoria.ObterFotos());
        }

        #region Tratamento de a��es do usu�rio

        /// <summary>
        /// Ocorre ao clicar em procurar por mercadoria.
        /// </summary>
        private void op��oProcurar_Click(object sender, EventArgs e)
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
        private void listaFotos_AoSelecionar(Entidades.�lbum.Foto foto)
        {
            quadroItem.Visible = foto != null;
        }

        /// <summary>
        /// Usu�rio requisita edi��o de foto.
        /// </summary>
        private void op��oEditar_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();

            Fot�grafo f = new Fot�grafo();
            Controlador.InserirBaseInferior(f);
            f.Editar(listaFotos.Sele��o);
            AguardeDB.Fechar();

            UseWaitCursor = false;
        }

        /// <summary>
        /// Exclui foto do banco de dados.
        /// </summary>
        private void op��oExcluir_Click(object sender, EventArgs e)
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
                    listaFotos.Sele��o.Descadastrar();
                }
                finally
                {
                    AguardeDB.Fechar();
                }
            }
        }

        private void op��oExportar_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = listaFotos.Sele��o.Refer�nciaFormatada + ".jpg";

            if (saveFileDialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                listaFotos.Sele��o.Imagem.Save(saveFileDialog.FileName);
            }
        }

        #endregion
    }
}

