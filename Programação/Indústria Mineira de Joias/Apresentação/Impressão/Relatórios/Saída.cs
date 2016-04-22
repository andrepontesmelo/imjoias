//using System;
//using System.Collections.Generic;
//using System.Text;
//using Report;
//using Report.Layout;
//using Report.Layout.Simple;
//using Entidades.Relacionamento;

//namespace Apresentação.Impressão.Relatórios
//{
//    class Saída : Relatório<Entidades.Relacionamento.Saída.Saída>
//    {
//        public override void Preparar(Entidades.Relacionamento.Saída.Saída documento)
//        {
//            layout.Columns.Add(new Column("Referência", typeof(SaquinhoRelacionamento), "Mercadoria"));
//            layout.Columns.Add(new Column("Peso", typeof(SaquinhoRelacionamento), "Peso"));
//            layout.Columns.Add(new Column("Índice", typeof(SaquinhoRelacionamento), "Índice"));
//            layout.Columns.Add(new Column("Quantidade", typeof(SaquinhoRelacionamento), "Quantidade"));
//            layout.Columns["Índice"].Format = "{0:###,###,###,###,##0.00}";
//            layout.Columns["Índice"].ToSum = true;
//            layout.Columns["Peso"].Format = "{0:###,###,###,###,##0.00}g";
//            layout.Columns["Peso"].ToSum = true;
//            layout.Columns["Quantidade"].ToSum = true;
//        }
//    }
//}
