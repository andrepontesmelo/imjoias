using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Fiscal.Pdf
{
    public class CacheIds : DbManipulaçãoSimples
    {
        private List<string> códigos = null;
        private string relação;

        public CacheIds(string relação)
        {
            this.relação = relação;
        }

        public List<string> ObterIdsCadastrados()
        {
            if (códigos == null)
                códigos = MapearStrings("select id from " + relação);

            return códigos;
        }

        public void LimparCache()
        {
            códigos = null;
        }
    }
}
