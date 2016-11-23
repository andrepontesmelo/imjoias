using Acesso.Comum;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Fechamento : DbManipulaçãoAutomática
    {
        [DbChavePrimária(true)]
        private int codigo;
        private DateTime inicio;
        private DateTime fim;
        private bool fechado;

        public Fechamento()
        {
            inicio = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month,
                1);

            fim = inicio.AddMonths(1).AddDays(-1);

            fechado = false;
        }

        public int Código => codigo;

        public DateTime Início
        {
            get { return inicio; }
            set
            {
                inicio = value;
                DefinirDesatualizado();
            }
        }

        public DateTime Fim
        {
            get { return fim; }
            set
            {
                fim = value;
                DefinirDesatualizado();
            }
        }

        public bool Fechado
        {
            get { return fechado; }
            set
            {
                fechado = value;
                DefinirDesatualizado();
            }
        }

        public static List<Fechamento> Obter()
        {
            return Mapear<Fechamento>("select * from fechamento");
        }

        public void Excluir()
        {
            ExecutarComando(string.Format("delete from fechamento where codigo = {0}",
                Código));
        }
    }
}
