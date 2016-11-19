using Acesso.Comum;
using System.Data;
using System.Text;

namespace Entidades.Mercadoria
{
    public class MatériaPrima : DbManipulaçãoSimples
    {
        public static void Importar(DataTable cadmer)
        {
            StringBuilder str = new StringBuilder("delete from materiaprima; ");
            
            foreach (DataRow item in cadmer.Rows)
            {
                var referência = item["cm_codmer"].ToString().Trim();
                var preçoCusto = decimal.Parse(item["cm_punit"].ToString());

                if (!ÉMatériaPrima(referência))
                    continue;

                str.Append(string.Format("insert into materiaprima (referencia, valor) values ({0}, {1}); ",
                    DbTransformar(referência),
                    DbTransformar(preçoCusto)));
            }

            ExecutarComando(str.ToString());
        }

        public static bool ÉMatériaPrima(string referência)
        {
            return referência.StartsWith("9");
        }
    }
}
