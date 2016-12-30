using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica.ArquivoPdf
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
            vendasComPdfs = MapearCódigos("select n.venda from nfe n join saidafiscal s on n.nfe=s.numero " +
                " join saidafiscalpdf p on s.id=p.id WHERE s.setor != " + DbTransformar((int)SetorSistema.Varejo));
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
