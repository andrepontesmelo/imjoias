using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Entidades;
using Apresenta��o.Formul�rios;
using Entidades.Acerto;
using Entidades.Configura��o;

namespace Apresenta��o.Financeiro.Acerto
{
    public partial class AcertoBaseInferior : Apresenta��o.Formul�rios.BaseInferior
    {
        private Entidades.Pessoa.Pessoa pessoa;

        /// <summary>
        /// �ltima sa�da registrada.
        /// </summary>
        private DateTime �ltimaSa�da;
        private DateTime? primeiroDocumentoN�oAcertado;

        /// <summary>
        /// Determina se a base inferior deve verificar o per�odo.
        /// </summary>
        private bool verificarPer�odo = true;

        public AcertoBaseInferior()
        {
            InitializeComponent();

            dataIn�cio.Value = dataIn�cio.MinDate;
            dataFinal.Value = DadosGlobais.Inst�ncia.HoraDataAtual;
        }

        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; }
        }

        ///// <summary>
        ///// Abre acerto da pessoa, sugerindo escolha de per�odo.
        ///// </summary>
        //public void Abrir(Entidades.Pessoa.Pessoa pessoa)
        //{
        //    UseWaitCursor = true;

        //    AguardeDB.Mostrar();

        //    dataIn�cio.Enabled = false;
        //    dataFinal.Enabled = false;

        //    this.pessoa = pessoa;

        //    t�tuloBaseInferior.Descri��o =
        //        "Trata-se de um resumo das mercadorias relacionadas para o " +
        //        ((Entidades.Pessoa.Representante.�Representante(pessoa)) ? "representante" : "cliente")
        //        + " desde �ltimo acerto.";

        //    t�tuloBaseInferior.T�tulo = "Acerto de Mercadorias de " + pessoa.Nome;

        //    // Verificar per�odo.
        //    primeiroDocumentoN�oAcertado = Entidades.Acerto.Acerto.ObterPrimeiraDataN�oAcertada(pessoa);

        //    if (primeiroDocumentoN�oAcertado.HasValue)
        //    {
        //        �ltimaSa�da = Entidades.Relacionamento.Sa�da.Sa�da.ObterData�ltimaSa�da(pessoa);

        //        // Se estiver abrindo o acerto, j� leva a data de �nicio para a da primeira sa�da
        //        if (dataIn�cio.Value == dataIn�cio.MinDate)
        //            dataIn�cio.Value = primeiroDocumentoN�oAcertado.Value.Date;

        //        if (dataIn�cio.Value < primeiroDocumentoN�oAcertado.Value)
        //            dataIn�cio.Value = primeiroDocumentoN�oAcertado.Value.Date;

        //        if (verificarPer�odo && �ltimaSa�da >= DateTime.Now.Date && primeiroDocumentoN�oAcertado.Value < DateTime.Now.Date)
        //        {
        //            AguardeDB.Fechar();
        //            SugerirMudan�aPer�odo();
        //            AguardeDB.Mostrar();
        //        }

        //        // Abrir acerto.
        //        bandejaAcerto.Abrir(pessoa, dataIn�cio.Value, dataFinal.Value);

        //        // Abrir sa�das
        //        listaSa�das.Carregar(pessoa, dataIn�cio.Value, dataFinal.Value);

        //        // Abrir retornos
        //        listaRetornos.Carregar(pessoa);

        //    #warning Para acertos de atacado, o m�todo deve ser outro, que j� escolhe a pessoa correta, sendo vendedor ou cliente.

        //        // Abrir vendas
        //        listaVendas.Abrir(pessoa, dataIn�cio.Value, dataFinal.Value);

        //        AguardeDB.Fechar();
        //    }
        //    else // N�o existe sa�da
        //    {
        //        AguardeDB.Fechar();

        //        MessageBox.Show(
        //            this.ParentForm,
        //            "N�o existe nenhum documento para ser acertado.\n\nSer� que o acerto anterior foi zerado indevidamente?"
        //            + "\nOu ser� que voc� escolheu o cliente/representante errado?",
        //            "Acerto de " + pessoa.Nome,
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);

        //        SubstituirBaseParaAnterior();
        //    }

        //    dataFinal.Enabled = dataIn�cio.Enabled = true;
        //    MostrarAlertas();

        //    UseWaitCursor = false;
        //}

        /// <summary>
        /// Sugere mudan�a de per�odo para realiza��o do acerto.
        /// </summary>
        private void SugerirMudan�aPer�odo()
        {
            verificarPer�odo = false;

            if (MessageBox.Show(
                this.ParentForm,
                "Existe uma rela��o de sa�da da empresa datada em " + �ltimaSa�da.ToLongDateString()
                + ". Talvez o acerto esteja sendo feito no mesmo dia que outro relacionamento de sa�da.\n\n"
                + "Deseja alterar o per�odo?",
                "Acerto de " + pessoa.Nome,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditarPer�odo();
            }
        }

        /// <summary>
        /// Mostra di�logo para edi��o de per�odo inicial e final.
        /// </summary>
        private void EditarPer�odo()
        {
            using (Sele��oPer�odo dlg = new Sele��oPer�odo(
                "Per�odo para acerto de " + pessoa.Nome,
                "Escolha o per�odo relativo ao acerto que deseja realizar.",
                dataIn�cio.Value,
                dataFinal.Value))
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                {
                    dataIn�cio.Value = dlg.Per�odoInicial;
                    dataFinal.Value = dlg.Per�odoFinal;
                }
            }
        }

        private void op��oImprimir_Click(object sender, EventArgs e)
        {
            JanelaImpress�o j = new Apresenta��o.Financeiro.Acerto.JanelaImpress�o(bandejaAcerto.Acerto);
            j.Abrir(this);

            j.Impresso += new EventHandler(j_Impresso);
        }

        void j_Impresso(object sender, EventArgs e)
        {
            Recarregar();

            JanelaImpress�o j = (JanelaImpress�o)sender;
            j.Impresso -= new EventHandler(j_Impresso);
        }

        private void op��oRastro_Click(object sender, EventArgs e)
        {
            AbrirRastro();
        }

        private void bandejaAcerto_DuploClique(Apresenta��o.Mercadoria.Bandeja.Bandeja bandeja, ISaquinho saquinho)
        {
            AbrirRastro();
        }

        private void AbrirRastro()
        {
            JanelaRastro janela = new JanelaRastro();

            AguardeDB.Mostrar();

            Entidades.Mercadoria.Mercadoria mercadoria = bandejaAcerto.SaquinhoSelecionado.Mercadoria;
            mercadoria.Peso = bandejaAcerto.SaquinhoSelecionado.Peso;
            janela.Abrir(mercadoria, pessoa, dataIn�cio.Value, dataFinal.Value, this.ParentForm);

            AguardeDB.Fechar();
        }

        private void chkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            chkFiltro.Enabled = false;
            Apresenta��o.Formul�rios.AguardeDB.Mostrar();

            bandejaAcerto.FiltragemAcerto = chkFiltro.Checked;

            Apresenta��o.Formul�rios.AguardeDB.Fechar();
            chkFiltro.Enabled = true;
            UseWaitCursor = false;
        }

        private void op��oZerarAcerto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apesar desta opera��o n�o apagar os documentos, as sa�das e retornos n�o ser�o mais exibidos nem computados em futuro acerto. As vendas tamb�m n�o ser�o computadas em novo acerto, no entanto continuar�o presentes no hist�rico de vendas.", "Opera��o irrevers�vel", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                AguardeDB.Mostrar();

                try
                {
                    Entidades.Privil�gio.Permiss�oFuncion�rio.AssegurarPermiss�o(Entidades.Privil�gio.Permiss�o.ZerarAcerto);

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
                    "O processo de zerar acerto para " + pessoa.Nome + " foi conclu�do com �xito.",
                    "Zerar acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bandejaAcerto_Sele��oMudou(Apresenta��o.Mercadoria.Bandeja.Bandeja bandeja, ISaquinho saquinho)
        {
            quadroRastro.Visible = saquinho != null;
        }

        /// <summary>
        /// Ocorre ao alterar o per�odo.
        /// </summary>
        private void AoAlterarPer�odo(object sender, EventArgs e)
        {
            /* Se o campo estiver desligado, significa que foi alterado
             * pelo programa.
             */
            if (((Control)sender).Enabled && pessoa != null && ((Control)sender).Tag == null)
                Recarregar();
        }

        /// <summary>
        /// Ocorre quando abre-se o dropdown do per�odo.
        /// </summary>
        private void AoIniciarSele��oPer�odo(object sender, EventArgs e)
        {
            ((Control)sender).Tag = Sinaliza��oCarga.Sinalizar(
                bandejaAcerto,
                "Alterando per�odo",
                "Esta lista ser� atualizada ao t�rmino da sele��o de per�odo.");
        }

        /// <summary>
        /// Ocorre quando fecha-se o dropdown do per�odo,
        /// indicando uma poss�vel mudan�a do per�odo.
        /// </summary>
        private void AoFecharSele��oPer�odo(object sender, EventArgs e)
        {
            Sinaliza��oCarga.Dessinalizar(((Sinaliza��oCarga)((Control)sender).Tag));

            if (dataIn�cio.Value > dataFinal.Value)
            {
                MessageBox.Show(
                    this.ParentForm,
                    "A data do per�odo inicial est� maior que a data do per�odo final.",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                EditarPer�odo();
            }

            if (dataIn�cio.Value > DadosGlobais.Inst�ncia.HoraDataAtual.Date)
                if (MessageBox.Show(
                    this.ParentForm,
                    "A data inicial est� no futuro. Deseja utiliz�-lo mesmo assim?",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    EditarPer�odo();
                }

            if (dataIn�cio.Value < primeiroDocumentoN�oAcertado.Value)
                MessageBox.Show(
                    this.ParentForm,
                    "N�o existe nenhuma sa�da n�o acertada antes de " + primeiroDocumentoN�oAcertado.Value.ToLongDateString() + "."
                    + " Portanto, a data inicial ser� atribu�da para este dia.",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            if (dataIn�cio.Value.Date > primeiroDocumentoN�oAcertado.Value.Date)
                if (MessageBox.Show(
                    this.ParentForm,
                    "A data do per�odo inicial - " + dataIn�cio.Value.ToLongDateString()
                    + " - � maior que a data do relacionamento da primeira sa�da da empresa n�o acertada - "
                    + primeiroDocumentoN�oAcertado.Value.ToLongDateString() + "."
                    + "\n\nDeseja mesmo utilizar o novo per�odo inicial?",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (MessageBox.Show(
                        this.ParentForm,
                        "Realizar o acerto ignorando relacionamentos de sa�da antigos pode gerar confus�o."
                        + "\n\nDeseja proteger os dados, desligando op��es de gerar documentos e alterar os dados, por�m permitindo a visualiza��o dos dados?",
                        "Acerto de " + pessoa.Nome,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        op��oImprimir.Enabled = false;
                        op��oZerarAcerto.Enabled = false;
                    }
                }

            Recarregar();
        }

        /// <summary>
        /// Mostra alertas, se aplic�vel, a respeito do acerto
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
                        Notifica��oAlerta.Mostrar(
                            typeof(Notifica��oAlerta),
                            alerta);
                }
            }
        }

        private void listaVendas_AoDuploClique(long? c�digoVenda)
        {
            Apresenta��o.Financeiro.Venda.BaseEditarVenda baseVenda;

            if (c�digoVenda.HasValue)
            {
                Apresenta��o.Formul�rios.AguardeDB.Mostrar();
                baseVenda = new Apresenta��o.Financeiro.Venda.BaseEditarVenda();
                baseVenda.Abrir(Entidades.Relacionamento.Venda.Venda.ObterVenda(c�digoVenda.Value));
                SubstituirBase(baseVenda);
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
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

            dataIn�cio.Enabled = false;
            dataFinal.Enabled = false;

            t�tuloBaseInferior.Descri��o =
                "Trata-se de um resumo das mercadorias relacionadas para o " +
                ((Entidades.Pessoa.Representante.�Representante(pessoa)) ? "representante" : "cliente")
                + " desde �ltimo acerto.";

            t�tuloBaseInferior.T�tulo = "Acerto de Mercadorias de " + pessoa.Nome;

            // Verificar per�odo.
            primeiroDocumentoN�oAcertado = Entidades.Acerto.Acerto.ObterPrimeiraDataN�oAcertada(pessoa);

            if (primeiroDocumentoN�oAcertado.HasValue)
            {
                DateTime hoje = DadosGlobais.Inst�ncia.HoraDataAtual.Date;

                �ltimaSa�da = Entidades.Relacionamento.Sa�da.Sa�da.ObterData�ltimaSa�da(pessoa);

                // Se estiver abrindo o acerto, j� leva a data de �nicio para a da primeira sa�da
                if (dataIn�cio.Value == dataIn�cio.MinDate)
                    dataIn�cio.Value = primeiroDocumentoN�oAcertado.Value.Date;

                if (dataIn�cio.Value < primeiroDocumentoN�oAcertado.Value)
                    dataIn�cio.Value = primeiroDocumentoN�oAcertado.Value.Date;

                if (verificarPer�odo && �ltimaSa�da >= hoje && primeiroDocumentoN�oAcertado.Value < hoje)
                {
                    AguardeDB.Fechar();
                    SugerirMudan�aPer�odo();
                    AguardeDB.Mostrar();
                }

                // Abrir acerto.
                bandejaAcerto.Abrir(pessoa, dataIn�cio.Value, dataFinal.Value);

                // Abrir sa�das
                listaSa�das.Carregar(pessoa, dataIn�cio.Value, dataFinal.Value);

                // Abrir retornos
                listaRetornos.Carregar(pessoa);

#warning Para acertos de atacado, o m�todo deve ser outro, que j� escolhe a pessoa correta, sendo vendedor ou cliente.

                // Abrir vendas
                listaVendas.Carregar(pessoa, dataIn�cio.Value, dataFinal.Value);

                AguardeDB.Fechar();
            }
            else // N�o existe sa�da
            {
                AguardeDB.Fechar();

                MessageBox.Show(
                    this.ParentForm,
                    "N�o existe nenhum documento para ser acertado.\n\nSer� que o acerto anterior foi zerado indevidamente?"
                    + "\nOu ser� que voc� escolheu o cliente/representante errado?",
                    "Acerto de " + pessoa.Nome,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                SubstituirBaseParaAnterior();
            }

            dataFinal.Enabled = dataIn�cio.Enabled = true;
            MostrarAlertas();

            UseWaitCursor = false;


        }

        private void listaSa�das_DoubleClick(object sender, EventArgs e)
        {
            Apresenta��o.Financeiro.Sa�da.Sa�daBaseInferior baseSa�da;

            if (listaSa�das.ItemSelecionado != null)
            {
                Apresenta��o.Formul�rios.AguardeDB.Mostrar();
                baseSa�da = new Apresenta��o.Financeiro.Sa�da.Sa�daBaseInferior();
                baseSa�da.Abrir(listaSa�das.ItemSelecionado);
                SubstituirBase(baseSa�da);
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
            }
        }

        private void listaRetornos_DoubleClick(object sender, EventArgs e)
        {
            Apresenta��o.Financeiro.Retorno.RetornoBaseInferior baseRetorno;

            if (listaRetornos.ItemSelecionado != null)
            {
                Apresenta��o.Formul�rios.AguardeDB.Mostrar();
                baseRetorno = new Apresenta��o.Financeiro.Retorno.RetornoBaseInferior();
                baseRetorno.Abrir(listaRetornos.ItemSelecionado);
                SubstituirBase(baseRetorno);
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
            }
        }
    }
}

 