using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMJWeb.Dominio;
using System.Reflection;
using System.Diagnostics;

namespace IMJWeb.DAO.EF
{
    public static class Conversao
    {
        /// <summary>
        /// Converte uma interface na entidade do EF.
        /// </summary>
        /// <typeparam name="Interface">Interface a ser convertida.</typeparam>
        /// <typeparam name="Entidade">Entidade que implementa a interface a ser gerada.</typeparam>
        /// <param name="objeto">Objeto a ser convertido na interface.</param>
        /// <returns>Objeto convertido.</returns>
        internal static Entidade Converter<Interface, Entidade>(Interface objeto) where Entidade : Interface, new()
        {
            var propriedades = typeof(Interface).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField);
            var entidade = new Entidade();

            foreach (var p in propriedades)
            {
                if (p.CanWrite && p.CanRead)
                    p.SetValue(entidade, p.GetValue(objeto, null), null);
                else
                {
                    var pw = typeof(Entidade).GetProperty(p.Name, BindingFlags.Instance | BindingFlags.SetField | BindingFlags.Public | BindingFlags.NonPublic);

                    if (pw != null)
                        try
                        {
                            pw.SetValue(entidade, p.GetValue(objeto, null), null);
                        }
                        catch (ArgumentException e)
                        {
                            Debug.WriteLine(e.ToString());
                        }
                        catch (TargetInvocationException e)
                        {
                            Debug.WriteLine(e.ToString());
                        }
                }
            }

            return entidade;
        }

        /// <summary>
        /// Converte para entidade no modelo do EF.
        /// </summary>
        /// <param name="usuario">Usuário a ser convertido.</param>
        /// <returns>Entidade no modelo do EF.</returns>
        public static Usuario ParaEF(this IUsuario usuario)
        {
            Usuario entidade = usuario as Usuario;

            if (entidade == null)
                entidade = Converter<IUsuario, Usuario>(usuario);

            return entidade;
        }

        /// <summary>
        /// Converte para entidade no modelo do EF.
        /// </summary>
        /// <param name="catalogo">Catálogo a ser convertido.</param>
        /// <returns>Entidade no modelo do EF.</returns>
        public static Catalogo ParaEF(this ICatalogo catalogo)
        {
            var entidade = catalogo as Catalogo;

            if (entidade == null)
            {
                entidade = Converter<ICatalogo, Catalogo>(catalogo);

                //foreach (var m in catalogo.Mercadorias)
                //    entidade.Mercadorias.Add(m.ParaEF());

                //foreach (var r in catalogo.Regioes)
                //    entidade.Regioes.Add(new CatalogoRegiao()
                //    {
                //        IDCatalogo = catalogo.IDCatalogo,
                //        Regiao = r.IDRegiao
                //    });
            }

            return entidade;
        }

        /// <summary>
        /// Converte para entidade no modelo do EF.
        /// </summary>
        /// <param name="mercadoria">Mercadoria a ser convertida.</param>
        /// <returns>Entidade no modelo do EF.</returns>
        public static Mercadoria ParaEF(this IMercadoria mercadoria)
        {
            var entidade = mercadoria as Mercadoria;

            if (entidade == null)
                entidade = Converter<IMercadoria, Mercadoria>(mercadoria);

            return entidade;
        }
    }
}
