using Apresentação.Formulários.Consultas;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    class ColetorPedidos : Coletor
    {
        private readonly int padrãoLimiteMínimo = 7;
        private readonly int? padrãoLimiteMáximo = 80;
        private readonly int padrãoDemoraMáximaMs = 400;

        private ControladorLimiteColetor controladorLimiteNomes;

        public delegate void RecuperaçãoPedidosDelegate(Entidades.PedidoConserto.Pedido[] pedidos);
        private RecuperaçãoPedidosDelegate recuperaçãoPedidos;

        public ColetorPedidos(RecuperaçãoPedidosDelegate recuperação)
		{
            this.recuperaçãoPedidos = recuperação;
            controladorLimiteNomes = new ControladorLimiteColetor(padrãoLimiteMínimo, padrãoLimiteMáximo, padrãoDemoraMáximaMs);
		}

		protected override void Recuperar(string chave)
		{
            controladorLimiteNomes.CronometrarInicioObter();
            recuperaçãoPedidos(Entidades.PedidoConserto.Pedido.Obter(chave, controladorLimiteNomes.LimiteDinâmico));
            controladorLimiteNomes.CronometrarFimObter();
		}
    }
}
