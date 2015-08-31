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
using Entidades.Relacionamento;
using Entidades.Relacionamento.Venda;

namespace Apresenta��o.Financeiro.Acerto
{
    /// <summary>
    /// Permite a sele��o de documentos para iniciar o acerto.
    /// </summary>
    public partial class BaseSele��oDocumentos : Apresenta��o.Formul�rios.BaseInferior
    {
        private AcertoConsignado acerto;

        public BaseSele��oDocumentos()
        {
            InitializeComponent();
        }

        public AcertoConsignado Acerto
        {
            get { return acerto; }
            set { acerto = value; }
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
        private void listaSa�das_DoubleClick(object sender, EventArgs e)
        {
            Apresenta��o.Financeiro.Sa�da.Sa�daBaseInferior baseSa�da;

            if (listaSa�das.ItemSelecionado != null)
            {
                Apresenta��o.Formul�rios.AguardeDB.Mostrar();
                baseSa�da = new Apresenta��o.Financeiro.Sa�da.Sa�daBaseInferior();
                baseSa�da.Abrir((RelacionamentoAcerto) listaSa�das.ItemSelecionado);
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

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();
            Recarregar();
        }

        private void Recarregar()
        {
            UseWaitCursor = true;

            AguardeDB.Mostrar();

            t�tuloBaseInferior.T�tulo = "Acerto de Mercadorias (cod " + acerto.C�digo.ToString() + ") de " + acerto.Cliente.Nome;

            // Abrir sa�das
            listaSa�das.Carregar(acerto.Cliente);
            listaSa�das.MarcarTudo();

            // Abrir retornos
            listaRetornos.Carregar(acerto.Cliente);
            listaRetornos.MarcarTudo();

            // Abrir vendas
            listaVendas.Carregar(acerto.Cliente, false);
            listaVendas.SelecionarTudo();

            AguardeDB.Fechar();

            UseWaitCursor = false;
        }

        //private void btnContabilizar_Click(object sender, EventArgs e)
        //{
        //    UseWaitCursor = true;
        //    AguardeDB.Mostrar();

        //    AcertoDocumentos documentos =
        //        new AcertoDocumentos(listaSa�das.ObterC�digosMarcados(),
        //        listaRetornos.ObterC�digosMarcados(),
        //        listaVendas.ObterC�digosMarcados());

        //    documentos.Pessoa = pessoa;

        //    AlertaBaseInferior alerta = new AlertaBaseInferior();
        //    alerta.Carregar(documentos);
        //    SubstituirBase(alerta);
            
        //    AguardeDB.Fechar();
        //    UseWaitCursor = false;
        //}

        private void btnAtribuir_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                SubstituirLista(listaSa�das.ObterDocumentosMarcados(), acerto.Sa�das.ExtrairElementos());
                SubstituirLista(listaRetornos.ObterDocumentosMarcados(), acerto.Retornos.ExtrairElementos());
                SubstituirLista(listaVendas.ObterVendasSelecionadas(), acerto.Vendas.ExtrairElementos());
                Acerto.Atualizar();
                SubstituirBaseParaAnterior();
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        /// <summary>
        /// Substitui a lista de relacionamentos de um acerto.
        /// </summary>
        /// <param name="novaLista">Nova lista a ser colocada no acerto.</param>
        /// <param name="antigaLista">Lista antiga j� existente no acerto.</param>
        private void SubstituirLista(IEnumerable novaLista, IList antigaLista)
        {
            List<Relacionamento> adicionar = new List<Relacionamento>();

            foreach (Relacionamento relacionamento in novaLista)
                if (antigaLista.Contains(relacionamento))
                    antigaLista.Remove(relacionamento);
                else
                    adicionar.Add(relacionamento);
            
            /* Primeiro deve-se remover para permitir
             * mudan�a de tabela de pre�o e minimizar
             * a probabilidade de gera��o de inconsist�ncias
             * que poderiam ocorrer devido a relacionamentos
             * que deveriam ter sido removidos.
             */
            foreach (Relacionamento relacionamento in antigaLista)
                acerto.Remover(relacionamento);

            foreach (Relacionamento relacionamento in adicionar)
                acerto.Adicionar(relacionamento);
        }
    }
}

 