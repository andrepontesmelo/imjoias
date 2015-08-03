using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Entidades.Acerto;
using Entidades.Balanço;

namespace Negócio
{
    public class ControleBalanço : Acesso.Comum.DbManipulaçãoSimples
    {
        /// <summary>
        /// Hash que contm o acerto em s. chave  gerada pela mercadoria oca.
        /// </summary>
        private Dictionary<string, SaquinhoBalanço> hash;

        public List<SaquinhoBalanço> ColeçãoSaquinhos
        {
            get
            {
                // Lista gerada toda vez intencionamente:
                // Na bandeja de acerto, a lista é modificada quando usuário solicita filtragem.
                // Ao utilizar esta propriedade em mais locais, modificar implementação da filtragem.
                //if (coleçãoSaquinhos == null)
                //{
                List<SaquinhoBalanço> coleçãoSaquinhos = new List<SaquinhoBalanço>(hash.Count);

                foreach (KeyValuePair<string, SaquinhoBalanço> tupla in hash)
                    coleçãoSaquinhos.Add(tupla.Value);

                coleçãoSaquinhos.Sort(new SaquinhoBalançoComparador());
                //}

                return coleçãoSaquinhos;
            }
        }

        public ControleBalanço()
        {
            IDbConnection conexão = Conexão;
            List<long> saídas, retornos, vendas;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT codigo FROM saida WHERE acerto in (select codigo from acertoConsignado where acertado = 0)";
                    saídas = ObterLista(cmd);

                    cmd.CommandText = "SELECT codigo FROM retorno WHERE acerto in (select codigo from acertoConsignado where acertado = 0)";
                    retornos = ObterLista(cmd);

                    cmd.CommandText = "SELECT codigo FROM venda WHERE acerto in (select codigo from acertoConsignado where acertado = 0)";
                    vendas = ObterLista(cmd);
                }
            }

            //Agrupar();
        }

        private List<long> retornos, saídas, vendas, sedex;

        public ControleBalanço(List<long> saídas, List<long> retornos, List<long> vendas, List<long> sedex)
        {
            this.hash = new Dictionary<string, SaquinhoBalanço>(StringComparer.Ordinal);

            this.saídas = saídas;
            this.retornos = retornos;
            this.vendas = vendas;
            this.sedex = sedex;

            Entidades.Relacionamento.Saída.Saída.ObterAcerto(saídas, hash);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(retornos, hash);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(vendas, hash);
            Entidades.Relacionamento.Venda.Sedex.ObterAcertoSedex(sedex, hash);
        }

        private static List<long> ObterLista(IDbCommand cmd)
        {
            List<long> lista = new List<long>();

            using (IDataReader leitor = cmd.ExecuteReader())
            {
                try
                {
                    while (leitor.Read())
                    {
                        lista.Add(leitor.GetInt64(0));
                    }
                }
                finally
                {
                    leitor.Close();
                }
            }

            return lista;
        }

        public System.Data.DataSet ObterImpressão()
        {   
            System.Data.DataSet ds = new System.Data.DataSet();
            DataTable tabelaItens = new DataTable("Itens");
            DataTable tabelaInformações = new DataTable("Informações");

            tabelaItens.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("referência"),
                new DataColumn("peso"),
                new DataColumn("quantidade"),
                new DataColumn("saída"),
                new DataColumn("retorno"),
                new DataColumn("venda"),
                new DataColumn("acerto"),
                new DataColumn("depeso", typeof(bool)),
                new DataColumn("faixagrupo"),
                new DataColumn("índice"),
                new DataColumn("descrição"),
                new DataColumn("devolução"),
                new DataColumn("sedex")
                // Adicionado devolução por motivo de compatibilidade
                // Com SaquinhoAcerto
            });

            tabelaInformações.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("saídas"),
                new DataColumn("retornos"),
                new DataColumn("vendas"),
                new DataColumn("sedex")
                });

            List<SaquinhoBalanço> lista = new List<SaquinhoBalanço>();

            List<SaquinhoBalanço> coleção = ColeçãoSaquinhos;

            foreach (SaquinhoBalanço saquinho in coleção)
            {
                // Adiciona saquinho à uma lista ordenada por referência.
                if (saquinho.QtdAcerto != 0)
                    lista.Add(saquinho);
            }

            // Ordena lista por referência e peso.
            lista.Sort(new SaquinhoBalançoComparador());

            foreach (SaquinhoBalanço s in lista)
            {
                DataRow linha = tabelaItens.NewRow();
                s.PreencherDataRow(linha);
                tabelaItens.Rows.Add(linha);
            }

            // Adiciona as tabelas ao dataset.
            ds.Tables.Add(tabelaItens);

            DataRow info = tabelaInformações.NewRow();

            bool primeiro = true;

            foreach (long codSaída in saídas)
            {
                if (!primeiro)
                    info["saídas"] += ", ";
                else
                    primeiro = false;

                info["saídas"] += codSaída.ToString();
            }

            primeiro = true;

            foreach (long codRetorno in retornos)
            {
                if (!primeiro)
                    info["retornos"] += ", ";
                else
                    primeiro = false;

                info["retornos"] += codRetorno.ToString();
            }

            primeiro = true;

            foreach (long codVenda in vendas)
            {
                if (!primeiro)
                    info["vendas"] += ", ";
                else
                    primeiro = false;

                info["vendas"] += codVenda.ToString();
            }

            foreach (long codSedex in sedex)
            {
                if (!primeiro)
                    info["sedex"] += ", ";
                else
                    primeiro = false;

                info["sedex"] += codSedex.ToString();
            }


            tabelaInformações.Rows.Add(info);

            ds.Tables.Add(tabelaInformações);

            return ds;
        }

        private void Agrupar()
        {
            List<SaquinhoBalanço> original = new List<SaquinhoBalanço>(ColeçãoSaquinhos);
            
            foreach (SaquinhoBalanço s in original)
                if (s.Mercadoria.Referência.StartsWith("2"))
                {
                    SaquinhoBalanço grupo;

                    if (hash.TryGetValue(s.Mercadoria.Referência, out grupo))
                    {
                        grupo.QtdRetorno += s.QtdRetorno;
                        grupo.QtdSaída += s.QtdSaída;
                        grupo.QtdVenda += s.QtdVenda;
                    }
                    else
                    {
                        grupo = new SaquinhoBalanço(new Entidades.Mercadoria.Mercadoria(
                            s.Mercadoria.ReferênciaNumérica, s.Mercadoria.Dígito,
                            s.Mercadoria.ForaDeLinha, true, 0, 0,
                            s.Mercadoria.Referência, s.Mercadoria.Faixa, s.Mercadoria.Grupo, s.Mercadoria.Teor),
                            s.Quantidade, 0, s.Índice);
                        grupo.QtdRetorno = s.QtdRetorno;
                        grupo.QtdSaída = s.QtdSaída;
                        grupo.QtdVenda = s.QtdVenda;
                        hash[s.Mercadoria.Referência] = grupo;
                    }

                    hash.Remove(s.IdentificaçãoAgrupável());
                }
                else if ((s.Mercadoria.ReferênciaNumérica[3] == '8' || s.Mercadoria.ReferênciaNumérica[3] == '9') && s.Mercadoria.DePeso)
                {
                    SaquinhoBalanço grupo;

                    if (hash.TryGetValue(s.Mercadoria.Referência.Substring(0, 3), out grupo))
                    {
                        grupo.QtdRetorno += s.QtdRetorno * s.Peso;
                        grupo.QtdSaída += s.QtdSaída * s.Peso;
                        grupo.QtdVenda += s.QtdVenda * s.Peso;
                    }
                    else
                    {
                        grupo = new SaquinhoBalanço(new Entidades.Mercadoria.Mercadoria(
                            s.Mercadoria.ReferênciaNumérica.Substring(0, 3), 0,
                            s.Mercadoria.ForaDeLinha, true, 0, 0,
                            s.Mercadoria.Referência, s.Mercadoria.Faixa, s.Mercadoria.Grupo, s.Mercadoria.Teor),
                            s.Quantidade, 0, s.Índice);
                        grupo.QtdRetorno = s.QtdRetorno * s.Peso;
                        grupo.QtdSaída = s.QtdSaída * s.Peso;
                        grupo.QtdVenda = s.QtdVenda * s.Peso;
                        hash[s.Mercadoria.Referência.Substring(0, 3)] = grupo;
                    }

                    hash.Remove(s.IdentificaçãoAgrupável());
                }
        }
    }
}
