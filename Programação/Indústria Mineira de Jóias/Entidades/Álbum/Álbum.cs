using System;
using Acesso.Comum;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Drawing;
using Entidades.Configura��o;

namespace Entidades.�lbum
{
	/// <summary>
	/// � a entidade para a tabela 'album'.
	/// Um album possui diversas fotos.
	/// </summary>
	/// <remarks>
	/// O vinculo entre fotos e album � definido na tabela vinculofotosalbum.
	/// Deve existir, na entidade foto, a lista de �lbuns em que ela est� inserida.
	/// </remarks>
    [DbTabela("album"), DbTransa��o]
	public class �lbum : DbManipula��oAutom�tica
	{
		// Atributos
        [DbChavePrim�ria(true), DbColuna("codigo")]
        private ulong       c�digo = 0;

        private string      nome;

        [DbColuna("criacao")]
        private DateTime    cria��o;

        [DbColuna("alteracao")]
        private DateTime?   altera��o;

        [DbColuna("descricao")]
        private string      descri��o;

        private DbComposi��o<Foto> fotos = null;

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
        
        public ulong C�digo
        {
            get { return c�digo; }
        }
        
        public DateTime Cria��o
        {
            get { return cria��o; }
        }
        
        public DateTime? Altera��o
        {
            get { return altera��o; }
        }
        
        public string Descri��o
        {
            get { return descri��o; }
            set 
            { 
                descri��o = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// Lista de fotos.
        /// </summary>
        public DbComposi��o<Foto> Fotos
        {
            get
            {
                if (fotos == null)
                    RecuperarFotos();

                return fotos;
            }
        }

        #endregion

        #region Recupera��o de dados

        /// <summary>
        /// Obt�m todos os �lbuns do banco de dados.
        /// </summary>
        /// <returns>Lista de �lbuns.</returns>
        public static �lbum[] Obter�lbuns()
        {
            return Mapear<�lbum>("SELECT * FROM album order by nome").ToArray();
        }


        /// <summary>
        /// Obt�m um �lbum
        /// </summary>
        /// <returns>Lista de �lbuns.</returns>
        public static �lbum Obter�lbum(ulong c�digo)
        {
            return Mapear�nicaLinha<�lbum>(("SELECT * FROM album where codigo = " + DbTransformar(c�digo.ToString())));
        }

        /// <summary>
        /// Recupera lista de fotos associadas.
        /// </summary>
        private void RecuperarFotos()
        {
            if (!Cadastrado)
            {
                fotos = new DbComposi��o<Foto>(
                    new DbA��o<Foto>(AdicionarFoto),
                    null,
                    new DbA��o<Foto>(RemoverFoto));
            }
            else
            {
                fotos = new DbComposi��o<Foto>(
                    Foto.ObterFotos(this),
                    new DbA��o<Foto>(AdicionarFoto),
                    null,
                    new DbA��o<Foto>(RemoverFoto));
            }

            fotos.AoAdicionar += new DbComposi��o<Foto>.EventoComposi��o(AoAdicionarFoto);
            fotos.AoRemover += new DbComposi��o<Foto>.EventoComposi��o(AoRemoverFoto);
        }

        /// <summary>
        /// Ocorre ao remover uma foto da lista, removendo tamb�m
        /// o �lbum da lista da foto.
        /// </summary>
        /// <remarks>
        /// Como a foto pode ser desassociada do �lbum por meio da
        /// entidade �lbum ou da entidade Foto, � necess�rio a determina��o
        /// da origem da modifica��o.
        /// </remarks>
        void AoRemoverFoto(DbComposi��o<Foto> composi��o, Foto entidade)
        {
            if (entidade.�lbuns.Contains(this))
                entidade.�lbuns.Remove(this);
        }

        /// <summary>
        /// Ocorre ao adicionar uma foto � lista, adicionando tamb�m
        /// o �lbum na lista da foto.
        /// </summary>
        /// <remarks>
        /// Como a foto pode ser desassociada do �lbum por meio da
        /// entidade �lbum ou da entidade Foto, � necess�rio a determina��o
        /// da origem da modifica��o.
        /// </remarks>
        void AoAdicionarFoto(DbComposi��o<Foto> composi��o, Foto entidade)
        {
            if (!entidade.�lbuns.Contains(this))
                entidade.�lbuns.Add(this);
        }

        #endregion

        public override void Atualizar()
        {
            this.altera��o = DadosGlobais.Inst�ncia.HoraDataAtual;

            base.Atualizar();
        }

        public override string ToString()
        {
            return nome;
        }

        public static �lbum Cadastrar(string nome, string descri��o)
        {
            �lbum novo = new �lbum();
            
            novo.nome = nome;
            novo.descri��o = descri��o;
            novo.cria��o = DadosGlobais.Inst�ncia.HoraDataAtual;

            novo.Cadastrar();

            return novo;
        }

        ///// <summary>
        ///// Adiciona foto no �lbum.
        ///// </summary>
        private void AdicionarFoto(IDbCommand cmd, Foto foto)
        {
            cmd.CommandText = "INSERT INTO vinculofotoalbum (album, foto) VALUES ("
                + DbTransformar(c�digo) + ", " + DbTransformar(foto.C�digo) + ")";

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Remove associa��o de foto a este �lbum.
        /// </summary>
        private void RemoverFoto(IDbCommand cmd, Foto foto)
        {
            /* Se a foto foi descadastrada, ent�o espera-se
             * que ela tamb�m tenha sido removida pelo banco de dados
             * (ON DELETE CASCADE).
             */
            if (foto.Cadastrado)
            {
                cmd.CommandText = "DELETE FROM vinculofotoalbum WHERE"
                    + " album = " + DbTransformar(c�digo)
                    + " AND foto = " + DbTransformar(foto.C�digo);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
