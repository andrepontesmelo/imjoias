using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;

namespace Entidades.Pessoa
{
    public class Telefone : DbManipulaçãoAutomática
    {
        [DbRelacionamento(true, "codigo", "pessoa")]
        private Pessoa pessoa;

        [DbChavePrimária(false)]
        private uint id = 0;

        [DbColuna("descricao")]
        private string descrição;

        private string telefone;

        [DbColuna("observacoes")]
        private string observações;

        #region Propriedades

        /// <summary>
        /// Pessoa que possui o telefone.
        /// </summary>
        public Pessoa Pessoa { get { return pessoa; } set { pessoa = value; DefinirCadastrado(false); } }

        protected uint TelefoneID { get { return id; } }

        /// <summary>
        /// Descrição do telefone.
        /// </summary>
        public string Descrição { get { return descrição; } set { descrição = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Número do telefone.
        /// </summary>
        public string Número { get { return telefone; } set { telefone = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Observações sobre o telefone.
        /// </summary>
        public string Observações { get { return observações; } set { observações = value; DefinirDesatualizado(); } }

        #endregion

        public static Telefone[] ObterTelefones(Pessoa pessoa)
        {
            return Mapear<Telefone>(
                "SELECT * FROM telefone WHERE pessoa = " + DbTransformar(pessoa.Código)).ToArray();
        }



        public static Dictionary<Pessoa, Telefone[]> ObterTelefonesConsultaÚnica(List<Pessoa> pessoas)
        {
            Dictionary<Pessoa, Telefone[]> retorno = new Dictionary<Pessoa, Telefone[]>();

            if (pessoas.Count == 0)
                return retorno;

            string consulta = " SELECT pessoa, id, telefone, descricao, observacoes from telefone where pessoa in " 
            + Pessoa.ObterCódigoPessoas(pessoas) + " order by pessoa";

            Dictionary<ulong, KeyValuePair<Pessoa, List<Telefone>>> hashPessoaTelefones = 
                new Dictionary<ulong, KeyValuePair<Pessoa, List<Telefone>>>();
            
            foreach (Pessoa p in pessoas)
                hashPessoaTelefones.Add(p.Código, new KeyValuePair<Pessoa, List<Telefone>>(p, new List<Telefone>()));

            IDbConnection conexão = Conexão;
            IDataReader leitor = null;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = consulta;
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                uint códigoPessoaAgora = (uint)leitor.GetInt64(0);

                                Telefone t = new Telefone();
                                t.id = (uint)leitor.GetInt64(1);
                                t.telefone = leitor.GetString(2);
                                t.descrição = leitor.GetString(3);
                                t.observações = leitor.IsDBNull(4) ? null : leitor.GetString(4);
                                KeyValuePair<Pessoa, List<Telefone>> par = hashPessoaTelefones[códigoPessoaAgora];
                                t.Pessoa = par.Key;
                                par.Value.Add(t);
                            }
                        }
                    }
                } catch (Exception)
                {
                    Environment.Exit(-2);
                }
                finally
                {
                    if (leitor != null && !leitor.IsClosed)
                        leitor.Close();

                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }

            }

            foreach (KeyValuePair<ulong, KeyValuePair<Pessoa, List<Telefone>>> par in hashPessoaTelefones)
                retorno.Add(par.Value.Key, par.Value.Value.ToArray());

            return retorno;
        }

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            cmd.CommandText = "SELECT MAX(id) FROM telefone WHERE pessoa = " + DbTransformar(pessoa.Código);
            object mId = cmd.ExecuteScalar();

            if (mId != null && mId != DBNull.Value)
                id = Convert.ToUInt32(mId) + 1;

            base.Cadastrar(cmd);
        }

        private static Dictionary<ulong, DbComposição<Telefone>> hashTelefones = new Dictionary<ulong, DbComposição<Telefone>>();

        public static void PreencherTelefonesUsandoCache(List<Entidades.Pessoa.Pessoa> lstPessoas)
        {
            List<Pessoa> telefonesNãoCarregados = null;

            foreach (Pessoa p in lstPessoas)
            {
                DbComposição<Telefone> telefones;

                if (!hashTelefones.TryGetValue(p.Código, out telefones))
                {
                    if (telefonesNãoCarregados == null)
                        telefonesNãoCarregados = new List<Pessoa>();

                    telefonesNãoCarregados.Add(p);
                }

                p.Telefones = telefones;
            }

            if (telefonesNãoCarregados != null)
            {
                Dictionary<ulong, DbComposição<Telefone>> telefonesCarregadosAgora = CarregarTelefonesConsultaÚnica(telefonesNãoCarregados);

                foreach (KeyValuePair<ulong, DbComposição<Telefone>> par in telefonesCarregadosAgora)
                    hashTelefones.Add(par.Key, par.Value);

            }
        }

        private static Dictionary<ulong, DbComposição<Telefone>> CarregarTelefonesConsultaÚnica(List<Pessoa> telefonesNãoCarregados)
        {
            // Carrega do DB

            Dictionary<ulong, DbComposição<Telefone>> retorno = new Dictionary<ulong, DbComposição<Telefone>>();

            Dictionary<Pessoa, Telefone[]> telefonesBd = ObterTelefonesConsultaÚnica(telefonesNãoCarregados);

            foreach (Pessoa p in telefonesNãoCarregados)
            {
                p.AdicionarJáCadastrado(telefonesBd[p]);
                retorno.Add(p.Código, p.Telefones);
            }

            return retorno;
        }
    }
}
