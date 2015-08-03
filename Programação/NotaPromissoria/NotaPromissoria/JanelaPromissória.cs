using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class JanelaPromissória : Form, IPromissoria
    {
        public JanelaPromissória()
        {
            InitializeComponent();
            txtQtd.Text = "1";
            dataPriVencimento.Value = DateTime.Now;
            data.Value = DateTime.Now;
            AtualizarInterface();
            dataPriVencimento.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog opcoes = new PrintDialog();
            opcoes.AllowSomePages = true;
            if (opcoes.ShowDialog() != DialogResult.OK)
                return;

            DateTime mesPrimeiroVencimento =  new DateTime(PrimeiroVencimento.Year, PrimeiroVencimento.Month, 1);
            int totalPaginas = opcoes.PrinterSettings.ToPage == 0 ? TotalParcelas : opcoes.PrinterSettings.ToPage;

            for (int página = opcoes.PrinterSettings.FromPage; página < totalPaginas; página++)
            {
                int páginaAtual = página + 1;

                DateTime mesVencimentoAtual = mesPrimeiroVencimento.AddMonths(páginaAtual - 1);
                DateTime vencimentoAtual;
                try
                {
                    vencimentoAtual = new DateTime(mesVencimentoAtual.Year, mesVencimentoAtual.Month, PrimeiroVencimento.Day);
                } catch (Exception mesNaoTemEsseDia)
                {
                    vencimentoAtual = mesVencimentoAtual.AddMonths(1).AddDays(-1);
                }

                PromissoriaImprimivel promissória = CriarPromissória(páginaAtual, vencimentoAtual);
                promissória.Print();    
            }
        }

        private PromissoriaImprimivel CriarPromissória(int páginaAtual, DateTime vencimentoAtual)
        {
            return new PromissoriaImprimivel(
                    (páginaAtual).ToString("00") + "/" + TotalParcelas.ToString("00"),
                    vencimentoAtual.Day.ToString() + " de " + ObterNomeMes(vencimentoAtual.Month) + " de " + vencimentoAtual.Year.ToString(),
                    Quantia.ToString("C"),
                    (chkContraApresentacao.Checked ? "" : ObterDiaMesPorExtenso(vencimentoAtual.Day)),
                    (chkContraApresentacao.Checked ? "" : ObterNomeMes(vencimentoAtual.Month)),
                    (chkContraApresentacao.Checked ? "" : vencimentoAtual.Year.ToString()),
                    Transformar(Quantia),
                    Data.Day.ToString(),
                    ObterNomeMes(Data.Month),
                    Data.Year.ToString(),
                    Emitente,
                    Endereço,
                    CPF,
                    CGC,
                    chkContraApresentacao.Checked
                    );
        }

        #region IPromissoria Members

        public int TotalParcelas
        {
            get 
            {
                int valor;
                if (Int32.TryParse(txtQtd.Text, out valor))
                {
                    return valor;
                }
                else
                    return 0;
            }
        }

        public DateTime PrimeiroVencimento
        {
            get
            {
                return dataPriVencimento.Value;
            }
        }

        public DateTime Data
        {
            get { return data.Value; }
        }

        public double Quantia
        {
            get 
            {
                double valor;
                if (double.TryParse(txtValor.Text, out valor))
                    return valor;
                else
                    return 0;
            }
        }

        public string Emitente
        {
            get { return txtEmitente.Text; }
        }

        public string Endereço
        {
            get { return txtEndereco.Text; }
        }

        public string CPF
        {
            get { return txtCPF.Text; }
        }

        public string CGC
        {
            get { return txtCGC.Text; }
        }

        #endregion

        /// <summary>
        /// Transforma um número real para o formato extenso
        /// </summary>
        /// <param name="número">Valor a ser formatado</param>
        /// <returns>Número extenso</returns>
        public static string Transformar(double valor)
        {
            int conta, parte;
            string[] s_singular = new string[] { "REAL", "MIL", "MILHÃO", "BILHÃO", "TRILHÃO" };
            string[] s_plural = new string[] { "REAIS", "MIL", "MILHÕES", "BILHÕES", "TRILHÕES" };
            string[] s_unidade = new string[] {"ZERO", "UM", "DOIS", "TRÊS", "QUATRO", "CINCO",
				"SEIS", "SETE", "OITO", "NOVE", "DEZ", "ONZE", "DOZE", "TREZE",
				"QUATORZE", "QUINZE", "DEZESSEIS", "DEZESSETE", "DEZOITO", "DEZENOVE"};
            string[] s_dezena = new string[] {"", "", "VINTE", "TRINTA", "QUARENTA",
				"CINQÜENTA", "SESSENTA", "SETENTA", "OITENTA", "NOVENTA", "CEM"};
            string[] s_centena = new string[] {"", "CENTO", "DUZENTOS", "TREZENTOS",
				"QUATROCENTOS", "QUINHENTOS", "SEISCENTOS", "SETECENTOS",
				"OITOCENTOS", "NOVECENTOS"};
            const string s_espaco = " ", s_e = " E ";
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

                if (conta > 100)
                {
                    txt = s_centena[conta / 100];
                    conta %= 100;
                    anterior = true;
                    cont = 3;
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

                if (i == 0 && parte % 1000 <= 1 && valor > 1)
                    extenso = txt + s_espaco + s_plural[i] + extenso;
                else if (parte % 1000 > 0)
                    extenso = txt + s_espaco + (parte > 1 ? s_plural[i] : s_singular[i]) + extenso;

                if (i++ == 0 && cont <= 3 && cont > 0 && valor > 999)
                {
                    extenso = s_e + extenso;
                    anterior = false;
                }

                parte /= 1000;
            } while (parte > 0);

            if (extenso.Length > 0)
                switch (extenso[0])
                {
                    case ' ':
                        extenso = extenso.Trim();
                        break;

                    case 'U':
                        extenso = "H" + extenso;
                        break;
                }

            //txt.Format("%f", (valor - (int) valor) * 100);
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

                if (fracao > 1)
                    extenso += " CENTAVOS";
                else
                    extenso += "CENTAVO";
            }

            return extenso;
        }

        private string ObterNomeMes(int mes)
        {
            return ObterNomeMesNormal(mes).ToUpper();
        }

        private string ObterNomeMesNormal(int mes)
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


        public static string ObterDiaMesPorExtenso(double valor)
        {
            int conta, parte;
            string[] s_unidade = new string[] {"ZERO", "UM", "DOIS", "TRÊS", "QUATRO", "CINCO",
				"SEIS", "SETE", "OITO", "NOVE", "DEZ", "ONZE", "DOZE", "TREZE",
				"QUATORZE", "QUINZE", "DEZESSEIS", "DEZESSETE", "DEZOITO", "DEZENOVE"};
            string[] s_dezena = new string[] {"", "", "VINTE", "TRINTA", "QUARENTA",
				"CINQÜENTA", "SESSENTA", "SETENTA", "OITENTA", "NOVENTA", "CEM"};
            const string s_espaco = " ", s_e = " E ";
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

            //txt.Format("%f", (valor - (int) valor) * 100);
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

        private void txtQtd_Validated(object sender, EventArgs e)
        {
            AtualizarInterface();
        }

        private void AtualizarInterface()
        {
            PromissoriaImprimivel promissória = CriarPromissória(1, dataPriVencimento.Value);
            txtAos.Text = promissória.Aos;
            txtDiasDoMesDe.Text = promissória.DiasDoMesDe;
            txtDoAnoDe.Text = promissória.DoAnoDe;
            txtQuantia.Text = promissória.AQuantiaDeL1;
            txtQuantiaL2.Text = promissória.AQuantiaDeL2;
        }

        private void dataPriVencimento_ValueChanged(object sender, EventArgs e)
        {
            AtualizarInterface();
        }

        private void txtValor_Validated(object sender, EventArgs e)
        {
            AtualizarInterface();
        }

        private void txtAos_Validated(object sender, EventArgs e)
        {
            AtualizarInterface();
        }

        private void txtDiasDoMesDe_Validated(object sender, EventArgs e)
        {
            AtualizarInterface();
        }

        private void txtDoAnoDe_Validated(object sender, EventArgs e)
        {
            AtualizarInterface();
        }

        private void data_Validated(object sender, EventArgs e)
        {
            AtualizarInterface();
        }

        private void txtQtd_Validating(object sender, CancelEventArgs e)
        {
            int valor;
            e.Cancel = !Int32.TryParse(txtQtd.Text, out valor);
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            double valor;
            e.Cancel = !Double.TryParse(txtValor.Text, out valor);

        }

        private void JanelaPromissória_Resize(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(657, 438);
        }

        private void chkContraApresentacao_CheckedChanged(object sender, EventArgs e)
        {
            panelEscondeVencimento.Visible = chkContraApresentacao.Checked;

            txtAos.Visible =
            txtDiasDoMesDe.Visible = 
            txtDoAnoDe.Visible =
            !chkContraApresentacao.Checked;
        }
    }
}
