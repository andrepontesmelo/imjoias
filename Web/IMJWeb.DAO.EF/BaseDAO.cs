using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace IMJWeb.DAO.EF
{
    /// <summary>
    /// Base para DAOs.
    /// </summary>
    /// <typeparam name="Interface">Interface da entidade do domínio.</typeparam>
    /// <typeparam name="Entidade">Tipo concreto da entidade do domínio.</typeparam>
    /// <typeparam name="ID">Tipo do identificador único da entidade.</typeparam>
    public abstract class BaseDAO<Interface, Entidade, ID> : IDAO<Interface, ID>, IDisposable, IContextoReferenciador where Entidade : EntityObject, Interface, new()
    {
        private ModeloMercadorias modelo = new ModeloMercadorias();

        ModeloMercadorias IContextoReferenciador.Modelo
        {
            get { return modelo; }
        }

        /// <summary>
        /// Modelo de mercadorias.
        /// </summary>
        protected ModeloMercadorias Modelo
        {
            get { return modelo; }
        }

        /// <summary>
        /// Inclui a entidade.
        /// </summary>
        /// <typeparam name="entidade">Entidade a ser incluída.</typeparam>
        public abstract Interface Incluir(Interface entidade);

        /// <summary>
        /// Atualiza a entidade.
        /// </summary>
        /// <typeparam name="objeto">Entidade a ser atualizada.</typeparam>
        public virtual void Atualizar(Interface objeto)
        {
            var entidade = objeto as Entidade;

            ObjectStateEntry estado;

            // Anexa o objeto, caso esteja desanexado...
            if (entidade.EntityState == System.Data.EntityState.Detached)
                Anexar(entidade);

            // Anexa um clone do objeto, caso esteja anexado a outro modelo...
            else if (!modelo.ObjectStateManager.TryGetObjectStateEntry(entidade, out estado))
                Anexar(Conversao.Converter<Interface, Entidade>(entidade));

            modelo.ObjectStateManager.GetObjectStateEntry(objeto).SetModified();
            modelo.Refresh(RefreshMode.ClientWins, objeto);
            modelo.SaveChanges();
        }

        protected abstract void Anexar(object entidade);

        /// <summary>
        /// Remove a entidade.
        /// </summary>
        /// <typeparam name="objeto">Entidade a ser removida.</typeparam>
        public virtual void Remover(Interface objeto)
        {
            var entidade = objeto as Entidade;

            ObjectStateEntry estado;

            // Anexa o objeto, caso esteja desanexado...
            if (entidade.EntityState == System.Data.EntityState.Detached)
                Anexar(entidade);

            // Anexa um clone do objeto, caso esteja anexado a outro modelo...
            else if (!modelo.ObjectStateManager.TryGetObjectStateEntry(entidade, out estado))
                Anexar(Conversao.Converter<Interface, Entidade>(entidade));

            modelo.DeleteObject(entidade);
            modelo.SaveChanges();
        }

        /// <summary>
        /// Obtém a entidade por meio de seu identificador.
        /// </summary>
        /// <param name="identificador">Identificador da entidade.</param>
        /// <returns>Entidade, se existente, ou nulo.</returns>
        public abstract Interface Obter(ID identificador);

        /// <summary>
        /// Libera a entidade, removendo qualquer referência.
        /// </summary>
        /// <param name="objeto">Entidade a ser liberada.</param>
        public void Liberar(Interface objeto)
        {
            var entidade = objeto as Entidade;

            // Deanexa o objeto, caso esteja anexado...
            if (entidade.EntityState != System.Data.EntityState.Detached)
                modelo.Detach(entidade);
        }

        public void AssociarSe<Entidade2, ID2>(IDAO<Entidade2, ID2> dao)
        {
            this.modelo = ((IContextoReferenciador)dao).Modelo;
        }

        #region IDisposable Members

        public void Dispose()
        {
            modelo.Dispose();
        }

        #endregion
    }
}
