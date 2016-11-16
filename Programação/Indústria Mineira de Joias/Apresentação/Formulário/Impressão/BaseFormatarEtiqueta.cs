using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using System.Globalization;
using System.Drawing.Printing;

namespace Apresentação.Formulários.Impressão
{
    public partial class BaseFormatarEtiqueta : BaseInferior
    {
        public BaseFormatarEtiqueta()
        {
            InitializeComponent();

            labelLayout.Items.Add(layoutEtiqueta);
        }

        private void propriedades_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            layoutDesign.Redraw();
        }

        /// <summary>
        /// Ocorre ao teclar em campo numérico. Somente números e
        /// separador de decimais são aceitos.
        /// </summary>
        private void AoDigitarNúmeros(object sender, KeyPressEventArgs e)
        {
			if (e.KeyChar == '.' || e.KeyChar == ',')
			{
				e.Handled = true;

				((TextBox) sender).SelectedText = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
			}
			else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
				e.Handled = true;		
        }

        #region Mapeamento de propriedades do labelLayout para o formulário

        private void txtMargemSuperior_Validated(object sender, System.EventArgs e)
        {
            labelLayout.MarginTop = float.Parse(txtMargemSuperior.Text, NumberFormatInfo.CurrentInfo);
        }

        private void txtMargemEsquerda_Validated(object sender, System.EventArgs e)
        {
            labelLayout.MarginLeft = float.Parse(txtMargemEsquerda.Text, NumberFormatInfo.CurrentInfo);
        }

        private void txtMargemInferior_Validated(object sender, System.EventArgs e)
        {
            labelLayout.MarginBottom = float.Parse(txtMargemInferior.Text, NumberFormatInfo.CurrentInfo);
        }

        private void txtMargemDireita_Validated(object sender, System.EventArgs e)
        {
            labelLayout.MarginRight = float.Parse(txtMargemDireita.Text, NumberFormatInfo.CurrentInfo);
        }

        private void txtEspaçamentoHorizontal_Validated(object sender, System.EventArgs e)
        {
            labelLayout.GapHorizontal = float.Parse(txtEspaçamentoHorizontal.Text, NumberFormatInfo.CurrentInfo);
        }

        private void txtEspaçamentoVertical_Validated(object sender, System.EventArgs e)
        {
            labelLayout.GapVertical = float.Parse(txtEspaçamentoVertical.Text, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Ocorre ao validar o tamanho da etiqueta
        /// </summary>
        private void Tamanho_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (sender == txtLargura)
                    layoutEtiqueta.Width = float.Parse(txtLargura.Text, NumberFormatInfo.CurrentInfo);
                else if (sender == txtAltura)
                    layoutEtiqueta.Height = float.Parse(txtAltura.Text, NumberFormatInfo.CurrentInfo);

                layoutDesign.ResizePage();
                layoutDesign.Redraw();

                e.Cancel = false;
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void txtLarguraFolha_Validated(object sender, System.EventArgs e)
        {
            if (labelLayout.PaperSize.Kind != PaperKind.Custom)
                labelLayout.PaperSize = new PaperSize("Personalizado", (int)(float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f), (int)(float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f));
            else
                try
                {
                    labelLayout.PaperSize.Width = (int)(float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f);
                }
                catch
                {
                    labelLayout.PaperSize = new PaperSize("Personalizado", (int)(float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f), (int)(float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f));
                }
        }

        private void txtAlturaFolha_Validated(object sender, System.EventArgs e)
        {
            if (labelLayout.PaperSize.Kind != PaperKind.Custom)
                labelLayout.PaperSize = new PaperSize("Personalizado", (int)(float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f), (int)(float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f));
            else
                try
                {
                    labelLayout.PaperSize.Height = (int)(float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f);
                }
                catch
                {
                    labelLayout.PaperSize = new PaperSize("Personalizado", (int)(float.Parse(txtLarguraFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f), (int)(float.Parse(txtAlturaFolha.Text, NumberFormatInfo.CurrentInfo) / 0.0254f));
                }
        }

        #endregion
    }
}
