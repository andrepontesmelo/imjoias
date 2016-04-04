using System;
using Programa.Recep��o.Formul�rios.EntradaSa�da;

namespace Programa.Recep��o
{
	/// <summary>
	/// Controlador do bot�o ordenarPorRod�zio.
	/// </summary>
	public class ControladorBot�oRod�zio : Apresenta��o.Formul�rios.ControladorBaseInferior
	{
		public override void Exibir()
		{
			Rod�zioPropriedades rod�zio = new Rod�zioPropriedades();

			rod�zio.ShowDialog();	
		}
	}
}
