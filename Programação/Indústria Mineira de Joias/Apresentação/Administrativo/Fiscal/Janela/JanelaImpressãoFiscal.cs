using Apresentação.Impressão.Relatórios.Fiscal.Inventário;
using System;

namespace Apresentação.Administrativo.Fiscal.Janela
{
    public partial class JanelaImpressãoFiscal : Formulários.JanelaImpressão
    {
        public JanelaImpressãoFiscal()
        {
            InitializeComponent();
        }

        public void InserirDocumento(DateTime data)
        {
            Título = "Inventário";
            Descrição = "Relatório de inventário";
            InserirDocumento(new ControladorImpressãoInventário().CriarRelatório(data), "Inventário");
        }
    }
}
