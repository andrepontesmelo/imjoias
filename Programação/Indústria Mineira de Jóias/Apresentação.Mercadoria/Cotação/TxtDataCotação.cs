using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Configuração;

namespace Apresentação.Mercadoria.Cotação
{
    /// <summary>
    /// Trata-se de um caixa de texto de preenchimento de data
    /// que é associado à um controle de cotação.
    /// 
    /// Tota vez que a data é alterada, a cotação já é escolhida automaticamente.
    /// </summary>
    public partial class TxtDataCotação : DateTimePicker
    {
        private TxtCotação controleCotaçao = null;
        private DateTime antigaData;

        public TxtDataCotação()
        {
            InitializeComponent();
            
            ValueChanged += new EventHandler(TxtDataCotação_ValueChanged);
            antigaData = DadosGlobais.Instância.HoraDataAtual.Date;
        }

        public TxtDataCotação(bool DesignMode)
        {
            InitializeComponent();
        }



        void TxtDataCotação_ValueChanged(object sender, EventArgs e)
        {
#if DEBUG
            if (this.DesignMode)
                return;
#endif
            if (controleCotaçao != null)
            {
                controleCotaçao.AvisarCotaçõesDesatualizadas = this.Value.Date == DateTime.Today;

                if (controleCotaçao.Cotação == null || !controleCotaçao.Cotação.Data.HasValue ||
                    (controleCotaçao.Cotação.Data.Value.Date == antigaData.Date))
                        controleCotaçao.Data = this.Value.Date;
            }

            antigaData = this.Value;
        }

        [Browsable(true)]
        [Description("Cotação do dia selecionado será automaticamente atribuído")]
        public TxtCotação ControleCotação
        {
            get { return controleCotaçao; }
            set { controleCotaçao = value; }
        }
    }
}
