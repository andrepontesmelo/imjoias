using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using IMJWeb.DAO.Db4o.Entidades;

namespace IMJWeb.DAO.Db4o.TransicaoEF
{
    public class MercadoriaDAO : IMercadoriaDAO
    {
        private static readonly Db4o.MercadoriaDAO daoDb4o = new Db4o.MercadoriaDAO();
        private readonly EF.MercadoriaDAO daoEF = new EF.MercadoriaDAO();

        public void IncluirFoto(Dominio.IFoto foto)
        {
            daoDb4o.IncluirFoto(foto);
            daoEF.IncluirFoto(foto);
        }

        public Dominio.IFoto CriarFoto(Dominio.IMercadoria mercadoria)
        {
            if (mercadoria is EF.Mercadoria)
                return daoEF.CriarFoto(mercadoria);
            else
                return daoDb4o.CriarFoto(mercadoria);
        }

        public void Remover(Dominio.IMercadoria mercadoria, Dominio.IIndice indice)
        {
            daoDb4o.Remover(mercadoria, indice);
            daoEF.Remover(mercadoria, indice);
        }

        public long[] ObterFotos(Dominio.Referencia referencia)
        {
            long[] fotos = daoDb4o.ObterFotos(referencia);

            if (fotos == null || fotos.Length == 0)
                return daoEF.ObterFotos(referencia);
            else
                return fotos;
        }

        public void RemoverFotos(Dominio.Referencia referencia)
        {
            daoDb4o.RemoverFotos(referencia);
            daoEF.RemoverFotos(referencia);
        }

        public int ContarFotos(Dominio.Referencia referencia)
        {
            return daoDb4o.ContarFotos(referencia);
        }

        public List<Dominio.IMercadoria> ListarMercadorias(Dominio.Referencia parteReferencia)
        {
            var lista = daoDb4o.ListarMercadorias(parteReferencia);

            if (lista == null || lista.Count == 0)
                return daoEF.ListarMercadorias(parteReferencia);
            else
                return lista;
        }

        public void IncrementarHitMiniaturaMercadoria(Dominio.Referencia referencia, ulong incremento)
        {
            daoDb4o.IncrementarHitMiniaturaMercadoria(referencia, incremento);
        }

        public void IncrementarVisualizacaoMercadoria(Dominio.Referencia referencia, ulong incremento)
        {
            daoDb4o.IncrementarVisualizacaoMercadoria(referencia, incremento);
        }

        public DateTime? ObterDataUltimaAtualizacao()
        {
            return daoDb4o.ObterDataUltimaAtualizacao();
        }

        public IList<Dominio.IMercadoria> ObterMercadoriasAPartirDe(DateTime data)
        {
            //return daoDb4o.ObterMercadoriasAPartirDe(data);
            return daoEF.ObterMercadoriasAPartirDe(data);
        }

        public int ContarMercadoriasAPartirDe(DateTime data)
        {
            //return daoDb4o.ContarMercadoriasAPartirDe(data);
            return daoEF.ContarMercadoriasAPartirDe(data);
        }

        public Dominio.IMercadoria Incluir(Dominio.IMercadoria entidade)
        {
            daoDb4o.Incluir(entidade);

            return daoEF.Incluir(entidade);
        }

        public void Atualizar(Dominio.IMercadoria entidade)
        {
            daoDb4o.Atualizar(entidade);
            daoEF.Atualizar(entidade);
        }

        public void Remover(Dominio.IMercadoria entidade)
        {
            daoDb4o.Remover(entidade);
            daoEF.Remover(entidade);
        }

        public Dominio.IMercadoria Obter(Dominio.Referencia identificador)
        {
            var mercadoria = daoDb4o.Obter(identificador);

            if (mercadoria == null)
            {
                mercadoria = daoEF.Obter(identificador);

                if (mercadoria != null)
                {
                    daoDb4o.Incluir(mercadoria);

                    foreach (var foto in mercadoria.Fotos)
                        daoDb4o.IncluirFoto(foto);
                }
            }

            return mercadoria;
        }

        public void Liberar(Dominio.IMercadoria entidade)
        {
            daoDb4o.Liberar(entidade);
            daoEF.Liberar(entidade);
        }

        public void AssociarSe<Entidade2, ID2>(IDAO<Entidade2, ID2> dao)
        {
            daoDb4o.AssociarSe(dao);
            daoEF.AssociarSe(dao);
        }

        public void Dispose()
        {
            daoDb4o.Dispose();
            daoEF.Dispose();
        }
    }
}
