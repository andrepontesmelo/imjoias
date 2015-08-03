using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Pessoa
{
    [DbConversão(typeof(ConversorDbEstadoCivil))]
    public enum EstadoCivil
    {
        Desconhecido, Solteiro, Casado, Divorciado, Viuvo
    }

    public class ConversorDbEstadoCivil : DbConversor
    {
        public override object ConverterDeDB(object valor)
        {
            switch (valor.ToString())
            {
                case "S":
                    return EstadoCivil.Solteiro;

                case "C":
                    return EstadoCivil.Casado;

                case "D":
                    return EstadoCivil.Divorciado;

                case "V":
                    return EstadoCivil.Viuvo;

                case "O":
                    return EstadoCivil.Desconhecido;

                default:
                    throw new NotSupportedException();
            }
        }

        public override object ConverterParaDB(object valor)
        {
            switch ((EstadoCivil)valor)
            {
                case EstadoCivil.Solteiro:
                    return "S";

                case EstadoCivil.Casado:
                    return "C";

                case EstadoCivil.Divorciado:
                    return "D";

                case EstadoCivil.Viuvo:
                    return "V";

                case EstadoCivil.Desconhecido:
                    return "O";

                default:
                    throw new NotSupportedException("Estado civil não suportado para conversão.");
            }
        }
    }
}
