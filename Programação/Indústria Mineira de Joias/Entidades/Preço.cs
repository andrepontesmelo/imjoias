using Entidades.Configuração;
using Entidades.Financeiro;
using Entidades.Moedas;
using System;

namespace Entidades
{
    /// <summary>
    /// Estrutura para cálculo de preço de mercadoria.
    /// </summary>
    public struct Preço
    {
        private static int PRECISÃO_DIGITOS_JUROS = 6;

        private double juros;
        private int dias;
        private Mercadoria.Mercadoria mercadoria;
        private Cotação cotação;
        private double índice;
        private double preço;
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

        private void CalcularPreço()
        {
            preço = AcrescentarJurosSimples(índice, juros, dias);

            preço = Math.Round(preço * cotação.Valor, 2);
            preço = Math.Round(preço * fator, 2);
            preço = Math.Round(preço, 2);

            if (preço < 0)
                throw new Exception("Preço não pode ser negativo!");
        }

        public static double AcrescentarJurosSimples(double valor, double juros, int dias)
        {
            return (dias > 0 ? valor + CalcularJuros(dias, valor, juros) : CorrigirInverso(dias, valor, juros));
        }

        public override string ToString()
        {
            return preço.ToString("C", DadosGlobais.Instância.Cultura);
        }

        public static implicit operator double(Preço preço)
        {
            return preço.preço;
        }

        public static implicit operator string(Preço preço)
        {
            return preço.ToString();
        }

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
                    média += dias;
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

        public static int ContarPrestações(string prestações)
        {
            return Math.Max(prestações.Split('x', 'X').Length, 1);
        }

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

        public static double CalcularJuros(string prestações, double valor, double juros)
        {
            return CalcularJuros(InterpretarPrestações(prestações), valor, juros);
        }

        public static double Corrigir(DateTime cobrança, DateTime hoje, double quantia, double juros)
        {
            int dias = CalcularDias(cobrança, hoje);

            if (dias > 0)
                return quantia + CalcularJuros(dias, quantia, juros);
            else
                return CorrigirInverso(dias, quantia, juros);
        }

        public static double CalcularJuros(DateTime cobrança, DateTime hoje, double quantia, double juros)
        {
            return CalcularJuros(CalcularDias(cobrança, hoje), quantia, juros);
        }

        public static double CalcularJuros(int dias, double quantia, double jurosMensal)
        {
            double valor;

            bool diasNegativos = dias < 0;

            dias = Math.Abs(dias);

            // Juros maluco da firma:
            double jurosDiário = Math.Round(jurosMensal / 30, PRECISÃO_DIGITOS_JUROS);
            double f1 = jurosDiário * dias;
            double complemento = 100 - f1;

            if (complemento < 0)
                return 0;

            double fatorJuros = Math.Round(100 / complemento, PRECISÃO_DIGITOS_JUROS);

            valor = fatorJuros * quantia;

            double resposta = Math.Round(Math.Round(valor, PRECISÃO_DIGITOS_JUROS) - quantia, PRECISÃO_DIGITOS_JUROS);

            resposta = resposta * (diasNegativos ? -1 : 1);

            return resposta;
        }

        public static double CalcularJurosSimples(int dias, double quantia, double jurosMensal)
        {
            bool diasNegativos = dias < 0;

            dias = Math.Abs(dias);

            double jurosDiário = Math.Round(jurosMensal / 30, PRECISÃO_DIGITOS_JUROS);
            double indice = 1 + Math.Round(jurosDiário * dias / 100, PRECISÃO_DIGITOS_JUROS);
            double valorCorrigido = Math.Round(quantia * indice, PRECISÃO_DIGITOS_JUROS);

            double apenasJuros = Math.Round(Math.Round(valorCorrigido, PRECISÃO_DIGITOS_JUROS) - quantia, PRECISÃO_DIGITOS_JUROS);
            apenasJuros = apenasJuros * (diasNegativos ? -1 : 1);

            return apenasJuros;
        }

        public static double CorrigirInverso(int diasAtras, double quantia, double juros)
        {
            double valor;
            diasAtras = Math.Abs(diasAtras);

            // Juros maluco da firma:
            double jurosDiário = Math.Round(juros / 30, PRECISÃO_DIGITOS_JUROS);
            double f1 = jurosDiário * diasAtras;
            double complemento = 100 - f1;

            if (complemento < 0)
                return 0;

            double fatorJuros = Math.Round(100 / complemento, PRECISÃO_DIGITOS_JUROS);

            valor = quantia / fatorJuros;

            return valor;
        }

        public static DateTime SomarDiasTabelaComercial(DateTime data, int dias)
        {
            // Nao existe mes com 31 dias na tabela comercial.
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
                DateTime dataAnterior = novaData;
                int diasQueFaltamParaOFimDoMês = 31 - novaData.Day;

                novaData = novaData.AddMonths(dias > 0 ? 1 : -1);
                novaData = novaData.Subtract(new TimeSpan(novaData.Day - 1, 0, 0, 0));

                int diasAdicionadosVirtualmente = diasQueFaltamParaOFimDoMês;

                if (diasAdicionadosVirtualmente < dias)
                    novaData = novaData.AddDays(dias - diasAdicionadosVirtualmente);
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

            if (antes.Day > 30)
                antes = new DateTime(antes.Year, antes.Month, 30);

            int diasDiferênça = Math.Abs(mesesDiferênça * 30 + (depois.Day - antes.Day));

            return data2 == depois ? diasDiferênça : -diasDiferênça;
        }

        public static DateTime SomarDias(DateTime data, int dias)
        {
            return SomarDiasTabelaComercial(data, dias);
        }
    }
}
