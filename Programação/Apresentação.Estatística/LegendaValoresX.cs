//using System;

//namespace Apresentação.Estatística.Comum
//{
//    /// <summary>
//    /// Coloca legenda nos valores do eixo X
//    /// </summary>
//    public abstract class LegendaValoresX
//    {
//        public abstract string Legenda(double valor);

//        public static LegendaValoresX Data(Gráfico gráfico, DateTime início)
//        {
//            LegendaValoresData obj = new LegendaValoresData(início);

//            gráfico.ValorX += new Apresentação.Estatística.ConversãoValor(obj.Legenda);

//            return obj;
//        }
//    }

//    public class LegendaValoresData : LegendaValoresX
//    {
//        private DateTime início;
//        private string formato = "dd/MM/yyyy";

//        public LegendaValoresData(DateTime início)
//        {
//            this.início = início;
//        }

//        public override string Legenda(double valor)
//        {
//            DateTime data = início.AddDays(valor);

//            return data.ToString(formato);
//        }

//        public string Formato
//        {
//            get { return formato; }
//            set { formato = value; }
//        }
//    }
//}
