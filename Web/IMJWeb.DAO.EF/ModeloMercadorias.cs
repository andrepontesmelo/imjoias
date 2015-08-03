using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.DAO.EF
{
    partial class ModeloMercadorias
    {
        partial void OnContextCreated()
        {
            // .net 4
            //this.ContextOptions.LazyLoadingEnabled = true;

            this.CommandTimeout = 20;
        }   
    }
}
