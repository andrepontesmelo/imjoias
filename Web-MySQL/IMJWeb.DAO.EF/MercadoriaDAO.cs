using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using System.Data;
using System.Data.EntityClient;
using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace IMJWeb.DAO.EF
{
    public class MercadoriaDAO : BaseDAO<IMercadoria, Mercadoria, Referencia>, IMercadoriaDAO
    {
        protected override void Anexar(object entidade)
        {
            Modelo.AttachTo("Mercadorias", entidade);
        }

        public override IMercadoria Incluir(IMercadoria entidade)
        {
            var ef = entidade.ParaEF();

            ef.DataCriacao = DateTime.Now;
            ef.Catalogo = Modelo.Catalogos.First(c => c.IDCatalogo == ef.Catalogo.IDCatalogo);

            Modelo.AddToMercadorias(ef);
            Modelo.SaveChanges();

            return ef;
        }

        public override IMercadoria Obter(Referencia referencia)
        {
            if (referencia.ValorNumerico.Length < 12)
                return Modelo.Mercadorias.FirstOrDefault(m => m.Referencia.StartsWith(referencia.ValorNumerico));
            else
                return Modelo.Mercadorias.FirstOrDefault(m => m.Referencia == referencia.ValorNumerico);
        }

        /// <summary>
        /// Lista as mercadorias por parte da referência.
        /// </summary>
        /// <param name="parteReferencia">Parte da referência a ser procurada.</param>
        /// <returns>Lista de mercadorias.</returns>
        public List<IMercadoria> ListarMercadorias(Referencia parteReferencia)
        {
            return Modelo.Mercadorias.Include("Catalogo").Include("Grupos").Where(m => m.Referencia.StartsWith(parteReferencia.ValorNumerico)).ToList().Cast<IMercadoria>().ToList();
        }

        public void IncluirFoto(IFoto foto)
        {
            Modelo.AddToFotos((Foto)foto);
            Modelo.SaveChanges();
        }

        /// <summary>
        /// Cria uma foto vazia para uma mercadoria.
        /// </summary>
        /// <param name="mercadoria">Mercadoria cuja foto será criada.</param>
        /// <returns>Foto vazia criada.</returns>
        public IFoto CriarFoto(IMercadoria mercadoria)
        {
            return new Foto()
            {
                Mercadoria = mercadoria.ParaEF()
            };
        }

        /// <summary>
        /// Remove um índice de uma mercadoria.
        /// </summary>
        /// <param name="indice">Índice da mercadoria.</param>
        public void Remover(IMercadoria mercadoria, IIndice indice)
        {
            var ef = mercadoria.ParaEF();
            var efIndice = ef.Indices.First(i => i.IDTabela == indice.IDTabela);

            Modelo.DeleteObject(indice);
            Modelo.SaveChanges();
        }

        public long[] ObterFotos(Referencia referencia)
        {
            IMercadoria mercadoria = Obter(referencia);

            var q = from f in Modelo.Fotos
                    where f.IMJ_IDFoto.HasValue
                    && f.Mercadoria.Referencia == referencia.ValorNumerico
                    select f.IMJ_IDFoto.Value;

            return q.ToArray();
        }

        /// <summary>
        /// Exclui todas as fotos de uma mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        public void RemoverFotos(Referencia referencia)
        {
            foreach (var f in Modelo.Fotos.Where(f => f.Mercadoria.Referencia == referencia.ValorNumerico).ToArray())
                Modelo.DeleteObject(f);

            Modelo.SaveChanges();
        }

        /// <summary>
        /// Conta a quantidade de fotos.
        /// </summary>
        public int ContarFotos(Referencia referencia)
        {
            return Modelo.Fotos.Count(f => f.Mercadoria.Referencia == referencia.ValorNumerico);
        }

        /// <summary>
        /// Incrementa a contagem de hits na miniatura da mercadoria.
        /// </summary>
        /// <param name="referencia">Referência cuja contagem de hits será incrementada.</param>
        [Obsolete]
        public void IncrementarHitMiniaturaMercadoria(Referencia referencia, ulong incremento)
        {
            //using (IDbConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLDireto"].ConnectionString))
            //{
            //    using (IDbCommand comando = conexao.CreateCommand())
            //    {
            //        comando.CommandText = "UPDATE mercadoria SET HitsMiniaturas = HitsMiniaturas + @incremento WHERE Referencia = @referencia";

            //        var pIncremento = comando.CreateParameter();
            //        pIncremento.DbType = DbType.UInt64;
            //        pIncremento.Value = incremento;
            //        pIncremento.ParameterName = "incremento";
            //        comando.Parameters.Add(pIncremento);

            //        var pReferencia = comando.CreateParameter();
            //        pReferencia.DbType = DbType.String;
            //        pReferencia.Value = referencia.ValorNumerico;
            //        pReferencia.ParameterName = "referencia";
            //        comando.Parameters.Add(pReferencia);

            //        if (conexao.State != ConnectionState.Open)
            //        {
            //            conexao.Open();

            //            try
            //            {
            //                comando.ExecuteNonQuery();
            //            }
            //            finally
            //            {
            //                conexao.Close();
            //            }
            //        }
            //        else
            //            comando.ExecuteNonQuery();
            //    }
            //}
        }

        /// <summary>
        /// Incrementa a contagem de hits na mercadoria.
        /// </summary>
        /// <param name="referencia">Referência cuja contagem de hits na miniatura será incrementada.</param>
        [Obsolete]
        public void IncrementarVisualizacaoMercadoria(Referencia referencia, ulong incremento)
        {
            //using (IDbConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLDireto"].ConnectionString))
            //{
            //    using (IDbCommand comando = conexao.CreateCommand())
            //    {
            //        comando.CommandText = "UPDATE mercadoria SET HitsVisualizacao = HitsVisualizacao + @incremento WHERE Referencia = @referencia";

            //        var pIncremento = comando.CreateParameter();
            //        pIncremento.DbType = DbType.UInt64;
            //        pIncremento.Value = incremento;
            //        pIncremento.ParameterName = "incremento";
            //        comando.Parameters.Add(pIncremento);

            //        var pReferencia = comando.CreateParameter();
            //        pReferencia.DbType = DbType.String;
            //        pReferencia.Value = referencia.ValorNumerico;
            //        pReferencia.ParameterName = "referencia";
            //        comando.Parameters.Add(pReferencia);

            //        if (conexao.State != ConnectionState.Open)
            //        {
            //            conexao.Open();

            //            try
            //            {
            //                comando.ExecuteNonQuery();
            //            }
            //            finally
            //            {
            //                conexao.Close();
            //            }
            //        }
            //        else
            //            comando.ExecuteNonQuery();
            //    }
            //}
        }

        /// <summary>
        /// Obtém data da última atualização.
        /// </summary>
        /// <returns>Data da última atualização.</returns>
        public DateTime? ObterDataUltimaAtualizacao()
        {
            try
            {
                return Modelo.Mercadorias.Max(m => m.DataCriacao);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtém mercadorias a partir de uma data.
        /// </summary>
        /// <param name="data">Data de referência cujas mercadorias cadastradas após esta deverão ser retornadas.</param>
        /// <returns>Lista de mercadorias cadastradas após a data especificada.</returns>
        public IList<IMercadoria> ObterMercadoriasAPartirDe(DateTime data)
        {
            var mercadorias = from m in Modelo.Mercadorias.Include("Catalogo").Include("Grupos")
                              where m.DataCriacao >= data.Date
                              select m;

            return mercadorias.ToList().Cast<IMercadoria>().ToList();
        }

        /// <summary>
        /// Conta a quantidade de mercadorias a partir de uma data.
        /// </summary>
        /// <param name="data">Data de referência.</param>
        /// <returns>Quantidade de mercadorias.</returns>
        public int ContarMercadoriasAPartirDe(DateTime data)
        {
            return Modelo.Mercadorias.Where(m => m.DataCriacao >= data.Date).Count();
        }
    }
}
