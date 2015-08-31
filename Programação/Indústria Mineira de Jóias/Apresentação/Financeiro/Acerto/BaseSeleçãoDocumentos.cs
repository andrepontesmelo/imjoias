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
using Entidades.Relacionamento;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Acerto
{
    /// <summary>
    /// Permite a seleção de documentos para iniciar o acerto.
    /// </summary>
    public partial class BaseSeleçãoDocumentos : Apresentação.Formulários.BaseInferior
    {
        private AcertoConsignado acerto;

        public BaseSeleçãoDocumentos()
        {
            InitializeComponent();
        }

        public AcertoConsignado Acerto
        {
            get { return acerto; }
            set { acerto = value; }
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
        private void listaSaídas_DoubleClick(object sender, EventArgs e)
        {
            Apresentação.Financeiro.Saída.SaídaBaseInferior baseSaída;

            if (listaSaídas.ItemSelecionado != null)
            {
                Apresentação.Formulários.AguardeDB.Mostrar();
                baseSaída = new Apresentação.Financeiro.Saída.SaídaBaseInferior();
                baseSaída.Abrir((RelacionamentoAcerto) listaSaídas.ItemSelecionado);
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

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();
            Recarregar();
        }

        private void Recarregar()
        {
            UseWaitCursor = true;

            AguardeDB.Mostrar();

            títuloBaseInferior.Título = "Acerto de Mercadorias (cod " + acerto.Código.ToString() + ") de " + acerto.Cliente.Nome;

            // Abrir saídas
            listaSaídas.Carregar(acerto.Cliente);
            listaSaídas.MarcarTudo();

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
        //        new AcertoDocumentos(listaSaídas.ObterCódigosMarcados(),
        //        listaRetornos.ObterCódigosMarcados(),
        //        listaVendas.ObterCódigosMarcados());

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
                SubstituirLista(listaSaídas.ObterDocumentosMarcados(), acerto.Saídas.ExtrairElementos());
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
        /// <param name="antigaLista">Lista antiga já existente no acerto.</param>
        private void SubstituirLista(IEnumerable novaLista, IList antigaLista)
        {
            List<Relacionamento> adicionar = new List<Relacionamento>();

            foreach (Relacionamento relacionamento in novaLista)
                if (antigaLista.Contains(relacionamento))
                    antigaLista.Remove(relacionamento);
                else
                    adicionar.Add(relacionamento);
            
            /* Primeiro deve-se remover para permitir
             * mudança de tabela de preço e minimizar
             * a probabilidade de geração de inconsistências
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

 