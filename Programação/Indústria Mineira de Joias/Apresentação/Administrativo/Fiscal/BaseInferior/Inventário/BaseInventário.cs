using Apresentação.Administrativo.Fiscal.BaseInferior.Esquema;
using Apresentação.Administrativo.Fiscal.BaseInferior.Produção;
using Apresentação.Formulários;
using Entidades.Fiscal.Excessões;
using Entidades.Fiscal.Produção;
using System;
using System.Collections.Generic;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Inventário
{
    public partial class BaseInventário : Apresentação.Formulários.BaseInferior
    {
        public BaseInventário()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Carregar();
        }

        private void Carregar()
        {
            títuloBaseInferior1.Título = string.Format("Inventário {0}",
                !Data.HasValue ? "atual" : "em " + Data.Value.ToShortDateString() + " " + Data.Value.ToShortTimeString());

            AguardeDB.Mostrar();
            listaInventário.Carregar(Data);
            AguardeDB.Fechar();
        }
        
        public DateTime? Data
        {
            get
            {
                if (optPassado.Checked)
                    return dataMáxima.Value as DateTime?;

                return null;
            }
        }
        private void dataMáxima_Validated(object sender, System.EventArgs e)
        {
            if (optPassado.Checked)
                Carregar();
        }

        private void optAtual_CheckedChanged(object sender, EventArgs e)
        {
            Carregar();
        }

        private void opçãoProduzir_Click(object sender, EventArgs e)
        {
            List<ItemProduçãoFiscal> itens = listaInventário.ObterItensChecados();
            ProduçãoFiscal novaProdução;

            if (itens.Count == 0)
                return;

            try
            {
                novaProdução = ProduçãoFiscal.Criar(itens);
            } catch (EsquemaInexistente erro)
            {
                MensagemErro.MostrarMensagem(this, erro, "Erro ao criar produção");
                return;
            }

            SubstituirBase(new BaseProdução(novaProdução));
        }
    }
}
