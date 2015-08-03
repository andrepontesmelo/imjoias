/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using Report.Layout.Simple;

namespace Report.Layout
{
	public class SimpleLayout : System.ComponentModel.Component
	{
		// Constants
		private const float			columnsDistance = 0.393f * 20;

        public delegate SizeF MeasureObjectHandler(Graphics g, object obj, out bool handled);
        public delegate void PrintObjectHandler(Graphics g, object obj, float y);

        public event MeasureObjectHandler OnMeasureObject;
        public event PrintObjectHandler OnPrintObject;

		// Relationship
		private Line				line;
		private IList				objects;
		private CollectionSections	sections;
		private Header				header;
		private PrintDocument		document;

		// Layout
		private bool				distributeColumns = true;

		// While printing (runtime)
		private int					_page;
		private int					_elementCount;

		// Event handlers
		private PrintEventHandler	  beginPrint;
		private PrintPageEventHandler printPage;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SimpleLayout(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			InitializeSimpleLayout();
		}

		public SimpleLayout()
		{
			InitializeComponent();
			InitializeSimpleLayout();
        
            // Add default sections
            sections = new CollectionSections();
            sections.Add(new Title());
            sections.Add(header = new Header());
            sections.Add(new Sum());
            sections.Add(new Footer());
        }

        public SimpleLayout(params Section[] sections)
        {
            InitializeComponent();
            
            this.sections = new CollectionSections();

            foreach (Section section in sections)
            {
                this.sections.Add(section);

                if (section is Header)
                    header = (Header)section;
            }
        }

		private void InitializeSimpleLayout()
		{
			line = new Line();
			
			// Preparing events handlers
			beginPrint	= new PrintEventHandler(BeginPrint);
			printPage	= new PrintPageEventHandler(PrintPage);
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

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

		/// <summary>
		/// Import property and fields from a class,
		/// creating columns instead.
		/// </summary>
		/// <param name="type">Class to be imported</param>
		public void ImportarClasse(Type type)
		{
			// Imports all properties
			foreach (PropertyInfo property in type.GetProperties())
			{
				Column column;

				// Check if is readable property
				if (!property.CanRead)
					continue;

				// Creates a column
				column = new Column(property);

				// Inserts into a line
				line.Columns.Add(column);
			}
		}

		/// <summary>
		/// Column to print
		/// </summary>
		[Category("Layout")]
		[Description("Columns to print")]
		public CollectionColumns Columns
		{
			get { return line.Columns; }
		}

		/// <summary>
		/// Objects containing data to print
		/// </summary>
		[Category("Data")]
		[Description("Objects containing data to print")]
		[DefaultValue(typeof(IList), null)]
		public IList Objects
		{
			get { return objects; }
			set { objects = value; }
		}

		/// <summary>
		/// Prepare to print
		/// </summary>
		private void BeginPrint(object sender, PrintEventArgs e)
		{
			if (objects == null)
				throw new NullReferenceException("Objects is null!");

			// Reset counters
			_page = 0;
			_elementCount = 0;

			// Reset columns counter
			foreach (Column column in line.Columns)
				column.SumTotal = 0;

			// Prepare sections
			sections.PreparePrinting(this, e);
		}

		/// <summary>
		/// Print a page
		/// </summary>
		private void PrintPage(object sender, PrintPageEventArgs e)
		{
			float		y;				// Absolute position
			RectangleF	area;

			// Set print area
			area = new RectangleF(
				e.MarginBounds.Left,
				e.MarginBounds.Top,
				e.MarginBounds.Width,
				e.MarginBounds.Height);

			// Distribute columns, if necessary
			if (_page == 0 && this.distributeColumns)
				DistributeColumns(e.Graphics, area.Width, area.Left);

			// Advances page count
			_page++;
			e.HasMorePages = false;

			// Reset page's sum
			foreach (Column column in line.Columns)
				if (column.ToSum)
					column.SumPage = 0;

			// Print headers and reserves footer's area
			foreach (Section section in sections)
			{
				// Check if section is a header
				if (section.PrintBeforeData)
					section.Print(
						e.Graphics,
						ref area,
						line.Columns,
						_page);

				// Guarantee footer's area
				if (section.PrintAfterData)
					area.Height -=
						section.MeasureHeight(e.Graphics, area, line.Columns, _page);
			}

			// Print data
			y = area.Top;

			while (_elementCount < objects.Count)
			{
				SizeF	size;
				object	obj;
                bool handled = false;

				obj = objects[_elementCount];

                if (OnMeasureObject != null)
                {
                    size = OnMeasureObject(e.Graphics, obj, out handled);

                    /* Measure the necessary area needed to print all line*/
                    if (!handled)
                        size = line.MeasureDataPrint(e.Graphics, obj);
                }
                /* Measure the necessary area needed to print all line*/
                else
                    size = line.MeasureDataPrint(e.Graphics, obj);

				/* If there is no sufficient space, break while and
				 * set that document has more pages.
				 */
				if (size.Height + y > area.Bottom)
				{
					e.HasMorePages = true;
					break;
				}
				else
				{
					// Print data
                    if (!handled)
                        line.Print(e.Graphics, obj, y);
                    else
                        OnPrintObject(e.Graphics, obj, y);
					
					// Increment counter
					_elementCount++;

					// Increment current y position
					y += (int) size.Height;
				}
			}

			// Set footer's area
			area = new RectangleF(
				e.MarginBounds.Left,
				y,
				e.MarginBounds.Width,
				e.MarginBounds.Height - (y - e.MarginBounds.Top));

			// Print footers
			foreach (Section section in sections)
			{
				if (section.GetType() != typeof(SectionVersátil) &&
					section.PrintAfterData)
				{
					section.Print(e.Graphics, ref area, line.Columns, _page);
				}
			}

			// Check if all sections has finished.
			foreach (Section section in sections)
			{
				SectionVersátil versátil = section as SectionVersátil;

				if (versátil == null)
					continue;
				
				if (section.PrintAfterData)
					section.Print(e.Graphics, ref area, line.Columns, _page);

				if (!versátil.PrintCompleted)
					e.HasMorePages = true;
			}
		}
		
		/// <summary>
		/// Distribute columns
		/// </summary>
		private void DistributeColumns(Graphics g, float width, float left)
		{
			bool []				adaptable;		// Columns which can be adapt
			ArrayList			columns;		// Columns list
			float				maxWidth;		// Maximum width size of a column

			columns			= (ArrayList) line.Columns.Clone();
			adaptable		= new bool[columns.Count];

			width		   -= columns.Count * columnsDistance;

			/* Measure maximum width of a column need to print a data
			 * into a single line.
			 */
			for (int i = 0; i < columns.Count; i++)
			{
				Column column = (Column) columns[i];
				float columnWidth;

				/* Measure column's label's width.
				 * 
				 * "column.Width" cannot be used instead because it
				 * may influence the result of column.MeasureDataPrint(...)
				 */
				columnWidth = g.MeasureString(
					column.Label,
					header.Font).Width;

				// column.Width will temporary assume maximum width permitted.
				column.Width = width;

				// Measure maximum data's width
				foreach (object obj in objects)
				{
					SizeF size;
					
					size = column.MeasureDataPrint(g, obj);

					if (columnWidth < size.Width)
						columnWidth = size.Width;
				}

				column.Width = columnWidth;

				// Check if column can be broken into many lines
				if (column.MemberType == typeof(int) ||
					column.MemberType == typeof(long) ||
					column.MemberType == typeof(float) ||
					column.MemberType == typeof(double))
				{
					adaptable[i]  = false;
					width		 -= column.Width;
				}
				else
					adaptable[i]  = true;
			}

			// Remove fixed columns (not adaptable)
			for (int i = adaptable.Length - 1; i >= 0; i--)
				if (!adaptable[i])
					columns.RemoveAt(i);

			/* * WARNING * * * * * * * * * * * * * * * * * * * * * * * * * 
			 * At this point, the collection "columns" do not represents *
			 * all line's columns. To access such collection, use        *
			 * "line.Columns" instead.                                   *
			 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

			// Sort columns by width
			columns.Sort(new CompararColumnsLargura());

			maxWidth = width / (float) columns.Count;

			/* Serão mantidas os tamanhos de todas columns
			 * que necessitarem menos que o tamanho máximo
			 * (uniforme) de todas as columns que faltam
			 * ser distribuídas. Para essas columns,
			 * serão deduzidas seu espaço das demais,
			 * recalculando o tamanho máximo.
			 */
			/* All column's width lesser than maxWidth will remain.
			 * Therefore, they'll descrease the total width and
			 * will not be considered anymore on maxWidth's formule.
			 */
			for (int i = 0; i < columns.Count; i++)
			{
				Column column = ((Column) columns[i]);

				if (column.Width <= width)
				{
					width   -= column.Width;
					maxWidth = (float) width / (float) (columns.Count - i - 1);
				}
				else
				{
					column.Width = maxWidth;
					width       -= maxWidth;
				}
			}

			// Distribute any space left
			if (width > 0)
			{
				maxWidth = (float) width / (float) line.Columns.Count;
				
				foreach (Column column in line.Columns)
					column.Width += maxWidth;
			}

			// Set columns X position
			float x = left;

			foreach (Column column in line.Columns)
			{
				column.X = x;
				x		+= column.Width + columnsDistance;
			}
		}

		/// <summary>
		/// Class used to sort columns by width
		/// </summary>
		private class CompararColumnsLargura : IComparer
		{
			#region IComparer Members

			public int Compare(object x, object y)
			{
				return ((Column) x).Width.CompareTo(((Column) y).Width);
			}

			#endregion
		}

		/// <summary>
		/// Last page to be printed
		/// </summary>
		internal bool LastPage
		{
			get { return _elementCount >= objects.Count; }
		}

		/// <summary>
		/// Getter/Setters DistributeColumns
		/// </summary>
		[Category("Layout")]
		[Description("Auto distribute columns")]
		public bool AutoDistributeColumns
		{
			get { return distributeColumns; }
			set { distributeColumns = value; }
		}

		/// <summary>
		/// Get printed element counter
		/// </summary>
		internal int ElementCounter
		{
			get { return _elementCount; }
		}

		/// <summary>
		/// Sections que serão impressas
		/// </summary>
		[Category("Layout")]
		[Description("Sections to print")]
		public CollectionSections Sections
		{
			get { return sections; }
		}

		/// <summary>
		/// Print report
		/// </summary>
		public void Print()
		{
			if (document == null)
				this.Document = new PrintDocument();

			document.Print();
		}

		/// <summary>
		/// Document to be printed
		/// </summary>
		[Category("Print")]
		[Description("Document to be printed")]
		public PrintDocument Document
		{
			get { return document; }
			set
			{
				// Remove handler from older document
				if (document != null)
				{
					document.BeginPrint -= beginPrint;
					document.PrintPage -= printPage;
				}

				// Prepare document to be printed
				document = value;

				if (value != null)
				{
					document.BeginPrint += beginPrint;
					document.PrintPage += printPage;
				}
			}
		}

		/// <summary>
		/// Change font's size from all columns
		/// </summary>
		public void ChangeFontSize(float size)
		{
			foreach (Column column in line.Columns)
				column.Font = new Font(column.Font.Name, size, column.Font.Style);

			header.Font = new Font(header.Font.Name, size, header.Font.Style);
		}
	}
}
