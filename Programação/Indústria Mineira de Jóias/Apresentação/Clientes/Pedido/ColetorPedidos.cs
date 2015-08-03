using System;
using System.Collections.Generic;
using System.Text;
using Apresentação.Formulários.Consultas;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    class ColetorPedidos : Apresentação.Formulários.Consultas.Coletor
    {
		// Constantes
        private readonly int    padrãoLimiteMínimo = 7;
        private readonly int?   padrãoLimiteMáximo = 80;
        private readonly int    padrãoDemoraMáximaMs = 400;

        //// Atributos
        //private bool			            funcionários = false;	// Coletar somente funcionários
        //private bool			            vendedores = false;	    // Coletar somente vendedores
        private ControladorLimiteColetor    controladorLimite;      // Controla o limite dos nomes

		// Delegações
        public delegate void RecuperaçãoPedidosDelegate(Entidades.PedidoConserto.Pedido[] pedidos);
        private RecuperaçãoPedidosDelegate recuperaçãoPedidos;

        public ColetorPedidos(RecuperaçãoPedidosDelegate recuperação)
		{
			// Atribui tratamento de recuperação
            this.recuperaçãoPedidos = recuperação;

            controladorLimite = new ControladorLimiteColetor(padrãoLimiteMínimo, padrãoLimiteMáximo, padrãoDemoraMáximaMs);
		}

		protected override void Recuperar(string chave)
		{
			Entidades.PedidoConserto.Pedido [] pedidos;

            controladorLimite.CronometrarInicioObter();
            pedidos = Entidades.PedidoConserto.Pedido.Obter(chave, controladorLimite.LimiteDinâmico);
            recuperaçãoPedidos(pedidos);
            controladorLimite.CronometrarFimObter();
		}
    }
}
