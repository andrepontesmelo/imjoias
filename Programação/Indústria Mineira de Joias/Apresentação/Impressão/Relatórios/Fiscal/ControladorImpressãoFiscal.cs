using Entidades.Fiscal.Registro;
using Entidades.Fiscal.Tipo;
using Entidades.Pessoa;
using System.Data;

namespace Apresentação.Impressão.Relatórios.Fiscal
{
    public abstract class ControladorImpressãoFiscal
    {
        protected static string ObterSigla(TipoUnidade tipoUnidadeComercial)
        {
            switch (tipoUnidadeComercial.Id)
            {
                case (int)TipoUnidadeSistema.Cxa:
                    return "CXA";
                case (int)TipoUnidadeSistema.Grs:
                    return "GRS";
                case (int)TipoUnidadeSistema.Par:
                    return "PAR";
                case (int)TipoUnidadeSistema.Pca:
                    return "PÇA";
                case (int)TipoUnidadeSistema.Un:
                    return "UN";
                case (int)TipoUnidadeSistema.Klt:
                    return "KLT";

                default:
                    return tipoUnidadeComercial.Nome.ToUpper();
            }
        }

        protected virtual DataRow CriarLinhaDocumento(DataTable tabelaDocumento)
        {
            var empresa = PessoaJurídica.ObterEmpresa();

            DataRow linha = tabelaDocumento.NewRow();
            linha["nomeEmpresa"] = empresa.Nome.ToUpper();
            linha["cnpj"] = empresa.CNPJ;
            linha["inscriçãoEstadual"] = empresa.InscEstadual;

            return linha;
        }

        protected virtual DataRow CriarItem(DataTable tabelaItens, RegistroAbstrato entidade)
        {
            DataRow item = tabelaItens.NewRow();

            item["referência"] = Entidades.Mercadoria.Mercadoria.MascararReferência(entidade.Referência, true);
            item["classificaçãoFiscal"] = entidade.ClassificaçãoFiscalFormatada;
            item["descrição"] = entidade.Descrição?.ToUpper();
            item["tipoUnidade"] = ObterSigla(entidade.TipoUnidadeComercial);

            return item;
        }
    }
}
