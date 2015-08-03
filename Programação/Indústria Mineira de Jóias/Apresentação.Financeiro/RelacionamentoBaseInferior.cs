using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Negócio;
using System.Runtime.Remoting.Lifetime;
using Apresentação.Mercadoria.Bandeja;
using Entidades;
using Apresentação.Útil;
using Entidades.Relacionamento;

namespace Apresentação.Financeiro
{
    public partial class RelacionamentoBaseInferior : Apresentação.Formulários.BaseInferior
    {
        private Entidades.Relacionamento.Relacionamento entidade;

        // Componentes
        private AMS.TextBox.IntegerTextBox integerTextBox1;
        private Apresentação.Mercadoria.QuadroMercadoria quadroMercadoria;
        private Apresentação.Mercadoria.QuadroFoto quadroFoto;
        protected Apresentação.Mercadoria.Bandeja.BandejaHistóricoRelacionamento bandejaHistórico;
        private System.ComponentModel.IContainer components = null;
        protected Apresentação.Mercadoria.Bandeja.BandejaConsignado bandejaAgrupada;
        private System.Windows.Forms.Button button1;
        private Apresentação.Formulários.Quadro quadroAlternaBandeja;
        private System.Windows.Forms.RadioButton optConsignado;
        private System.Windows.Forms.Label lblExplicaçãoPedido;
        private System.Windows.Forms.Label lblExplicaçãoRelacionamento;
        private System.Windows.Forms.RadioButton optRelacionamento;
        private Apresentação.Formulários.Quadro quadroRelacionamento;
        protected Apresentação.Formulários.TítuloBaseInferior título;
        private Apresentação.Formulários.Quadro quadroOpçãoPedido;
        private Apresentação.Formulários.Opção opçãoOutro;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private Apresentação.Formulários.Opção opçãoDestravar;
        private Apresentação.Formulários.Quadro quadroAgrupado;

        public RelacionamentoBaseInferior()
        {
            InitializeComponent();
        }
        protected Entidades.Relacionamento.Relacionamento Relacionamento
        {
            get { return entidade; }
        }

        private void AtualizarApresentação(bool entidadeTravada)
        {
            bandejaAgrupada.PermitirExclusão = !entidadeTravada;
            quadroMercadoria.Enabled = !entidadeTravada;
            quadroDestravar.Visible = entidadeTravada;
        }

        /// <summary>
        /// Deve ser chamado para abrir a propria base inferior
        /// </summary>
        /// <param name="relacionamento"></param>
        public virtual void Abrir(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            if (relacionamento == null)
                throw new NullReferenceException("Relacionamento é nulo no Abrir() do RelacionamentoBaseInferior");

            // Registra o objeto de contexto
            this.entidade = relacionamento;

            // Abre as bandejas
            bandejaAgrupada.Abrir(relacionamento);

            AtualizarApresentação(relacionamento.Travado);
        }

        private void quadroMercadoria_EventoAdicionou(Entidades.Mercadoria mercadoria, double quantidade)
        {
            bool entidadeTravada = entidade.Travado;
            AtualizarApresentação(entidadeTravada);

            if (entidadeTravada)
            {
                Beepador.Erro();
                MessageBox.Show(this, "O documento não pode ser alterado porque encontra-se travado. \nContacte o supervisor para seu destravamento.",
                    "Documento travado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bandejaAgrupada.Adicionar(new Saquinho(mercadoria, quantidade));

            Entidades.Pessoa.Funcionário funcionário = Entidades.Pessoa.Funcionário.FuncionárioAtual;
            bandejaHistórico.Adicionar(new SaquinhoRelacionado(mercadoria, quantidade, DateTime.Now, funcionário, SaquinhoRelacionado.EnumAção.Inserção));

            ItemRelacionado itemAdicionado = entidade.Itens.Adicionar(mercadoria, quantidade);

            if (!itemAdicionado.Cadastrado)
                itemAdicionado.Cadastrar();
            else
                itemAdicionado.Atualizar();
        }


        private void bandejaPedido_SeleçãoMudou(Entidades.Saquinho saquinho)
        {
            if (saquinho != null)
            {
                quadroFoto.MostrarFoto(saquinho.Mercadoria);
                quadroMercadoria.AlternarParaAlteração(saquinho);
            }
            else
            {
                // Des-selecionou
                quadroMercadoria.AlternarParaAdicionar();
                //quadroFoto.MostrarFoto();
            }
        }

        private void MudarBandeja(object sender, System.EventArgs e)
        {
            quadroAgrupado.Visible = optConsignado.Checked;
            quadroRelacionamento.Visible = optRelacionamento.Checked;
        }

        /// <summary>
        /// Ocorre ao clicar em "escolher outro pedido".
        /// </summary>
        private void opçãoOutro_Click(object sender, System.EventArgs e)
        {
            SubstituirBaseParaAnterior();
        }

        private void quadroMercadoria_EventoAlterou(Entidades.Saquinho saquinhoOriginal, Entidades.Mercadoria novaMercadoria, double novaQtd)
        {
            bool entidadeTravada = entidade.Travado;
            AtualizarApresentação(entidadeTravada);

            if (entidadeTravada)
            {
                Beepador.Erro();
                MessageBox.Show(this, "O documento não pode ser alterado porque encontra-se travado. \nContacte o supervisor para seu destravamento.", "Documento travado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((saquinhoOriginal.Mercadoria.Peso != saquinhoOriginal.Peso) && (saquinhoOriginal.Mercadoria.DePeso))
                throw new Exception("Peso da mercadoria deveria ser igual do saquinho");

            bandejaAgrupada.Remover(saquinhoOriginal);
            bandejaAgrupada.Adicionar(new Saquinho(novaMercadoria, novaQtd));

            bandejaHistórico.Adicionar(new SaquinhoRelacionado(saquinhoOriginal.Mercadoria, saquinhoOriginal.Quantidade, DateTime.Now, Entidades.Pessoa.Funcionário.FuncionárioAtual, SaquinhoRelacionado.EnumAção.Remoção));
            bandejaHistórico.Adicionar(new SaquinhoRelacionado(novaMercadoria, novaQtd, DateTime.Now, Entidades.Pessoa.Funcionário.ObterFuncionárioPorUsuário(Acesso.Comum.Usuários.UsuárioAtual), SaquinhoRelacionado.EnumAção.Inserção));

            entidade.Itens.Remover(saquinhoOriginal.Mercadoria, saquinhoOriginal.Quantidade);
            entidade.Itens.Adicionar(novaMercadoria, novaQtd);

            // Já atualiza os itens
            entidade.Atualizar();
        }

        private void bandejaPedido_SeleçãoMudou(Bandeja bandeja, Saquinho saquinho)
        {
            if (saquinho != null)
            {
                quadroFoto.MostrarFoto(saquinho.Mercadoria);
                quadroMercadoria.AlternarParaAlteração(saquinho);
            }
            else
            {
                // Des-selecionou
                quadroMercadoria.AlternarParaAdicionar();
                //quadroFoto.MostrarFoto();
            }
        }

        private void bandejaRelacionada_SeleçãoMudou(Bandeja bandeja, Saquinho saquinho)
        {
            if (saquinho != null)
                quadroFoto.MostrarFoto(saquinho.Mercadoria);
            //else
            //    quadroFoto.MostrarFoto();
        }

        protected virtual JanelaImpressão CriarJanelaImpressão()
        {
            throw new Exception("Método abstrato");
        }

        private void opçãoImprimir_Click(object sender, System.EventArgs e)
        {
            JanelaImpressão janela = CriarJanelaImpressão();

            try
            {
                janela.Abrir(this);
            }
            catch (Exception err)
            {
                Beepador.Erro();
                MessageBox.Show(this, "Erro ao abrir janela de impressão \n\n" + err.Message, "Erro na impressão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (janela != null)
                {
                    janela.Close();
                    janela.Dispose();
                }
            }

        }

        private void bandejaAgrupada_SaquinhosExcluídos(Bandeja bandeja, Saquinho[] saquinhos)
        {
            bool entidadeTravada = entidade.Travado;
            AtualizarApresentação(entidadeTravada);

            if (!entidadeTravada)
            {
                foreach (Saquinho saquinho in saquinhos)
                {
                    entidade.Itens.Remover(saquinho.Mercadoria, saquinho.Quantidade);
                    bandejaHistórico.Adicionar(new SaquinhoRelacionado(saquinho.Mercadoria, saquinho.Quantidade, DateTime.Now, Entidades.Pessoa.Funcionário.FuncionárioAtual, SaquinhoRelacionado.EnumAção.Remoção));
                }

                entidade.Atualizar();
            }
            else
            {
                if (entidadeTravada)
                {
                    Beepador.Erro();
                    MessageBox.Show(this, "O documento não pode ser alterado porque encontra-se travado. \nContacte o supervisor para seu destravamento.",
                        "Documento travado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void opçãoDestravar_Click(object sender, EventArgs e)
        {
            bool entidadeTravada = entidade.Travado;
            AtualizarApresentação(entidadeTravada);

            if (!entidadeTravada)
            {
                //Beepador.Erro();
                MessageBox.Show(this, "O documento já está destravado", "Erro ao destravar documento de consignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.ConsignadoDestravar))
            {
                MessageBox.Show(this, "Você não tem permissão para destravar o documento.\n", "Não é possível destravar documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (MessageBox.Show(this, "Ao destravar um documento de consignado, ele poderá ser modificado, e então poderá existir uma versão impressa diferente do documento no computador. \nDestravar mesmo assim ? ", "Destravar documento de consignado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No) return;

            try
            {
                entidade.Travado = false;
                AtualizarApresentação(false);
            }
            catch (Exception err)
            {
                Beepador.Erro();
                MessageBox.Show(this, " O servidor não pode destravar documento de consignado\n\n" + err.Message, "Erro ao destravar consignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void bandejaAgrupada_AntesExcusão(ref bool cancelar)
        {
            bool travado = entidade.Travado;
            AtualizarApresentação(travado);

            cancelar = travado;
        }
    }
}
