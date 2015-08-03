//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace IMJWeb.DAO
//{
//    public class MercadoriaDAOInsistente : IMercadoriaDAO
//    {
//        public IMercadoriaDAO DAO { get; set; }

//        public MercadoriaDAOInsistente(IMercadoriaDAO dao)
//        {
//            this.DAO = dao;
//        }

//        #region IMercadoriaDAO Members

//        public void IncluirFoto(Dominio.IFoto foto)
//        {
//            DAO.IncluirFoto(foto);
//        }

//        public Dominio.IFoto CriarFoto(Dominio.IMercadoria mercadoria)
//        {
//            return DAO.CriarFoto(mercadoria);
//        }

//        public void Remover(Dominio.IMercadoria mercadoria, Dominio.IIndice indice)
//        {
//            DAO.Remover(mercadoria, indice);
//        }

//        public long[] ObterFotos(Dominio.Referencia referencia)
//        {
//            return DAO.ObterFotos(referencia);
//        }

//        public void RemoverFotos(Dominio.Referencia referencia)
//        {
//            DAO.RemoverFotos(referencia);
//        }

//        public int ContarFotos(Dominio.Referencia referencia)
//        {
//            return DAO.ContarFotos(referencia);
//        }

//        public List<Dominio.IMercadoria> ListarMercadorias(Dominio.Referencia parteReferencia)
//        {
//            return DAO.ListarMercadorias(parteReferencia);
//        }

//        public void IncrementarHitMiniaturaMercadoria(Dominio.Referencia referencia)
//        {
//            DAO.IncrementarHitMiniaturaMercadoria(referencia);
//        }

//        public void IncrementarVisualizacaoMercadoria(Dominio.Referencia referencia)
//        {
//            DAO.IncrementarVisualizacaoMercadoria(referencia);
//        }

//        #endregion

//        #region IDAO<IMercadoria,Referencia> Members

//        public Dominio.IMercadoria Incluir(Dominio.IMercadoria entidade)
//        {
//            return DAO.Incluir(entidade);
//        }

//        public void Atualizar(Dominio.IMercadoria entidade)
//        {
//            DAO.Atualizar(entidade);
//        }

//        public void Remover(Dominio.IMercadoria entidade)
//        {
//            DAO.Remover(entidade);
//        }

//        public Dominio.IMercadoria Obter(Dominio.Referencia identificador)
//        {
//            return DAO.Obter(identificador);
//        }

//        public void Liberar(Dominio.IMercadoria entidade)
//        {
//            DAO.Liberar(entidade);
//        }

//        public void AssociarSe<Entidade2, ID2>(IDAO<Entidade2, ID2> dao)
//        {
//            dao.AssociarSe(dao);
//        }

//        #endregion

//        #region IDisposable Members

//        public void Dispose()
//        {
//            DAO.Dispose();
//        }

//        #endregion
//    }
//}
