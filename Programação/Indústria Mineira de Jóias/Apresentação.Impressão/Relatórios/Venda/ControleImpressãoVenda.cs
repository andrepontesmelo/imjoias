using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades.Relacionamento.Venda;
using Entidades;
using Entidades.Pagamentos;
using Entidades.Pessoa;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Impressão.Relatórios.Venda
{
    public class ControleImpressãoVenda : ControleImpressãoRelacionamento<DataSetVenda, Entidades.Relacionamento.Venda.Venda>
    {
        /*
        private VendaSintetizada[] vendasRelacionadas = null;
        private VendaSintetizada[] ObterVendasRelacionadas(Entidades.Relacionamento.Venda.Venda venda)
        {
            if (vendasRelacionadas == null)
                vendasRelacionadas = 
                    Entidades.Relacionamento.Venda.VendaSintetizada.ObterVendasRelacionadasPorPagamento(venda.Código);

            return vendasRelacionadas;
        }
        */

        protected override void MapearInformações(DataRow linha, Entidades.Relacionamento.Venda.Venda venda)
        {
            double dívida, juros, jurosPagamentos;
            List<Entidades.Pagamentos.Pagamento> pagamentos;
            string[] prestações;
           
            base.MapearInformações(linha, venda);

            List<IPagamento> listaPagamentos = new List<IPagamento>();

            prestações = venda.ObterPrestações(out pagamentos);
            foreach (Pagamento p in pagamentos) listaPagamentos.Add(p);

            venda.CalcularDívida(venda.Data, out dívida, out juros, pagamentos, prestações);

            jurosPagamentos = Entidades.Pagamentos.Pagamento.CalcularJuros(listaPagamentos, Preço.SomarDiasTabelaComercial(venda.Data, (int) venda.DiasSemJuros), venda.TaxaJuros);

            List<IPagamento> lst = new List<IPagamento>();
            foreach (Pagamento p in pagamentos)
                lst.Add((IPagamento)p);


            linha["valorPago"] = Entidades.Pagamentos.Pagamento.CalcularValorPago(lst);
            linha["dívida"] = dívida;
            linha["juros"] = jurosPagamentos;
            linha["pagoLíquido"] = Entidades.Pagamentos.Pagamento.CalcularValorPagoLíquido(listaPagamentos, Preço.SomarDiasTabelaComercial(venda.Data, (int)venda.DiasSemJuros), venda.TaxaJuros);
            linha["mostrarDívida"] = true;
/*
            double valorTotalVendasRelacionadas = 0;
            foreach (VendaSintetizada v in ObterVendasRelacionadas(venda))
                valorTotalVendasRelacionadas += v.Valor;
            */

            linha["funcionário"] = venda.Vendedor.Nome;
            linha["cotação"] = venda.Cotação;
            linha["controle"] = venda.Controle.HasValue ? venda.Controle.Value.ToString() : "Sem número de controle";
            
            
                linha["valorVenda"] = venda.Itens.CalcularPreço(venda.Cotação);
            
            //linha["valorTotal"] = venda.Valor;
            linha["valorTotal"] = venda.Valor;
            
            linha["valorDevolução"] = venda.ItensDevolução.CalcularPreço(venda.Cotação);
            linha["desconto"] = venda.Desconto;
            linha["observações"] = venda.Observações;
            linha["diasSemJuros"] = venda.DiasSemJuros == 0 ? "" : venda.DiasSemJuros.ToString() + " dias sem juros";

            double débitos = venda.CalcularDébitos();
            double créditos = venda.CalcularCréditos();

            linha["totalDébitos"] = débitos;
            linha["totalCréditos"] = créditos;
            linha["valorPagar"] = venda.Valor + débitos - créditos;
            
            if (venda.Cliente != null)
            {
                Endereço[] endereços = venda.Cliente.Endereços.ToArray();

                string estado = (endereços.Length > 0 && endereços[0].Localidade != null) ?
                    (endereços[0].Localidade.Estado != null ? endereços[0].Localidade.Estado.Sigla : "" ) : "";
                linha["cidade"] =
                    (endereços.Length > 0 && endereços[0].Localidade != null) ?
                    endereços[0].Localidade.Nome + " - " + estado: "";
            }

        }

        public override DataSetVenda GerarDataSet(Entidades.Relacionamento.Venda.Venda venda)
        {
            DataSetVenda ds = base.GerarDataSet(venda);
            DataTable itens = ds.Tables["Itens"];
            DataTable tabelaModoPagamentos = ds.Tables["ModoPagamento"];
            DataTable tabelaDébitos = ds.Tables["Débito"];
            DataTable tabelaCréditos = ds.Tables["Crédito"];
            DataTable tabelaPagamentos = ds.Tables["Pagamentos"];
            DataTable tabelaInformações = ds.Tables["Informações"];
            DataTable tabelaVendasRelacionadas = ds.Tables["VendasRelacionadas"];
            DataRow linhaInfo = tabelaInformações.Rows[0];

            // Preencher devoluções
            foreach (SaquinhoDevolução devolução in venda.ItensDevolução.ObterSaquinhosAgrupadosOrdenados())
            {
                DataRow linha = itens.NewRow();
                MapearItem(linha, devolução, venda);
                linha["devolvido"] = true;
                itens.Rows.Add(linha);
            }

            
            // Preencher vendas relacionadas
            linhaInfo["mostrarVendasRelacionadas"] = false;
            //double valorTotalVendasRelacionadas = 0;
            //foreach (VendaSintetizada v in ObterVendasRelacionadas(venda))
            //{
            //    DataRow item = tabelaVendasRelacionadas.NewRow();
            //    item["data"] = v.Data.ToShortDateString();
            //    item["código"] = v.Código.ToString();
            //    item["controle"] = v.Controle.ToString();
            //    item["valorVenda"] = v.Valor.ToString("C");
            //    tabelaVendasRelacionadas.Rows.Add(item);
            //    linhaInfo["mostrarVendasRelacionadas"] = true;
            //    //valorTotalVendasRelacionadas += v.Valor;
            // }
             //linhaInfo["valorTotalVendasRelacionadas"] = valorTotalVendasRelacionadas.ToString("C");

            // Preencher formas de pagamento
            foreach (Entidades.Relacionamento.Venda.ModoPagamento m in ModoPagamento.ObterModosPagamento(venda))
            {
                int[] dias = Preço.InterpretarDiasPrestações(m.Prestações);

                if (dias.Length != 0)
                {
                    DataRow item = tabelaModoPagamentos.NewRow();
                    item["valorParcela"] = m.ValorParcela;
                    item["valorTotal"] = m.ValorTotal;

                    if (dias.Length == 1 && dias[0] == 0)
                        item["prestações"] = "Á Vista";
                    else
                        item["prestações"] = m.Prestações;
                    
                    string data = "";
                    foreach (int dia in dias)
                    {
                        data += Preço.SomarDiasTabelaComercial(venda.Data, dia + (int) venda.DiasSemJuros).ToString("dd/MM") + "; ";
                    }

                    item["data"] = data;
                    item["juros"] = m.Juros;
                    tabelaModoPagamentos.Rows.Add(item);
                    linhaInfo["mostrarModosPagamentos"] = true;
                }
            }

            System.Globalization.CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;

            // Preencher débitos
            List<VendaDébito> debitos = venda.ItensDébito.ExtrairElementos();

            foreach (VendaDébito a in debitos)
            {
                DataRow item = tabelaDébitos.NewRow();
                item["valorBruto"] = a.ValorBruto; //.ToString("C", cultura);
                item["valorLíquido"] = a.ValorLíquido; //.ToString("C", cultura);
                item["cobrarJuros"] = a.CobrarJuros;
                item["diasDeJuros"] = a.DiasDeJuros.ToString();
                item["descrição"] = a.Descrição;
                item["data"] = a.Data.ToShortDateString();
               
                tabelaDébitos.Rows.Add(item);
            }

            linhaInfo["mostrarDébitos"] = debitos.Count > 0;

            // Preencher créditos
            List<VendaCrédito> creditos = venda.ItensCrédito.ExtrairElementos();

            foreach (VendaCrédito a in creditos)
            {
                DataRow item = tabelaCréditos.NewRow();
                item["valorBruto"] = a.ValorBruto; //.ToString("C", cultura);
                item["valorLíquido"] = a.ValorLíquido; //.ToString("C", cultura);
                item["cobrarJuros"] = a.CobrarJuros;
                item["diasDeJuros"] = a.DiasDeJuros.ToString();
                item["descrição"] = a.Descrição;
                item["data"] = a.Data.ToShortDateString();

                tabelaCréditos.Rows.Add(item);
            }

            linhaInfo["mostrarCréditos"] = creditos.Count > 0;

            // Preencher pagamentos
            foreach (Pagamento p in Pagamento.ObterPagamentos(venda))
            {
                DataRow item = tabelaPagamentos.NewRow();
                item["valor"] = p.Valor;
                //item["valorLíquido"]
                //    = Entidades.Preço.Corrigir(p.ÚltimoVencimento, Preço.SomarDiasTabelaComercial(venda.Data, (int) venda.DiasSemJuros), 
                //   p.Valor, Entidades.Configuração.DadosGlobais.Instância.Juros)
                //   .ToString();
                item["valorLíquido"] = p.ObterValorLíquido(venda).ToString();

                switch (p.Tipo)
                {
                    case Pagamento.TipoEnum.Cheque:
                        item["tipo"] = "Ch";
                        break;

                    case Pagamento.TipoEnum.Dinheiro:
                        item["tipo"] = "Esp.";
                        break;

                    case Pagamento.TipoEnum.NotaPromissória:
                        item["tipo"] = "NP";
                        break;

                    case Pagamento.TipoEnum.Crédito:
                        item["tipo"] = "CR";
                        break;

                    case Pagamento.TipoEnum.Ouro:
                        item["tipo"] = "FF";
                        break;

                    case Pagamento.TipoEnum.Dolar:
                        item["tipo"] = "US$";
                        break;

                    default:
                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(new Exception("Tipo de pagamento desconhecido no momento de impressão: " + p.Tipo.ToString()));
                        item["tipo"] = "?";
                        break;
                }

                //if (String.IsNullOrEmpty(p.Descrição))
                //    item["tipo"] += " - " + p.Descrição;

                //if (p.Venda.HasValue)
                //{
                //    int cnt = 0;

                //    item["tipo"] += " (venda: " + p.Venda.Value.ToString() + ")";

                //    foreach (IDadosVenda v in p.Vendas)
                //    {
                //        if (cnt++ > 0)
                //            item["tipo"] += ", ";

                //        item["tipo"] += v.Código.ToString();
                //    }

                //    item["tipo"] += ")";
                //}

                item["pendente"] = p.Pendente;
                item["vencimento"] = p.ÚltimoVencimento;
                item["data"] = p.Data;
                item["código"] = p.Código;
                //item["dias"] = Preço.CalcularDiasTabelaComercial(venda.Data.Date, p.ÚltimoVencimento.Date);
                item["dias"] = p.ObterDiasJuros(venda);

                item["observações"] = p.Descrição + " " + p.DescriçãoAdicional;

                if (p.Tipo == Pagamento.TipoEnum.Ouro)
                    item["observações"] += " " + p.ToString();

                item["deTerceiro"] = p.Tipo == Pagamento.TipoEnum.Cheque ? ((Cheque)p).DeTerceiro : false;

                if (p.Tipo == Pagamento.TipoEnum.Cheque && ((Cheque)p).DeTerceiro)
                    item["tipo"] += " cliente";

                tabelaPagamentos.Rows.Add(item);

                linhaInfo["mostrarPagamentos"] = true;
            }

            if (Representante.ÉRepresentante(venda.Vendedor))
                linhaInfo["mostrarModosPagamentos"] = false;

            return ds;
        }

        protected override void MapearItem(DataRow linha, Entidades.Relacionamento.SaquinhoRelacionamento s, Entidades.Relacionamento.Venda.Venda venda)
        {
            base.MapearItem(linha, s, venda);

            linha["devolvido"] = false;
            linha["valorUnitário"] = (double)s.Mercadoria.CalcularPreço(venda.Cotação);
            linha["valorTotal"] = (double)s.Mercadoria.CalcularPreço(venda.Cotação) * s.Quantidade;
        }

        public override void PrepararImpressão(CrystalDecisions.CrystalReports.Engine.ReportClass relatório, Entidades.Relacionamento.Venda.Venda venda)
        {
            DataSetVenda ds = GerarDataSet(venda);

            relatório.SetDataSource(ds);
            relatório.Subreports["ModosPagamento.rpt"].SetDataSource(ds);
            relatório.Subreports["Débitos.rpt"].SetDataSource(ds);
        }
    }
}
