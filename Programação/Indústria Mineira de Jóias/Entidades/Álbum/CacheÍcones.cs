using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Xml;
using System.Data;
using System.Drawing;

namespace Entidades.Álbum
{
    public class CacheÍcones : DbManipulaçãoSimples
    {
        private Encoding codificador = System.Text.Encoding.Default;

        //private string arquivoXml = System.IO.Path.Combine(
        //    System.IO.Directory.GetCurrentDirectory(),
        //    "miniaturas.xml");

        //private int miniaturasSalvas = 0;

        //private DateTime últimoSalvamento = DateTime.Now;

        private static CacheÍcones instância;

        public static CacheÍcones Instância
        {
            get
            {
                if (instância == null)
                    instância = new CacheÍcones();

                return instância;
            }
        }

        /// <summary>
        /// Dado uma chave GerarChave(), retorna o ícone.
        /// </summary>
        private Dictionary<string, Ícone> hashÍcones;

        /// <summary>
        /// Obtem a miniatura de uma foto. 
        /// Este método deve ser evitado, é preferível utilizar 
        /// ObterMiniaturas() para obtenção em batch com mais desempenho.
        /// </summary>
        /// <param name="código"></param>
        /// <returns></returns>
        public Ícone Obter(Entidades.Mercadoria.Mercadoria mercadoriaFoto)
        {
            Ícone entidade;
            double peso = 0;

            if (mercadoriaFoto.DePeso)
                peso = mercadoriaFoto.Peso;

            if (hashÍcones.TryGetValue(GerarChave(mercadoriaFoto.ReferênciaNumérica, peso), out entidade))
            {
                return entidade;
            }
            else
            {
                return null;
            }
        }

        private CacheÍcones()
        {
            Carregar();
        }


        private static string GerarChave(string referenciaNuméria, double peso)
        {
            return referenciaNuméria + "#" + peso.ToString();
        }

        /// <summary>
        /// Faz uma consulta ao BD
        /// Carregando todos os ícones para a memória.
        /// </summary>
        public void Carregar()
        {
            DateTime inicio = DateTime.Now;
            Console.WriteLine("Consulta de obtenção de ícones!");

            hashÍcones = new Dictionary<string, Ícone>(StringComparer.Ordinal);
            string consulta = "SELECT mercadoria, peso, icone FROM foto where icone is not null";

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);


                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = consulta;

                    IDataReader leitor = null;

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string chave;
                                double peso;

                                if (leitor.IsDBNull(1))
                                    peso = 0;
                                else
                                    peso = leitor.GetDouble(1);

                                chave = GerarChave(leitor.GetString(0), peso);
                                hashÍcones[chave] = new Ícone((byte[])leitor.GetValue(2));
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null && !leitor.IsClosed)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);

                    }
                }
            }

            TimeSpan tempo = DateTime.Now - inicio;
            Console.WriteLine("total carga ícones: " + tempo.ToString());
        }
    }
}
