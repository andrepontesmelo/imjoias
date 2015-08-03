/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;

namespace Report.Layout.Complex
{
	[Serializable]
	public class CollectionPageLayout : ArrayList
	{
		public new PageLayout this[int index]
		{
			get { return (PageLayout) base[index]; }
			set { base[index] = value; }
		}

		public void AddRange(PageLayout[] c)
		{
			base.AddRange (c);
		}
	}
}
