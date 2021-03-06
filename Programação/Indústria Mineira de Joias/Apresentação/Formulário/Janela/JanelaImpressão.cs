using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public partial class JanelaImpressão : JanelaExplicativa
    {
        private List<ReportClass> documentos;

        public JanelaImpressão()
        {
            InitializeComponent();
            Título = "Visualização de Impressão ";
            Descrição = "";

            documentos = new List<ReportClass>();
        }

        public CrystalReportViewer InserirDocumento(ReportClass documento, string texto)
        {
            AguardeDB.Mostrar();

            // Insere documento na lista
            documentos.Add(documento);

            // Insere controles
            CrystalReportViewer novoViewer;
            TabPage novaTab;

            novoViewer = new CrystalReportViewer();
            novaTab = new TabPage();
            tabControl.TabPages.Add(novaTab);
            tabControl.SuspendLayout();
            novaTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // visualizador
            // 
            novoViewer.ActiveViewIndex = -1;
            novoViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            novoViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            novoViewer.EnableDrillDown = false;
            novoViewer.Location = new System.Drawing.Point(0, 0);
            novoViewer.Name = "visualizador";
            novoViewer.SelectionFormula = "";
            novoViewer.ShowCloseButton = false;
            novoViewer.ShowExportButton = false;
            novoViewer.ShowGotoPageButton = false;
            novoViewer.ShowGroupTreeButton = false;
            novoViewer.ShowPrintButton = false;
            novoViewer.ShowRefreshButton = false;
            novoViewer.ShowTextSearchButton = false;
            novoViewer.Size = new System.Drawing.Size(709, 210);
            novoViewer.TabIndex = 0;
            novoViewer.ViewTimeSelectionFormula = "";

            novaTab.Controls.Add(novoViewer);
            novaTab.Location = new System.Drawing.Point(4, 22);
            novaTab.Padding = new System.Windows.Forms.Padding(3);
            novaTab.Size = new System.Drawing.Size(709, 210);
            novaTab.TabIndex = 0;
            novaTab.Text = texto;
            novaTab.UseVisualStyleBackColor = true;
            this.tabControl.ResumeLayout(false);
            novaTab.ResumeLayout(false);
            this.ResumeLayout(false);
            novoViewer.ReportSource = documento;

            AguardeDB.Fechar();

            return novoViewer;
        }

        public string Descrição
        {
            set { lblDescrição.Text = value; }
        }

        public string Título
        {
            set { lblTítulo.Text = value; }
        }

        public void Abrir(IWin32Window owner)
        {
            ShowDialog(owner);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDialog.AllowSelection = (documentos.Count == 1);

            DialogResult resultado = printDialog.ShowDialog(this);

            if (resultado == DialogResult.OK)
            {
                Imprimir();
                Close();
            }
        }

        private void Imprimir()
        {
            AguardeDB.Mostrar();

            foreach (ReportClass documento in documentos)
            {
                documento.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                documento.PrintToPrinter(printDialog.PrinterSettings.Copies, false,
                    printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            }


            AguardeDB.Fechar();

            ApósImpresso();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void ApósImpresso()
        {
        }
    }
}

