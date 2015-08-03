using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        
        {
            // 1 = OK
            // double juros = Entidades.Preço.CalcularJuros(60, 1000, 8);

            // 2 = OK 
            // double juros = Entidades.Preço.CalcularJuros(125, 40000, 3);

            //double juros = Entidades.Preço.CalcularJuros(145, 70000, 10.5) + 70000;
            double juros = Entidades.Preço.CalcularJuros(860, 200, 2.8);

            //Console.Write(Entidades.Preço.CalcularJuros(30, 100, 2.8));
            StringBuilder s = new StringBuilder();

            for (int dia = 1; dia <= 999; dia++)
            {
                Mostrar(dia.ToString(), s);
                Mostrar("\t", s);
                //Mostrar(Entidades.Preço.CalcularJurosAntigo(dia, 100, 2.8).ToString(), s);
                Mostrar("\t", s);
                Mostrar(Entidades.Preço.CalcularJuros(dia, 100, 2.8).ToString(), s);
                Mostrar("\r\n", s);
            }

            System.IO.File.WriteAllText("c:\\users\\andre\\Documents\\Documentos\\Firma\\saida.txt", s.ToString());
            Console.Read();
        }

        static void Mostrar(string texto, StringBuilder s)
        {
            Console.Write(texto);
            s.Append(texto);
        }
    }
}
