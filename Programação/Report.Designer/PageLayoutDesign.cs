/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Report.Layout.Complex;
using Report.Layout;

namespace Report.Designer
{
	public class PageLayoutDesign : System.Windows.Forms.UserControl
	{
		// Attributes
		private Metric.Metrics	metric = Metric.Metrics.cm;
		private Pen				penPosition = Pens.Aquamarine;
		private Brush			selectedItemBrush = new SolidBrush(Color.FromArgb(50, Color.Aquamarine));
		private GraphicsUnit	unit = GraphicsUnit.Millimeter;
		private Brush			selectedBorderBrush = Brushes.Black;
		private float			dpi;
		private SizeF			grid = new SizeF(1, 1);

		// Events
		public delegate void DoingSomethingEvent(PageLayoutDesign sender, Doing what);
		public event DoingSomethingEvent DoingSomething;

		public delegate void SelectedItemChangedEvent(PageLayoutDesign sender, IPrintableItem selection);
		public event SelectedItemChangedEvent SelectedItemChanged;

		// Runtime
		private Point			_lastPosition;			// Last mouse position

		// Runtime - Action operation
		private Bitmap			_bmp;
		private Type			_toInsert = null;
		private SizeF			_toInsertSize = new SizeF(50, 9);
		private Doing			_doing = Doing.Nothing;
		public enum Doing
		{
			Nothing, Inserting, Moving, ResizeTopLeft, ResizeTopMiddle,
			ResizeTopRight, ResizeMiddleRight, ResizeBottomRight,
			ResizeBottomMiddle, ResizeBottomLeft, ResizeMiddleLeft
		};

		// Runtime - Selection
		private IPrintableItem  _selectedItem = null;
		private RectangleF []	_selectionEdges;
		private bool			_selectable = true;		// If pointer can select
		private Size			_selectionDistance;		// Distance of selection from mouse position
		private enum SelectionEdge
		{
			TopLeft, TopMiddle, TopRight, MiddleRight, BottomRight,
			BottomMiddle, BottomLeft, MiddleLeft
		}

		// Designer
		private System.Windows.Forms.PictureBox picPage;
		private Report.Designer.Ruler vRuler;
        private Report.Designer.Ruler hRuler;
        private ILayout pageLayout;
		private System.ComponentModel.IContainer components;

		public PageLayoutDesign()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			using (Graphics g = picPage.CreateGraphics())
				dpi = g.DpiX;

			pageLayout.DesignMode = true;
			penPosition = new Pen(Brushes.Aquamarine, 1f / dpi);
		}

		private void PageLayoutDesign_Load(object sender, System.EventArgs e)
		{
			if (!DesignMode)
			{
				_bmp = new Bitmap(picPage.Width, picPage.Height);

				pageLayout.DesignMode = true;

				Redraw();
			}
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageLayoutDesign));
            Report.Layout.MetricCentimeter metricCentimeter4 = new Report.Layout.MetricCentimeter();
            this.picPage = new System.Windows.Forms.PictureBox();
            this.vRuler = new Report.Designer.Ruler();
            this.hRuler = new Report.Designer.Ruler();
            this.pageLayout = new Report.Layout.Complex.PageLayout(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).BeginInit();
            this.SuspendLayout();
            // 
            // picPage
            // 
            this.picPage.BackColor = System.Drawing.Color.White;
            this.picPage.Location = new System.Drawing.Point(24, 24);
            this.picPage.Name = "picPage";
            this.picPage.Size = new System.Drawing.Size(464, 288);
            this.picPage.TabIndex = 5;
            this.picPage.TabStop = false;
            this.picPage.MouseLeave += new System.EventHandler(this.picPage_MouseLeave);
            this.picPage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPage_MouseDown);
            this.picPage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPage_MouseMove);
            this.picPage.Paint += new System.Windows.Forms.PaintEventHandler(this.picPage_Paint);
            this.picPage.Resize += new System.EventHandler(this.picPage_Resize);
            this.picPage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPage_MouseUp);
            // 
            // vRuler
            // 
            this.vRuler.FarDistance = 0F;
            this.vRuler.Location = new System.Drawing.Point(0, 24);
            this.vRuler.Name = "vRuler";
            this.vRuler.NearDistance = 0F;
            this.vRuler.RulerOrientation = Report.Designer.Ruler.Orientation.Vertical;
            this.vRuler.Size = new System.Drawing.Size(24, 288);
            this.vRuler.TabIndex = 4;
            this.vRuler.Unit = System.Drawing.GraphicsUnit.Millimeter;
            // 
            // hRuler
            // 
            this.hRuler.BackColor = System.Drawing.SystemColors.Control;
            this.hRuler.FarDistance = 0F;
            this.hRuler.Location = new System.Drawing.Point(24, 0);
            this.hRuler.Name = "hRuler";
            this.hRuler.NearDistance = 0F;
            this.hRuler.Size = new System.Drawing.Size(464, 24);
            this.hRuler.TabIndex = 3;
            this.hRuler.Unit = System.Drawing.GraphicsUnit.Millimeter;
            // 
            // pageLayout
            // 
            this.pageLayout.DefaultAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.pageLayout.DefaultMetric = metricCentimeter4;
            this.pageLayout.DefaultTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            // 
            // PageLayoutDesign
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.picPage);
            this.Controls.Add(this.vRuler);
            this.Controls.Add(this.hRuler);
            this.Name = "PageLayoutDesign";
            this.Size = new System.Drawing.Size(488, 312);
            this.Load += new System.EventHandler(this.PageLayoutDesign_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PageLayoutDesign_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Properties

		/// <summary>
		/// What're user doing
		/// </summary>
		[Browsable(false)]
		public Doing WhatsDoing
		{
			get { return _doing; }
		}

		/// <summary>
		/// Selected item
		/// </summary>
		[Browsable(false)]
		public IPrintableItem SelectedItem
		{
			get
			{
				return this._selectedItem;
			}
		}

		/// <summary>
		/// Unit of measure
		/// </summary>
		[DefaultValue(Metric.Metrics.cm)]
		public Metric.Metrics Unit
		{
			get { return metric; }
			set
			{
				metric = value;

				switch (metric)
				{
					case Metric.Metrics.cm:
						unit = hRuler.Unit = vRuler.Unit = GraphicsUnit.Millimeter;
						break;

					case Metric.Metrics.inch:
						unit = hRuler.Unit = vRuler.Unit = GraphicsUnit.Inch;
						break;
				}

				using (Graphics g = picPage.CreateGraphics())
					dpi = g.DpiX;

				Redraw();
			}
		}

		/// <summary>
		/// Page layout
		/// </summary>
		public ILayout PageLayout
		{
			get { return pageLayout; }
			set
			{
				components.Remove(pageLayout);

				pageLayout = value;

				components.Add(pageLayout);

				if (!this.DesignMode)
				{
					ResizePage();
				}
			}
		}

		public void ResizePage()
		{
			if (pageLayout is PageLayout && ((PageLayout) pageLayout).PageSettings.Landscape)
			{
				hRuler.SetSize((int) pageLayout.Size.Height);
				vRuler.SetSize((int) pageLayout.Size.Width);
			}
			else
			{
				hRuler.SetSize((int) pageLayout.Size.Width);
				vRuler.SetSize((int) pageLayout.Size.Height);
			}

			picPage.Width = hRuler.Width;
			picPage.Height = vRuler.Height;
		}

		/// <summary>
		/// Grid
		/// </summary>
		public SizeF Grid
		{
			get { return grid; }
			set { grid = value; }
		}

		#endregion

		#region Action

		/// <summary>
		/// Do something
		/// </summary>
		/// <param name="what">What to do</param>
		private void Do(Doing what)
		{
			_doing = what;

			if (DoingSomething != null)
				DoingSomething(this, what);
		}

		/// <summary>
		/// Insert a type into page layout
		/// </summary>
		/// <param name="type">Type to be inserted</param>
		public void Insert(Type type)
		{
			SelectItem(null);
			Do(Doing.Inserting);
			_toInsert = type;
			_selectable = false;
			picPage.Cursor = Cursors.Cross;
			_selectionDistance = new Size(0, 0);
		}

		/// <summary>
		/// Insert a printable item
		/// </summary>
		private void Insert(float x, float y)
		{
			IPrintableItem item;

			// Creates an object
			item = (IPrintableItem)
				Assembly.GetAssembly(_toInsert).CreateInstance(_toInsert.FullName);

			// Set attributes
			item.DesignMode = true;
			item.SetDefault(pageLayout);
			item.Location = new RectangleF(x, y, _toInsertSize.Width, _toInsertSize.Height);

			// Add to pagelayout
			pageLayout.Items.Add(item);

			// Draw it
			Redraw();

			// Set "item" as the selected item
			SelectItem(item);
		}

		/// <summary>
		/// Moves selected object
		/// </summary>
		private new void Move(float x, float y)
		{
			_selectedItem.Location = new RectangleF(
				x, y,
				_selectedItem.Location.Width, _selectedItem.Location.Height);
//			SelectItem(_selectedItem);
			Redraw();
		}

		/// <summary>
		/// Selects an item
		/// </summary>
		/// <param name="item">Item to select</param>
		private void SelectItem(IPrintableItem item)
		{
			SelectItem(item, true);
		}

		private void SelectItem(IPrintableItem item, bool redraw)
		{
			const int sizeSelectionMark = 8;

			this._selectedItem = item;

			// First, redraw
			if (redraw)
				Redraw();

			#region Create selection marks

			if (item != null)
			{
				using (Graphics g = Graphics.FromImage(_bmp))
				{
					g.PageUnit = unit;
					float markHSize = hRuler.Convert(sizeSelectionMark);
					float markVSize = vRuler.Convert(sizeSelectionMark);

					// Calculates selection edges
					_selectionEdges = new RectangleF[8];

					_selectionEdges[(int) SelectionEdge.TopLeft] =
						new RectangleF(
							item.Location.X - markHSize / 2,
							item.Location.Y - markVSize / 2,
							markHSize,
							markVSize);

					_selectionEdges[(int) SelectionEdge.TopRight] =
						new RectangleF(
							item.Location.X - markHSize / 2 + item.Location.Width,
							item.Location.Y - markVSize / 2,
							markHSize,
							markVSize);

					_selectionEdges[(int) SelectionEdge.BottomRight] =
						new RectangleF(
							item.Location.X - markHSize / 2 + item.Location.Width,
							item.Location.Y - markVSize / 2 + item.Location.Height,
							markHSize,
							markVSize);

					_selectionEdges[(int) SelectionEdge.BottomLeft] =
						new RectangleF(
							item.Location.X - markHSize / 2,
							item.Location.Y - markVSize / 2 + item.Location.Height,
							markHSize,
							markVSize);

					_selectionEdges[(int) SelectionEdge.MiddleLeft] =
						new RectangleF(
							item.Location.X - markHSize / 2,
							item.Location.Y + item.Location.Height / 2 - markVSize / 2,
							markHSize,
							markVSize);

					_selectionEdges[(int) SelectionEdge.TopMiddle] =
						new RectangleF(
							item.Location.X + item.Location.Width / 2 - markHSize / 2,
							item.Location.Y - markVSize / 2,
							markHSize,
							markVSize);

					_selectionEdges[(int) SelectionEdge.MiddleRight] =
						new RectangleF(
							item.Location.X + item.Location.Width - markHSize / 2,
							item.Location.Y + item.Location.Height / 2 - markVSize / 2,
							markHSize,
							markVSize);
						
					_selectionEdges[(int) SelectionEdge.BottomMiddle] =
						new RectangleF(
							item.Location.X + item.Location.Width / 2 - markHSize / 2,
							item.Location.Y + item.Location.Height - markVSize / 2,
							markHSize,
							markVSize);

					// Draw selection mark
					g.FillRectangle(selectedItemBrush, item.Location);

					foreach (RectangleF mark in _selectionEdges)
						g.FillRectangle(Brushes.Black, mark);

					Refresh();

					_selectable = true;
				}
			}

			#endregion

			if (SelectedItemChanged != null)
				SelectedItemChanged(this, item);
		}

		/// <summary>
		/// Set pointer
		/// </summary>
		/// <param name="selectable">If can select</param>
		public void SetPointer(bool selectable)
		{
			_toInsert = null;
			_selectable = selectable;
			Do(Doing.Nothing);
		}

		/// <summary>
		/// Resizes a selected item
		/// </summary>
		private new void Resize(float x, float y)
		{
			#region Do resize

			switch (_doing)
			{
				case Doing.ResizeTopLeft:
					_selectedItem.Location = new RectangleF(
						x,
						y,
						_selectedItem.Location.X - x + _selectedItem.Location.Width,
						_selectedItem.Location.Y - y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeTopMiddle:
					_selectedItem.Location = new RectangleF(
						_selectedItem.Location.X,
						y,
						_selectedItem.Location.Width,
						_selectedItem.Location.Y - y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeTopRight:
					_selectedItem.Location = new RectangleF(
						_selectedItem.Location.X,
						y,
						x - _selectedItem.Location.X,
						_selectedItem.Location.Y - y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeMiddleRight:
					_selectedItem.Location = new RectangleF(
						_selectedItem.Location.X,
						_selectedItem.Location.Y,
						x - _selectedItem.Location.X,
						_selectedItem.Location.Height);
					break;

				case Doing.ResizeBottomRight:
					_selectedItem.Location = new RectangleF(
						_selectedItem.Location.X,
						_selectedItem.Location.Y,
						x - _selectedItem.Location.X,
						y - _selectedItem.Location.Y);
					break;

				case Doing.ResizeBottomMiddle:
					_selectedItem.Location = new RectangleF(
						_selectedItem.Location.X,
						_selectedItem.Location.Y,
						_selectedItem.Location.Width,
						y - _selectedItem.Location.Y);
					break;

				case Doing.ResizeBottomLeft:
					_selectedItem.Location = new RectangleF(
						x,
						_selectedItem.Location.Y,
						_selectedItem.Location.X - x + _selectedItem.Location.Width,
						y - _selectedItem.Location.Y);
					break;

				case Doing.ResizeMiddleLeft:
					_selectedItem.Location = new RectangleF(
						x,
						_selectedItem.Location.Y,
						_selectedItem.Location.X - x + _selectedItem.Location.Width,
						_selectedItem.Location.Height);
					break;
			}

			#endregion

			Redraw();
		}

		public void Delete()
		{
			if (_selectedItem != null)
			{
				pageLayout.Items.Remove(_selectedItem);
				Redraw();
				SelectItem(null);
			}
		}

		#endregion

		#region Drawing

		/// <summary>
		/// Draws pagelayout into a Image
		/// </summary>
		public void Redraw()
		{
			if (!DesignMode && _bmp != null)
			{
				using (Graphics g = Graphics.FromImage(_bmp))
				{
					//				Graphics g = picPage.CreateGraphics();

					g.FillRectangle(Brushes.White, 0, 0, picPage.Width, picPage.Height);

					g.PageUnit = unit;

					pageLayout.Print(g, null);
					
					if (_selectedItem != null)
						SelectItem(_selectedItem, false);

					this.Refresh();
				}
			}
		}

		/// <summary>
		/// Draw bitmap
		/// </summary>
		/// 
		#endregion

		#region picPage events

		private void picPage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!DesignMode)
			{
				if (_selectedItem != null)
				{
					float x, y;

					x = hRuler.Convert(e.X);
					y = vRuler.Convert(e.Y);

					#region Resize operation check

					// Check if mouse is over selection mark
					for (int i = 0; i < _selectionEdges.Length; i++)
					{
						RectangleF selection = _selectionEdges[i];

						if (selection.Left <= x && selection.Right >= x &&
							selection.Top <= y && selection.Bottom >= y)
						{
							_selectionDistance = new Size(0, 0);

							// Check wich selection mark is pointed
							switch ((SelectionEdge) i)
							{
								case SelectionEdge.TopLeft:
									Do(Doing.ResizeTopLeft);
									break;

								case SelectionEdge.BottomRight:
									Do(Doing.ResizeBottomRight);
									break;

								case SelectionEdge.TopRight:
									Do(Doing.ResizeTopRight);
									break;

								case SelectionEdge.BottomLeft:
									Do(Doing.ResizeBottomLeft);
									break;

								case SelectionEdge.TopMiddle:
									Do(Doing.ResizeTopMiddle);
									break;

								case SelectionEdge.BottomMiddle:
									Do(Doing.ResizeBottomMiddle);
									break;

								case SelectionEdge.MiddleLeft:
									Do(Doing.ResizeMiddleLeft);
									break;

								case SelectionEdge.MiddleRight:
									Do(Doing.ResizeMiddleRight);
									break;
							}

							_selectable = false;
							break;
						}
					}

					#endregion
				}

				#region Select operation

				if (_selectable)
				{
					// Check if some item is being selected
					IPrintableItem selection;

					selection = pageLayout.Items[hRuler.Convert(e.X), vRuler.Convert(e.Y)];

					SelectItem(selection);

					_lastPosition = new Point(e.X, e.Y);

					if (selection != null)
						_selectionDistance = new Size(
							(int) (selection.Location.X * dpi / Ruler.GetFactorConvert(unit)) - e.X,
							(int) (selection.Location.Y * dpi / Ruler.GetFactorConvert(unit)) - e.Y);
				}

				#endregion
			}
		}

		private void picPage_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!DesignMode)
			{
				PointF realWorldPosition;

				// Get real-world position
				realWorldPosition = AlignToGrid(
					hRuler.Convert(e.X + _selectionDistance.Width),
					vRuler.Convert(e.Y + _selectionDistance.Height));

				// Check what're user doing
				switch (_doing)
				{
					case Doing.Inserting:
						_selectionDistance = new Size(0, 0);
						Insert(realWorldPosition.X, realWorldPosition.Y);
						Do(Doing.Nothing);
						picPage.Cursor = Cursors.Default;
						break;

					case Doing.Moving:
						Move(realWorldPosition.X, realWorldPosition.Y);
						Do(Doing.Nothing);
						picPage.Cursor = Cursors.Default;
						break;

					case Doing.ResizeTopLeft:
					case Doing.ResizeTopMiddle:
					case Doing.ResizeTopRight:
					case Doing.ResizeMiddleRight:
					case Doing.ResizeBottomRight:
					case Doing.ResizeBottomMiddle:
					case Doing.ResizeBottomLeft:
					case Doing.ResizeMiddleLeft:
						Resize(realWorldPosition.X, realWorldPosition.Y);
						Do(Doing.Nothing);
						picPage.Cursor = Cursors.Default;
						break;
				}
			}
		}

		/// <summary>
		/// On MouseLeave picPage
		/// </summary>
		private void picPage_MouseLeave(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// On MouseMove insides picPage
		/// </summary>
		private void picPage_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!DesignMode)
			{
				// Check what're user doing
				switch (_doing)
				{
					#region Inserting
					case Doing.Inserting:
						/* User is insertind an item.
						 * Draw a cross-line at insert position.
						 */
						RestoreCrossLine(_lastPosition);
						DrawCrossLine(e.X, e.Y);						
						_lastPosition = new Point(e.X, e.Y);
						break;
					#endregion

					#region Moving
					case Doing.Moving:
						RestoreMoving(_lastPosition);

						_lastPosition.X = e.X + (int) _selectionDistance.Width;
						_lastPosition.Y = e.Y + (int) _selectionDistance.Height;

						DrawMoving(_lastPosition.X, _lastPosition.Y);
						break;
					#endregion

					#region Resizing
					case Doing.ResizeTopLeft:
					case Doing.ResizeTopMiddle:
					case Doing.ResizeTopRight:
					case Doing.ResizeMiddleRight:
					case Doing.ResizeBottomRight:
					case Doing.ResizeBottomMiddle:
					case Doing.ResizeBottomLeft:
					case Doing.ResizeMiddleLeft:
						RestoreResizing(hRuler.Convert(_lastPosition.X), vRuler.Convert(_lastPosition.Y));
						DrawResizing(hRuler.Convert(e.X), vRuler.Convert(e.Y));
						_lastPosition = new Point(e.X, e.Y);
						break;
					#endregion
					
					#region Nothing
					case Doing.Nothing:
						/* User is doing nothing, until now.
						 * Check if it can make something.
						 */
						switch (e.Button)
						{
							case MouseButtons.Left:
								// Check if selection is moving
								if (_selectedItem != null &&
									(Math.Abs(e.X - _lastPosition.X) > 5 ||
									Math.Abs(e.Y - _lastPosition.Y) > 5))
								{ 
									#region Start move operation

									// Do moving operation
									Do(Doing.Moving);

									// Set position
									_lastPosition.X = (int) (_selectedItem.Location.X * dpi / Ruler.GetFactorConvert(unit));
									_lastPosition.Y = (int) (_selectedItem.Location.Y * dpi / Ruler.GetFactorConvert(unit));

									// Draw position
									DrawMoving(_lastPosition.X, _lastPosition.Y);
									
									// Change cursor's pointer
									picPage.Cursor = Cursors.SizeAll;

#endregion
								}
								break;

							case MouseButtons.None:
								if (picPage.Cursor != Cursors.Default)
									picPage.Cursor = Cursors.Default;

								// Check if mouse is over selection mark
								if (_selectedItem != null)
								{
									#region Change mouse pointer according to mouse position

									float x, y;

									x = hRuler.Convert(e.X);
									y = vRuler.Convert(e.Y);

									for (int i = 0; i < _selectionEdges.Length; i++)
									{
										RectangleF selection = _selectionEdges[i];

										if (selection.Left <= x && selection.Right >= x &&
											selection.Top <= y && selection.Bottom >= y)
										{
											// Check wich selection mark is pointed
											switch ((SelectionEdge) i)
											{
												case SelectionEdge.TopLeft:
												case SelectionEdge.BottomRight:
													picPage.Cursor = Cursors.SizeNWSE;
													break;

												case SelectionEdge.TopRight:
												case SelectionEdge.BottomLeft:
													picPage.Cursor = Cursors.SizeNESW;
													break;

												case SelectionEdge.TopMiddle:
												case SelectionEdge.BottomMiddle:
													picPage.Cursor = Cursors.SizeNS;
													break;

												case SelectionEdge.MiddleLeft:
												case SelectionEdge.MiddleRight:
													picPage.Cursor = Cursors.SizeWE;
													break;
											}
										}
									}

									#endregion
								}
								break;
						}

						break;
					#endregion
				}
			}
		}

		/// <summary>
		/// Paint picPage
		/// </summary>
		private void picPage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (!DesignMode && _bmp != null)
			{
				e.Graphics.DrawImage(
					_bmp,
					e.ClipRectangle,
					e.ClipRectangle,
					GraphicsUnit.Pixel);
			}
		}

		/// <summary>
		/// On picPage resizes
		/// </summary>
		private void picPage_Resize(object sender, System.EventArgs e)
		{
			if (_bmp != null)
			{
				//_bmp = new Bitmap(_bmp, this.Size);
				_bmp = new Bitmap(picPage.Width, picPage.Height);
				//_bmp = new System.Drawing.Imaging.Metafile(picPage.CreateGraphics().GetHdc(), System.Drawing.Imaging.EmfType.EmfPlusOnly);
				Redraw();
			}
		}

		#endregion

		/// <summary>
		/// Restore cross line marking
		/// </summary>
		private void RestoreCrossLine(Point position)
		{
			RestoreCrossLine(position.X, position.Y);
		}

		/// <summary>
		/// Restore cross line marking
		/// </summary>
		private void RestoreCrossLine(float x, float y)
		{
			using (Graphics g = picPage.CreateGraphics())
			{
				// Restore last horizontal line
				g.DrawImage(
					_bmp,
					new RectangleF(x - 1, 0f,
					1f + 2, g.VisibleClipBounds.Height),
					new RectangleF(x - 1, 0f,
					1f + 2, g.VisibleClipBounds.Height),
					GraphicsUnit.Pixel);

				// Restore last vertical line
				g.DrawImage(
					_bmp,
					new RectangleF(0f, y - 1,
					g.VisibleClipBounds.Width, 1f + 2),
					new RectangleF(0f, y - 1,
					g.VisibleClipBounds.Width, 1f + 2),
					GraphicsUnit.Pixel);			
			}
		}

		/// <summary>
		/// Draws a cross line at (x, y) coordinate
		/// </summary>
		private void DrawCrossLine(float x, float y)
		{
			using (Graphics g = picPage.CreateGraphics())
			{
				g.PageUnit = GraphicsUnit.Pixel;

				// Draw horizontal line
				g.DrawLine(
					penPosition,
					x, 0, x, g.VisibleClipBounds.Height);

				// Draw vertical line
				g.DrawLine(
					penPosition,
					0, y, g.VisibleClipBounds.Width, y);
			}						
		}

		private void DrawCrossLineMm(float x, float y)
		{
			using (Graphics g = picPage.CreateGraphics())
			{
				g.PageUnit = GraphicsUnit.Millimeter;

				// Draw horizontal line
				g.DrawLine(
					penPosition,
					x, 0, x, g.VisibleClipBounds.Height);

				// Draw vertical line
				g.DrawLine(
					penPosition,
					0, y, g.VisibleClipBounds.Width, y);
			}						
		}

		private void RestoreCrossLineMm(float x, float y)
		{
			using (Graphics g = picPage.CreateGraphics())
				g.DrawImageUnscaled(_bmp, 0, 0);
		}

		/// <summary>
		/// Draw moving selected item
		/// </summary>
		private void DrawMoving(int x, int y)
		{
			DrawCrossLine(x, y);
			DrawCrossLine(
				x + _selectedItem.Location.Width * dpi / Ruler.GetFactorConvert(unit),
				y + _selectedItem.Location.Height * dpi / Ruler.GetFactorConvert(unit));

		}

		/// <summary>
		/// Restore moving drawing
		/// </summary>
		private void RestoreMoving(Point position)
		{
			RestoreCrossLine(position);
			RestoreCrossLine(
				position.X + _selectedItem.Location.Width * dpi / Ruler.GetFactorConvert(unit),
				position.Y + _selectedItem.Location.Height * dpi / Ruler.GetFactorConvert(unit));
		}

		/// <summary>
		/// Aligns a real-world coordinate to grid
		/// </summary>
		private PointF AlignToGrid(float x, float y)
		{
			return new PointF(
				(float) (grid.Width * Math.Round(x / grid.Width)),
				(float) (grid.Height * Math.Round(y / grid.Height)));
		}

		private void RestoreResizing(float x, float y)
		{
			switch (_doing)
			{
				case Doing.ResizeTopLeft:
					RestoreCrossLineMm(x, y);
					RestoreCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeTopMiddle:
					RestoreCrossLineMm(_selectedItem.Location.X, y);
					RestoreCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeTopRight:
					RestoreCrossLineMm(_selectedItem.Location.X, y);
					RestoreCrossLineMm(
						x,
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeMiddleRight:
					RestoreCrossLineMm(_selectedItem.Location.X, _selectedItem.Location.Y);
					RestoreCrossLineMm(x, 
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeBottomRight:
					RestoreCrossLineMm(_selectedItem.Location.X, _selectedItem.Location.Y);
					RestoreCrossLineMm(x, y);
					break;

				case Doing.ResizeBottomMiddle:
					RestoreCrossLineMm(_selectedItem.Location.X, _selectedItem.Location.Y);
					RestoreCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						y);
					break;

				case Doing.ResizeBottomLeft:
					RestoreCrossLineMm(x, _selectedItem.Location.Y);
					RestoreCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						y);
					break;

				case Doing.ResizeMiddleLeft:
					RestoreCrossLineMm(x, _selectedItem.Location.Y);
					RestoreCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;
			}
		}

		private void DrawResizing(float x, float y)
		{
			switch (_doing)
			{
				case Doing.ResizeTopLeft:
					DrawCrossLineMm(x, y);
					DrawCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeTopMiddle:
					DrawCrossLineMm(_selectedItem.Location.X, y);
					DrawCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeTopRight:
					DrawCrossLineMm(_selectedItem.Location.X, y);
					DrawCrossLineMm(
						x,
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeMiddleRight:
					DrawCrossLineMm(_selectedItem.Location.X, _selectedItem.Location.Y);
					DrawCrossLineMm(x, 
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;

				case Doing.ResizeBottomRight:
					DrawCrossLineMm(_selectedItem.Location.X, _selectedItem.Location.Y);
					DrawCrossLineMm(x, y);
					break;

				case Doing.ResizeBottomMiddle:
					DrawCrossLineMm(_selectedItem.Location.X, _selectedItem.Location.Y);
					DrawCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						y);
					break;

				case Doing.ResizeBottomLeft:
					DrawCrossLineMm(x, _selectedItem.Location.Y);
					DrawCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						y);
					break;

				case Doing.ResizeMiddleLeft:
					DrawCrossLineMm(x, _selectedItem.Location.Y);
					DrawCrossLineMm(
						_selectedItem.Location.X + _selectedItem.Location.Width,
						_selectedItem.Location.Y + _selectedItem.Location.Height);
					break;
			}
		}

		private void PageLayoutDesign_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				this.Delete();
		}

		/// <summary>
		/// Page Settings
		/// </summary>
		[Category("Layout")]
		//[Browsable(false)]
		public System.Drawing.Printing.PageSettings PageSettings
		{
			get
			{
				if (pageLayout.GetType() == typeof(PageLayout))
					return ((PageLayout) pageLayout).PageSettings;
				else
					return null;
			}
			set
			{
				if (pageLayout.GetType() == typeof(PageLayout))
				{
					((PageLayout) pageLayout).PageSettings = value;
					ResizePage();
				}
			}
		}
	}
}
