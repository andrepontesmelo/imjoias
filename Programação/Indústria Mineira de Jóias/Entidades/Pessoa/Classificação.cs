using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Acesso.Comum.Cache;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Entidade de classificação de cliente.
    /// </summary>
    /// <remarks>
    /// Esta classe é marcada com DbTransação para verificar se o código
    /// extrapola o limite da variávei utilizada para flag.
    /// </remarks>
    [DbTabela("classpessoa"), Cacheável("ObterClassificação"), DbTransação]
    public class Classificação : ItemAlertável, IComparable
    {
        public enum CódigoSistema : int
        {
            FazerFicha = 1,
            CréditoCortado = 2,
            ConstaSPC = 3,
            Experiência = 4,
            NãoEnviarCorreio = 5,
            SomenteDinheiro = 6,
            Devedor = 7,
            NãoPagaFrete = 8,
            Aprovado = 9,
            DifícilPagar = 10,
            Eliminado = 11,
            SomenteÀVista = 12,
            ConsultarSePodeVender = 15,
            AguardarPagamento = 18,
            IncluimosSPC = 22,
        }

        /// <summary>
        /// Código utilizado para o bitwise.
        /// </summary>
        [DbChavePrimária(true), DbColuna("codigo")]
        private uint código = 0;

        /// <summary>
        /// Valor máximo que o código pode assumir, sem gerar overflow.
        /// </summary>
        private const uint códigoMax = 63;

        /// <summary>
        /// Denominação da classificação.
        /// </summary>
        [DbColuna("denominacao")]
        private string denominação;

        /// <summary>
        /// A data de criação pode ser utilizada
        /// para verificar se cadastros antigos
        /// não devem ser reclassificados.
        /// </summary>
        [DbColuna("criacao")]
        private DateTime criação = DateTime.Now;

        /// <summary>
        /// Define se deve questionar atualização
        /// de cadastros antigos frente a este campo.
        /// </summary>
        private bool questionarAntigos;

        /// <summary>
        /// Mensagem gravada ao marcar a classificação.
        /// </summary>
        private string msgMarcando;

        /// <summary>
        /// Mensagem gravada ao desmarcar a classificação.
        /// </summary>
        private string msgDesmarcando;

        /// <summary>
        /// Determina se a classificação foi criada pelo sistema.
        /// </summary>
        private bool sistema = false;

        [DbColuna("exigirPrivilegios")]
        private Privilégio.Permissão exigirPrivilégios;


        #region Propriedades

        /// <summary>
        /// Código da classificação.
        /// </summary>
        public uint Código { get { return código; } }

        /// <summary>
        /// Flag para uso como bitwise.
        /// </summary>
        /// <remarks>
        /// Caso o código seja superior maior ou igual a 64,
        /// a flag será truncada e o classificador não funcionará.
        /// 
        /// Simplesmente alterar o tipo não é suficiente. Deve-se
        /// verificar o tipo da coluna "privilegios" da tabela
        /// "funcionario" tanto no banco de dados quanto na classe
        /// Entidades.Pessoa.Funcionário.
        /// </remarks>
        public ulong Flag
        {
            get
            {
                return unchecked((ulong)1 << ((int)código - 1));
            }
        }

        /// <summary>
        /// Denominação da classificação.
        /// </summary>
        public string Denominação
        {
            get { return denominação; }
            set
            {
                if (sistema)
                    throw new NotSupportedException("Não é permitida a alteração da dominação de uma classificação do sistema.");

                denominação = value; DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Data de criação.
        /// </summary>
        public DateTime Criação
        {
            get { return criação; }
        }

        /// <summary>
        /// Define se deseja questionar cadastros
        /// antigos para reclassificação diante este
        /// campo.
        /// </summary>
        public bool QuestionarAntigos
        {
            get { return questionarAntigos; }
            set
            {
                questionarAntigos = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Mensagem gravada no histórico ao marcar a classificação.
        /// </summary>
        public string MsgMarcando
        {
            get { return msgMarcando; }
            set
            {
                msgMarcando = value.Length > 0 ? value : null;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Mensagem gravada no histórico ao desmarcar a classificação.
        /// </summary>
        public string MsgDesmarcando
        {
            get { return msgDesmarcando; }
            set
            {
                msgDesmarcando = value.Length > 0 ? value : null;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Determina se a classificação foi criada pelo sistema.
        /// </summary>
        public bool Sistema
        {
            get { return sistema; }
        }

        /// <summary>
        /// Determina os privilégios necessários para liberação
        /// do alerta.
        /// </summary>
        public Privilégio.Permissão ExigirPrivilégios
        {
            get { return exigirPrivilégios; }
            set { exigirPrivilégios = value; DefinirDesatualizado(); }
        }

        #endregion

        #region Recuperação

        /// <summary>
        /// Obtém todas as classificações possíveis.
        /// </summary>
        /// <returns>Vetor do tipo Classificação</returns>
        public static Classificação[] ObterClassificações()
        {
            return Mapear<Classificação>("SELECT * FROM classpessoa").ToArray();
        }

        /// <summary>
        /// Obtém classificações demarcadas em bitwise flag.
        /// </summary>
        /// <param name="classificações">Classificações em bitwise flag.</param>
        /// <returns>Vetor de classificação.</returns>
        public static Classificação[] ObterClassificações(ulong classificações)
        {
            List<Classificação> lista = new List<Classificação>();
            uint i = 1;

            while (classificações > 0)
            {
                if ((classificações & 1) > 0)
                {
                    Classificação entidade;
                    
                    entidade = (Classificação)CacheDb.Instância.ObterEntidade(typeof(Classificação), i);
                    lista.Add(entidade);
                }

                i++;
                classificações >>= 1;
            }

            return lista.ToArray();
        }

        /// <summary>
        /// Obtém classificações demarcadas em bitwise flag para
        /// um determinado alerta.
        /// </summary>
        /// <param name="classificações">Classificações em bitwise flag.</param>
        /// <param name="alerta">Tipo de alerta desejado.</param>
        /// <returns>Vetor de classificação.</returns>
        public static Classificação[] ObterClassificações(ulong classificações, TipoAlerta alerta)
        {
            List<Classificação> lista = new List<Classificação>();
            uint i = 1;

            while (classificações > 0)
            {
                if ((classificações & 1) > 0)
                {
                    Classificação entidade;
                    bool ok;

                    entidade = (Classificação)CacheDb.Instância.ObterEntidade(typeof(Classificação), i);

                    switch (alerta)
                    {
                        case TipoAlerta.Pedido:
                            ok = entidade.AlertarPedido;
                            break;

                        case TipoAlerta.Correio:
                            ok = entidade.AlertarCorreio;
                            break;

                        case TipoAlerta.Saída:
                            ok = entidade.AlertarSaída;
                            break;

                        case TipoAlerta.Venda:
                            ok = entidade.AlertarVenda;
                            break;

                        default:
                            throw new NotSupportedException();
                    }

                    if (ok)
                        lista.Add(entidade);
                }

                i++;
                classificações >>= 1;
            }

            return lista.ToArray();
        }

        /// <summary>
        /// Obtém classificação a partir de seu código.
        /// </summary>
        /// <param name="código">Código da classificação.</param>
        /// <returns>Entidade de classificação.</returns>
        public static Classificação ObterClassificação(uint código)
        {
            return MapearÚnicaLinha<Classificação>("SELECT * FROM classpessoa WHERE codigo = "
                + DbTransformar(código));
        }

        #endregion

        /// <summary>
        /// Verifica se esta classificação está atribuída
        /// em uma determinada flag.
        /// </summary>
        /// <param name="valor">Valor a ser verificado.</param>
        /// <returns>Se encontra-se atribuído.</returns>
        public bool AtribuídoA(ulong valor)
        {
            return (valor & Flag) > 0;
        }

        /// <summary>
        /// Verifica se esta classificação está atribuída
        /// a uma pessoa.
        /// </summary>
        /// <param name="pessoa">Pessoa que será verificada.</param>
        /// <returns>Se encontra-se atribuída.</returns>
        public bool AtribuídoA(Pessoa pessoa)
        {
            return (pessoa.Classificações & Flag) > 0;
        }

        /// <summary>
        /// Define atribuição para uma pessoa.
        /// </summary>
        /// <param name="pessoa">Pessoa a ser classificada.</param>
        /// <param name="atribuído">Se a pessoa será classificada ou não.</param>
        public void DefinirAtribuição(Pessoa pessoa, bool atribuído)
        {
            if (atribuído)
                pessoa.Classificações |= Flag;
            else
                pessoa.Classificações &= ~Flag;
        }

        public override string ToString()
        {
            return denominação;
        }

        public int CompareTo(object obj)
        {
            return denominação.CompareTo(obj.ToString());
        }

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            base.Cadastrar(cmd);

            /* Para que esta proteção funcione, é necessário atribuição do
             * atributo DbTransação na classe.
             */
            if (código > códigoMax)
                throw new OverflowException("O número máximo de classificadores (" + códigoMax.ToString() + ") já foi atingido. Não é possível adicionar novos classificadores.");
        }

        protected override void Atualizar(System.Data.IDbCommand cmd)
        {
            if (sistema)
                throw new NotSupportedException("Não é possível atualizar classificação criada pelo sistema.");

            base.Atualizar(cmd);
        }
    }
}
