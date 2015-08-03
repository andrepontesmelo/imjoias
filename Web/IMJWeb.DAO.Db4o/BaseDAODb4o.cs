using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using System.Diagnostics;

namespace IMJWeb.DAO.Db4o
{
    public abstract class BaseDAODb4o<IEntidade, Entidade, ID> : IDAO<IEntidade, ID> where Entidade : class, IEntidade, new()
    {
        protected IObjectContainer db;

        public BaseDAODb4o(String arquivo)
        {
            db = Db4oEmbedded.OpenFile(arquivo);
        }

        public virtual IEntidade Incluir(IEntidade entidade)
        {
            Entidade obj = entidade as Entidade;

            if (obj == null)
                obj = Converter(entidade);

            if (ExtrairChave(obj) == null)
            {
                GerarChave(obj);

                if (ExtrairChave(obj) == null)
                    throw new NullReferenceException("Chave da entidade é nula.");
            }

            lock (db)
            {
                try
                {
                    db.Store(obj);
                    db.Commit();

                    if (db.Query<IEntidade>(CompararChave(ExtrairChave(entidade))).Count > 1)
                        Debugger.Break();
                }
                catch
                {
                    db.Rollback();
                    throw;
                }
            }

            return obj;
        }

        /// <summary>
        /// Converte uma entidade no tipo suportado no armazenamento.
        /// </summary>
        /// <param name="origem">Entidade original.</param>
        /// <returns>Entidade final.</returns>
        protected virtual Entidade Converter(IEntidade origem)
        {
            Entidade entidade = new Entidade();
            Copiar(origem, entidade);
            return entidade;
        }

        /// <summary>
        /// Copia os dados de uma entidade em outra.
        /// </summary>
        /// <param name="origem">Entidade cujos dados serão copiados.</param>
        /// <param name="destino">Entidade para o qual os dados serão copiados.</param>
        protected virtual void Copiar(IEntidade origem, Entidade destino)
        {
            foreach (var p in typeof(Entidade).GetProperties().Where(p => p.CanWrite))
                if (p.GetIndexParameters().Length == 0)
                    p.SetValue(destino, typeof(IEntidade).GetProperty(p.Name).GetValue(origem, null), null);
        }

        /// <summary>
        /// Gera a chave para a entidade.
        /// </summary>
        /// <param name="entidade">Entidade cuja chave deve ser gerada.</param>
        protected abstract void GerarChave(IEntidade entidade);

        /// <summary>
        /// Extrai a chave de uma entidade.
        /// </summary>
        /// <param name="entidade">Entidade cuja chave será extraída.</param>
        /// <returns>Chave da entidade.</returns>
        protected abstract ID ExtrairChave(IEntidade entidade);

        public virtual void Atualizar(IEntidade entidade)
        {
            Entidade obj = entidade as Entidade;

            if (obj == null)
            {
                obj = (Entidade) Obter(ExtrairChave(entidade));
                Copiar(entidade, obj);
            }

            if (ExtrairChave(obj) == null)
                throw new NullReferenceException("Chave da entidade é nula.");

            lock (db)
            {
                try
                {
                    db.Store(obj);
                    db.Commit();

                    if (db.Query<IEntidade>(CompararChave(ExtrairChave(entidade))).Count > 1)
                        Debugger.Break();
                }
                catch
                {
                    db.Rollback();
                    throw;
                }
            }
        }

        public virtual void Remover(IEntidade entidade)
        {
            lock (db)
            {
                try
                {
                    db.Delete(entidade);
                    db.Commit();
                }
                catch
                {
                    db.Rollback();
                    throw;
                }
            }
        }

        public virtual IEntidade Obter(ID identificador)
        {
            var q = db.Query<IEntidade>(CompararChave(identificador));
            
            return q.SingleOrDefault();
        }

        protected abstract Predicate<IEntidade> CompararChave(ID identificador);

        public virtual void Liberar(IEntidade entidade)
        {
            // Nada aqui.
        }

        public virtual void AssociarSe<Entidade2, ID2>(IDAO<Entidade2, ID2> dao)
        {
            // Nada aqui.
        }

        public virtual void Dispose()
        {
            // Está sendo usado como singleton.
            //try
            //{
            //    db.Close();
            //}
            //finally
            //{
            //    db.Dispose();
            //}
        }
    }
}
