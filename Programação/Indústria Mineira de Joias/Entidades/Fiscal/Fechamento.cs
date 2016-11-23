using Acesso.Comum;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Fechamento : DbManipulaçãoSimples
    {
        private int codigo;
        private DateTime inicio;
        private DateTime fim;
        private bool fechado;

        public Fechamento()
        {
        }

        public int Código => codigo;

        public DateTime Início
        {
            get { return inicio; }
            set { inicio = value; }
        }

        public DateTime Fim
        {
            get { return fim; }
            set { fim = value; }
        }

        public bool Fechado
        {
            get { return fechado; }
            set { fechado = value; }
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
