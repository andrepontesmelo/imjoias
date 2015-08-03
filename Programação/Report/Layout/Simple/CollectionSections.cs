/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing.Printing;

namespace Report.Layout.Simple
{
	/// <summary>
	/// Summary description for CollectionSections.
	/// </summary>
	public class CollectionSections : ArrayList
	{
		/// <summary>
		/// Section
		/// </summary>
		public new Section this[int i]
		{
			get { return (Section) base[i]; }
		}

		/// <summary>
		/// Prepare secionts to be printed
		/// </summary>
		internal void PreparePrinting(SimpleLayout sender, PrintEventArgs e)
		{
			foreach (Section section in this)
				section.PreparePrinting(sender, e);
		}
	}
}
