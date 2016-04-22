using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Acesso.Comum;


namespace Entidades.Mercadoria
{
    /// <summary>
    /// Constar na documentação:
    /// Ao inserir nova mercadoria,
    /// é inserido nas duas tabelas, (mercadoria e mercadoriaalteração)
    /// porém na mercadoria com foradelinha=1.
    /// </summary>
    public class MercadoriaManutenção : Acesso.Comum.DbManipulação
    {
        private string referencia;
        private int digito = -1;
        private string nome;
        private int teor;
        private double peso;
        private string faixa;
        private int? grupo;
        private bool depeso;
        private bool foradelinha;

        public string Descrição { get { return nome; } set { nome = value; } }
        public double Peso { get { return peso; } set { peso = value; } }
        public string Faixa { get { return faixa; } set { faixa = value; } }
        public bool ForaDeLinha { get { return foradelinha; } set { foradelinha = value; } }
        public int? Grupo { get { return grupo; } set { grupo = value; } }
        public int Teor { get { return teor; } set { teor = value; } }
        public int Dígito { get { return digito; } set { digito = value; } }
        public string Referência { get { return referencia; } set { referencia = value; } }
        public string ReferênciaNumérica { get { return referencia; } set { referencia = value; } }
        public bool DePeso { get { return depeso; } set { depeso = value; } }


#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'
        private bool alterar;
#pragma warning restore 0649

        public bool Alterar
        {
            get { return alterar; }
        }

        /// <summary>
        /// Consulta única, retorna lista de MercadoriaManutenção
        /// Para exibição em ListaMercadorias.
        /// 
        /// São mescladas informações das tabelas mercadoria e mercadoriaalteração, para exibição.
        /// </summary>
        /// <returns></returns>
        public static List<MercadoriaManutenção> Obter(bool apenasDentroDeLinha)
        {
            string consulta;

            consulta = "select referencia, alterar, nome, teor, peso, faixa, grupo, digito, foradelinha, depeso "
              + " from (select * from (SELECT mercadoria.referencia as ref, mercadoriaalteracao.referencia is not null as "
              + " alterar FROM mercadoria left join mercadoriaalteracao on mercadoria.referencia=mercadoriaalteracao.referencia) "
              + " b join mercadoria on ref=mercadoria.referencia where alterar=0 union select * from (SELECT mercadoria.referencia "
              + " as ref, mercadoriaalteracao.referencia is not null as alterar FROM mercadoria left join mercadoriaalteracao on "
              + " mercadoria.referencia=mercadoriaalteracao.referencia) b join mercadoriaalteracao on ref=mercadoriaalteracao.referencia "
              + " where alterar=1)c ";

            if (apenasDentroDeLinha)
                consulta = "SELECT * from (" + consulta + ") consulta WHERE foradelinha=0 limit 5";

            return Mapear<MercadoriaManutenção>(consulta);
        }

        /// <summary>
        /// Executa as atualizações pendentes, atualizando mercadorias da tabela vigente com novo índice.
        /// </summary>
        public static void AtualizarTabela()
        {
            Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.EditarMercadorias);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastra nas duas tabelas, na mercadoria e na mercadoriaalteracao uma nova referencia a adentrar no sistema.
        /// </summary>
        public static MercadoriaManutenção Cadastrar(string referênciaFormatada)
        {
            IDbCommand cmd;
            IDbConnection conexão;

            MercadoriaManutenção entidade;
            string consulta;
            string referência;
            int dígito;

            Mercadoria.DesmascararReferência(referênciaFormatada, out referência, out dígito);

            consulta = "insert into mercadoria (referencia, digito, foradelinha) values ("
            + DbTransformar(referência) + "," + DbTransformar(dígito) + ", 1); ";

            consulta += "insert into mercadoriaalteracao (referencia, digito, foradelinha) values ("
            + DbTransformar(referência) + "," + DbTransformar(dígito) + ", 0)";

            conexão = Conexão;

            lock (conexão)
            {
                cmd = conexão.CreateCommand();
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
            }

            entidade = new MercadoriaManutenção();
            entidade.Referência = referênciaFormatada;
            entidade.DefinirCadastrado();

            return entidade;
        }

        public void GravarAlterações()
        {
            IDbCommand cmd;
            IDbConnection conexão;

            string consulta;

            // Primeiro marca mercadoria atual para alteração
            MarcarAlteração();

            consulta = "UPDATE mercadoriaalteracao set "
            + " nome = " + DbTransformar(Descrição)
            + ", teor = " + DbTransformar(Teor)
            + ", peso = " + DbTransformar(peso)
            + ", faixa = " + DbTransformar(Faixa)
            + ", grupo = " + DbTransformar(Grupo)
            + ", digito = " + DbTransformar(Dígito)
            + ", foradelinha = " + DbTransformar(ForaDeLinha)
            + ", depeso = " + DbTransformar(DePeso)
            + " WHERE referencia=" + DbTransformar(ReferênciaNumérica);

            conexão = Conexão;

            lock (conexão)
            {
                cmd = conexão.CreateCommand();

                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Marca lista de mercadorias para exclusão na próxima implantação
        /// Isto é, marca elas para serem marcadas com foradelinha=1
        /// </summary>
        /// <param name="mercadorias"></param>
        public static void Excluir(List<MercadoriaManutenção> mercadorias)
        {
            IDbConnection conexão;
            IDbCommand cmd;

            if (mercadorias.Count == 0)
                return;

            // Marca mercadorias para alteração
            MarcarAlteração(mercadorias);

            // Marca alteração para foradelinha=1
            bool primeiro = true;
            string consulta = "update mercadoriaalteracao set foradelinha=1 where referencia=";
            foreach (MercadoriaManutenção m in mercadorias)
            {
                if (!primeiro)
                    consulta += " OR referencia=";
                else
                    primeiro = false;

                consulta += DbTransformar(m.ReferênciaNumérica);
            }

            conexão = Conexão;
            lock (conexão)
            {
                cmd = conexão.CreateCommand();
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Marca mercadoria atual para alteração.
        /// Copia dados de tabela mercadoria para mercadoriaalteração,
        /// caso ainda não já esteja feito
        /// </summary>
        public void MarcarAlteração()
        {
            // Aproveita método estático
            List<MercadoriaManutenção> itemÚnico = new List<MercadoriaManutenção>();
            itemÚnico.Add(this);
            MarcarAlteração(itemÚnico);
        }

        /// <summary>
        /// Marca algumas mercadorias para manutenção.
        /// Copia da tabela mercadoria para tabela mercadoriaalteração, 
        /// apenas os itens que não estiverem já no mercadorialateração.
        /// </summary>
        /// <param name="mercadorias"></param>
        public static void MarcarAlteração(List<MercadoriaManutenção> mercs)
        {
            IDbCommand cmd;
            IDbConnection conexão;
            IDataReader leitor = null;
            List<MercadoriaManutenção> mercadorias = new List<MercadoriaManutenção>(mercs);

            Dictionary<string, bool> hashReferênciaJáAlterada = new Dictionary<string, bool>(StringComparer.Ordinal);
            List<MercadoriaManutenção> mercadoriasJáAlteradas = new List<MercadoriaManutenção>();

            conexão = Conexão;

            lock (conexão)
            {
                cmd = conexão.CreateCommand();

                cmd.CommandText = "select referencia from mercadoriaalteracao";

                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                            hashReferênciaJáAlterada.Add(leitor.GetString(0), true);
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();
                }
            }

            // Retira os itens que já estão na tabela de alteração
            foreach (MercadoriaManutenção m in mercadorias)
                if (hashReferênciaJáAlterada.ContainsKey(m.ReferênciaNumérica))
                    mercadoriasJáAlteradas.Add(m);

            foreach (MercadoriaManutenção m in mercadoriasJáAlteradas)
                mercadorias.Remove(m);

            if (mercadorias.Count == 0)
                return;

            // Pronto, agora mercadorias só são aquelas para cadastro.
            // insert into mercadoriaalteracao (referencia) values ('123')
            string consulta = "insert into mercadoriaalteracao (referencia) values (";
            bool primeiro = true;

            foreach (MercadoriaManutenção m in mercadorias)
            {
                if (!primeiro)
                    consulta += ",";
                else
                    primeiro = false;

                consulta += DbTransformar(m.ReferênciaNumérica);
            }

            consulta += "); ";

            // Agora copia todos os dados do mercadoria para o mercadoriaalteração.
            consulta += "update mercadoriaalteracao a, mercadoria m set a.nome=m.nome, a.teor=m.teor,a.peso=m.peso, a.faixa=m.faixa, a.grupo=m.grupo, a.digito=m.digito,a.foradelinha=m.foradelinha,a.depeso=m.depeso where "
            + " a.referencia =  ";

            primeiro = true;
            foreach (MercadoriaManutenção m in mercadorias)
            {
                if (!primeiro)
                    consulta += " OR a.referencia = ";
                else
                    primeiro = false;

                consulta += DbTransformar(m.ReferênciaNumérica);
            }

            conexão = Conexão;

            lock (conexão)
            {
                cmd = conexão.CreateCommand();
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
            }
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Atualizar(IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

       ////  <summary>
       ////  Apartir desse objeto de alteração, constói uma mercadoria!
       ////  </summary>
       ////  <returns></returns>
       //// public Mercadoria CriarMercadoria()
       //// {
       ////     MercadoriaCampos campos = new MercadoriaCampos(referencia,
       ////         digito, foradelinha, depeso, peso, Descrição, faixa, grupo, teor);

       ////     Mercadoria m = new Mercadoria(campos, Tabela.TabelaPadrão);
       ////     return m;
       ////}

        public static MercadoriaManutenção Criar(Mercadoria m)
        {
            MercadoriaManutenção manutenção = new MercadoriaManutenção();
            manutenção.Referência = m.Referência;
            manutenção.Faixa = m.Faixa;
            manutenção.Teor = m.Teor;
            manutenção.Peso = m.Peso;
            manutenção.DePeso = m.DePeso;
            manutenção.Descrição = m.Descrição;
            manutenção.digito = m.Dígito;
            manutenção.Grupo = m.Grupo;
            manutenção.ForaDeLinha = m.ForaDeLinha;

            return manutenção;
        }
    }
}