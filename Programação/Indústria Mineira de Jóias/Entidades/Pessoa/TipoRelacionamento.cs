using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Pessoa
{
    /* Não altere nem remova os valores abaixo. Risco
     * de causar inconsistências no banco de dados!!!
     * 
     * ATENÇÃO:
     * Lembre-se de ao acrescentar novo item, incluí-lo no
     * tratamento de:
     * - RelacionamentoInterPessoal.InverterRelacionamento(...);
     * - DadosRelacionamento.DadosRelacionamento().
     */
    [DbConversão(typeof(ConversorDbTipoRelacionamento))]
    public enum TipoRelacionamento
    {
        Nenhum = -1,
        Desconhecido = 0,
        Pai = 1,
        Mãe = 2,
        Irmão = 3,
        Tio = 4,
        Avô = 5,
        Bisavô = 6,
        Filho = 7,
        Sobrinho = 8,
        Neto = 9,
        Bisneto = 10,
        Primo = 11,
        Primo2o = 12,
        Amigo = 13,
        Funcionário = 14,
        Representante = 15,
        Empregador = 16,
        Namorado = 17,
        Esposo = 18,
        Colega = 19,
        Cunhado = 20, // simétrico
        Genro = 21,   // Nora
        Sogro = 22,     // Genro<->sogro
        VendePara = 23,
        CompraDe = 24

        // *** ATENÇÃO *** ATENÇÃO *** ATENÇÃO *** ATENÇÃO *** ATENÇÃO *** \\
        // *                                                             * \\
        // * Incluiu novo? Então têm mais dois arquivos para alterar! =) * \\
        // *                                                             * \\
        // *** ATENÇÃO *** ATENÇÃO *** ATENÇÃO *** ATENÇÃO *** ATENÇÃO *** \\
    }

    public sealed class ConversorDbTipoRelacionamento : DbConversor
    {
        public override object ConverterDeDB(object valor)
        {
            return (TipoRelacionamento)Enum.Parse(typeof(TipoRelacionamento), valor.ToString());
        }

        public override object ConverterParaDB(object valor)
        {
            return (int)valor;
        }
    }
}
