using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;
using Apresentação.Formulários;
using Apresentação.Formulários.Impressão;
using Apresentação.Impressão;
using Apresentação.Impressão.Relatórios.Mercadoria;

//[assembly: ExporBotão("Manutenção", true, typeof(Apresentação.Mercadoria.Manutenção.BaseListagem))]

namespace Apresentação.Mercadoria.Manutenção
{
    public partial class BaseListagem : Apresentação.Formulários.BaseInferior
    {
        public BaseListagem()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SubstituirBase(new BaseEdição());
        }

        private void opção2_Click(object sender, EventArgs e)
        {
            SubstituirBase(new ComponentesDeCusto.BaseListagem());
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            lista.Carregar();
        }

        private void chkFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            lista.ApenasDentroDeLinha = chkFiltrar.Checked;
        }

        private void lista_Alterar(Entidades.Mercadoria.MercadoriaManutenção manutenção)
        {
            BaseEdição novaBase;

            if (Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.EditarMercadorias))
            {
                Apresentação.Formulários.AguardeDB.Mostrar();

                novaBase = new BaseEdição();

                novaBase.Abrir(manutenção);

                SubstituirBase(novaBase);
                Apresentação.Formulários.AguardeDB.Fechar();
            }
            else MostrarJanelaSemPermissão();
        }

        private void lista_Adicionar(object sender, EventArgs e)
        {
            if (Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.EditarMercadorias))
            {
                JanelaReferência janela = new JanelaReferência();
                if (janela.ShowDialog() == DialogResult.OK)
                    lista_Alterar(Entidades.Mercadoria.MercadoriaManutenção.Cadastrar(janela.Referência));
            }
            else MostrarJanelaSemPermissão();
        }

        private static void MostrarJanelaSemPermissão()
        {
            MessageBox.Show("Sem permissão", "Você não tem permissão para esta operação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void lista_Excluir(object sender, EventArgs e)
        {
            List<Entidades.Mercadoria.MercadoriaManutenção> seleção = lista.ObterItensSelecionados();
            if (seleção.Count == 0) return;

            if (Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.EditarMercadorias))
            {
                // Solicita confirmação
                if (MessageBox.Show("Marcar " + seleção.Count.ToString() + " mercadoria(s) para exclusão ?", "Apagar mercadorias", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Apresentação.Formulários.AguardeDB.Mostrar();
                    Entidades.Mercadoria.MercadoriaManutenção.Excluir(seleção);
                    Apresentação.Formulários.AguardeDB.Fechar();
                }
                
                lista.Carregar();
            }
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            Impressão.JanelaOpçõesImpressão janelaOpções = new Impressão.JanelaOpçõesImpressão();

            if (janelaOpções.ShowDialog() != DialogResult.OK)
                return;

            using (RequisitarImpressão dlg = new RequisitarImpressão(TipoDocumento.Mercadoria))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    DadosRelatórioMercadoria dados = new DadosRelatórioMercadoria(Entidades.Tabela.TabelaPadrão);
                    dados.Cópias = dlg.NúmeroCópias;
                    dlg.ControleImpressão.RequisitarImpressão(dlg.Impressora, dados);
                }
            }
        }
    }
}
