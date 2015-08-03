using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using System.ComponentModel;

namespace Negócio.Importação.EntidadesAntigas
{
    [DbTransação]
    public class CadCli : DbManipulaçãoAutomática
    {
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'
        private long cod;           // Código
        private char dig;           // Ignorado
        private string nosso;       // Data de registro, maior venda, crédito, setor, classificações e observações
        private string nome;        // Nome
        private uint regiao;        // Região ou setor
        private string end;         // Endereço
        private string bairro;      // Endereço
        private string cep;         // Endereço
        private string cid;         // Endereço
        private string uf;          // Endereço
        private string cgc;         // CNPJ (Pessoa Jurídica)
        private string cpf;         // CPF (Pessoa Física)
        private string insc;        // DI ou Inscrição Estadual
        private string endcob;      // Endereço
        private string cidcob;      // Endereço
        private string cepcob;      // Endereço
        private string ufcob;       // Endereço
        private string contato;     // Observação de telefone
        private string fone;        // Telefone
        private string fax;         // Telefone
        private uint conta;       // Ignorado
        private string classe;      // Fornecedor
        private string categor;     // Classificação
        private string obs;         // Observações  
        private long intervencaoFuncionario;      // Funcionário que fez a intervenção.
        private DateTime dataintervencao;         // Data que funcionario fez a intervenção.

        [DbChavePrimária(true)]
        private ulong codigo;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'
        
        [DbRelacionamento("codigo", "mapeamento")]
        private Entidades.Pessoa.Pessoa mapeamento;

        [Category("Identificação")]
        public string Código { get { return cod + "-" + dig; } }

        [Browsable(false)]
        public long CódigoNumérico { get { return cod; } }

        [Category("Identificação")]
        public string Nome { get { return nome; } }
        [Category("Identificação")]
        public string CNPJ { get { return cgc; } }
        [Category("Identificação")]
        public string CPF { get { return cpf; } }
        [Category("Identificação")]
        public string Insc { get { return insc; } }

        [DisplayName("Nosso número")]
        public string NossoNúmero { get { return nosso; } }
        public uint Região { get { return regiao; } }

        [Category("Endereço")]
        public string Endereço { get { return end; } }
        [Category("Endereço")]
        public string Bairro { get { return bairro; } }
        [Category("Endereço")]
        public string CEP { get { return cep; } }
        [Category("Endereço")]
        public string Cidade { get { return cid; } }
        [Category("Endereço")]
        public string UF { get { return uf; } }

        [Category("Endereço de cobrança"), DisplayName("Endereço")]
        public string EndereçoCobrança { get { return endcob; } }
        [Category("Endereço de cobrança"), DisplayName("Cidade")]
        public string CidadeCobrança { get { return cidcob; } }
        [Category("Endereço de cobrança"), DisplayName("CEP")]
        public string CEPCobrança { get { return cepcob; } }
        [Category("Endereço de cobrança"), DisplayName("UF")]
        public string UFCobrança { get { return ufcob; } }

        public string Contato { get { return contato; } }
        public string Telefone { get { return fone; } }
        public string Fax { get { return fax; } }
        public uint Conta { get { return conta; } }
        public string Classe { get { return classe; } }
        public string Categoria { get { return categor; } }
        public string Obs { get { return obs.Replace('\n', ' '); } }

        public DateTime DataIntervenção { get { return dataintervencao; } }

        public Entidades.Pessoa.Pessoa Mapeamento { get { return mapeamento; } }

        protected override void Atualizar(IDbCommand cmd)
        {
            if (mapeamento.Cadastrado)
                AtualizarEntidade(cmd, mapeamento);
            else
                CadastrarEntidade(cmd, mapeamento);

            cmd.CommandText = "UPDATE cadcli SET mapeamento = " +
                DbTransformar(mapeamento.Código);

            cmd.ExecuteNonQuery();
        }
        
        public void Mapear(Entidades.Pessoa.Pessoa pessoa)
        {
            mapeamento = pessoa;

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "UPDATE cadcli SET mapeamento = " + DbTransformar(mapeamento.Código) +
                        " WHERE codigo = " + DbTransformar(codigo);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public static CadCli ObterAleatório()
        {
            return (CadCli)MapearÚnicaLinha<CadCli>("SELECT * FROM cadcli WHERE mapeamento IS NULL ORDER BY RAND() LIMIT 1");
        }

        public static CadCli Obter(long código)
        {
            return MapearÚnicaLinha<CadCli>("SELECT * FROM cadcli WHERE mapeamento is null and cod = " + DbTransformar(código));
        }

        public bool VerificarMapeamento()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT mapeamento FROM cadcli WHERE codigo = " + DbTransformar(codigo);

                    object obj = cmd.ExecuteScalar();

                    return obj != null && obj != DBNull.Value;
                }
            }
        }

        public void AcabouIntervenção(long códigoFuncionário)
        {
            intervencaoFuncionario = códigoFuncionário; ;

            IDbConnection conexão = Conexão;

                lock (conexão)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "update cadcli set dataintervencao=NOW() AND intervencaofuncionario=" + códigoFuncionário.ToString() + " WHERE codigo = " + codigo;

                        cmd.ExecuteNonQuery();
                    }
                }
            }

    

        public int ObterNúmeroFuncionáriosIntervindo()
        {
            return 1;

        }
    }
}
