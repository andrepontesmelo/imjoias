using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Pessoa
{
    [DbConversão(typeof(ConversorDbSexo))]
    public enum Sexo
    {
        Desconhecido, Masculino, Feminino
    }

    public sealed class ConversorDbSexo : DbConversor
    {
        public override object ConverterDeDB(object valor)
        {
            switch (valor.ToString())
            {
                case "M":
                    return Sexo.Masculino;

                case "F":
                    return Sexo.Feminino;

                default:
                    throw new NotSupportedException();
            }
        }

        public override object ConverterParaDB(object valor)
        {
            switch ((Sexo)valor)
            {
                case Sexo.Masculino:
                    return "M";

                case Sexo.Feminino:
                    return "F";

                case Sexo.Desconhecido:
                    return null;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
