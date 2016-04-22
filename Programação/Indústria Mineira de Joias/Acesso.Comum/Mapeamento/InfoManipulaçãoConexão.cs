using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using Acesso.Comum.Exceções;

namespace Acesso.Comum.Mapeamento
{
    /// <summary>
    /// Informações de manipulação específica de uma conexão
    /// do banco de dados.
    /// </summary>
    internal class InfoManipulaçãoConexão : IDisposable
    {
        /// <summary>
        /// Comandos de manipulação do banco de dados.
        /// </summary>
        private IDbCommand cadastrar, atualizar, descadastrar;

        /// <summary>
        /// Mapeamentos de campos para parâmetros do banco de dados.
        /// </summary>
        private CampoParâmetroBase[] mapCadastrar, mapAtualizar, mapDescadstrar;

        /// <summary>
        /// Constrói as informações para manipulação de uma
        /// entidade em uma conexão específica.
        /// </summary>
        /// <param name="info">Informações de manipulação da entidade.</param>
        /// <param name="conexão">Conexão com o banco de dados.</param>
        public InfoManipulaçãoConexão(InfoManipulação info, IDbConnection conexão)
        {
            ConstruirComandos(conexão, info.Tabela, info.ChavePrimária, info.ChavePrimáriaPersonalizável, info.Atributos);
        }

        #region Construção de comandos

        /// <summary>
        /// Constrói comandos para manipulação do banco de dados.
        /// </summary>

        private void ConstruirComandos(
            IDbConnection conexão,
            string tabela,
            FieldInfo[] vetorChavePrimária,
            FieldInfo[] vetorChavePrimáriaPersonalizável,
            FieldInfo[] vetorAtributos)
        {
            lock (this)
            {
#if DEBUG
                int ocupação = ((Adaptadores.ConexãoConcorrente)conexão).Ocupado;
#endif
                try
                {
                    ConstruirCadastrar(conexão, tabela, vetorChavePrimáriaPersonalizável, vetorAtributos);
                    ConstruirAtualizar(conexão, tabela, vetorChavePrimária, vetorAtributos);
                    ConstruirDescadastrar(conexão, tabela, vetorChavePrimária);
                }
                catch (ExcessãoMapeamentoTipo e)
                {
                    string novaMsgErro = e.Message + "\nIsto ocorreu porque na classe que define a tabela " + tabela +
                        " existe o tipo não reconhecido " + e.TipoNãoEncontrado.ToString()
                        + "\nSolução: Adicione [DbAtributo(TipoAtributo.Ignorar)] ou Cadastre o tipo.";

                    System.Diagnostics.Debug.Fail(novaMsgErro);

                    throw new ExcessãoMapeamentoTipo(novaMsgErro, e.TipoNãoEncontrado);
                }
#if DEBUG
                finally
                {
                    System.Diagnostics.Debug.Assert(ocupação == ((Adaptadores.ConexãoConcorrente)conexão).Ocupado, "Ocupação deveria sair igual!");
                }
#endif
            }
        }

        /// <summary>
        /// Constrói comando para cadastrar no banco de dados.
        /// </summary>
        private void ConstruirCadastrar(IDbConnection conexão, string tabela, FieldInfo[] chavePrimáriaPersonalizável, FieldInfo[] atributosComuns)
        {
            string prefixo, colunas, valores;
            int nColunas = 0;
            List<CampoParâmetroBase> mapeamento;

            cadastrar = conexão.CreateCommand();
            prefixo = "INSERT INTO " + tabela;
            colunas = " (";
            valores = " VALUES (";
            mapeamento = new List<CampoParâmetroBase>();

            // Inserir chave-primária personalizável.
            foreach (FieldInfo chave in chavePrimáriaPersonalizável)
            {
                CampoParâmetroBase[] mapCampo;

                mapCampo = FábricaCampoParâmetro.MapearCampoParâmetro(chave, cadastrar);
                mapeamento.AddRange(mapCampo);

                foreach (CampoParâmetroBase map in mapCampo)
                {
                    colunas += nColunas > 0 ? ", " + map.Coluna : map.Coluna;
                    valores += nColunas > 0 ? ", " + map.Parâmetro : map.Parâmetro;

                    nColunas++;
                }
            }

            // Inserir demais atributos.
            foreach (FieldInfo atributo in atributosComuns)
            {
                CampoParâmetroBase[] mapCampo;

                mapCampo = FábricaCampoParâmetro.MapearCampoParâmetro(atributo, cadastrar);
                mapeamento.AddRange(mapCampo);

                foreach (CampoParâmetroBase map in mapCampo)
                {
                    colunas += nColunas > 0 ? ", " + map.Coluna : map.Coluna;

                    valores += nColunas > 0 ? ", " + map.Parâmetro : map.Parâmetro;
                    nColunas++;
                }
            }

            colunas += ")";
            valores += ")";

            // Atribuir comando.
            cadastrar.CommandText = prefixo + colunas + valores;
            mapCadastrar = mapeamento.ToArray();
            //cadastrar.Prepare();

            if (conexão is Adaptadores.ConexãoConcorrente)
            {
                ((Adaptadores.ConexãoConcorrente)conexão).Ocupado--;
//#if DEBUG
//                ((Adaptadores.ConexãoConcorrente)conexão).cmdTexto = null;
//#endif
            }
        }

        /// <summary>
        /// Constrói comando para atualizar no banco de dados.
        /// </summary>
        private void ConstruirAtualizar(IDbConnection conexão, string tabela, FieldInfo[] chavePrimária, FieldInfo[] atributosComuns)
        {
            string prefixo, valores, condição;
            int nColunas;
            List<CampoParâmetroBase> mapeamento;

            atualizar = conexão.CreateCommand();
            prefixo = "UPDATE " + tabela;
            valores = " SET ";
            condição = " WHERE ";
            mapeamento = new List<CampoParâmetroBase>();

            // Inserir valores.
            nColunas = 0;

            foreach (FieldInfo atributo in atributosComuns)
            {
                CampoParâmetroBase[] mapCampo;

                mapCampo = FábricaCampoParâmetro.MapearCampoParâmetro(atributo, atualizar);
                mapeamento.AddRange(mapCampo);

                foreach (CampoParâmetroBase map in mapCampo)
                    valores += (nColunas++ > 0 ? ", " + map.Coluna : map.Coluna) + " = " + map.Parâmetro;
            }

            // Inserir chave-primária.
            nColunas = 0;

            foreach (FieldInfo chave in chavePrimária)
            {
                CampoParâmetroBase[] mapCampo;

                mapCampo = FábricaCampoParâmetro.MapearCampoParâmetro(chave, atualizar);
                mapeamento.AddRange(mapCampo);

                foreach (CampoParâmetroBase map in mapCampo)
                {
                    if (nColunas++ > 0)
                        condição += " AND ";

                    condição += map.Coluna + " = " + map.Parâmetro;
                }
            }

            // Atribuir comando.
            atualizar.CommandText = prefixo + valores + condição;
            mapAtualizar = mapeamento.ToArray();
            //			atualizar.Prepare();

            if (conexão is Adaptadores.ConexãoConcorrente)
            {
                ((Adaptadores.ConexãoConcorrente)conexão).Ocupado--;
//#if DEBUG
//                ((Adaptadores.ConexãoConcorrente)conexão).cmdTexto = null;
//#endif
            }
        }

        /// <summary>
        /// Constrói comando para descadastrar no banco de dados.
        /// </summary>
        private void ConstruirDescadastrar(IDbConnection conexão, string tabela, FieldInfo[] chavePrimária)
        {
            string prefixo, condição;
            int nColunas;
            List<CampoParâmetroBase> mapeamento;

            descadastrar = conexão.CreateCommand();
            prefixo = "DELETE FROM " + tabela;
            condição = " WHERE ";
            mapeamento = new List<CampoParâmetroBase>();

            // Inserir chave-primária.
            nColunas = 0;

            foreach (FieldInfo chave in chavePrimária)
            {
                CampoParâmetroBase[] mapCampo;

                mapCampo = FábricaCampoParâmetro.MapearCampoParâmetro(chave, descadastrar);
                mapeamento.AddRange(mapCampo);

                foreach (CampoParâmetroBase map in mapCampo)
                {
                    if (nColunas++ > 0)
                        condição += " AND ";

                    condição += map.Coluna + " = " + map.Parâmetro;
                }
            }

            // Atribuir comando.
            descadastrar.CommandText = prefixo + condição;
            mapDescadstrar = mapeamento.ToArray();
            //			descadastrar.Prepare();

            if (conexão is Adaptadores.ConexãoConcorrente)
            {
                ((Adaptadores.ConexãoConcorrente)conexão).Ocupado--;
//#if DEBUG
//                ((Adaptadores.ConexãoConcorrente)conexão).cmdTexto = null;
//#endif
            }
        }

        #endregion

        #region Atribuição de valores para comandos

        /// <summary>
        /// Prepara o cadastramento de uma entidade.
        /// </summary>
        /// <param name="entidade">Entidade a ser cadastrada.</param>
        /// <returns>Comando para cadastro.</returns>
        public IDbCommand PrepararCadastramento(DbManipulaçãoAutomática entidade)
        {
            foreach (CampoParâmetroBase mapeamento in mapCadastrar)
                mapeamento.DefinirParâmetro(entidade);

            return cadastrar;
        }

        /// <summary>
        /// Prepara o atualização de uma entidade.
        /// </summary>
        /// <param name="entidade">Entidade a ser atualizada.</param>
        /// <returns>Comando para atualização.</returns>
        public IDbCommand PrepararAtualização(DbManipulaçãoAutomática entidade)
        {
            foreach (CampoParâmetroBase mapeamento in mapAtualizar)
                mapeamento.DefinirParâmetro(entidade);

            return atualizar;
        }

        /// <summary>
        /// Prepara o descadastramento de uma entidade.
        /// </summary>
        /// <param name="entidade">Entidade a ser descadastrada.</param>
        /// <returns>Comando para descadastramento.</returns>
        public IDbCommand PrepararDescadastramento(DbManipulaçãoAutomática entidade)
        {
            foreach (CampoParâmetroBase mapeamento in mapDescadstrar)
                mapeamento.DefinirParâmetro(entidade);

            return descadastrar;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            cadastrar.Dispose();
            atualizar.Dispose();
            descadastrar.Dispose();
        }

        #endregion
    }
}
