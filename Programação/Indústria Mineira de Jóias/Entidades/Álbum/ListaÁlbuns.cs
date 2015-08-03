using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Álbum
{
    [DbTransação]
    public class ListaÁlbuns : DbManipulação, IList<Álbum>
    {
        /// <summary>
        /// Lista de álbuns em que esta foto está inserida.
        /// </summary>
        /// <remarks>
        /// Quando o valor é nulo, indica que não foi carregado
        /// ainda do banco de dados. Quando nenhum álbum está
        /// vinculado, a lista é instanciada, porém vazia.
        /// </remarks>
        private List<Álbum> álbuns = null;

        private List<Álbum> Álbuns
        {
            get
            {
                if (álbuns == null)
                    Carregar();

                return álbuns;
            }
            set 
            { 
                álbuns = value; 
            }
        }

        /// <summary>
        /// Foto vinculada.
        /// </summary>
        private Foto foto;

        //private List<Álbum> adicionando = new List<Álbum>();
        //private List<Álbum> removendo = new List<Álbum>();

        /// <summary>
        /// Constrói a lista de álbuns.
        /// </summary>a
        public ListaÁlbuns(Foto foto)
        {
            this.foto = foto;

            DefinirCadastrado();
        }

        #region IList<Álbum> Members

        public int IndexOf(Álbum item)
        {
            return Álbuns.IndexOf(item);
        }

        public void Insert(int index, Álbum item)
        {
            DefinirDesatualizado();
            Álbuns.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            DefinirDesatualizado(); 
            Álbuns.RemoveAt(index);
        }

        public Álbum this[int index]
        {
            get
            {
                return Álbuns[index];
            }
            set
            {
                DefinirDesatualizado();
                Álbuns[index] = value;
            }
        }

        #endregion

        #region ICollection<Álbum> Members

        public void Add(Álbum item)
        {
            DefinirDesatualizado(); 
            Álbuns.Add(item);
         }

        public void Clear()
        {
            DefinirDesatualizado();
            Álbuns.Clear();
        }

        public bool Contains(Álbum item)
        {
            return Álbuns.Contains(item);
        }

        public void CopyTo(Álbum[] array, int arrayIndex)
        {
            Álbuns.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Álbuns.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Álbum item)
        {
            DefinirDesatualizado();
            return Álbuns.Remove(item);
        }

        #endregion

        #region IEnumerable<Álbum> Members

        public IEnumerator<Álbum> GetEnumerator()
        {
            return Álbuns.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Álbuns.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// Carrega vínculos do banco de dados. TODO: private
        /// </summary>
        public void Carregar()
        {
            if (!foto.Cadastrado)
                álbuns = new List<Álbum>();
            else
            {
                string cmd = "SELECT a.* FROM album a, vinculofotoalbum v WHERE a.codigo = v.album AND v.foto = " + DbTransformar(foto.Código);

                álbuns = Mapear<Álbum>(cmd);
                DefinirAtualizado();
            }
        }

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Atualiza vínculos da foto.
        /// </summary>
        protected override void Atualizar(System.Data.IDbCommand cmd)
        {
            if (!Atualizado)
            {
                Console.WriteLine("Atualizando foto de código..." + foto.Código.ToString());
                cmd.CommandText = "DELETE FROM vinculofotoalbum"
                    + " WHERE foto = " + DbTransformar(foto.Código);

                cmd.ExecuteNonQuery();

                if (Álbuns.Count > 0)
                {
                    cmd.CommandText = "INSERT INTO vinculofotoalbum"
                        + " (foto,album) VALUES "
                        + "(" + DbTransformar(foto.Código)
                        + "," + DbTransformar(Álbuns[0].Código)
                        + ")";

                    for (int i = 1; i < Álbuns.Count; i++)
                        cmd.CommandText += ",(" + DbTransformar(foto.Código)
                            + "," + DbTransformar(Álbuns[i].Código)
                            + ")";
                }

                cmd.ExecuteNonQuery();
            }
            else
            {
                Console.WriteLine("Não precisou atualizar foto " + foto.Código.ToString());
            }

            DefinirAtualizado();
        } 

        /// <summary>
        /// Descadastra vínculos da foto.
        /// </summary>
        protected override void Descadastrar(System.Data.IDbCommand cmd)
        {
            Console.WriteLine("Delete from.... .." + foto.Código.ToString());

            cmd.CommandText = "DELETE FROM vinculofotoalbum"
                + " WHERE foto = " + DbTransformar(foto.Código);

            cmd.ExecuteNonQuery();

            álbuns = new List<Álbum>();
            DefinirAtualizado();
        }

        internal void Gravar(System.Data.IDbCommand cmd)
        {
            Atualizar(cmd);
        }

        public override void Atualizar()
        {
            if (!foto.Cadastrado)
                return;

            base.Atualizar();
        }
    }
}
