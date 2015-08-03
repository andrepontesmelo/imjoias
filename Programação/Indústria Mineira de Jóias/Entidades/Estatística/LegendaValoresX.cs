//using System;

//namespace Apresenta��o.Estat�stica.Comum
//{
//    /// <summary>
//    /// Coloca legenda nos valores do eixo X
//    /// </summary>
//    public abstract class LegendaValoresX
//    {
//        public abstract string Legenda(double valor);

//        public static LegendaValoresX Data(Gr�fico gr�fico, DateTime in�cio)
//        {
//            LegendaValoresData obj = new LegendaValoresData(in�cio);

//            gr�fico.ValorX += new Apresenta��o.Estat�stica.Convers�oValor(obj.Legenda);

//            return obj;
//        }
//    }

//    public class LegendaValoresData : LegendaValoresX
//    {
//        private DateTime in�cio;
//        private string formato = "dd/MM/yyyy";

//        public LegendaValoresData(DateTime in�cio)
//        {
//            this.in�cio = in�cio;
//        }

//        public override string Legenda(double valor)
//        {
//            DateTime data = in�cio.AddDays(valor);

//            return data.ToString(formato);
//        }

//        public string Formato
//        {
//            get { return formato; }
//            set { formato = value; }
//        }
//    }
//}
