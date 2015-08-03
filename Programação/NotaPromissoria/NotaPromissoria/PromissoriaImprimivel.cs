using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class PromissoriaImprimivel : PrintDocument
    {
        private string parcela;
        private string vencimento;
        private string valor;
        private string aos;
        private string diasDoMesDe;
        private string doAnoDe;
        private string aQuantiaDe;
        private string dia;
        private string mes;
        private string ano;
        private string emitente;
        private string endereço;
        private string cpf;
        private string cgc;
        private bool contraApresentação;

        public string Aos
        { get { return aos; } }

        public string DiasDoMesDe
        { get { return diasDoMesDe; } }

        public string DoAnoDe { get { return doAnoDe; } }
        public string AQuantiaDeL1 
        {
            get
            {
                string[] palavras = DividirEmLinhas(aQuantiaDe, totalPalavrasPorLinhaQuantiaDe);
                return palavras[0];
            }
        }

        public string AQuantiaDeL2 
        { 
            get 
            {
                string[] palavras = DividirEmLinhas(aQuantiaDe, totalPalavrasPorLinhaQuantiaDe);
                if (palavras.Length > 1)
                    return palavras[1];
                else
                    return "";
            } 
        }

        public PromissoriaImprimivel(string parcela, string vencimento,
            string valor, string aos, string diasDoMesDe,
            string doAnoDe, string aQuantiaDe, string dia,
            string mes, string ano, 
            string emitente, string endereço, string cpf, string cgc, bool contraApresentação)
        {
            this.parcela = parcela;
            this.vencimento = vencimento;
            this.valor = valor;
            this.aos = aos;
            this.diasDoMesDe = diasDoMesDe;
            this.doAnoDe = doAnoDe;
            this.aQuantiaDe = aQuantiaDe;
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            this.emitente = emitente;
            this.endereço = endereço;
            this.cpf = cpf;
            this.cgc = cgc;
            this.contraApresentação = contraApresentação;

            PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        }

        static int totalPalavrasPorLinhaQuantiaDe = 11;
        static int totalPalavrasPorLinhaEndereco = 9;
        static int totalPalavrasPorLinhaEmitente = 10;


        static void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float proporção = 37;
            PromissoriaImprimivel doc = (PromissoriaImprimivel) sender;

            //System.Drawing.Font printFont = new Font("Courier New", 12);
            //System.Drawing.Font printFontMenor = new Font("Courier New", 8);

            System.Drawing.Font printFontMenor = new Font("Courier New", 10);
            System.Drawing.Font printFont = printFontMenor;

            e.Graphics.DrawString(doc.parcela, printFont, Brushes.Black, proporção * 5.1f, proporção * 3f);
            e.Graphics.DrawString(doc.valor, printFont, Brushes.Black, proporção * 16.2f, proporção * 3.1f);
            if (!doc.contraApresentação)
                e.Graphics.DrawString(doc.vencimento.Replace(" de ", " "), printFontMenor, Brushes.Black, proporção * 15.8f, proporção * 1.8f);
            else
                e.Graphics.DrawString("CONTRA APRESENTAÇÃO", printFontMenor, Brushes.Black, proporção * 15.8f, proporção * 1.8f);

            e.Graphics.DrawString(doc.aos, printFont, Brushes.Black, proporção * 7f, proporção * 4.3f);
            e.Graphics.DrawString(doc.diasDoMesDe, printFont, Brushes.Black, proporção * 14f, proporção * 4.3f);
            e.Graphics.DrawString(doc.doAnoDe, printFont, Brushes.Black, proporção * 18.9f, proporção * 4.3f);

            e.Graphics.DrawString(doc.AQuantiaDeL1, printFontMenor, Brushes.Black, proporção * 7.1f, proporção * 6.4f);
            e.Graphics.DrawString(doc.AQuantiaDeL2, printFontMenor, Brushes.Black, proporção * 4.8f, proporção * 7.1f);

            e.Graphics.DrawString(doc.dia, printFont, Brushes.Black, proporção * 12.5f, proporção * 7.98f);
            e.Graphics.DrawString(doc.mes, printFont, Brushes.Black, proporção * 14.5f, proporção * 7.98f);
            e.Graphics.DrawString(doc.ano, printFont, Brushes.Black, proporção * 19.5f, proporção * 7.98f);

            string[] palavrasEmitente = DividirEmLinhas(doc.emitente, totalPalavrasPorLinhaEmitente);
            e.Graphics.DrawString(palavrasEmitente[0], printFont, Brushes.Black, proporção * 6.5f, proporção * 10f);
            if (palavrasEmitente.Length > 1)
                e.Graphics.DrawString(palavrasEmitente[1], printFont, Brushes.Black, proporção * 6.5f, proporção * 10.4f);

            string[] palavrasEndereco = DividirEmLinhas(doc.endereço, totalPalavrasPorLinhaEndereco);
            e.Graphics.DrawString(palavrasEndereco[0], printFontMenor, Brushes.Black, proporção * 6.6f, proporção * 11f);

            if (palavrasEndereco.Length > 1)
                e.Graphics.DrawString(palavrasEndereco[1], printFontMenor, Brushes.Black, proporção * 6.6f, proporção * 11.5f);
            
            
            e.Graphics.DrawString(doc.cpf, printFont, Brushes.Black, proporção * 5.5f, proporção * 12f);
            e.Graphics.DrawString(doc.cgc, printFont, Brushes.Black, proporção * 13.1f, proporção * 12f);
        }

        private static string[] DividirEmLinhas(string texto, int totalPalavrasPorLinha)
        {
            string[] palavras = texto.Split(' ');

            if (palavras.Length < totalPalavrasPorLinha)
            {
                string[] resultado = new string[1];
                resultado[0] = texto;
                return resultado;
            }
            else
            {
                // Duas Linhas!
                string linha1 = "";
                string linha2 = "";
                int qtdPalavras = 0;
                foreach (string palavra in palavras)
                {
                    qtdPalavras++;
                    linha1 += palavra + " ";
                    if (qtdPalavras > totalPalavrasPorLinha)
                        break;
                }

                for (int p = qtdPalavras; p < palavras.Length; p++)
                {
                    linha2 += palavras[p] + " ";
                }

                string[] resultado = new string[2];
                resultado[0] = linha1;
                resultado[1] = linha2;

                return resultado;
            }
        }
    }
}
