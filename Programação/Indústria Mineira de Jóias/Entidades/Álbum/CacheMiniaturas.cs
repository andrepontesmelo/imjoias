using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Xml;
using System.Data;
using System.Drawing;
using System.IO;

namespace Entidades.Álbum
{
    /// <summary>
    /// Cache de miniaturas para as fotos.
    ///
    ///
    /// É utilizada ao abrir o listview de navegação do álbum;
    /// Também é utilizada no QuadroFoto.
    /// 
    /// Mantem em mémórias duas hashes:
    ///  hashMiniaturas: dado o código da foto, retorna sua miniatura,
    ///  hashMercadoriaMiniatura: dado a chave (referencia, peso), retorna o código da miniatura.
    ///  
    /// as imagens já redimensionadas (miniaturas) são salvas localmente em um arquivo XML 
    /// (cache para evitar acessos ao banco).
    /// </summary>
    public class CacheMiniaturas : DbManipulaçãoSimples
    {
        // Intervalo em segundos entre um salvamento e outro da cache de miniaturas.
        private static readonly int intervaloSegundosSalvamento = 20;

        private Encoding codificador = System.Text.Encoding.Default;

        public readonly string arquivoXml = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "miniaturas.xml");

        private int miniaturasSalvas = 0;

        private DateTime últimoSalvamento = DateTime.Now;

        private static CacheMiniaturas instância;

        public static CacheMiniaturas Instância
        {
            get
            {
                if (instância == null)
                    instância = new CacheMiniaturas();

                return instância;
            }
        }

        /// <summary>
        /// Dado o código da foto, retorna a miniatura.
        /// </summary>
        private Dictionary<uint, DbFoto> hashMiniaturas;

        /// <summary>
        /// Obtem a miniatura de uma foto. 
        /// Este método deve ser evitado, é preferível utilizar 
        /// ObterMiniaturas() para obtenção em batch com mais desempenho.
        /// </summary>
        /// <param name="código"></param>
        /// <returns></returns>
        public DbFoto Obter(Foto foto)
        {
            DbFoto entidade = null;

            if (hashMiniaturas.TryGetValue(foto.Código, out entidade))
            {
                return entidade;
            }
            else
            {
                // tenta obter pela cache ou banco de dados:
                Dictionary<uint, Foto> hash = new Dictionary<uint, Foto>();
                hash[foto.Código] = foto;
                ObterMiniaturas(hash);

                hashMiniaturas.TryGetValue(foto.Código, out entidade);

                return entidade;
            }
        }
        
        private CacheMiniaturas()
        {
            hashMiniaturas = new Dictionary<uint, DbFoto>();
            Carregar();
        }

        public void Inserir(uint código, DbFoto miniatura)
        {
            hashMiniaturas[código] = miniatura;
            // Console.WriteLine("Inserindo miniatura na cache...");
            if ((DateTime.Now - últimoSalvamento).TotalSeconds > intervaloSegundosSalvamento)
            {
                lock (this)
                {
                    if ((DateTime.Now - últimoSalvamento).TotalSeconds > intervaloSegundosSalvamento)
                        Salvar();
                }
            }
            // Console.WriteLine("Inseriu! " + miniaturasSalvas.ToString());
        }

        /// <summary>
        /// Carrega as duas hashes.
        /// 1) Carrega do banco de dados a hash[referencia,peso] -> código foto.
        /// 2) Carrega do XML a hash[código foto] -> imagem da miniatura.
        /// </summary>
        private void Carregar()
        {
            hashMercadoriaMiniatura = new Dictionary<string, uint>(StringComparer.Ordinal);

            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT mercadoria, peso, codigo FROM foto";

                    using (leitor = cmd.ExecuteReader())
                    {

                        try
                        {
                            while (leitor.Read())
                            {
                                string referência = leitor.GetString(0);
                                uint códigoFoto;
                                double peso = 0;

                                if (!leitor.IsDBNull(1))
                                    peso = leitor.GetDouble(1);

                                códigoFoto = (uint)leitor.GetInt32(2);
                                string chave = GerarChave(referência);

                                hashMercadoriaMiniatura[chave] = códigoFoto;
                            }

                        }
                        finally
                        {
                            if (leitor != null)
                                leitor.Close();

                            Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                        }
                    }
                }
            }

            // Agora carrega as miniaturas do XML

            if (!System.IO.File.Exists(arquivoXml))
                return;

            XmlTextReader objXmlTextReader = new XmlTextReader(arquivoXml);

            uint códigoMiniatura = 0;
            byte[] miniatura;
            miniaturasSalvas = 0;

            string sName = "";

            try
            {
                while (objXmlTextReader.Read())
                {
                    switch (objXmlTextReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            sName = objXmlTextReader.Name;
                            break;
                        case XmlNodeType.Text:
                            switch (sName)
                            {
                                case "Código":
                                    códigoMiniatura = uint.Parse(objXmlTextReader.Value);
                                    break;
                                case "Miniatura":
                                    miniatura = codificador.GetBytes(objXmlTextReader.Value);

                                    DbFoto entidade = new DbFoto(miniatura);
                                    hashMiniaturas.Add(códigoMiniatura, entidade);
                                    miniaturasSalvas++;
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
                // Erro no arquivo de miniaturas.
                try
                {
                    System.IO.File.Delete(arquivoXml);
                }
                catch (Exception)
                {
                }
            } 
            finally
            {
                if (objXmlTextReader != null)
                    objXmlTextReader.Close();
            }
            
            Console.WriteLine(miniaturasSalvas.ToString() + " miniaturas carregadas!");
        }
        
        private void Salvar()
        {
            últimoSalvamento = DateTime.Now;

            try
            {
                XmlTextWriter objXmlTextWriter = new XmlTextWriter(arquivoXml, null);

                objXmlTextWriter.Formatting = Formatting.Indented;

                objXmlTextWriter.WriteStartDocument();

                objXmlTextWriter.WriteStartElement("Miniaturas");

                foreach (KeyValuePair<uint, DbFoto> par in hashMiniaturas)
                {
                    objXmlTextWriter.WriteStartElement("Código");
                    objXmlTextWriter.WriteString(par.Key.ToString());
                    objXmlTextWriter.WriteEndElement();

                    objXmlTextWriter.WriteStartElement("Miniatura");
                    objXmlTextWriter.WriteString(codificador.GetString(par.Value.Vetor));
                    objXmlTextWriter.WriteEndElement();
                }

                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndDocument();
                objXmlTextWriter.Flush();
                objXmlTextWriter.Close();

                miniaturasSalvas = hashMiniaturas.Count;
                Console.WriteLine("Salvado arquivo de miniaturas. Itens:" + miniaturasSalvas.ToString());
                Console.WriteLine(arquivoXml);

            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Dado o código, retorna a foto.
        /// Método padrão para obtenção de miniaturas via cache.
        /// Obtem várias miniaturas de uma só vez, seja da cache seja do banco de dados.
        /// </summary>
        /// <param name="?"></param>
        public void ObterMiniaturas(Dictionary<uint, Foto> fotos)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            StringBuilder comando = new StringBuilder("SELECT codigo, foto from foto where codigo IN (");
            int contadorObtençãoFoto = 0;

            foreach (uint código in fotos.Keys)
            {
                if (!hashMiniaturas.ContainsKey(código))
                {
                    // Realizar consulta no banco
                    if (contadorObtençãoFoto > 0)
                        comando.Append(", ");

                    comando.Append(código.ToString());
                    contadorObtençãoFoto++;
                }
            }
            comando.Append(")");

            if (contadorObtençãoFoto > 0)
            {
                // Necessário realizar consulta no banco
                conexão = Conexão;

                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);


                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = comando.ToString();

                        using (leitor = cmd.ExecuteReader())
                        {

                            try
                            {
                                while (leitor.Read())
                                {
                                    uint código = (uint)leitor.GetInt32(0);
                                    Foto entidade = fotos[código];

                                    DbFoto foto = new DbFoto((byte[])leitor.GetValue(1));

                                    if (foto.Imagem != null)
                                    {

                                        double proporção = foto.Imagem.Width / (double)foto.Imagem.Height;
                                        int width, height;

                                        if (foto.Imagem.Width > foto.Imagem.Height)
                                        {
                                            width = Foto.tamanhoMaiorLadoMiniatura;
                                            height = Convert.ToInt32(Foto.tamanhoMaiorLadoMiniatura / proporção);
                                        }
                                        else
                                        {
                                            width = Convert.ToInt32(proporção * Foto.tamanhoMaiorLadoMiniatura);
                                            height = Foto.tamanhoMaiorLadoMiniatura;
                                        }

                                        // Insere na cache:
                                        Inserir(entidade.Código, foto.Imagem.GetThumbnailImage(width, height, null, IntPtr.Zero));
                                    }
                                }
                            }
                            finally
                            {
                                if (leitor != null)
                                    leitor.Close();

                                Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Obtenção em batch de " + fotos.Count.ToString() + ". Foi necessário SQL p/ " + contadorObtençãoFoto.ToString() + " fotos.");
        }

        private static string GerarChave(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            return GerarChave(mercadoria.ReferênciaNumérica);
        }

        private static string GerarChave(string referência)
        {
            return referência;
        }

        /// <summary>
        /// Obtem a foto da cache. 
        /// Pode retornar nulo caso foto não exista.
        /// </summary>
        /// <param name="mercadoria"></param>
        /// <returns></returns>
        public DbFoto Obter(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            if (mercadoria == null)
                return null;

            uint códigoMiniatura;

            if (hashMercadoriaMiniatura.TryGetValue(GerarChave(mercadoria), out códigoMiniatura))
                return Obter(new Foto(códigoMiniatura, mercadoria.ReferênciaNumérica));
            else
                return null;
        }

        /// <summary>
        /// Dado a chave GerarChave(referencia, peso), retorna o código de sua miniatura.
        /// </summary>
        private Dictionary<string, uint> hashMercadoriaMiniatura;

        /// <summary>
        /// É necessário saber o código da foto para obtenção de sua miniatura.
        /// Este método utiliza a tabela de vinculo em cache para retornar uma foto oca, 
        /// apenas com a referencia para a miniatura da foto.
        /// 
        /// Nenhuma consulta ao banco é feita.
        /// </summary> 
        public Foto ObterFoto(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            uint códigoMiniatura;

            if (hashMercadoriaMiniatura.TryGetValue(GerarChave(mercadoria), out códigoMiniatura))
                return new Foto(códigoMiniatura, mercadoria.ReferênciaNumérica);
            else
                return null;
        }

        /// <summary>
        /// Carrega toda a cache de miniaturas
        /// </summary>
        public void CarregarCacheMiniaturas()
        {
            Foto[] fotos = Foto.ObterFotos(true);
            Dictionary<uint, Foto> hashFotos = new Dictionary<uint, Foto>();
            foreach (Foto f in fotos)
                hashFotos[f.Código] = f;

            ObterMiniaturas(hashFotos);
        }

        public void Remover(Mercadoria.Mercadoria mercadoria)
        {
            uint códigoMiniatura;

            string chave = GerarChave(mercadoria);

            if (hashMercadoriaMiniatura.TryGetValue(chave, out códigoMiniatura))
            {
                hashMercadoriaMiniatura.Remove(chave);
                Salvar();
            }
        }
    }
}
