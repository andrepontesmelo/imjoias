using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Configuração;
using System.Globalization;
using Entidades.Pagamentos;
using Entidades.Financeiro;
using Entidades.Moedas;

namespace Entidades
{
    /// <summary>
    /// Estrutura para cálculo de preço de mercadoria.
    /// </summary>
    public struct Preço
    {
        private static int precisãoDigitosCalculoJuros = 6;

        private double juros;

        /// <summary>
        /// Dias para calculo dos juros.
        /// </summary>
        private int dias;

        /// <summary>
        /// Mercadoria que contém este preço.
        /// </summary>
        private Entidades.Mercadoria.Mercadoria mercadoria;

        /// <summary>
        /// Cotação a ser utilizada.
        /// </summary>
        private Entidades.Financeiro.Cotação cotação;

        /// <summary>
        /// Índice a ser utilizada na mercadoria.
        /// </summary>
        private double índice;

        /// <summary>
        /// Preço da mercadoria.
        /// </summary>
        private double preço;

        /// <summary>
        /// Fator multiplicativo.
        /// </summary>
        private double fator;


        #region Construtoras

        /// <summary>
        /// Constrói a estrutura de preço com um índice personalizado.
        /// </summary>
        /// <param name="cotação">Cotação a ser usada.</param>
        /// <param name="índice">Índice da mercadoria.</param>
        public Preço(Mercadoria.Mercadoria mercadoria, Cotação cotação, double índice)
        {
            this.mercadoria = mercadoria;
            this.cotação = cotação;
            this.índice = índice;
            this.fator = 1;
            this.preço = 0;
            this.dias = 0;
            this.juros = Configuração.DadosGlobais.Instância.Juros;

            CalcularPreço();
        }

        /// <summary>
        /// Constrói a estrutura de preço de uma mercadoria.
        /// </summary>
        /// <param name="cotação">Cotação a ser utilizada.</param>
        public Preço(Mercadoria.Mercadoria mercadoria, Cotação cotação)
            : this(mercadoria, cotação, mercadoria.ÍndiceArredondado)
        { }

        /// <summary>
        /// Constrói a estrutura de preço de uma mercadoria,
        /// utilizando a cotação vigente carregada do banco de dados.
        /// </summary>
        public Preço(Mercadoria.Mercadoria mercadoria, Moeda moeda)
            : this(mercadoria, Cotação.ObterCotaçãoVigente(moeda))
        { }

        #endregion

        #region Propriedades

        public Entidades.Mercadoria.Mercadoria Mercadoria
        {
            get { return mercadoria; }
        }

        /// <summary>
        /// Cotação a ser utilizada.
        /// </summary>
        public Entidades.Financeiro.Cotação Cotação
        {
            get { return cotação; }
            set
            {
                cotação = value;
                CalcularPreço();
            }
        }

        /// <summary>
        /// Índice a ser utilizado.
        /// </summary>
        public double Índice
        {
            get { return índice; }
            set
            {
                índice = value;
                CalcularPreço();
            }
        }

        /// <summary>
        /// Dias para cálculo dos juros
        /// </summary>
        public int Dias
        {
            get { return dias; }
            set 
            { 
                dias = value;
                CalcularPreço();
            }
        }

        /// <summary>
        /// Fator multiplicativo (padrão = 1).
        /// </summary>
        /// <remarks>
        /// Esta propriedade está vinculada na mesma variável
        /// da propriedade Desconto.
        /// </remarks>
        public double Fator
        {
            get { return fator; }
            set
            {
                fator = value;
                CalcularPreço();
            }
        }

        /// <summary>
        /// Desconto em percentual.
        /// </summary>
        /// <remarks>
        /// Esta propriedade
        /// é apenas uma unidade de medida diferente
        /// da utilizada em fator, mas correspondem
        /// à mesma variável.
        /// </remarks>
        public double Desconto
        {
            get { return (1 - fator) * 100; }
            set { Fator = 1 - value / 100; }
        }

        /// <summary>
        /// Valor do preço.
        /// </summary>
        public double Valor
        {
            get { return preço; }
        }

        #endregion

        /// <summary>
        /// Calcula preço.
        /// </summary>
        private void CalcularPreço()
        {
            preço = AcrescentarJurosSimples(índice, juros, dias);

            /* Apesar de trabalharmos com muita casa decimal,
             * aumentando assim a precisão, no comércio só existem
             * duas casas decimais. O preço à vista TEM que ser em
             * duas casa decimais e, portanto, o cálculo de juros
             * deve ser feito em cima das duas casas decimais.
             * -- Júlio, 27 a 28/03/2006
             */
            
            // O seguinte arredondamento não pode - dá diferença no preço de varejo.
            //preço = Math.Round(preço, 2);

            preço = Math.Round(preço * cotação.Valor, 2);
            preço = Math.Round(preço * fator, 2);


            // Não é interesse do financeiro perder a precisão (por lourdes, 27-março-2006)
            //// Perde a precisão para apenas duas casas decimais:
            //preço = Math.Round(preço * 100) / 100;
            //// preço antes = 13.45678;
            //// erro depois = 13.47;

            /* No final das contas, interessa ao comércio o preço
             * em duas casas decimais. Se este for o preço mostrado
             * ao cliente, soma de décimos de centavos não podem
             * acumular centavos "invisíveis" ao consumidor final.
             * -- Júlio, 27 a 28/03/2006
             */
            preço = Math.Round(preço, 2);

            if (preço < 0)
                throw new Exception("Preço não pode ser negativo!");
        }

        /// <summary>
        /// Calcula juros simples, com precisão de 4 casas decimais.
        /// </summary>
        public static double AcrescentarJurosSimples(double valor, double juros, int dias)
        {
            //double preço;

            /* Trecho do F38.prg que calcula juros.
            w_jd     = val(str((ac_juros1 / 30),5,4))
            w_juros  = w_jd * w_cont
            calculo1 = 100.0000 - w_juros
            calculo2 = 100.0000 / calculo1
            */
            // SE ALTERAR A FÓRMULA, MUDA A FUNÇÃO ObterCálculoJurosSQL ABAIXO TAMBÉM.
            //preço = valor * (100 / (100 - (Math.Round(juros / 30, 4) * dias)));
            if (dias > 0)
                return valor + CalcularJuros(dias, valor, juros);
            else
                return CorrigirInverso(dias, valor, juros);
        }

        /// <summary>
        /// Formata o preço.
        /// </summary>
        /// <returns>Preço formatado.</returns>
        public override string ToString()
        {
            string preçoFormatado = preço.ToString("C", DadosGlobais.Instância.Cultura);

            /* Em ambientes em que os dados são obtidos a partir
             * do banco de dados, é difícil determinar a cotação utilizada,
             * sendo recuperado somente o valor, sem qualquer outra informação.
             * 
             * Como estes casos correspondem ao de maior uso no sistema,
             * os textos do preço apresentam quase todos cotações desconhecidas,
             * indicado com (???), piorando a legibilidade.
             * 
             * Acredito que seja melhor remover informações de cotação
             * no preço, inserindo tais informações manualmente somente
             * quando necessário e possível.
             * 
             * -- Júlio, 20/04/2006
             */
            //if (cotação.Data.HasValue && cotação.Data.Value.Month == DateTime.Now.Month & cotação.Data.Value.Year == DateTime.Now.Year)
            //    return preçoFormatado + " (dia " + cotação.Data.Value.Day + ")";
            //else
            //    return preçoFormatado + " (" + (cotação.Data.HasValue ? cotação.Data.Value.ToShortDateString() : "???") + ")";

            return preçoFormatado;
        }

        /// <summary>
        /// Conversão implícita para double.
        /// </summary>
        public static implicit operator double(Preço preço)
        {
            return preço.preço;
        }

        /// <summary>
        /// Conversão implícita para string.
        /// </summary>
        public static implicit operator string(Preço preço)
        {
            return preço.ToString();
        }

        /// <summary>
        /// Calcula diferença entre o preço normal e atual
        /// da mercadoria pelo preço contido nesta estrutura.
        /// </summary>
        /// <returns>Diferença de preço.</returns>
        public double CalcularDiferença()
        {
            Preço preço = new Preço(mercadoria, cotação);

            return preço - this.preço;
        }

        /// <summary>
        /// Calcula a media de dias das prestações
        /// no formato 30x60x90.
        /// </summary>
        /// <param name="prestações">Prestações (ex: 30x60x90)</param>
        /// <returns>Número de dias para cálculo de juros.</returns>
        public static int InterpretarPrestações(string prestações)
        {
            double média = 0;
            int qtd;
            string[] prazos = prestações.Split('x', 'X');

            if (prazos.Length == 0 || String.IsNullOrWhiteSpace(prestações))
                return 0;

            qtd = prazos.Length;

            try
            {
                foreach (string prazo in prazos)
                {
                    int dias = int.Parse(prazo);

                    //if (dias > 0)
                        média += dias;
                    //else
                    //    qtd--;
                }
            }
            catch
            {
                throw new FormatException(
                    "Não foi possível interpretar o prazo proposto. O formato deve seguir o seguinte exemplo: 30x60x90");
            }

            média /= qtd;

            return Convert.ToInt32(Math.Ceiling(média));
        }

        /// <summary>
        /// Conta o número de prestações.
        /// </summary>
        public static int ContarPrestações(string prestações)
        {
            return Math.Max(prestações.Split('x', 'X').Length, 1);
        }

        /// <summary>
        /// Interpreta os dias de cada prestação.
        /// </summary>
        public static int[] InterpretarDiasPrestações(string prestações)
        {
            int[] dias;
            string[] prazos = prestações.Split('x', 'X');

            if (prestações.Trim().Length == 0)
                return new int[] { };

            if (prazos.Length == 0) 
                return new int[] { 0 };

            dias = new int[prazos.Length];

            for (int i = 0; i < prazos.Length; i++)
                dias[i] = int.Parse(prazos[i]);

            return dias;
        }

        /// <summary>
        /// Calcula o valor dos juros.
        /// </summary>
        /// <param name="prestações">Prestações no formato 30x60.</param>
        public static double CalcularJuros(string prestações, double valor, double juros)
        {
            return CalcularJuros(InterpretarPrestações(prestações), valor, juros);
        }

        /// <summary>
        /// Calcula o valor dos juros.
        /// </summary>
        public static double Corrigir(DateTime cobrança, DateTime hoje, double quantia, double juros)
        {
            int dias = CalcularDias(cobrança, hoje);

            if (dias > 0)
                return quantia + CalcularJuros(dias, quantia, juros);
            else
                return CorrigirInverso(dias, quantia, juros);
        }

        /// <summary>
        /// Calcula o valor dos juros.
        /// </summary>
        public static double CalcularJuros(DateTime cobrança, DateTime hoje, double quantia, double juros)
        {
            return CalcularJuros(CalcularDias(cobrança, hoje), quantia, juros);
        }

        /// <summary>
        /// Calcula o valor dos juros.
        /// </summary>
        public static double CalcularJuros(int dias, double quantia, double jurosMensal)
        {
            double valor;

            bool diasNegativos = dias < 0;

            dias = Math.Abs(dias);

            // Juros maluco da firma:
            double jurosDiário = Math.Round(jurosMensal / 30, precisãoDigitosCalculoJuros);
            double f1 = jurosDiário * dias;
            double complemento = 100 - f1;

            if (complemento < 0)
                return 0;

            double fatorJuros = Math.Round(100 / complemento, precisãoDigitosCalculoJuros);

            valor = fatorJuros * quantia;

            double resposta = Math.Round(Math.Round(valor, precisãoDigitosCalculoJuros) - quantia, precisãoDigitosCalculoJuros);

            resposta = resposta * (diasNegativos ? -1 : 1);

            return resposta;
        }

        /// <summary>
        /// Calcula o valor dos juros.
        /// </summary>
        public static double CalcularJurosSimples(int dias, double quantia, double jurosMensal)
        {
            bool diasNegativos = dias < 0;

            dias = Math.Abs(dias);

            double jurosDiário = Math.Round(jurosMensal / 30, precisãoDigitosCalculoJuros);

            double indice = 1 + Math.Round(jurosDiário * dias / 100, precisãoDigitosCalculoJuros);

            double valorCorrigido = Math.Round(quantia * indice, precisãoDigitosCalculoJuros);

            double apenasJuros = Math.Round(Math.Round(valorCorrigido, precisãoDigitosCalculoJuros) - quantia, precisãoDigitosCalculoJuros);

            apenasJuros = apenasJuros * (diasNegativos ? -1 : 1);

            return apenasJuros;
        }


        /// <summary>
        /// Corrige para dias atras. 
        /// </summary>
        /// <param name="diasAtras"></param>
        /// <param name="quantia"></param>
        /// <param name="juros"></param>
        /// <returns></returns>
        public static double CorrigirInverso(int diasAtras, double quantia, double juros)
        {
            double valor;
            diasAtras = Math.Abs(diasAtras);

            // Juros maluco da firma:
            double jurosDiário = Math.Round(juros / 30, precisãoDigitosCalculoJuros);
            double f1 = jurosDiário * diasAtras;
            double complemento = 100 - f1;

            if (complemento < 0)
                return 0;
                //throw new Exception("Cálculo de juros não suporta estes valores: DIAS: " + diasAtras.ToString() + " QUANTIA: " + quantia.ToString() + " JUROS: " + juros.ToString());

            double fatorJuros = Math.Round(100 / complemento, precisãoDigitosCalculoJuros);

            valor = quantia / fatorJuros;

            //double resposta =  Math.Round(valor,2);
            return valor;
        }

        public static DateTime SomarDiasTabelaComercial(DateTime data, int dias)
        {
            // Nao existe mes com 31 dias na tabela comercia.
            if (data.Day == 31)
                data = new DateTime(data.Year, data.Month, 30);

            DateTime novaData;

            int meses = dias / 30;
            dias = dias % 30;

            novaData = data.AddMonths(meses);

            bool mudaráMês = (novaData.AddDays(dias).Month != novaData.Month);

            if (!mudaráMês)
            {
                novaData = novaData.AddDays(dias);
                if (novaData.Day > 30)
                {
                    int diasNoMês = DateTime.DaysInMonth(novaData.Year, novaData.Month);

                    novaData = novaData.AddDays(1 + diasNoMês - novaData.Day);
                }
                return novaData;
            }

            if (dias > 0)
            {
                // Precisa mudar o mês.
                // No entanto, talvés seja necessário adicionar alguns dias.
                DateTime dataAnterior = novaData;
                int diasQueFaltamParaOFimDoMês = 31 - novaData.Day;

                // novaData = primeiro dia do próximo mes
                novaData = novaData.AddMonths(dias > 0 ? 1 : -1);
                novaData = novaData.Subtract(new TimeSpan(novaData.Day - 1, 0, 0, 0));

                // Verifica quantos dias adicionou de 'dataAnterior' até novaData:
                int diasAdicionadosVirtualmente = diasQueFaltamParaOFimDoMês;

                if (diasAdicionadosVirtualmente < dias)
                {
                    // Adiciona dias faltantes.
                    novaData = novaData.AddDays(dias - diasAdicionadosVirtualmente);
                }
            }
            else
            {
                var mêsAnterior = novaData.AddDays(dias);
                int diasNoMês = DateTime.DaysInMonth(mêsAnterior.Year, mêsAnterior.Month);
                int delta = 30 - diasNoMês;
                novaData = novaData.AddDays(dias + delta);
            }

            return novaData;
        }


        //public static int CalcularDiasSimples(DateTime data1, DateTime data2)
        //{
        //    // Ignora horas, minutos, segundos
        //    data1 = data1.Date;
        //    data2 = data2.Date;

        //    TimeSpan totalTempo = data2 - data1;
        //    int totalDias = (int) totalTempo.TotalDays;

        //    return totalDias;
        //}

        /// <summary>
        /// Segundo toninho, para cálculo de juros é utilizada a tabela comercial.
        /// Quantos dias existem entre 1 de fev e 28 de fev ? 27. OK.
        /// E entre 28 de fev e 1 de março ? pela TAB COMERCIAL são 3 dias.
        /// Isto porque esta tabela pensa que todos os meses tem 30 dias.
        /// Bizzaro!
        /// </summary>
        public static int CalcularDias(DateTime data1, DateTime data2)
        {
            DateTime antes, depois;
            DateTime cursor;

            if (data1 > data2)
            {
                antes = data2;
                depois = data1;
            }
            else
            {
                antes = data1;
                depois = data2;
            }

            cursor = antes;

            int mesesDiferênça = (depois.Year - antes.Year) * 12 + (depois.Month - antes.Month);
            /* antes.Day pode ser no máximo 30, se for 31, deve-se força-lo para dia 30.
             * 
             * dia 30/1 ao dia 5/2, 
             * depois.Day = 5
             * antes.Day = 30
             * Diferença: 5-30 = -25. (+30) = 5 dias. ok.

             * * dia 31/1 ao dia 5/2, 
             * depois.Day = 5
             * antes.Day = 31
             * Dierença: 5-31 = -26. (+30) = 4 dias. errado.
             */

            if (antes.Day > 30)
                antes = new DateTime(antes.Year, antes.Month, 30);

            int diasDiferênça = Math.Abs(mesesDiferênça * 30 + (depois.Day - antes.Day));

            return data2 == depois ? diasDiferênça : -diasDiferênça;
        }


        ///// <summary>
        ///// Obtém trecho de código para cálculo de juros em SQL.
        ///// </summary>
        ///// <param name="valor">Coluna ou valor.</param>
        ///// <param name="dias">Expressão ou número de dias.</param>
        ///// <returns>Trecho da expressão SQL.</returns>
        //public static string ObterCálculoJurosSQL(string valor, string dias)
        //{
        //    //return string.Format(
        //    //    "({0}*(100/(100-({1}*{2}))))",
        //    //    valor, ((double)Math.Round(DadosGlobais.Instância.Juros / 30, 4)).ToString(NumberFormatInfo.InvariantInfo), dias);
        //    return string.Format(
        //        "(ROUND({0}*(({1}*{2})),2))",
        //        valor, ((double)Math.Round(DadosGlobais.Instância.Juros / 30 / 100, 4)).ToString(NumberFormatInfo.InvariantInfo), dias);
        //}

        public static DateTime SomarDias(DateTime data, int dias)
        {
            //return data.AddDays(dias);

            return SomarDiasTabelaComercial(data, dias);
        }
    }
}
