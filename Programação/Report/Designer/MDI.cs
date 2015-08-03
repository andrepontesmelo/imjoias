/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Report.Layout.Complex;

namespace Report.Designer.Editor
{
	/// <summary>
	/// Summary description for MDI.
	/// </summary>
	public class MDI : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.ToolBarButton toggleStaticLabel;
		private System.Windows.Forms.ToolBarButton toggleTextMapped;
		private System.Windows.Forms.ToolBarButton toggleImageMapped;
		private System.Windows.Forms.ToolBarButton toggleLabelTextMapped;
		private System.Windows.Forms.ToolBarButton togglePointer;
		private System.Windows.Forms.ImageList toggleIcons;
		private System.Windows.Forms.ToolBar toggleButtons;
		private System.Windows.Forms.Panel panelProperties;
		private System.Windows.Forms.Splitter splitterProperties;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList toolBarIcons;
		private System.Windows.Forms.ToolBarButton cmdNew;
		private System.Windows.Forms.ToolBarButton cmdOpen;
		private System.Windows.Forms.ToolBarButton cmdSave;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuNew;
		private System.Windows.Forms.MenuItem menuOpen;
		private System.Windows.Forms.MenuItem menuSave;
		private System.Windows.Forms.MenuItem menuSaveAs;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.OpenFileDialog openDlg;
		private System.Windows.Forms.PageSetupDialog pageSetupDlg;
		private System.Windows.Forms.MenuItem menuNewPage;
		private System.Windows.Forms.MenuItem menuNewLabel;
		private System.Windows.Forms.MenuItem menuNewItem;
		private System.ComponentModel.IContainer components;

		public MDI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			pageSetupDlg.PageSettings = new System.Drawing.Printing.PageSettings();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MDI));
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.cmdNew = new System.Windows.Forms.ToolBarButton();
			this.cmdOpen = new System.Windows.Forms.ToolBarButton();
			this.cmdSave = new System.Windows.Forms.ToolBarButton();
			this.toolBarIcons = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuNew = new System.Windows.Forms.MenuItem();
			this.menuOpen = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuSave = new System.Windows.Forms.MenuItem();
			this.menuSaveAs = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.toggleButtons = new System.Windows.Forms.ToolBar();
			this.togglePointer = new System.Windows.Forms.ToolBarButton();
			this.toggleStaticLabel = new System.Windows.Forms.ToolBarButton();
			this.toggleTextMapped = new System.Windows.Forms.ToolBarButton();
			this.toggleImageMapped = new System.Windows.Forms.ToolBarButton();
			this.toggleLabelTextMapped = new System.Windows.Forms.ToolBarButton();
			this.toggleIcons = new System.Windows.Forms.ImageList(this.components);
			this.panelProperties = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.splitterProperties = new System.Windows.Forms.Splitter();
			this.openDlg = new System.Windows.Forms.OpenFileDialog();
			this.pageSetupDlg = new System.Windows.Forms.PageSetupDialog();
			this.menuNewPage = new System.Windows.Forms.MenuItem();
			this.menuNewLabel = new System.Windows.Forms.MenuItem();
			this.menuNewItem = new System.Windows.Forms.MenuItem();
			this.panelProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBar
			// 
			this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.cmdNew,
																					   this.cmdOpen,
																					   this.cmdSave});
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.toolBarIcons;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(584, 28);
			this.toolBar.TabIndex = 3;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// cmdNew
			// 
			this.cmdNew.ImageIndex = 0;
			this.cmdNew.ToolTipText = "New";
			// 
			// cmdOpen
			// 
			this.cmdOpen.ImageIndex = 1;
			this.cmdOpen.ToolTipText = "Open...";
			// 
			// cmdSave
			// 
			this.cmdSave.ImageIndex = 2;
			this.cmdSave.ToolTipText = "Save";
			// 
			// toolBarIcons
			// 
			this.toolBarIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.toolBarIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolBarIcons.ImageStream")));
			this.toolBarIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFile});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuNew,
																					 this.menuOpen,
																					 this.menuItem4,
																					 this.menuSave,
																					 this.menuSaveAs,
																					 this.menuItem7,
																					 this.menuExit});
			this.menuFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.menuFile.Text = "&File";
			// 
			// menuNew
			// 
			this.menuNew.Index = 0;
			this.menuNew.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuNewPage,
																					this.menuNewLabel,
																					this.menuNewItem});
			this.menuNew.Text = "&New";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuOpen
			// 
			this.menuOpen.Index = 1;
			this.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuOpen.Text = "&Open...";
			this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.MergeOrder = 1;
			this.menuItem4.Text = "-";
			// 
			// menuSave
			// 
			this.menuSave.Index = 3;
			this.menuSave.MergeOrder = 1;
			this.menuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuSave.Text = "&Save";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuSaveAs
			// 
			this.menuSaveAs.Index = 4;
			this.menuSaveAs.MergeOrder = 2;
			this.menuSaveAs.Text = "Save &As...";
			this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 5;
			this.menuItem7.MergeOrder = 99;
			this.menuItem7.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 6;
			this.menuExit.MergeOrder = 99;
			this.menuExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// toggleButtons
			// 
			this.toggleButtons.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toggleButtons.AutoSize = false;
			this.toggleButtons.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							 this.togglePointer,
																							 this.toggleStaticLabel,
																							 this.toggleTextMapped,
																							 this.toggleImageMapped,
																							 this.toggleLabelTextMapped});
			this.toggleButtons.ButtonSize = new System.Drawing.Size(140, 22);
			this.toggleButtons.Dock = System.Windows.Forms.DockStyle.Left;
			this.toggleButtons.DropDownArrows = true;
			this.toggleButtons.ImageList = this.toggleIcons;
			this.toggleButtons.Location = new System.Drawing.Point(0, 28);
			this.toggleButtons.Name = "toggleButtons";
			this.toggleButtons.ShowToolTips = true;
			this.toggleButtons.Size = new System.Drawing.Size(141, 357);
			this.toggleButtons.TabIndex = 4;
			this.toggleButtons.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toggleButtons.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toggleButtons_ButtonClick);
			// 
			// togglePointer
			// 
			this.togglePointer.ImageIndex = 0;
			this.togglePointer.Pushed = true;
			this.togglePointer.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.togglePointer.Text = "Pointer";
			// 
			// toggleStaticLabel
			// 
			this.toggleStaticLabel.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.toggleStaticLabel.Text = "Text";
			// 
			// toggleTextMapped
			// 
			this.toggleTextMapped.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.toggleTextMapped.Text = "Text data field";
			// 
			// toggleImageMapped
			// 
			this.toggleImageMapped.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.toggleImageMapped.Text = "Image data field";
			// 
			// toggleLabelTextMapped
			// 
			this.toggleLabelTextMapped.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.toggleLabelTextMapped.Text = "Label and text data field";
			// 
			// toggleIcons
			// 
			this.toggleIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.toggleIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toggleIcons.ImageStream")));
			this.toggleIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panelProperties
			// 
			this.panelProperties.Controls.Add(this.label1);
			this.panelProperties.Controls.Add(this.propertyGrid);
			this.panelProperties.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelProperties.Location = new System.Drawing.Point(392, 28);
			this.panelProperties.Name = "panelProperties";
			this.panelProperties.Size = new System.Drawing.Size(192, 357);
			this.panelProperties.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Properties of Printable Item";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// propertyGrid
			// 
			this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid.CommandsVisibleIfAvailable = true;
			this.propertyGrid.LargeButtons = false;
			this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid.Location = new System.Drawing.Point(0, 16);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(192, 342);
			this.propertyGrid.TabIndex = 0;
			this.propertyGrid.Text = "Properties";
			this.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
			// 
			// splitterProperties
			// 
			this.splitterProperties.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitterProperties.Location = new System.Drawing.Point(389, 28);
			this.splitterProperties.Name = "splitterProperties";
			this.splitterProperties.Size = new System.Drawing.Size(3, 357);
			this.splitterProperties.TabIndex = 7;
			this.splitterProperties.TabStop = false;
			this.splitterProperties.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.spliterProperties_SplitterMoved);
			// 
			// openDlg
			// 
			this.openDlg.DefaultExt = "pagelayout";
			this.openDlg.Filter = "Page Layout|*.pagelayout|Xml Files|*.xml|All files|*.*";
			// 
			// pageSetupDlg
			// 
			this.pageSetupDlg.AllowMargins = false;
			this.pageSetupDlg.AllowPrinter = false;
			this.pageSetupDlg.ShowNetwork = false;
			// 
			// menuNewPage
			// 
			this.menuNewPage.Index = 0;
			this.menuNewPage.Text = "Page";
			this.menuNewPage.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuNewLabel
			// 
			this.menuNewLabel.Enabled = false;
			this.menuNewLabel.Index = 1;
			this.menuNewLabel.Text = "Label";
			this.menuNewLabel.Click += new System.EventHandler(this.menuNewLabel_Click);
			// 
			// menuNewItem
			// 
			this.menuNewItem.Index = 2;
			this.menuNewItem.Text = "Item";
			this.menuNewItem.Click += new System.EventHandler(this.menuNewItem_Click);
			// 
			// MDI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 385);
			this.Controls.Add(this.splitterProperties);
			this.Controls.Add(this.panelProperties);
			this.Controls.Add(this.toggleButtons);
			this.Controls.Add(this.toolBar);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "MDI";
			this.Text = "Report Designer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panelProperties.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			MDI mdi = new MDI();

			Application.Run(mdi);
		}

		private void toggleButtons_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			Editor editor = this.ActiveMdiChild as Editor;

			foreach (ToolBarButton button in toggleButtons.Buttons)
				if (button != e.Button)
					button.Pushed = false;

			if (editor == null)
				return;

			if (e.Button == toggleStaticLabel)
				editor.PageLayout.Insert(typeof(StaticLabel));

			else if (e.Button == toggleTextMapped)
				editor.PageLayout.Insert(typeof(TextMapped));

			else if (e.Button == toggleImageMapped)
				editor.PageLayout.Insert(typeof(ImageMapped));

			else if (e.Button == toggleLabelTextMapped)
				editor.PageLayout.Insert(typeof(LabelTextMapped));

			else if (e.Button == togglePointer)
				editor.PageLayout.SetPointer(true);
		}

		/// <summary>
		/// Occurs when PageLayoutDesign raise an user action event
		/// </summary>
		public void DoingSomething(Report.Designer.PageLayoutDesign sender, Report.Designer.PageLayoutDesign.Doing what)
		{
			switch (what)
			{
				case PageLayoutDesign.Doing.Nothing:
					foreach (ToolBarButton button in toggleButtons.Buttons)
						button.Pushed = false;

					togglePointer.Pushed = true;
					break;
			}
		}

		/// <summary>
		/// Occurs when a selection is made
		/// </summary>
		public void SelectedItemChanged(Report.Designer.PageLayoutDesign sender, Report.Layout.Complex.IPrintableItem selection)
		{
			if (selection == null)
				propertyGrid.SelectedObject = sender.PageLayout;
			else
				propertyGrid.SelectedObject = selection;
		}

		private void spliterProperties_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
		{
			panelProperties.Width = Width - e.SplitX;
		}

		private void propertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			Editor editor;

			editor = this.ActiveMdiChild as Editor;

			if (editor != null)
				editor.Redraw();
		}

		private void menuNew_Click(object sender, System.EventArgs e)
		{
			if (pageSetupDlg.ShowDialog(this) == DialogResult.OK)
			{
				Editor editor = new Editor();

				editor.PageSettings = pageSetupDlg.PageSettings;

				editor.MdiParent = this;
				editor.Show();
			}
		}

		private void menuOpen_Click(object sender, System.EventArgs e)
		{
			if (openDlg.ShowDialog(this) == DialogResult.OK)
			{
				Editor editor = new Editor();
#if (!DEBUG)
				try
				{
#endif
					editor.LoadFromFile(openDlg.FileName);
					editor.MdiParent = this;
					editor.Show();
#if (!DEBUG)
				}
				catch (Exception err)
				{
					editor.Dispose();
					MessageBox.Show(this, "Can't read from file " + openDlg.FileName + ". It can be invalid!\n\n" + err.ToString(), "Report Designer", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
#endif
			}
		}

		private void menuSave_Click(object sender, System.EventArgs e)
		{
			Editor editor;

			editor = this.ActiveMdiChild as Editor;

			editor.SaveFile();
		}

		private void menuSaveAs_Click(object sender, System.EventArgs e)
		{
			Editor editor;

			editor = this.ActiveMdiChild as Editor;

			editor.SaveAs();		
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == cmdNew)
				menuNew_Click(this, null);
			else if (e.Button == cmdOpen)
				menuOpen_Click(this, null);
			else if (e.Button == cmdSave)
				menuSave_Click(this, null);
		}

		private void menuNewLabel_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuNewItem_Click(object sender, System.EventArgs e)
		{
			Editor editor = new Editor();

			editor.PageLayout.PageLayout = new ItemLayout();

			editor.MdiParent = this;
			editor.Show();
		}
	}
}
