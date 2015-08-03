/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Reflection;
using System.Xml;
using Report.Layout.Complex;

namespace Report.Layout
{
	/// <summary>
	/// Base of layout's components
	/// </summary>
	public abstract class Layout : System.ComponentModel.Component
	{
		// Relationships
		protected IList					objects;
		protected Hashtable				typeDictionary;

		// Layout
		private PrintDocument			document = null;

		// Events handlers
		private PrintPageEventHandler	printPage;
		private PrintEventHandler		beginPrint;
		private QueryPageSettingsEventHandler queryPageSettings;

		// Settings
		private string					xmlFileName = null;
		private Assembly				xmlResourceAssembly;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		protected System.ComponentModel.Container components = null;

		#region Constructors

		public Layout(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			printPage = new PrintPageEventHandler(PrintPage);
			beginPrint = new PrintEventHandler(BeginPrint);
			queryPageSettings = new QueryPageSettingsEventHandler(QueryPageSettings);
		}

		public Layout()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			printPage = new PrintPageEventHandler(PrintPage);
			beginPrint = new PrintEventHandler(BeginPrint);
			queryPageSettings = new QueryPageSettingsEventHandler(QueryPageSettings);
		}

		#endregion

		#region IDisposable implementation

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

			if (document != null)
				Document = null;
		}

		#endregion

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

		#region Public properties

		/// <summary>
		/// Document to print
		/// </summary>
		[Bindable(true), Browsable(true)]
		public PrintDocument Document
		{
			get { return document; }
			set
			{
				// Remove older document's handler
				if (document != null)
				{
					document.PrintPage -= printPage;
					document.BeginPrint -= beginPrint;
					document.QueryPageSettings -= queryPageSettings;
				}

				// Introduces handlers
				document = value;

				if (value != null)
				{
					document.BeginPrint += beginPrint;
					document.PrintPage += printPage;
					document.QueryPageSettings += queryPageSettings;
				}
			}
		}

		/// <summary>
		/// Objects containing data to print
		/// </summary>
		[Browsable(false)]
		public IList Objects
		{
			get { return objects; }
			set
			{
				objects = value;

				if (objects != null)
					ImportTypes();
			}
		}

		[Bindable(true)]
		[Browsable(true)]
		public string XmlFileName
		{
			get
			{
				return xmlFileName;
			}
			set
			{
				xmlFileName = value;
				xmlResourceAssembly = System.Reflection.Assembly.GetCallingAssembly();
			
				if (value != null && value.Length > 0 && objects != null)
					LoadFromFile(value);
			}
		}

		#endregion

		#region Printing handlers/functions

		/// <summary>
		/// Prepare to print
		/// </summary>
		protected abstract void BeginPrint(object sender, PrintEventArgs e);

		/// <summary>
		/// Setup page settings
		/// </summary>
		protected abstract void QueryPageSettings(object sender, QueryPageSettingsEventArgs e);

		/// <summary>
		/// Handle a PrintPage event.
		/// </summary>
		protected abstract void PrintPage(object sender, PrintPageEventArgs e);

		#endregion

		#region Loading and saving settings

		/// <summary>
		/// Construct page layout from Xml file
		/// </summary>
		/// <param name="filename">Xml Filename</param>
		public void LoadFromFile(string filename)
		{
			LoadFromFile(filename, false);
		}

		/// <summary>
		/// Load settings from file
		/// </summary>
		/// <param name="filename">Xml filename</param>
		/// <param name="designMode">If layout is on design mode</param>
		public void LoadFromFile(string filename, bool designMode)
		{
			XmlDocument	doc;

			// Create new XmlDoc
			doc = new XmlDocument();

			// Check if file exists
			if (System.IO.File.Exists(filename))
			{
				// Load from file
				doc.Load(filename);
			}
			else
			{
				System.IO.BufferedStream xmlStream = null;
				byte [] xmlData;
				const int bufferSize = 4096;

				// Try to load from resource
				try
				{
					xmlStream = new System.IO.BufferedStream(
						xmlResourceAssembly.GetManifestResourceStream(filename),
						bufferSize);
				}
				catch
				{
					foreach (string name in xmlResourceAssembly.GetManifestResourceNames())
						if (name.EndsWith(filename))
						{
							xmlStream = new System.IO.BufferedStream(
								xmlResourceAssembly.GetManifestResourceStream(name),
								bufferSize);
							break;
						}
				}

				xmlData = new byte[xmlStream.Length];

				while (xmlStream.Position < xmlStream.Length)
					xmlStream.Read((byte[]) xmlData, (int) xmlStream.Position, (int) Math.Min(bufferSize, xmlStream.Length - xmlStream.Position));
				
				xmlStream.Close();

                string str = System.Text.Encoding.UTF8.GetString(xmlData);

				doc.LoadXml(str.Substring(str.IndexOf('<')));
			}
			
			LoadFromXml(doc, designMode);
		}

		/// <summary>
		/// Load settings from a xml document
		/// </summary>
		/// <param name="doc">Xml document</param>
		/// <param name="designMode">If on design mode</param>
		public abstract void LoadFromXml(XmlDocument doc, bool designMode);

		/// <summary>
		/// Load settings from a xml document string
		/// </summary>
		/// <param name="xml">Xml document</param>
		/// <param name="designMode">If on design mode</param>
		public void LoadFromXml(string xml, bool designMode)
		{
			XmlDocument doc;

			doc = new XmlDocument();
			doc.LoadXml(xml);

			LoadFromXml(doc, designMode);
		}

		/// <summary>
		/// Save settings to a file with a xml document
		/// </summary>
		/// <param name="filename">Xml filename</param>
		public static void SaveToFile(string filename)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Save settings to a xml document
		/// </summary>
		/// <param name="doc">Xml document</param>
		public abstract void SaveToXml(XmlDocument doc);

		/// <summary>
		/// Save settings to a new xml document
		/// </summary>
		/// <returns>Xml document</returns>
		public XmlDocument SaveToXml()
		{
			XmlDocument doc;

			doc = new XmlDocument();
			
			SaveToXml(doc);

			return doc;
		}

		#endregion

		#region Internal static methods

		/// <summary>
		/// Creates a Pen from a Xml
		/// </summary>
		internal static Pen CreatePenFromXml(XmlElement root)
		{
			XmlElement element;
			float	   width;

			if (root.HasAttribute("Width"))
				width = float.Parse(root.GetAttribute("Width"), NumberFormatInfo.InvariantInfo);
			else
				width = 0.01f;

			if ((element = root["Color"]) != null)
				return new Pen(CreateColorFromXml(element), width);

			throw new Exception("Invalid elements on Xml Pen description");
		}

		/// <summary>
		/// Creates a Brush from a Xml
		/// </summary>
		internal static Brush CreateBrushFromXml(XmlElement root)
		{
			XmlElement element;

			if ((element = root["Color"]) != null)
				return new SolidBrush(CreateColorFromXml(element));

			throw new Exception("Invalid elements on Xml Pen description");
		}

		/// <summary>
		/// Creates a color from Xml
		/// </summary>
		internal static Color CreateColorFromXml(XmlElement element)
		{
			return Color.FromArgb(
				int.Parse(element.GetAttribute("Alpha")),
				int.Parse(element.GetAttribute("Red")),
				int.Parse(element.GetAttribute("Green")),
				int.Parse(element.GetAttribute("Blue")));
		}

		/// <summary>
		/// Creates a font from Xml
		/// </summary>
		internal static Font CreateFontFromXml(XmlElement root)
		{
			FontStyle fontStyle = FontStyle.Regular;

			foreach (XmlElement element in root)
				if (element.LocalName == "FontStyle")
					fontStyle |= (FontStyle) Enum.Parse(typeof(FontStyle), element.GetAttribute("Style"));

			return new Font(
				root.GetAttribute("Name"),
				float.Parse(root.GetAttribute("Size"), NumberFormatInfo.InvariantInfo),
				fontStyle);
		}

		/// <summary>
		/// Creates a PaperSize from Xml
		/// </summary>
		internal static PaperSize CreatePaperSizeFromXml(XmlElement root, Metric metric)
		{
			MetricHInch hInch = new MetricHInch();
			float width, height;
            PaperSize paper;

			if (root.HasAttribute("Metric"))
				metric = Metric.GetMetricParser(root.GetAttribute("Metric"));
			else
				metric = new MetricCentimeter();

			width = hInch.Reverse(metric.Parse(root.GetAttribute("Width")));
			height = hInch.Reverse(metric.Parse(root.GetAttribute("Height")));

            paper = new PaperSize(
				"Custom",
				(int) Math.Round(width),
				(int) Math.Round(height));

#if DEBUG
            if (paper.Width < Math.Round(width) || paper.Height < Math.Round(height))
                throw new Exception("DEBUG: Invalid paper size!");
#endif

            return paper;
		}

		#endregion

		#region Importing objects

		/// <summary>
		/// Import type of objects to a dictionary
		/// </summary>
		private void ImportTypes()
		{
			if (typeDictionary == null)
				typeDictionary = new Hashtable();

			// Import types
			foreach (object obj in objects)
			{
				Type objType;

				objType = obj.GetType();

				// Check if type is already imported
				if (!typeDictionary.ContainsKey(objType.Name))
					typeDictionary.Add(objType.Name, objType);

				if (!typeDictionary.ContainsKey(objType.FullName))
					typeDictionary.Add(objType.FullName, objType);
			}

			// Reload Xml
			if (xmlFileName != null)
				LoadFromFile(xmlFileName);
		}

		/// <summary>
		/// Type Dictionary
		/// </summary>
		internal IDictionary TypeDictionary
		{
			get { return typeDictionary; }
		}

		/// <summary>
		/// Set document containing a single object
		/// instead a collection
		/// </summary>
		/// <param name="obj">Object contaning all data
		/// to be printed</param>
		public void SetSingleObject(object obj)
		{
			ArrayList objects;

			objects = new ArrayList(1);
			objects.Add(obj);

			this.Objects = objects;
		}

		/// <summary>
		/// Import a type
		/// </summary>
		public void ImportType(Type type)
		{
			if (typeDictionary == null)
				typeDictionary = new Hashtable();

			typeDictionary[type.Name] = type;
			typeDictionary[type.FullName] = type;
		}

		#endregion
	}
}
