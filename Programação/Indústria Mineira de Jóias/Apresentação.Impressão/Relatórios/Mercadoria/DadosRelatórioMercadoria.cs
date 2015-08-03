using System;
using System.Collections.Generic;
using System.Text;
using Apresentação.Impressão;

namespace Apresentação.Impressão.Relatórios.Mercadoria
{
    public class DadosRelatórioMercadoria : Apresentação.Impressão.DadosRelatório
    {
        private Entidades.Tabela tabela;
        public Entidades.Tabela Tabela { get { return tabela; } set { tabela = value; } }

        public DadosRelatórioMercadoria(Entidades.Tabela tabela) 
        {
            this.tabela = tabela;
            base.Tipo = TipoDocumento.Mercadoria;
        }
    }
}
