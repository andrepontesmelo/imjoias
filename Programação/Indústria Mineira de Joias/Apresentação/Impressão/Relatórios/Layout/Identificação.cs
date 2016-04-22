//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Drawing;
//using Entidades.Relacionamento;
//using Entidades.Configuração;
//using Report.Layout.Simple;

//namespace Apresentação.Impressão.Relatórios.Layout
//{
//    class Identificação : Report.Layout.Simple.Section
//    {
//        private Font fonte = new Font(FontFamily.GenericSansSerif, 12);

//        private Relacionamento relacionamento;

//        public Relacionamento Relacionamento
//        {
//            get { return relacionamento; }
//            set { relacionamento = value; }
//        }

//        protected virtual string CódigoDocumento
//        {
//            get { return relacionamento.Código.ToString(); }
//        }

//        public override void Print(System.Drawing.Graphics g, ref System.Drawing.RectangleF area, System.Collections.IList columns, int page)
//        {
//            DateTime agora = DadosGlobais.Instância.HoraDataAtual;

//            SizeF tamanho = g.MeasureString("Código do documento:   ", fonte);

//            g.DrawString("Código do documento: ", fonte, Brushes.Black, area.Left, area.Top);
//            g.DrawString(
//                CódigoDocumento,
//                fonte,
//                Brushes.Black, area.Left + tamanho.Width, area.Top);

//            g.DrawString("Relacionado para: ", fonte, Brushes.Black, area.Left, area.Top);
//            g.DrawString(
//                string.Format("({0}) {1}", relacionamento.Pessoa.Código, relacionamento.Pessoa.Nome),
//                fonte,
//                Brushes.Black, area.Left + tamanho.Width, area.Top + tamanho.Height);

//            g.DrawString("Digitado por: ", fonte, Brushes.Black, area.Left, area.Top + tamanho.Height);
//            g.DrawString(
//                string.Format("({0}) {1}", relacionamento.DigitadoPor.Código, relacionamento.DigitadoPor.Nome),
//                fonte,
//                Brushes.Black, area.Left + tamanho.Width, area.Top + tamanho.Height * 2);

//            g.DrawString("Data documento: ", fonte, Brushes.Black, area.Left, area.Top + tamanho.Height * 3);
//            g.DrawString(
//                relacionamento.Data.ToLongDateString() + " " + relacionamento.Data.ToLongTimeString(),
//                fonte,
//                Brushes.Black, area.Left + tamanho.Width, area.Top + tamanho.Height * 3);

//            g.DrawString("Data impressão: ", fonte, Brushes.Black, area.Left, area.Top + tamanho.Height * 4);
//            g.DrawString(
//                agora.ToLongDateString() + " " + agora.ToLongTimeString(),
//                fonte,
//                Brushes.Black, area.Left + tamanho.Width, area.Top + tamanho.Height * 4);

//            g.DrawLine(
//                Pens.Black,
//                area.Left,
//                area.Top + tamanho.Height * 5 + Footer.lineDistance,
//                area.Right,
//                area.Top + tamanho.Height * 5 + Footer.lineDistance);

//            printCompleted = true;
//        }

//        public override float MeasureHeight(System.Drawing.Graphics g, System.Drawing.RectangleF area, System.Collections.IList columns, int page)
//        {
//            SizeF tamanho = g.MeasureString("Relacionado para:   ", fonte);

//            return tamanho.Height * 5 + Footer.lineDistance * 2;
//        }

//        public override bool PrintBeforeData
//        {
//            get { return true; }
//        }

//        public override bool PrintAfterData
//        {
//            get { return false; }
//        }
//    }
//}
