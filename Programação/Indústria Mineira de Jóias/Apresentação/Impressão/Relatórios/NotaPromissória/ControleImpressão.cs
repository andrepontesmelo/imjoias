using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Globalization;
using Entidades;
using Entidades.Pessoa;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Impressão.Relatórios.NotaPromissória
{
    public class ControleImpressão
    {
        public void PrepararImpressão(ReportClass relatório, Entidades.Pagamentos.NotaPromissória entidade)
        {
            DataSetNotaPromissória ds = new DataSetNotaPromissória();
            DataTable tabela = ds.Tables["NotaPromissória"];

            tabela.Rows.Add(CriarItem(entidade, tabela));

            relatório.SetDataSource(ds);
        }

        private static DataRow CriarItem(Entidades.Pagamentos.NotaPromissória entidade, DataTable tabela)
        {
            DataRow item = tabela.NewRow();

            CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;

            item["dataVencimento"] = entidade.Vencimento.ToShortDateString();

            if (entidade.Valor.ToString("C", cultura).Trim().Length == 0)
                throw new Exception("O valor formatado não pode ser vazio.");

            item["valor"] = entidade.Valor.ToString("C", cultura);
            item["valorExtenso"] = NúmeroExtenso.Transformar((decimal)entidade.Valor);
            Entidades.Pessoa.Pessoa cliente = Entidades.Pessoa.Pessoa.ObterPessoa(entidade.Cliente);

            item["emitenteNome"] = cliente.Nome.ToUpper();

            if (entidade.Venda.HasValue)
                item["venda"] = entidade.Venda.Value.ToString();

            if (cliente is PessoaFísica)
                item["emitenteDocumento"] = ((PessoaFísica)cliente).CPF;
            else if (cliente is PessoaJurídica)
                item["emitenteDocumento"] = ((PessoaJurídica)cliente).CNPJ;

            List<Endereço> endereços = cliente.Endereços.ExtrairElementos();
            if (endereços.Count > 0 && endereços[0].Localidade != null && endereços[0].Logradouro != null)
            {
                Endereço endereço = endereços[0];
                item["emitenteEndereço"] = string.Format("{0}, {1}, {2}", endereço.Logradouro, endereço.Número, endereço.Complemento);
                item["emitenteEndereço"] += " " + endereço.Localidade.Nome + " / " + endereço.Localidade.Estado.Sigla;
            }

            item["dataEmissão"] = entidade.Data.ToShortDateString();

            item["dataVencimentoExtenso"] = (entidade.Vencimento.Day == 1 ? "Ao primeiro dia " : "Aos " +
                ObterDiaMesPorExtenso(entidade.Vencimento.Day).ToLower() + " dias ")
                + "do mês de " + ObterNomeMes(entidade.Vencimento.Month).ToLower() + " do ano de " +
                NúmeroExtenso.Transformar(entidade.Vencimento.Year).ToLower().Replace("reais", "");
            
            return item;
        }

        private static string ObterNomeMes(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    throw new NotImplementedException();
            }
        }

        private static string ObterDiaMesPorExtenso(double valor)
        {
            int conta, parte;
            string[] s_unidade = new string[] {"ZERO", "UM", "DOIS", "TRÊS", "QUATRO", "CINCO",
				"SEIS", "SETE", "OITO", "NOVE", "DEZ", "ONZE", "DOZE", "TREZE",
				"QUATORZE", "QUINZE", "DEZESSEIS", "DEZESSETE", "DEZOITO", "DEZENOVE"};
            string[] s_dezena = new string[] {"", "", "VINTE", "TRINTA", "QUARENTA",
				"CINQÜENTA", "SESSENTA", "SETENTA", "OITENTA", "NOVENTA", "CEM"};
            
            const string s_e = " E ";
            bool anterior = false;
            int i = 0, cont;
            string txt;
            string extenso = "";

            if (valor < 0)
                return null;

            if (valor == 0)
                return s_unidade[0];

            parte = (int)valor;

            do
            {
                txt = "";

                conta = parte % 1000;
                cont = 0;

                if (anterior)
                {
                    extenso = ", " + extenso;
                    anterior = false;
                }

                if (conta > 19)
                {
                    if (anterior)
                        txt = txt + s_e + s_dezena[conta / 10];
                    else
                        txt = s_dezena[conta / 10];
                    anterior = true;
                    conta %= 10;
                    cont += 2;
                }

                if (conta > 0)
                {
                    if (i != 1 || parte != 1)
                    {
                        if (anterior)
                            txt = txt + s_e + s_unidade[conta];
                        else
                            txt = s_unidade[conta];
                    }
                    cont++;
                    anterior = true;
                }

                if (i++ == 0 && cont <= 3 && cont > 0 && valor > 999)
                {
                    extenso = s_e + extenso;
                    anterior = false;
                }

                parte /= 1000;
            } while (parte > 0);

            int fracao = (int)((valor - (int)valor) * 100);

            if (fracao > 0)
            {
                txt = "";

                if (fracao > 19)
                {
                    if (fracao % 10 > 0)
                        txt = txt + s_dezena[fracao / 10] + s_e + s_unidade[fracao % 10];

                    else
                        txt = s_dezena[fracao / 10];
                }
                else
                    txt = s_unidade[fracao];

                if (extenso.Length > 0)
                    extenso = extenso + s_e + txt;

                else
                    extenso = txt;

            }

            return txt;
        }

        internal void PrepararImpressão(Relatório relatório, List<Entidades.Pagamentos.NotaPromissória> lstNotasPromissórias)
        {
            DataSetNotaPromissória ds = new DataSetNotaPromissória();
            DataTable tabela = ds.Tables["NotaPromissória"];

            foreach (Entidades.Pagamentos.NotaPromissória entidade in lstNotasPromissórias)
                tabela.Rows.Add(CriarItem(entidade, tabela));

            relatório.SetDataSource(ds);
        }
    }
}
