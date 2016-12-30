using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica.Pdf
{
    public class MapaIdNfe : DbManipulaçãoSimples
    {
        private static MapaIdNfe instância;

        public static MapaIdNfe Instância
        {
            get
            {
                if (instância == null)
                    instância = new MapaIdNfe();

                return instância;
            }
        }

        private Dictionary<int, string> hashNfeId;

        public string ObterId(int númeroNotaFiscal)
        {
            string id = null;
            hashNfeId.TryGetValue(númeroNotaFiscal, out id);

            return id;
        }

        public void Recarregar()
        {
            instância = null;
        }

        private MapaIdNfe()
        {
            hashNfeId = new Dictionary<int, string>();

            var conexão = Conexão;
            lock (conexão)
            {
                using (var cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = string.Format("select id, numero from saidafiscal where setor != {0} group by id, numero",
                        DbTransformar((int) SetorSistema.Varejo));

                    using (var leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            if (leitor.IsDBNull(1))
                                continue;

                            var id = leitor.GetInt32(1);

                            if (hashNfeId.ContainsKey(id))
                                continue;

                            hashNfeId[id] = leitor.GetString(0);
                        }
                    }
                }
            }
        }
    }
}
