using Apresentação.Formulários;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Estoque
{
    public partial class JanelaOpçõesImpressão : JanelaExplicativa
    {
        private Entidades.Configuração.ConfiguraçãoUsuário<bool> configuraçãoReferência;
        private Entidades.Configuração.ConfiguraçãoUsuário<bool> configuraçãoPeso;

        public JanelaOpçõesImpressão()
        {
            InitializeComponent();

            configuraçãoReferência = new Entidades.Configuração.ConfiguraçãoUsuário<bool>("estoque_opcoes_impressao_incluir_referencia", true);
            configuraçãoPeso =  new Entidades.Configuração.ConfiguraçãoUsuário<bool>("estoque_opcoes_impressao_incluir_peso", true);

            chkReferência.Checked = configuraçãoReferência.Valor;
            chkPeso.Checked = configuraçãoPeso.Valor;
        }

        public bool IncluirReferência
        { get { return chkReferência.Checked;  } }

        public bool IncluirPeso
        { get { return chkPeso.Checked;  }  }

        private void btnOk_Click(object sender, EventArgs e)
        {
            configuraçãoPeso.Valor = IncluirPeso;
            configuraçãoReferência.Valor = IncluirReferência;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Hide();
        }
    }
}
