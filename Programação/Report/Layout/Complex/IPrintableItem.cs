/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using Report.Layout;

namespace Report.Layout.Complex
{
	public interface IPrintableItem
	{
		/// <summary>
		/// Location of printable item
		/// </summary>
		RectangleF Location { get; set; }

		/// <summary>
		/// Print an object data
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		void Print(Graphics g, object obj);

		void FromXml(XmlElement element, IDictionary typeDictionary);

		void SaveXml(XmlDocument doc, XmlElement element);

		/// <summary>
		/// Set properties to pageLayout's default.
		/// </summary>
		/// <param name="pageLayout">PageLayout containing default properties</param>
		void SetDefault(ILayout pageLayout);

		/// <summary>
		/// Metric used
		/// </summary>
		Metric Metric { get; set; }

		/// <summary>
		/// Design mode
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		bool DesignMode { get; set; }
	}
}
