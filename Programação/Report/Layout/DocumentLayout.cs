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
	public sealed class DocumentLayout : Layout
	{
		// Layout
		private CollectionPageLayout	pages = new CollectionPageLayout();

		// Runtime counters
		private int						_pageCycle;
		private int						_elementCount;

		public DocumentLayout(System.ComponentModel.IContainer container) : base(container)
		{
		}

		public DocumentLayout()
		{
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				pages.Clear();
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Pages Layout Collection
		/// </summary>
		[Browsable(true)]
//		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[ReadOnly(true)]
		public CollectionPageLayout Pages
		{
			get { return pages; }
		}

		/// <summary>
		/// Prepare to print
		/// </summary>
		protected override void BeginPrint(object sender, PrintEventArgs e)
		{
			bool finite = false;

			_pageCycle = 0;
			_elementCount = 0;

			// Check for an infinite loop
			foreach (PageLayout page in pages)
				finite |= page.AdvancesElements;

			if (!finite)
				throw new Exception("Inifite loop on pagelayout. None advances to next elements.");
		}

		/// <summary>
		/// Setup page settings
		/// </summary>
		protected override void QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
		{
			PageLayout currentPage = pages[_pageCycle];

			e.PageSettings = currentPage.PageSettings;
		}

		/// <summary>
		/// Handle a PrintPage event.
		/// </summary>
		protected override void PrintPage(object sender, PrintPageEventArgs e)
		{
			PageLayout currentPage;

			// Get current pagelayout
			currentPage = pages[_pageCycle];

			// Print a group of elements
			for (int i = 0; i < currentPage.GroupElements; i++)
				currentPage.Print(e.Graphics, objects[_elementCount + i]);

			// Increment elements counter
			if (currentPage.AdvancesElements)
			{
				_elementCount += currentPage.GroupElements;

				e.HasMorePages = (_elementCount < objects.Count);
			}
			else
				e.HasMorePages = true;

			// Increment page's counter
			_pageCycle = (_pageCycle + 1) % pages.Count;
		}

		/// <summary>
		/// Load settings from a xml document
		/// </summary>
		/// <param name="doc">Xml document</param>
		/// <param name="designMode">If on design mode</param>
		public override void LoadFromXml(XmlDocument doc, bool designMode)
		{
			// Remove older pages
			foreach (PageLayout page in pages)
				this.components.Remove(page);

			pages.Clear();
			
			// Imports printable items settings
			foreach (XmlElement element in doc["DocumentLayout"].GetElementsByTagName("PageLayout"))
			{
				PageLayout importedPage;

				importedPage = new PageLayout(this.components);
				importedPage.DesignMode = designMode;
				importedPage.LoadFromXml(element, typeDictionary);

				pages.Add(importedPage);
			}
		}

		public override void SaveToXml(XmlDocument doc)
		{
			throw new NotImplementedException();
		}

	}
}
