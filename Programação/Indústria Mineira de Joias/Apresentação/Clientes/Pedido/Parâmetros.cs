using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public class Parâmetros
    {
        public Entidades.Pessoa.Pessoa Cliente { get; set; }
        public DateTime Início { get; set; }
        public DateTime Fim { get; set; }
        public bool PeríodoPrevisão { get; set; }
        public bool OcultarJáEntregues { get; set; }
        public bool ApenasPedidos { get; set; }
    }
}
