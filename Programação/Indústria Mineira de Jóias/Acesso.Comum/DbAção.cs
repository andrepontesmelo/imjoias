using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum
{
    /// <summary>
    /// Executa ação sobre o banco de dados.
    /// </summary>
    /// <param name="cmd">Comando que participa de uma transação.</param>
    /// <param name="item">Item que sofrerá ação sobre o banco de dados.</param>
    /// <returns>Se a operação se sucedeu corretamente.</returns>
    public delegate void DbAção<Entidade>(System.Data.IDbCommand cmd, Entidade item);
}
