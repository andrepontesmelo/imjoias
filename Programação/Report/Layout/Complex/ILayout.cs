using System;
using System.Collections;
using System.Drawing;

namespace Report.Layout.Complex
{
	/// <summary>
	/// An interface for layouts
	/// </summary>
	public interface ILayout : System.ComponentModel.IComponent
	{
		/// <summary>
		/// Default text font
		/// </summary>
		Font DefaultTextFont { get; set; }

		/// <summary>
		/// Default text brush
		/// </summary>
		Brush DefaultTextBrush { get; set; }

		/// <summary>
		/// Default border
		/// </summary>
		Border DefaultBorder { get; set; }

		/// <summary>
		/// Default alignment
		/// </summary>
		ContentAlignment DefaultAlignment { get; set; }

		/// <summary>
		/// Default metric
		/// </summary>
		Metric DefaultMetric { get; set; }

		/// <summary>
		/// Design mode
		/// </summary>
		bool DesignMode { get; set; }

		/// <summary>
		/// Printable items
		/// </summary>
		CollectionIPrintableItem Items { get; }

		/// <summary>
		/// Layout's size
		/// </summary>
		SizeF Size { get; set; }

		/// <summary>
		/// Print an object
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		void Print(Graphics g, object obj);

		/// <summary>
		/// Save configuration to a XML file
		/// </summary>
		/// <param name="filename">The full path filename to save configuration</param>
		void SaveToXml(string filename);
	}
}
