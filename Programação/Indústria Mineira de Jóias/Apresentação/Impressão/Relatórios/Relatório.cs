//using System;
//using System.Collections.Generic;
//using System.Text;
//using Report.Layout.Simple;
//using Entidades.Relacionamento;

//namespace Apresentação.Impressão.Relatórios
//{
//    abstract class Relatório<TDocumento>
//    {
//        protected Report.Layout.SimpleLayout layout;
//        protected Relacionamento relacionamento;

//        protected abstract void ConstruirLayout();

//        public Relatório()
//        {
//            layout = new Report.Layout.SimpleLayout();
//            layout.OnMeasureObject += new Report.Layout.SimpleLayout.MeasureObjectHandler(OnMeasureObject);
//            layout.OnPrintObject += new Report.Layout.SimpleLayout.PrintObjectHandler(OnPrintObject);
//        }

//        void OnPrintObject(System.Drawing.Graphics g, object obj, float y)
//        {
//            throw new Exception("The method or operation is not implemented.");
//        }

//        System.Drawing.SizeF OnMeasureObject(System.Drawing.Graphics g, object obj, out bool handled)
//        {
//            throw new Exception("The method or operation is not implemented.");
//        }

//        public abstract void Preparar(TDocumento documento);
//    }
//}
