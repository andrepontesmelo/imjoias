/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;

namespace Report.Layout.Complex
{
	[Serializable]
	public class CollectionIPrintableItem : ArrayList
	{
		public new IPrintableItem this[int index]
		{
			get { return (IPrintableItem) base[index]; }
		}

		/// <summary>
		/// Find an IPrintableItem into (x, y) coordinate
		/// </summary>
		public IPrintableItem this[float x, float y]
		{
			get
			{
				IPrintableItem selection = null;

				foreach (IPrintableItem item in this)
				{
					// Ignores border
					if (item.GetType() == typeof(Border))
						continue;

					if (item.Location.Left <= x && item.Location.Right >= x &&
						item.Location.Top <= y && item.Location.Bottom >= y)
					{
						/* After founding this item, the function will still looking
						 * for others items, because user does frequently want the
						 * last inserted item that is overriding others.
						 */
						selection = item;
					}
				}

				return selection;
			}
		}

		/// <summary>
		/// Print an object
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		public void Print(Graphics g, object obj)
		{
			foreach (IPrintableItem item in this)
				item.Print(g, obj);
		}
	}
}
