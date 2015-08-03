using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using IMJWeb.Dominio.Azure;

namespace IMJWeb.DAO.Azure
{
    public class MercadoriaDAO : IMercadoriaDAO
    {
        private MercadoriaDataServiceContext contexto;

        public MercadoriaDAO()
        {
            var storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            
            contexto = new MercadoriaDataServiceContext(storageAccount.TableEndpoint.ToString(), storageAccount.Credentials);
            contexto.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
            storageAccount.CreateCloudTableClient().CreateTableIfNotExist(MercadoriaDataServiceContext.MercadoriaTableName);
        }

        #region IMercadoriaDAO Members

        public void IncluirFoto(Dominio.IFoto foto)
        {
            throw new NotImplementedException();
        }

        public Dominio.IFoto CriarFoto(Dominio.IMercadoria mercadoria)
        {
            throw new NotImplementedException();
        }

        public void Remover(Dominio.IMercadoria mercadoria, Dominio.IIndice indice)
        {
            throw new NotImplementedException();
        }

        public long[] ObterFotos(Dominio.Referencia referencia)
        {
            throw new NotImplementedException();
        }

        public void RemoverFotos(Dominio.Referencia referencia)
        {
            throw new NotImplementedException();
        }

        public int ContarFotos(Dominio.Referencia referencia)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.IMercadoria> ListarMercadorias(Dominio.Referencia parteReferencia)
        {
            throw new NotImplementedException();
        }

        public void IncrementarHitMiniaturaMercadoria(Dominio.Referencia referencia, ulong incremento)
        {
            throw new NotImplementedException();
        }

        public void IncrementarVisualizacaoMercadoria(Dominio.Referencia referencia, ulong incremento)
        {
            throw new NotImplementedException();
        }

        public DateTime? ObterDataUltimaAtualizacao()
        {
            throw new NotImplementedException();
        }

        public IList<Dominio.IMercadoria> ObterMercadoriasAPartirDe(DateTime data)
        {
            throw new NotImplementedException();
        }

        public int ContarMercadoriasAPartirDe(DateTime data)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDAO<IMercadoria,Referencia> Members

        public Dominio.IMercadoria Incluir(Dominio.IMercadoria entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Dominio.IMercadoria entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Dominio.IMercadoria entidade)
        {
            throw new NotImplementedException();
        }

        public Dominio.IMercadoria Obter(Dominio.Referencia identificador)
        {
            //var q = contexto.Mercadoria.Where(m => m.PartitionKey == Mercadoria.ObterPartitionKey(identificador) && m.RowKey == Mercadoria.ObterRowKey(identificador));

            return contexto.Mercadoria.ToArray()[0];
            //return q.First();
        }

        public void Liberar(Dominio.IMercadoria entidade)
        {
            throw new NotImplementedException();
        }

        public void AssociarSe<Entidade2, ID2>(IDAO<Entidade2, ID2> dao)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
