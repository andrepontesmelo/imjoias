using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Manutenção
{
    public partial class InformaçõesMercadoriaEdição : UserControl
    {
        private bool abrindoDados;
        private bool travado;
        private Entidades.Mercadoria.MercadoriaManutenção mercadoria;

        public InformaçõesMercadoriaEdição()
        {
            InitializeComponent();
        }

        public bool Travado
        {
            get { return travado; }
            set
            {
                travado = value;

                //txtReferência.Enabled = !value;
                txtPeso.Enabled = !value;
                txtGrupo.Enabled = !value;
                cmbFaixa.Enabled = !value;
                txtDescrição.Enabled = !value;
                txtTeor.Enabled = !value;
                chkDePeso.Enabled = !value;
                chkForaDeLinha.Enabled = !value;
            }
        }

        public Entidades.Mercadoria.MercadoriaManutenção Mercadoria
        {
            get { return mercadoria; }
            set
            {
                abrindoDados = true;
                mercadoria = value;

                if (mercadoria != null)
                {
                    txtReferência.Referência = mercadoria.Referência;
                    txtPeso.Double = mercadoria.Peso;
                    txtTeor.Int = mercadoria.Teor;

                    if (mercadoria.Faixa != null)
                    {
                        cmbFaixa.SelectedItem = mercadoria.Faixa.ToString();
                        cmbFaixa.Text = mercadoria.Faixa.ToString();
                    }

                    if (mercadoria.Grupo.HasValue)
                        txtGrupo.Int = mercadoria.Grupo.Value;
                    else
                        txtGrupo.Text = "";

                    txtDescrição.Text = mercadoria.Descrição;
                    chkDePeso.Checked = mercadoria.DePeso;
                    chkForaDeLinha.Checked = mercadoria.ForaDeLinha;
                }
                else
                {
                    txtReferência.Referência = "";
                    txtPeso.Text = "";
                    txtTeor.Text = "";
                    cmbFaixa.Text = "";
                    txtGrupo.Text = "";
                    txtDescrição.Text = "";
                    chkDePeso.Checked = chkForaDeLinha.Checked = false;
                }

                abrindoDados = false;
            }
        }

        private void txtDescrição_Validated(object sender, EventArgs e)
        {
            if (!abrindoDados)
            {
                mercadoria.Descrição = txtDescrição.Text;
                mercadoria.GravarAlterações();
            }
        }

        private void chkForaDeLinha_CheckedChanged(object sender, EventArgs e)
        {
            if (!abrindoDados)
            {

                mercadoria.ForaDeLinha = chkForaDeLinha.Checked;
                mercadoria.GravarAlterações();
            }
        }

        private void chkDePeso_CheckedChanged(object sender, EventArgs e)
        {
            if (!abrindoDados)
            {
                mercadoria.DePeso = chkDePeso.Checked;
                mercadoria.GravarAlterações();
            }
        }

        private void txtTeor_Validated(object sender, EventArgs e)
        {
            if (!abrindoDados)
            {
                mercadoria.Teor = txtTeor.Int;
                mercadoria.GravarAlterações();
            }
        }

        private void txtPeso_Validated(object sender, EventArgs e)
        {
            if (!abrindoDados)
            {
                mercadoria.Peso = txtPeso.Double;
                mercadoria.GravarAlterações();
            }
        }

        private void txtGrupo_TextChanged(object sender, EventArgs e)
        {
            if (!abrindoDados)
            {
                mercadoria.Grupo = txtGrupo.Int;
                mercadoria.GravarAlterações();
            }
        }

        void cmbFaixa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!abrindoDados)
            {
                mercadoria.Faixa = cmbFaixa.Text;
                mercadoria.GravarAlterações();
            }
        }
    }
}
