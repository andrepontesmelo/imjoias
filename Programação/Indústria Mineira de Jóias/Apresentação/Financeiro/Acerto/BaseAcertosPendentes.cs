using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Privilégio;
using Entidades.Acerto;

[assembly: ExporBotão(Permissão.Consignado, 7, "Acertos Pendentes", true, typeof(Apresentação.Financeiro.Acerto.BaseAcertosPendentes))]

namespace Apresentação.Financeiro.Acerto
{
    public partial class BaseAcertosPendentes : BaseInferior
    {
        public BaseAcertosPendentes()
        {
            InitializeComponent();
        }

        private void listaAcertos_AoMudarSeleção(object sender, EventArgs e)
        {
            quadroSeleção.Visible = listaAcertos.Seleção != null;
        }

        private void listaAcertos_DoubleClick(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                BaseDadosAcerto baseInferior = new BaseDadosAcerto();

                baseInferior.AcertoConsignado = listaAcertos.Seleção;

                SubstituirBase(baseInferior);
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        protected override void AoExibir()
        {
            AguardeDB.Mostrar();

            try
            {
                base.AoExibir();

                listaAcertos.MostrarAcertos(AcertoConsignado.ObterAcertosPendentes());
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }
    }
}
