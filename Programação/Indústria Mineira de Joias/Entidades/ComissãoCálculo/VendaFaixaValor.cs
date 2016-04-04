using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa.Endereço;

namespace Entidades.ComissãoCálculo
{
    public class VendaFaixaValor
    {
        public int Venda { get; set; }
        public List<FaixaValor> ListaFaixaValor { get; set; }

        public Região RegiãoDoCliente { get; set; }
        public ulong Vendedor { get; set; }
        public string Cliente { get; set; }
        public Setor SetorCliente { get; set; }

        public ulong? RepresentanteDoCliente
        {
            get
            {
                if (RegiãoDoCliente == null)
                    return null;

                Entidades.Pessoa.Representante representante = RegiãoDoCliente.ObterRepresentante();
                
                if (representante == null)
                    return null;
                
                return representante.Código;
            }
        }
    }
}
