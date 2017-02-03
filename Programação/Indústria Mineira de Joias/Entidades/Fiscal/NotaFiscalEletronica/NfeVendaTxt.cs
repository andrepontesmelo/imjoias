using Entidades.Configuração;
using Entidades.Pessoa;
using Entidades.Pessoa.Endereço;
using Entidades.Relacionamento;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class NfeVendaTxt
    {
        private VínculoNfeVenda entidade;

        Pessoa.Pessoa cliente;
        PessoaFísica física;
        PessoaJurídica jurídica;

        public NfeVendaTxt(VínculoNfeVenda entidade)
        {
            this.entidade = entidade;

            cliente = entidade.Venda.Cliente;
            física = cliente as PessoaFísica;
            jurídica = cliente as PessoaJurídica;
        }

        private CultureInfo cultura = null;
        private CultureInfo Cultura
        {
            get
            {
                if (cultura == null)
                {
                    cultura = (CultureInfo) DadosGlobais.Instância.Cultura.Clone();
                    cultura.NumberFormat.NumberDecimalSeparator = ".";
                }

                return cultura;
            }
        }

        public void Salvar(string arquivoUrl, bool usarApenasTipoUnidadeFiscalPeça)
        {
            using (StreamWriter s = new StreamWriter(arquivoUrl))
            {
                s.WriteLine("NOTAFISCAL|1");
                s.Write("A|3.10|");
                //s.Write("NFe31150518219329000103550010000003001200000201");
                s.WriteLine("|");
                s.Write("B|||Venda de produtos a vista|1|55|1|");
                s.Write(entidade.Nfe.ToString());
                s.Write("|");
                s.Write(TransformarData(DateTime.Now));
                s.Write("|");
                s.Write(TransformarData(DateTime.Now.AddMinutes(15)));

                //2015-05-04T15:59:00-03:00|2015-05-04T15:59:00-03:00
                s.Write("|1|1|3106200|1|1|7|1|1|");

                // Consumidor Final - (CNPJ) - Não.
                if (jurídica != null)
                    s.Write("0");
                else
                    s.Write("1");

                s.Write("|1|3|3.10.49|||");
                s.WriteLine();
                s.WriteLine("C|Industria Mineira de Joias Ltda|Industria Mineira de Joias Ltda|0621400540037||3184100016|3211602|1|");
                s.WriteLine("C02|18219329000103|");
                s.WriteLine("C05|Rua Pouso Alegre|546||Floresta|3106200|Belo Horizonte|MG|31110010|1058|BRASIL|3130577555|");
                PreeencherPessoa(s);

                PreencherProdutos(s, usarApenasTipoUnidadeFiscalPeça);
                string valorTotalVenda = entidade.Venda.Valor.ToString("0.00", Cultura);

                s.WriteLine("W|");
                s.Write("W02|0.00|0.00|0.00|0.00|0.00|");
                s.Write(valorTotalVenda);
                s.Write("|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|");
                s.Write(valorTotalVenda);
                s.WriteLine("||");
                s.WriteLine("X|0|");
                s.WriteLine("Y|");
                s.Write("Y02|");
                s.Write(entidade.Fatura.ToString());
                s.Write("|");
                //99999999.00
                s.Write(valorTotalVenda);

                s.Write("||");
                s.Write(valorTotalVenda);

                s.WriteLine("|");

                //s.WriteLine("Y07|423/01-04|2015-06-17|999.99|");
                //s.WriteLine("Y07|423/02-04|2015-07-17|999.99|");
                //s.WriteLine("Y07|423/03-04|2015-08-18|999.99|");
                //s.WriteLine("Y07|423/04-04|2015-09-18|999.99|");
                double aproveitamento = Math.Round(Math.Round(entidade.Venda.Valor, 2) * entidade.Alíquota / 100, 2);

                s.Write("Z||Permite o aproveitamento do credito de ICMS no valor de ");
                s.Write(aproveitamento.ToString("C", cultura));
                s.Write(", correspondente a documento emitido por  EPP optante  pelo simples nacional e não gera credito de ISS e IPI. Alíquota de ");
                s.Write(entidade.Alíquota.ToString());
                s.Write("%, nos termos do art. 23 da Lei complementar 128/08.|");
                //s.WriteLine("Y07|9999|2015-05-04|9999.00|");
                //s.WriteLine("Z||yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy|");
            }
        }

        private string TransformarData(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd")
            + "T" + dateTime.ToString("HH:mm:ss") + "-03:00";
        }

        private void PreencherProdutos(StreamWriter s, bool usarApenasTipoUnidadeFiscalPeça)
        {
            bool erro;
            ArrayList listaSaquinhos = entidade.Venda.Itens.ObterSaquinhosAgrupadosOrdenados(out erro);

            if (entidade.Venda.ValorDevolução > 0)
                throw new Exception("Não é possível gerar NFe de venda com devolução.");

            for (int x = 0; x < listaSaquinhos.Count; x++)
            {
                PreencherProduto(s, (SaquinhoRelacionamento) listaSaquinhos[x], x + 1, usarApenasTipoUnidadeFiscalPeça);
            }
        }

        private static string ObterReferenciaComDigito(Mercadoria.Mercadoria m)
        {
            return m.ReferênciaNumérica + m.Dígito;
        }

        private void PreencherProduto(StreamWriter s, SaquinhoRelacionamento saquinhoRelacionamento, int posição, bool usarApenasTipoUnidadeFiscalPeça)
        {

            string descricaoAdicionalProduto = "";
            s.WriteLine("H|" + posição.ToString() + "|" + descricaoAdicionalProduto + "|");

            if (ObterReferenciaComDigito(saquinhoRelacionamento.Mercadoria).Length != 12)
                throw new Exception("Referencia precisa ter 12 dígitos");

            s.Write("I|");
            s.Write(ObterReferenciaComDigito(saquinhoRelacionamento.Mercadoria));
            s.Write("||");
            s.Write(saquinhoRelacionamento.Mercadoria.Descrição);
            s.Write("|71131900||");
            s.Write(entidade.Cfop.ToString());

            var tipoUnidadePeça = usarApenasTipoUnidadeFiscalPeça || !saquinhoRelacionamento.Mercadoria.DePeso;
            if (tipoUnidadePeça)
                s.Write("|Pca|");
            else
                s.Write("|Grs|");

            PreencherQuantidade(s, saquinhoRelacionamento, tipoUnidadePeça);

            decimal valorUn = (decimal) saquinhoRelacionamento.Mercadoria.CalcularPreço(entidade.Venda.Cotação).Valor;

            if (!tipoUnidadePeça)
                valorUn = valorUn / (decimal) saquinhoRelacionamento.Peso;

            decimal valorTot = Math.Round(valorUn * CalcularQuantidade(saquinhoRelacionamento, tipoUnidadePeça), 2);

            s.Write("|");
            s.Write(valorUn.ToString("0.0000000000", Cultura));
            s.Write("|");
            s.Write(valorTot.ToString("0.00", Cultura));

            if (tipoUnidadePeça)
                s.Write("||Pca|");
            else
                s.Write("||Grs|");

            PreencherQuantidade(s, saquinhoRelacionamento, tipoUnidadePeça);

            s.Write("|");
            s.Write(valorUn.ToString("0.0000000000", Cultura));
            s.Write("|||||1|");
            s.Write("|");
            s.Write("||");
            s.WriteLine();
            s.WriteLine("M||");
            s.WriteLine("N|");
            s.WriteLine("N10h|0|900||||||||||||||");
            s.WriteLine("O|||||999|");
            s.WriteLine("O08|53|");
            s.WriteLine("Q|");
            s.WriteLine("Q04|07|");
            s.WriteLine("S|");

            s.WriteLine("S04|07|");
        }

        private void PreencherQuantidade(StreamWriter s, SaquinhoRelacionamento saquinho, bool tipoUnidadePeça)
        {
                s.Write(CalcularQuantidade(saquinho, tipoUnidadePeça).ToString("0.0000", Cultura));
        }

        private decimal CalcularQuantidade(SaquinhoRelacionamento saquinho, bool tipoUnidadePeça)
        {
            if (tipoUnidadePeça)
                return (decimal) saquinho.Quantidade;
            else
                return (decimal) saquinho.Quantidade * (decimal) saquinho.Peso;
        }

        private void PreeencherPessoa(StreamWriter s)
        {
            Endereço endereço;
            if (cliente.Endereços.ContarElementos() > 0)
                endereço = cliente.Endereços.First<Endereço>();
            else
                endereço = new Endereço();

            Telefone telefone;
            if (cliente.Telefones.ContarElementos() > 0)
                telefone = cliente.Telefones.First<Telefone>();
            else
                telefone = new Telefone();

            s.Write("E|");

            s.Write(cliente.Nome.Trim());
            s.Write(" - ");
            s.Write(cliente.Código.ToString());
            s.Write("|1|");

            if (jurídica != null && jurídica.InscEstadual != null)
                s.Write(jurídica.InscEstadual.Replace(".", "").Replace("-", ""));

            s.Write("||");

            if (jurídica != null && jurídica.InscMunicipal != null)
                s.Write(jurídica.InscMunicipal.Replace(".", "").Replace("-", ""));

            s.Write("|");
            s.Write(cliente.EMail);
            s.Write("|");

            s.WriteLine();
            if (jurídica != null)
            {
                s.Write("E02|");
                if (jurídica.CNPJ != null)
                    s.Write(jurídica.CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""));
            }
            else
            {
                s.Write("E03|");

                if (física.CPF != null)
                    s.Write(física.CPF.Replace(".", "").Replace("-", "").Replace("/", ""));
            }
            s.WriteLine("|");
            s.Write("E05|");
            s.Write(endereço.Logradouro);
            s.Write("|");
            s.Write(endereço.Número);
            s.Write("|");
            s.Write(endereço.Complemento);
            s.Write("'|");
            s.Write(endereço.Bairro);

            Municipio m = Municipio.Obter(endereço.Localidade);

            // Código da localidade.
            s.Write("|");

            if (m != null)
                s.Write(m.Código.ToString());

            s.Write("|");
            s.Write(Acentuação.Singleton.TirarAcentos(endereço.Localidade.Nome));
            s.Write("|");
            s.Write(endereço.Localidade.Estado.Sigla);
            s.Write("|");
            s.Write(endereço.CEP.Replace("-", ""));
            s.Write("|");
            s.Write("1058|BRASIL|");

            if (telefone.Número != null)
                s.Write(telefone.Número.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""));

            s.Write("|");
            s.WriteLine();
        }
    }
}
