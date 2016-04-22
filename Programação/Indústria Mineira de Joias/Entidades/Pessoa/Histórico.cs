using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Configuração;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Item de histórico da pessoa.
    /// </summary>
    [DbTabela("historico")]
    public class Histórico : ItemAlertável
    {
        /// <summary>
        /// Pessoa relacionada ao histórico.
        /// </summary>
        [DbRelacionamento(true, "codigo", "pessoa")]
        private Pessoa pessoa;

        /// <summary>
        /// Momento em que foi registrado o histórico.
        /// </summary>
        [DbChavePrimária]
        private DateTime data = DadosGlobais.Instância.HoraDataAtual;

        /// <summary>
        /// Funcionário que digitou o item do histórico.
        /// </summary>
        [DbRelacionamento("codigo", "digitadoPor")]
        private Funcionário digitadoPor;

        /// <summary>
        /// Texto deste item do histórico.
        /// </summary>
        private string texto;

        #region Propriedaes

        /// <summary>
        /// Pessoa relacionada ao histórico.
        /// </summary>
        public Pessoa Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Momento em que este item foi registrado no histórico.
        /// </summary>
        public DateTime Data
        {
            get { return data; }
        }

        /// <summary>
        /// Funcionário que digitou o item do histórico.
        /// </summary>
        public Funcionário DigitadoPor
        {
            get { return digitadoPor; }
            set { digitadoPor = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Texto deste item do histórico.
        /// </summary>
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        #endregion

        /// <summary>
        /// Cadastra a entidade no banco de dados utilizando
        /// a data atual do banco de dados.
        /// </summary>
        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            data = Configuração.DadosGlobais.Instância.HoraDataAtual;

            base.Cadastrar(cmd);
        }

        /// <summary>
        /// Obtém vetor de itens de histórico de uma pessoa,
        /// ordenado pela data.
        /// </summary>
        public static Histórico[] ObterHistórico(Pessoa pessoa)
        {
            return Mapear<Histórico>(
                "SELECT * FROM historico WHERE pessoa = "
                + DbTransformar(pessoa.Código)
                + " ORDER BY data").ToArray();
        }

        /// <summary>
        /// Obtém vetor de itens de histórico de uma pessoa,
        /// ordenado pela data.
        /// </summary>
        public static Histórico[] ObterHistórico(Pessoa pessoa, TipoAlerta alerta)
        {
            string strAlerta;

            switch (alerta)
            {
                case TipoAlerta.Pedido:
                    strAlerta = "alertarConserto";
                    break;

                case TipoAlerta.Correio:
                    strAlerta = "alertarCorreio";
                    break;

                case TipoAlerta.Saída:
                    strAlerta = "alertarSaida";
                    break;

                case TipoAlerta.Venda:
                    strAlerta = "alertarVenda";
                    break;

                default:
                    throw new NotSupportedException();
            }

            return Mapear<Histórico>(
                "SELECT * FROM historico WHERE pessoa = "
                + DbTransformar(pessoa.Código)
                + " AND " + strAlerta + " = 1"
                + " ORDER BY data").ToArray();
        }
    }
}
