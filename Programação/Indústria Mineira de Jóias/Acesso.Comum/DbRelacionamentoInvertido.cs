using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum
{
    /// <summary>
    /// Marca um tipo como um relacionamento invertido.
    /// Objetos DbManipulação marcados com este atributo
    /// não são considerados como coluna pelo DbManipulaçãoAutomática
    /// e são chamados os métodos correspondentes de manipulação
    /// ao término da manipulação do objeto relacionado.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DbRelacionamentoInvertido : Attribute
    {
    }
}
