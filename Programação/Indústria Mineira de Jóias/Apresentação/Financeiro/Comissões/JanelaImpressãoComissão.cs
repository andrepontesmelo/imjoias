using Apresentação.Formulários;
using Entidades.ComissãoCálculo.Impressão;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Comissões
{
    public partial class JanelaImpressãoComissão : JanelaImpressão
    {
        private Entidades.ComissãoCálculo.Comissão comissão;
        private Filtro filtro = null;

        public JanelaImpressãoComissão(Entidades.ComissãoCálculo.Comissão comissão, Filtro filtro)
        {
            this.comissão = comissão;
            this.filtro = filtro;
        }


        public JanelaImpressãoComissão()
        {
            InitializeComponent();
        }

        public void InserirRelatórioResumo()
        {
            Apresentação.Impressão.Relatórios.Comissao.RelatorioResumo r
                = new Apresentação.Impressão.Relatórios.Comissao.RelatorioResumo();

            new Apresentação.Impressão.Relatórios.Comissao.ControladorImpressãoResumo().
                PrepararImpressão(r, comissão.ObterImpressãoResumo(filtro), comissão);

            Título = "Comissão #" + comissão.Código.ToString();
            Descrição = "Relatório de resumo";
            InserirDocumento(r, "Resumo");
        }


        public void InserirRelatórioSetor()
        {
            Apresentação.Impressão.Relatórios.Comissao.RelatorioSetor r
                = new Apresentação.Impressão.Relatórios.Comissao.RelatorioSetor();

            new Apresentação.Impressão.Relatórios.Comissao.ControladorImpressãoComissãoSetor().
                PrepararImpressão(r, comissão.ObterImpressãoSetor(filtro), comissão);

            Título = "Comissão #" + comissão.Código.ToString();
            Descrição = "Relatório por setores";
            InserirDocumento(r, "Setor");
        }

        public void InserirRelatórioVenda()
        {
            Apresentação.Impressão.Relatórios.Comissao.RelatorioComissaoVenda r
                = new Apresentação.Impressão.Relatórios.Comissao.RelatorioComissaoVenda();

            new Apresentação.Impressão.Relatórios.Comissao.ControladorImpressãoComissãoVenda().
                PrepararImpressão(r, comissão.ObterImpressãoVenda(), comissão);

            Título = "Comissão #" + comissão.Código.ToString();
            Descrição = "Relatório de vendas";
            InserirDocumento(r, "Venda");
        }

        public void InserirRelatórioVendaItem()
        {
            Apresentação.Impressão.Relatórios.Comissao.RelatorioComissaoVendaItem r
                = new Apresentação.Impressão.Relatórios.Comissao.RelatorioComissaoVendaItem();

            new Apresentação.Impressão.Relatórios.Comissao.ControladorImpressãoComissãoVendaItem().
                PrepararImpressão(r, comissão.ObterImpressãoVendaItem(), comissão);

            Título = "Comissão #" + comissão.Código.ToString();
            Descrição = "Relatório de Item";
            InserirDocumento(r, "Item");
        }



        public void InserirRelatórioRegraPessoa()
        {
            Apresentação.Impressão.Relatórios.Comissao.RelatorioRegraPessoa r
                = new Apresentação.Impressão.Relatórios.Comissao.RelatorioRegraPessoa();

            new Apresentação.Impressão.Relatórios.Comissao.ControladorImpressãoRegraPessoa().
                PrepararImpressão(r, comissão.ObterImpressãoRegraPessoa(), comissão);

            Título = "Comissão #" + comissão.Código.ToString();
            Descrição = "Relatório Regra";
            InserirDocumento(r, "Regra");
        }

        public void InserirTodosRelatorios()
        {
            InserirRelatórioResumo();
            InserirRelatórioSetor();
            InserirRelatórioRegraPessoa();
            InserirRelatórioCompartilhada();
            InserirRelatórioVenda();
            InserirRelatórioVendaItem();
        }

        internal void InserirRelatórioCompartilhada()
        {
            Apresentação.Impressão.Relatórios.Comissao.RelatorioCompartilhada r
                = new Apresentação.Impressão.Relatórios.Comissao.RelatorioCompartilhada();

            new Apresentação.Impressão.Relatórios.Comissao.ControladorImpressãoCompartilhada().
                PrepararImpressão(r, comissão.ObterImpressãoCompartilhada(), comissão);

            Título = "Comissão #" + comissão.Código.ToString();
            Descrição = "Relatório de comissão compartilhada representante e atacado.";
            InserirDocumento(r, "Compartilhada");
        }
    }
}
