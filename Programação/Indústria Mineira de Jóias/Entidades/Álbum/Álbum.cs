using System;
using Acesso.Comum;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Drawing;
using Entidades.Configuração;

namespace Entidades.Álbum
{
	/// <summary>
	/// É a entidade para a tabela 'album'.
	/// Um album possui diversas fotos.
	/// </summary>
	/// <remarks>
	/// O vinculo entre fotos e album é definido na tabela vinculofotosalbum.
	/// Deve existir, na entidade foto, a lista de álbuns em que ela está inserida.
	/// </remarks>
    [DbTabela("album"), DbTransação]
	public class Álbum : DbManipulaçãoAutomática
	{
		// Atributos
        [DbChavePrimária(true), DbColuna("codigo")]
        private ulong       código = 0;

        private string      nome;

        [DbColuna("criacao")]
        private DateTime    criação;

        [DbColuna("alteracao")]
        private DateTime?   alteração;

        [DbColuna("descricao")]
        private string      descrição;

        private DbComposição<Foto> fotos = null;

        #region Propriedades

        public string Nome
        {
            get { return nome; }
            set 
            { 
                nome = value;
                DefinirDesatualizado();
            }
        }
        
        public ulong Código
        {
            get { return código; }
        }
        
        public DateTime Criação
        {
            get { return criação; }
        }
        
        public DateTime? Alteração
        {
            get { return alteração; }
        }
        
        public string Descrição
        {
            get { return descrição; }
            set 
            { 
                descrição = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Lista de fotos.
        /// </summary>
        public DbComposição<Foto> Fotos
        {
            get
            {
                if (fotos == null)
                    RecuperarFotos();

                return fotos;
            }
        }

        #endregion

        #region Recuperação de dados

        /// <summary>
        /// Obtém todos os álbuns do banco de dados.
        /// </summary>
        /// <returns>Lista de álbuns.</returns>
        public static Álbum[] ObterÁlbuns()
        {
            return Mapear<Álbum>("SELECT * FROM album order by nome").ToArray();
        }


        /// <summary>
        /// Obtém um álbum
        /// </summary>
        /// <returns>Lista de álbuns.</returns>
        public static Álbum ObterÁlbum(ulong código)
        {
            return MapearÚnicaLinha<Álbum>(("SELECT * FROM album where codigo = " + DbTransformar(código.ToString())));
        }

        /// <summary>
        /// Recupera lista de fotos associadas.
        /// </summary>
        private void RecuperarFotos()
        {
            if (!Cadastrado)
            {
                fotos = new DbComposição<Foto>(
                    new DbAção<Foto>(AdicionarFoto),
                    null,
                    new DbAção<Foto>(RemoverFoto));
            }
            else
            {
                fotos = new DbComposição<Foto>(
                    Foto.ObterFotos(this),
                    new DbAção<Foto>(AdicionarFoto),
                    null,
                    new DbAção<Foto>(RemoverFoto));
            }

            fotos.AoAdicionar += new DbComposição<Foto>.EventoComposição(AoAdicionarFoto);
            fotos.AoRemover += new DbComposição<Foto>.EventoComposição(AoRemoverFoto);
        }

        /// <summary>
        /// Ocorre ao remover uma foto da lista, removendo também
        /// o álbum da lista da foto.
        /// </summary>
        /// <remarks>
        /// Como a foto pode ser desassociada do álbum por meio da
        /// entidade Álbum ou da entidade Foto, é necessário a determinação
        /// da origem da modificação.
        /// </remarks>
        void AoRemoverFoto(DbComposição<Foto> composição, Foto entidade)
        {
            if (entidade.Álbuns.Contains(this))
                entidade.Álbuns.Remove(this);
        }

        /// <summary>
        /// Ocorre ao adicionar uma foto à lista, adicionando também
        /// o álbum na lista da foto.
        /// </summary>
        /// <remarks>
        /// Como a foto pode ser desassociada do álbum por meio da
        /// entidade Álbum ou da entidade Foto, é necessário a determinação
        /// da origem da modificação.
        /// </remarks>
        void AoAdicionarFoto(DbComposição<Foto> composição, Foto entidade)
        {
            if (!entidade.Álbuns.Contains(this))
                entidade.Álbuns.Add(this);
        }

        #endregion

        public override void Atualizar()
        {
            this.alteração = DadosGlobais.Instância.HoraDataAtual;

            base.Atualizar();
        }

        public override string ToString()
        {
            return nome;
        }

        public static Álbum Cadastrar(string nome, string descrição)
        {
            Álbum novo = new Álbum();
            
            novo.nome = nome;
            novo.descrição = descrição;
            novo.criação = DadosGlobais.Instância.HoraDataAtual;

            novo.Cadastrar();

            return novo;
        }

        ///// <summary>
        ///// Adiciona foto no álbum.
        ///// </summary>
        private void AdicionarFoto(IDbCommand cmd, Foto foto)
        {
            cmd.CommandText = "INSERT INTO vinculofotoalbum (album, foto) VALUES ("
                + DbTransformar(código) + ", " + DbTransformar(foto.Código) + ")";

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Remove associação de foto a este álbum.
        /// </summary>
        private void RemoverFoto(IDbCommand cmd, Foto foto)
        {
            /* Se a foto foi descadastrada, então espera-se
             * que ela também tenha sido removida pelo banco de dados
             * (ON DELETE CASCADE).
             */
            if (foto.Cadastrado)
            {
                cmd.CommandText = "DELETE FROM vinculofotoalbum WHERE"
                    + " album = " + DbTransformar(código)
                    + " AND foto = " + DbTransformar(foto.Código);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
