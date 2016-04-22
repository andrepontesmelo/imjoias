using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Entidades;
using Apresentação.Formulários;
using Entidades.Acerto;
using Entidades.Configuração;

namespace Apresentação.Financeiro.Acerto
{
    public partial class AcertoBaseInferior : Apresentação.Formulários.BaseInferior
    {
        private Entidades.Pessoa.Pessoa pessoa;

        /// <summary>
        /// Última saída registrada.
        /// </summary>
        private DateTime últimaSaída;
        private DateTime? primeiroDocumentoNãoAcertado;

        /// <summary>
        /// Determina se a base inferior deve verificar o período.
        /// </summary>
        private bool verificarPeríodo = true;

        public AcertoBaseInferior()
        {
            InitializeComponent();

            dataInício.Value = dataInício.MinDate;
            dataFinal.Value = DadosGlobais.Instância.HoraDataAtual;
        }

        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; }
        }

        ///// <summary>
        ///// Abre acerto da pessoa, sugerindo escolha de período.
        ///// </summary>
        //public void Abrir(Entidades.Pessoa.Pessoa pessoa)
        //{
        //    UseWaitCursor = true;

        //    AguardeDB.Mostrar();

        //    dataInício.Enabled = false;
        //    dataFinal.Enabled = false;

        //    this.pessoa = pessoa;

        //    títuloBaseInferior.Descrição =
        //        "Trata-se de um resumo das mercadorias relacionadas para o " +
        //        ((Entidades.Pessoa.Representante.ÉRepresentante(pessoa)) ? "representante" : "cliente")
        //        + " desde último acerto.";

        //    títuloBaseInferior.Título = "Acerto de Mercadorias de " + pessoa.Nome;

        //    // Verificar período.
        //    primeiroDocumentoNãoAcertado = Entidades.Acerto.Acerto.ObterPrimeiraDataNãoAcertada(pessoa);

        //    if (primeiroDocumentoNãoAcertado.HasValue)
        //    {
        //        últimaSaída = Entidades.Relacionamento.Saída.Saída.ObterDataÚltimaSaída(pessoa);

        //        // Se estiver abrindo o acerto, já leva a data de ínicio para a da primeira saída
        //        if (dataInício.Value == dataInício.MinDate)
        //            dataInício.Value = primeiroDocumentoNãoAcertado.Value.Date;

        //        if (dataInício.Value < primeiroDocumentoNãoAcertado.Value)
        //            dataInício.Value = primeiroDocumentoNãoAcertado.Value.Date;

        //        if (verificarPeríodo && últimaSaída >= DateTime.Now.Date && primeiroDocumentoNãoAcertado.Value < DateTime.Now.Date)
        //        {
        //            AguardeDB.Fechar();
        //            SugerirMudançaPeríodo();
        //            AguardeDB.Mostrar();
        //        }

        //        // Abrir acerto.
        //        bandejaAcerto.Abrir(pessoa, dataInício.Value, dataFinal.Value);

        //        // Abrir saídas
        //        listaSaídas.Carregar(pessoa, dataInício.Value, dataFinal.Value);

        //        // Abrir retornos
        //        listaRetornos.Carregar(pessoa);

        //    #warning Para acertos de atacado, o método deve ser outro, que já escolhe a pessoa correta, sendo vendedor ou cliente.

        //        // Abrir vendas
        //        listaVendas.Abrir(pessoa, dataInício.Value, dataFinal.Value);

        //        AguardeDB.Fechar();
        //    }
        //    else // Não existe saída
        //    {
        //        AguardeDB.Fechar();

        //        MessageBox.Show(
        //            this.ParentForm,
        //            "Não existe nenhum documento para ser acertado.\n\nSerá que o acerto anterior foi zerado indevidamente?"
        //            + "\nOu será que você escolheu o cliente/representante errado?",
        //            "Acerto de " + pessoa.Nome,
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);

        //        SubstituirBaseParaAnterior();
        //    }

        //    dataFinal.Enabled = dataInício.Enabled = true;
        //    MostrarAlertas();

        //    UseWaitCursor = false;
        //}

        /// <summary>
        /// Sugere mudança de período para realização do acerto.
        /// </summary>
        private void SugerirMudançaPeríodo()
        {
            verificarPeríodo = false;

            if (MessageBox.Show(
                this.ParentForm,
                "Existe uma relação de saída da empresa datada em " + últimaSaída.ToLongDateString()
                + ". Talvez o acerto esteja sendo feito no mesmo dia que outro relacionamento de saída.\n\n"
                + "Deseja alterar o período?",
                "Acerto de " + pessoa.Nome,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditarPeríodo();
            }
        }

        /// <summary>
        /// Mostra diálogo para edição de período inicial e final.
        /// </summary>
        private void EditarPeríodo()
        {
            using (SeleçãoPeríodo dlg = new SeleçãoPeríodo(
                "Período para acerto de " + pessoa.Nome,
                "Escolha o período relativo ao acerto que deseja realizar.",
                dataInício.Value,
                dataFinal.Value))
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                {
                    dataInício.Value = dlg.PeríodoInicial;
                    dataFinal.Value = dlg.PeríodoFinal;
                }
            }
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            JanelaImpressão j = new Apresentação.Financeiro.Acerto.JanelaImpressão(bandejaAcerto.Acerto);
            j.Abrir(this);

            j.Impresso += new EventHandler(j_Impresso);
        }

        void j_Impresso(object sender, EventArgs e)
        {
            Recarregar();

            JanelaImpressão j = (JanelaImpressão)sender;
            j.Impresso -= new EventHandler(j_Impresso);
        }

        private void opçãoRastro_Click(object sender, EventArgs e)
        {
            AbrirRastro();
        }

        private void bandejaAcerto_DuploClique(Apresentação.Mercadoria.Bandeja.Bandeja bandeja, ISaquinho saquinho)
        {
            AbrirRastro();
        }

        private void AbrirRastro()
        {
            JanelaRastro janela = new JanelaRastro();

            AguardeDB.Mostrar();

            Entidades.Mercadoria.Mercadoria mercadoria = bandejaAcerto.SaquinhoSelecionado.Mercadoria;
            mercadoria.Peso = bandejaAcerto.SaquinhoSelecionado.Peso;
            janela.Abrir(mercadoria, pessoa, dataInício.Value, dataFinal.Value, this.ParentForm);

            AguardeDB.Fechar();
        }

        private void chkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            chkFiltro.Enabled = false;
            Apresentação.Formulários.AguardeDB.Mostrar();

            bandejaAcerto.FiltragemAcerto = chkFiltro.Checked;

            Apresentação.Formulários.AguardeDB.Fechar();
            chkFiltro.Enabled = true;
            UseWaitCursor = false;
        }

        private void opçãoZerarAcerto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apesar desta operação não apagar os documentos, as saídas e retornos não serão mais exibidos nem computados em futuro acerto. As vendas também não serão computadas em novo acerto, no entanto continuarão presentes no histórico de vendas.", "Operação irreversível", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                AguardeDB.Mostrar();

                try
                {
                    Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.ZerarAcerto);

                    bandejaAcerto.Acerto.Acertar();

                    // Atualiza a lista
                    //Recarregar();

                    SubstituirBaseParaInicial();
                    Dispose();
                }
                finally
                {
                    AguardeDB.Fechar();
                }

                MessageBox.Show(
                    ParentForm,
                    "O processo de zerar acerto para " + pessoa.Nome + " foi concluído com êxito.",
                    "Zerar acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bandejaAcerto_SeleçãoMudou(Apresentação.Mercadoria.Bandeja.Bandeja bandeja, ISaquinho saquinho)
        {
            quadroRastro.Visible = saquinho != null;
        }

        /// <summary>
        /// Ocorre ao alterar o período.
        /// </summary>
        private void AoAlterarPeríodo(object sender, EventArgs e)
        {
            /* Se o campo estiver desligado, significa que foi alterado
             * pelo programa.
             */
            if (((Control)sender).Enabled && pessoa != null && ((Control)sender).Tag == null)
                Recarregar();
        }

        /// <summary>
        /// Ocorre quando abre-se o dropdown do período.
        /// </summary>
        private void AoIniciarSeleçãoPeríodo(object sender, EventArgs e)
        {
            ((Control)sender).Tag = SinalizaçãoCarga.Sinalizar(
                bandejaAcerto,
                "Alterando período",
                "Esta lista será atualizada ao término da seleção de período.");
        }

        /// <summary>
        /// Ocorre quando fecha-se o dropdown do período,
        /// indicando uma possível mudança do período.
        /// </summary>
        private void AoFecharSeleçãoPeríodo(object sender, EventArgs e)
        {
            SinalizaçãoCarga.Dessinalizar(((SinalizaçãoCarga)((Control)sender).Tag));

            if (dataInício.Value > dataFinal.Value)
            {
                MessageBox.Show(
                    this.ParentForm,
                    "A data do período inicial está maior que a data do período final.",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                EditarPeríodo();
            }

            if (dataInício.Value > DadosGlobais.Instância.HoraDataAtual.Date)
                if (MessageBox.Show(
                    this.ParentForm,
                    "A data inicial está no futuro. Deseja utilizá-lo mesmo assim?",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    EditarPeríodo();
                }

            if (dataInício.Value < primeiroDocumentoNãoAcertado.Value)
                MessageBox.Show(
                    this.ParentForm,
                    "Não existe nenhuma saída não acertada antes de " + primeiroDocumentoNãoAcertado.Value.ToLongDateString() + "."
                    + " Portanto, a data inicial será atribuída para este dia.",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            if (dataInício.Value.Date > primeiroDocumentoNãoAcertado.Value.Date)
                if (MessageBox.Show(
                    this.ParentForm,
                    "A data do período inicial - " + dataInício.Value.ToLongDateString()
                    + " - é maior que a data do relacionamento da primeira saída da empresa não acertada - "
                    + primeiroDocumentoNãoAcertado.Value.ToLongDateString() + "."
                    + "\n\nDeseja mesmo utilizar o novo período inicial?",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (MessageBox.Show(
                        this.ParentForm,
                        "Realizar o acerto ignorando relacionamentos de saída antigos pode gerar confusão."
                        + "\n\nDeseja proteger os dados, desligando opções de gerar documentos e alterar os dados, porém permitindo a visualização dos dados?",
                        "Acerto de " + pessoa.Nome,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        opçãoImprimir.Enabled = false;
                        opçãoZerarAcerto.Enabled = false;
                    }
                }

            Recarregar();
        }

        /// <summary>
        /// Mostra alertas, se aplicável, a respeito do acerto
        /// em andamento.
        /// </summary>
        private void MostrarAlertas()
        {
            IList<Alerta> alertas;

            if (bandejaAcerto.Acerto != null)
            {
                alertas = Alerta.VerificarAcerto(bandejaAcerto.Acerto);

                if (alertas.Count > 0)
                {
                    foreach (Alerta alerta in alertas)
                        NotificaçãoAlerta.Mostrar(
                            typeof(NotificaçãoAlerta),
                            alerta);
                }
            }
        }

        private void listaVendas_AoDuploClique(long? códigoVenda)
        {
            Apresentação.Financeiro.Venda.BaseEditarVenda baseVenda;

            if (códigoVenda.HasValue)
            {
                Apresentação.Formulários.AguardeDB.Mostrar();
                baseVenda = new Apresentação.Financeiro.Venda.BaseEditarVenda();
                baseVenda.Abrir(Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoVenda.Value));
                SubstituirBase(baseVenda);
                Apresentação.Formulários.AguardeDB.Fechar();
            }
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Recarregar();
        }

        private void Recarregar()
        {

            if (pessoa == null)
                throw new NullReferenceException("Sete a propriedade pessoa.");

            UseWaitCursor = true;

            AguardeDB.Mostrar();

            dataInício.Enabled = false;
            dataFinal.Enabled = false;

            títuloBaseInferior.Descrição =
                "Trata-se de um resumo das mercadorias relacionadas para o " +
                ((Entidades.Pessoa.Representante.ÉRepresentante(pessoa)) ? "representante" : "cliente")
                + " desde último acerto.";

            títuloBaseInferior.Título = "Acerto de Mercadorias de " + pessoa.Nome;

            // Verificar período.
            primeiroDocumentoNãoAcertado = Entidades.Acerto.Acerto.ObterPrimeiraDataNãoAcertada(pessoa);

            if (primeiroDocumentoNãoAcertado.HasValue)
            {
                DateTime hoje = DadosGlobais.Instância.HoraDataAtual.Date;

                últimaSaída = Entidades.Relacionamento.Saída.Saída.ObterDataÚltimaSaída(pessoa);

                // Se estiver abrindo o acerto, já leva a data de ínicio para a da primeira saída
                if (dataInício.Value == dataInício.MinDate)
                    dataInício.Value = primeiroDocumentoNãoAcertado.Value.Date;

                if (dataInício.Value < primeiroDocumentoNãoAcertado.Value)
                    dataInício.Value = primeiroDocumentoNãoAcertado.Value.Date;

                if (verificarPeríodo && últimaSaída >= hoje && primeiroDocumentoNãoAcertado.Value < hoje)
                {
                    AguardeDB.Fechar();
                    SugerirMudançaPeríodo();
                    AguardeDB.Mostrar();
                }

                // Abrir acerto.
                bandejaAcerto.Abrir(pessoa, dataInício.Value, dataFinal.Value);

                // Abrir saídas
                listaSaídas.Carregar(pessoa, dataInício.Value, dataFinal.Value);

                // Abrir retornos
                listaRetornos.Carregar(pessoa);

#warning Para acertos de atacado, o método deve ser outro, que já escolhe a pessoa correta, sendo vendedor ou cliente.

                // Abrir vendas
                listaVendas.Carregar(pessoa, dataInício.Value, dataFinal.Value);

                AguardeDB.Fechar();
            }
            else // Não existe saída
            {
                AguardeDB.Fechar();

                MessageBox.Show(
                    this.ParentForm,
                    "Não existe nenhum documento para ser acertado.\n\nSerá que o acerto anterior foi zerado indevidamente?"
                    + "\nOu será que você escolheu o cliente/representante errado?",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                SubstituirBaseParaAnterior();
            }

            dataFinal.Enabled = dataInício.Enabled = true;
            MostrarAlertas();

            UseWaitCursor = false;


        }

        private void listaSaídas_DoubleClick(object sender, EventArgs e)
        {
            Apresentação.Financeiro.Saída.SaídaBaseInferior baseSaída;

            if (listaSaídas.ItemSelecionado != null)
            {
                Apresentação.Formulários.AguardeDB.Mostrar();
                baseSaída = new Apresentação.Financeiro.Saída.SaídaBaseInferior();
                baseSaída.Abrir(listaSaídas.ItemSelecionado);
                SubstituirBase(baseSaída);
                Apresentação.Formulários.AguardeDB.Fechar();
            }
        }

        private void listaRetornos_DoubleClick(object sender, EventArgs e)
        {
            Apresentação.Financeiro.Retorno.RetornoBaseInferior baseRetorno;

            if (listaRetornos.ItemSelecionado != null)
            {
                Apresentação.Formulários.AguardeDB.Mostrar();
                baseRetorno = new Apresentação.Financeiro.Retorno.RetornoBaseInferior();
                baseRetorno.Abrir(listaRetornos.ItemSelecionado);
                SubstituirBase(baseRetorno);
                Apresentação.Formulários.AguardeDB.Fechar();
            }
        }
    }
}

 