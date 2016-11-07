using Apresentação.Formulários;
using System;

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
    }
}
