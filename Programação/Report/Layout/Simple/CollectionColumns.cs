/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing.Printing;

namespace Report.Layout.Simple
{
	/// <summary>
	/// Columns collection
	/// </summary>
	public class CollectionColumns : ArrayList
	{
		private Line line;

		public CollectionColumns(Line line)
		{
			this.line = line;
		}

		public override int Add(object value)
		{
			((Column) value).Line = line;
			return base.Add(value);
		}

		public override void AddRange(ICollection c)
		{
			foreach (Column column in c)
				column.Line = line;

			base.AddRange (c);
		}

		public override void Insert(int index, object value)
		{
			((Column) value).Line = line;
			base.Insert (index, value);
		}

		public override void InsertRange(int index, ICollection c)
		{
			foreach (Column column in c)
				column.Line = line;

			base.InsertRange (index, c);
		}

		/// <summary>
		/// Column
		/// </summary>
		public new Column this[int i]
		{
			get { return (Column) base[i]; }
		}

		/// <summary>
		/// Column
		/// </summary>
		public Column this[string label]
		{
			get
			{
				foreach (Column column in this)
					if (column.Label == label)
						return column;

				return null;
			}
		}
	}
}
