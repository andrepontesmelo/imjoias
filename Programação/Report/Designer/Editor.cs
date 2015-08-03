/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Report.Layout;

namespace Report.Designer.Editor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Editor : System.Windows.Forms.Form
	{
		private string filename = null;

		// Designer
		private Designer.PageLayoutDesign pageLayoutDesign;
		private System.Windows.Forms.SaveFileDialog saveDlg;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MainMenu menuEditor;
		private System.Windows.Forms.MenuItem menuDelete;
		private System.Windows.Forms.PrintPreviewDialog printPreview;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuPrint;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.MenuItem menuResize;
		private System.ComponentModel.IContainer components = null;

		public Editor()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Editor));
            this.pageLayoutDesign = new Designer.PageLayoutDesign();
			this.saveDlg = new System.Windows.Forms.SaveFileDialog();
			this.menuEditor = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuPrint = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuDelete = new System.Windows.Forms.MenuItem();
			this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.menuResize = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// pageLayoutDesign
			// 
			this.pageLayoutDesign.AutoScroll = true;
			this.pageLayoutDesign.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pageLayoutDesign.Grid = ((System.Drawing.SizeF)(resources.GetObject("pageLayoutDesign.Grid")));
			this.pageLayoutDesign.Location = new System.Drawing.Point(0, 0);
			this.pageLayoutDesign.Name = "pageLayoutDesign";
			this.pageLayoutDesign.Size = new System.Drawing.Size(432, 270);
			this.pageLayoutDesign.TabIndex = 0;
            this.pageLayoutDesign.DoingSomething += new Designer.PageLayoutDesign.DoingSomethingEvent(this.pageLayoutDesign_DoingSomething);
            this.pageLayoutDesign.SelectedItemChanged += new Designer.PageLayoutDesign.SelectedItemChangedEvent(this.pageLayoutDesign_SelectedItemChanged);
			// 
			// saveDlg
			// 
			this.saveDlg.Filter = "Page layout|*.pagelayout";
			// 
			// menuEditor
			// 
			this.menuEditor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuFile,
																					   this.menuItem1});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuPrint});
			this.menuFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.menuFile.Text = "&File";
			// 
			// menuPrint
			// 
			this.menuPrint.Index = 0;
			this.menuPrint.MergeOrder = 2;
			this.menuPrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.menuPrint.Text = "Print...";
			this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuDelete,
																					  this.menuResize});
			this.menuItem1.Text = "&Edit";
			// 
			// menuDelete
			// 
			this.menuDelete.Index = 0;
			this.menuDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuDelete.Text = "Delete";
			this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
			// 
			// printPreview
			// 
			this.printPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreview.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreview.Document = this.printDocument;
			this.printPreview.Enabled = true;
			this.printPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreview.Icon")));
			this.printPreview.Location = new System.Drawing.Point(202, 18);
			this.printPreview.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreview.Name = "printPreview";
			this.printPreview.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreview.UseAntiAlias = true;
			this.printPreview.Visible = false;
			// 
			// printDocument
			// 
			this.printDocument.DocumentName = "Page Layout";
			this.printDocument.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.printDocument_QueryPageSettings);
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
			// 
			// menuResize
			// 
			this.menuResize.Index = 1;
			this.menuResize.Text = "Resize";
			this.menuResize.Click += new System.EventHandler(this.menuResize_Click);
			// 
			// Editor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(432, 270);
			this.Controls.Add(this.pageLayoutDesign);
			this.Menu = this.menuEditor;
			this.Name = "Editor";
			this.Text = "Untitled";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion

        private void pageLayoutDesign_DoingSomething(Designer.PageLayoutDesign sender, Designer.PageLayoutDesign.Doing what)
		{
			((MDI) this.ParentForm).DoingSomething(sender, what);
		}

        private void pageLayoutDesign_SelectedItemChanged(Designer.PageLayoutDesign sender, Report.Layout.Complex.IPrintableItem selection)
		{
			((MDI) this.ParentForm).SelectedItemChanged(sender, selection);
		}

		public PageLayoutDesign PageLayout
		{
			get { return pageLayoutDesign; }
		}

		public void Redraw()
		{
			pageLayoutDesign.Redraw();
		}

		/// <summary>
		/// Page Settings
		/// </summary>
		[Category("Layout")]
		public System.Drawing.Printing.PageSettings PageSettings
		{
			get { return pageLayoutDesign.PageSettings; }
			set { pageLayoutDesign.PageSettings = value; }
		}

		public void LoadFromFile(string filename)
		{
			int idx = filename.LastIndexOf('\\');

			this.Text = idx > 0 ? filename.Substring(idx + 1) : filename;
			
			System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

			using (DocumentLayout doc = new DocumentLayout())
			{
				doc.LoadFromFile(filename, true);
				pageLayoutDesign.PageLayout = doc.Pages[0];
				pageLayoutDesign.Redraw();
			}

			System.Windows.Forms.Cursor.Current = Cursors.Default;
		}

		public void SaveFile()
		{
			if (filename == null)
				SaveAs();
			else
#if (!DEBUG)
				try
				{
#endif
					pageLayoutDesign.PageLayout.SaveToXml(filename);
#if (!DEBUG)
				}
				catch (Exception err)
				{
					MessageBox.Show(this, "Can't write to file " + filename + ". It can be invalid!\n\n" + err.ToString(), "Report Designer", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
#endif
		}

		public void SaveAs()
		{
			if (saveDlg.ShowDialog(this) == DialogResult.OK)
			{
				System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
#if (!DEBUG)
				try
				{
#endif
					pageLayoutDesign.PageLayout.SaveToXml(saveDlg.FileName);
					filename = saveDlg.FileName;
					int idx = filename.LastIndexOf('\\');
					this.Text = idx > 0 ? filename.Substring(idx + 1) : filename;
#if (!DEBUG)
				}
				catch (Exception err)
				{
					MessageBox.Show(this, "Can't write to file " + saveDlg.FileName + ". It can be invalid!\n\n" + err.ToString(), "Report Designer", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					System.Windows.Forms.Cursor.Current = Cursors.Default;;
				}
#else
				System.Windows.Forms.Cursor.Current = Cursors.Default;
#endif
			}
		}

		private void menuDelete_Click(object sender, System.EventArgs e)
		{
			pageLayoutDesign.Delete();
		}

		private void menuPrint_Click(object sender, System.EventArgs e)
		{
			if (printPreview.ShowDialog(this) == DialogResult.OK)
				printDocument.Print();
		}

		private void printDocument_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
		{
			e.PageSettings = pageLayoutDesign.PageSettings;
		}

		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			pageLayoutDesign.PageLayout.Print(e.Graphics, null);
			e.HasMorePages = false;
		}

		private void menuResize_Click(object sender, System.EventArgs e)
		{
			pageLayoutDesign.ResizePage();
		}
	}
}
