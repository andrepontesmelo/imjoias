using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;

namespace IMJWeb.DAO.EF
{
    public class UsuarioDAO : BaseDAO<IUsuario, Usuario, long>, IUsuarioDAO
    {
        protected override void Anexar(object entidade)
        {
            Modelo.AttachTo("Usuarios", entidade);
        }

        public override IUsuario Incluir(IUsuario entidade)
        {
            var ef = entidade.ParaEF();

            ef.DataCriacao = DateTime.Now;

            if (string.IsNullOrEmpty(ef.Senha))
                ef.Senha = Guid.NewGuid().ToString();

            ef.IDTabela = entidade.Tabela != null ? (int?)entidade.Tabela.IDTabela : null;

            Modelo.AddToUsuarios(ef);
            Modelo.SaveChanges();

            return ef;
        }

        public override void Atualizar(IUsuario objeto)
        {
            var ef = objeto.ParaEF();

            if (string.IsNullOrEmpty(ef.Senha))
            {
                using (ModeloMercadorias contexto = new ModeloMercadorias())
                {
                    var original = contexto.Usuarios.First(u => u.IDUsuario == ef.IDUsuario);

                    ef.Senha = original.Senha;
                }
            }

            ef.IDTabela = objeto.Tabela != null ? (int?)objeto.Tabela.IDTabela : null;

            base.Atualizar(ef);
        }

        public override void Remover(IUsuario objeto)
        {
            base.Remover(objeto.ParaEF());
        }

        public override IUsuario Obter(long identificador)
        {
            return Modelo.Usuarios.FirstOrDefault(m => m.IDUsuario == identificador);
        }

        /// <summary>
        /// Obtém usuário a partir de seu login.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <returns>Usuário.</returns>
        public IUsuario ObterPorLogin(string login)
        {
            return Modelo.Usuarios.FirstOrDefault(u => u.Login == login);
        }

        /// <summary>
        /// Lista os usuários cadastrados.
        /// </summary>
        /// <returns>Usuários cadastrados.</returns>
        public IEnumerable<IUsuario> Listar()
        {
            return Modelo.Usuarios.ToList().Cast<IUsuario>();
        }

        public void RegistrarLogin(IUsuario usuario)
        {
            Usuario entidade = usuario.ParaEF();

            entidade.UltimoAcesso = DateTime.Now;
            entidade.ContadorAcesso++;

            Modelo.SaveChanges();
        }
    }
}
