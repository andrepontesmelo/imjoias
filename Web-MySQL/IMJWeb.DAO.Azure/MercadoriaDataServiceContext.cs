using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using IMJWeb.Dominio.Azure;

namespace IMJWeb.DAO.Azure
{
    public class MercadoriaDataServiceContext : TableServiceContext
    {
        public MercadoriaDataServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public const string MercadoriaTableName = "Mercadoria";

        public IQueryable<Mercadoria> Mercadoria
        {
            get
            {
                return this.CreateQuery<Mercadoria>(MercadoriaTableName);
            }
        }
    }
}
