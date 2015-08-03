/*
using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Relacionamento interpessoal.
    /// </summary>
    [DbTabela("pessoarelacionamento")]
    public sealed class RelacionamentoInterpessoal : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false), DbRelacionamento("codigo", "pessoa1")]
        private Pessoa pessoa1;

        [DbChavePrimária(false), DbRelacionamento("codigo", "pessoa2")]
        private Pessoa pessoa2;

        /// <summary>
        /// Determina se pessoa1 foi indicada por pessoa2.
        /// </summary>
        [DbColuna("indicacao")]
        private bool indicação;

        /// <summary>
        /// Tipo de relacionamento da pessoa1 com a pessoa2.
        /// </summary>
        private TipoRelacionamento relacionamento;

        #region Propriedades

        /// <summary>
        /// Pessoa1 é 'TipoRelacionamento' de Pessoa2.
        /// </summary>
        public Pessoa Pessoa1
        {
            get { return pessoa1; }
            set
            {
                if (Cadastrado)
                    throw new Acesso.Comum.Exceções.AlteraçãoChavePrimária(this);

                pessoa1 = value;
            }
        }

        /// <summary>
        /// Pessoa1 é 'TipoRelacionamento' de Pessoa2.
        /// </summary>
        public Pessoa Pessoa2
        {
            get { return pessoa2; }
            set
            {
                if (Cadastrado)
                    throw new Acesso.Comum.Exceções.AlteraçãoChavePrimária(this);

                pessoa2 = value;
            }
        }

        /// <summary>
        /// Verifica se houve indicação de cliente.
        /// </summary>
        public bool Indicação
        {
            get { return indicação; }
            set
            {
                indicação = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Pessoa indicada.
        /// </summary>
        /// <remarks>Retorna nulo quando Indicação == false</remarks>
        public Pessoa Indicado
        {
            get
            {
                if (indicação)
                    return pessoa1;
                else
                    return null;
            }
        }

        /// <summary>
        /// Pessoa que indicou.
        /// </summary>
        /// <remarks>Retorna nulo quando Indicação == false</remarks>
        public Pessoa Referência
        {
            get
            {
                if (indicação)
                    return pessoa2;
                else
                    return null;
            }
        }

        /// <summary>
        /// Tipo de relacionamento.
        /// </summary>
        /// <remarks>
        /// Utilize Pessoa.ObterRelacionamento(p2) ao invés deste valor,
        /// pois ele organizará o relacionamento na ordem "p1 é 'tipo' de p2".
        /// Assim, se pessoa1 (desta entidade) é pai de pessoa2, ao obter o
        /// relacionamento de pessoa2.ObterRelacioanmento(pessoa1), será dito que
        /// "pessoa2 é filha de pessoa1".
        /// </remarks>
        public TipoRelacionamento TipoRelacionamento
        {
            get { return relacionamento; }
            set { relacionamento = value; DefinirDesatualizado(); }
        }

        #endregion

        /// <summary>
        /// Obtém todas as pessoas relacionadas com uma determinada pessoa.
        /// </summary>
        /// <returns>Pessoas relacionadas.</returns>
        public static RelacionamentoInterpessoal[] ObterRelacionamentos(Pessoa pessoa)
        {
            return Mapear<RelacionamentoInterpessoal>(
                "SELECT * FROM pessoarelacionamento WHERE pessoa1 = " +
                DbTransformar(pessoa.Código) +
                " OR pessoa2 = " + DbTransformar(pessoa.Código)).ToArray();
        }

        /// <summary>
        /// Inverte o tipo de relacionamento.
        /// </summary>
        /// <param name="tipo">Tipo a ser invertido.</param>
        /// <returns>Relacionamento invertido.</returns>
        /// <example>
        /// InverterRelacionamento(TipoRelacionamento.Pai)
        /// retorna TipoRelacionamento.Filho.</example>
        public static TipoRelacionamento InverterRelacionamento(TipoRelacionamento tipo)
        {
            switch (tipo)
            {
                Relacionamentos simétricos

                case TipoRelacionamento.Amigo:
                case TipoRelacionamento.Desconhecido:
                case TipoRelacionamento.Primo:
                case TipoRelacionamento.Primo2o:
                case TipoRelacionamento.Irmão:
                case TipoRelacionamento.Esposo:
                case TipoRelacionamento.Namorado:
                case TipoRelacionamento.Colega:
                case TipoRelacionamento.Cunhado:
                    return tipo;


                // Relacionamentos assimétricos 

                case TipoRelacionamento.Avô:
                    return TipoRelacionamento.Neto;

                case TipoRelacionamento.Bisavô:
                    return TipoRelacionamento.Bisneto;

                case TipoRelacionamento.Filho:
                    return TipoRelacionamento.Pai;

                case TipoRelacionamento.Funcionário:
                case TipoRelacionamento.Representante:
                    return TipoRelacionamento.Empregador;

                case TipoRelacionamento.Mãe:
                case TipoRelacionamento.Pai:
                    return TipoRelacionamento.Filho;

                case TipoRelacionamento.Neto:
                    return TipoRelacionamento.Avô;

                case TipoRelacionamento.Bisneto:
                    return TipoRelacionamento.Bisavô;

                case TipoRelacionamento.Tio:
                    return TipoRelacionamento.Sobrinho;

                case TipoRelacionamento.Sobrinho:
                    return TipoRelacionamento.Tio;

                case TipoRelacionamento.Genro:
                    return TipoRelacionamento.Sogro;

                case TipoRelacionamento.Sogro:
                    return TipoRelacionamento.Genro;

                case TipoRelacionamento.VendePara:
                    return TipoRelacionamento.CompraDe;

                case TipoRelacionamento.CompraDe:
                    return TipoRelacionamento.VendePara;


                // Relacionamentos incorretos //

#if DEBUG
                case TipoRelacionamento.Nenhum:
                    throw new Exception("Ninguém pode ter relacionamento nenhum!");

                default:
                    throw new NotSupportedException("Tipo de relacionamento " + tipo.ToString() + " não suportado!");
#else
                default:
                    return TipoRelacionamento.Desconhecido;
#endif
            }
        }
    }
}
*/