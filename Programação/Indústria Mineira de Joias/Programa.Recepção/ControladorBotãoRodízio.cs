using System;
using Programa.Recepção.Formulários.EntradaSaída;

namespace Programa.Recepção
{
	/// <summary>
	/// Controlador do botão ordenarPorRodízio.
	/// </summary>
	public class ControladorBotãoRodízio : Apresentação.Formulários.ControladorBaseInferior
	{
		public override void Exibir()
		{
			RodízioPropriedades rodízio = new RodízioPropriedades();

			rodízio.ShowDialog();	
		}
	}
}
