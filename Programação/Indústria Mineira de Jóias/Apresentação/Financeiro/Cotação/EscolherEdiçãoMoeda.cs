using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades;

namespace Apresentação.Financeiro.Cotação
{
    /// <summary>
    /// Pergunta ao usuário que operação de manutenção
    /// será realizada.
    /// </summary>
    public partial class EscolherEdiçãoMoeda : JanelaExplicativa
    {
        private EscolherEdiçãoMoeda()
        {
            InitializeComponent();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = radioCriar.Checked
                || (radioEditar.Checked && comboMoeda.Seleção != null);
        }

        public static void ExecutarManutenção(IWin32Window owner)
        {
            Moeda moeda;

            using (EscolherEdiçãoMoeda dlg = new EscolherEdiçãoMoeda())
            {
                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    if (dlg.radioCriar.Checked)
                        moeda = new Moeda();
                    else
                        moeda = dlg.comboMoeda.Seleção;
                }
                else
                    return;
            }

            using (EditarMoeda dlg = new EditarMoeda(moeda))
            {
                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    AguardeDB.Mostrar();

                    try
                    {
                        if (moeda.Cadastrado)
                            moeda.Atualizar();
                        else
                            moeda.Cadastrar();
                    }
                    finally
                    {
                        AguardeDB.Fechar();
                    }
                }
            }
        }

        private void comboMoeda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMoeda.Seleção != null)
                radioEditar.Checked = true;

            btnOK.Enabled = radioCriar.Checked
                || (radioEditar.Checked && comboMoeda.Seleção != null);
        }
    }
}