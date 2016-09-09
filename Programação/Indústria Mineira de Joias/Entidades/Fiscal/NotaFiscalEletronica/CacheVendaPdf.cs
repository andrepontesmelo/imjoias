using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    public class CacheVendaPdf : DbManipulaçãoSimples
    {
        List<long> vendasComPdfs;
        private DateTime últimaObtenção;
        private TimeSpan TempoDecorrido => DateTime.Now - últimaObtenção;

        private TimeSpan ExpiraçãoCacheVendaPdf = TimeSpan.FromMilliseconds(DadosGlobais.Instância.CacheExpiraçãoVendaPdfMs);
        private bool Expirado => TempoDecorrido > ExpiraçãoCacheVendaPdf;

        private static CacheVendaPdf instância;

        public static CacheVendaPdf Instância
        {
            get
            {
                if (instância == null)
                    instância = new CacheVendaPdf();

                return instância;
            }
        }

        public void Recarregar()
        {
            vendasComPdfs = MapearCódigos("select n.venda from nfe n join nfepdf p on n.nfe=p.nfe");
            últimaObtenção = DateTime.Now;
        }

        private CacheVendaPdf()
        {
            Recarregar();
        }
       
        public List<long> ObterVendasPdfs()
        {
            if (Expirado)
                Recarregar();

            return vendasComPdfs;
        }
        
    }
}
