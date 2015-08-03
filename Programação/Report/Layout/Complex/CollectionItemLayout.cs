/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;

namespace Report.Layout.Complex
{
	/// <summary>
	/// Collection of Item Layout
	/// </summary>
	public class CollectionItemLayout : ArrayList
	{
		public new ItemLayout this[int index]
		{
			get { return (ItemLayout) base[index]; }
			set { base[index] = value; }
		}

		public void AddRange(PageLayout[] c)
		{
			base.AddRange (c);
		}
	}
}
