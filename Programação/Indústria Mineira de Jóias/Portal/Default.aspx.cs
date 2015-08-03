using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AjaxControlToolkit;

namespace Portal
{
    public partial class _Default : System.Web.UI.Page
    {
        private static double totalPeso = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtBox.Focus();
            Utility.SetFocusOnLoad(txtBox);
        }

        protected void AutoCompleteExtender1_DataBinding(object sender, EventArgs e)
        {
    
        }

        protected void AutoCompleteExtender1_PreRender(object sender, EventArgs e)
        {
        }

        protected void AutoCompleteExtender1_ResolveControlID(object sender, AjaxControlToolkit.ResolveControlEventArgs e)
        {
        }

        protected void txtBox_TextChanged(object sender, EventArgs e)
        {
            AcessoBD.AssegurarConectado();

            if (txtBox.Text.Length == 16)
            {
                Entidades.Mercadoria.Mercadoria m =
                Entidades.Mercadoria.Mercadoria.ObterMercadoria(txtBox.Text, Entidades.Tabela.TabelaPadrão);
                if (m == null)
                {
                    txtBox.Font.Bold = true;
                    lblReferenciaNaoEncontrada.Visible = true;
                    txtPeso.Enabled = false;
                    btnAdicionar.Enabled = false;
                }
                else
                {
                    txtBox.Font.Bold = false;
                    lblReferenciaNaoEncontrada.Visible = false;
                    txtPeso.Enabled = m.DePeso;

                    if (!m.DePeso)
                    {
                        txtPeso.Text = m.Peso.ToString();
                        btnAdicionar.Focus();
                    }
                    else txtPeso.Focus();

                    btnAdicionar.Enabled = true;
                    if (!m.DePeso)
                        Image1.ImageUrl = "ObterFoto.aspx?ref=" + m.ReferênciaNumérica;
                    else
                        Image1.ImageUrl = "ObterFoto.aspx?ref=" + m.ReferênciaNumérica + "&peso=" + m.Peso.ToString();
                }
            }
            else
            {
                txtBox.Font.Bold = true;
                lblReferenciaNaoEncontrada.Visible = true;
                txtPeso.Enabled = false;

            }
        }

        protected void txtPeso_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
                            Entidades.Mercadoria.Mercadoria m =
                Entidades.Mercadoria.Mercadoria.ObterMercadoria(txtBox.Text, Entidades.Tabela.TabelaPadrão);
            
            if (m == null)
                return;

            BulletedList1.Items.Add(txtBox.Text + " PESO: " + txtPeso.Text);
            txtBox.Text = "";
            txtPeso.Text = "";
            //txtBox.Focus();
            //Utility.SetFocusOnLoad(txtBox);
            
            double peso;
            if (m.DePeso)
            {
                if (double.TryParse(txtPeso.Text, out peso))
                {
                    totalPeso += peso;
                } else
                {
                    totalPeso += m.Peso;
                }

                lblTotal.Text = "Total de peso: " + Entidades.Mercadoria.Mercadoria.FormatarPeso(totalPeso); 
            }
        }
    }
}
