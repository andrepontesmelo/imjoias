using System;
using Report.Layout.Complex;

namespace Report.Layout
{
	/// <summary>
	/// Group different objects
	/// </summary>
	public class GroupDifferentObjects : GroupObjects
	{
		private object [] objects;
		private int		  printCount = 0;

		/// <summary>
		/// Constructs a group of objects to a layout
		/// </summary>
		/// <param name="layout">Layout used to print objects</param>
		/// <param name="objects">Objects to print</param>
		public GroupDifferentObjects(ILayout layout, object [] objects) : base(layout)
		{
			this.objects = objects;
		}

		/// <summary>
		/// Next object to print
		/// </summary>
		internal override object Next
		{
			get { return printCount < objects.Length ? objects[printCount++] : null; }
		}

		internal override bool HasNext
		{
			get { return printCount < objects.Length; }
		}

		/// <summary>
		/// Objects to print
		/// </summary>
		public object [] Objects
		{
			get { return objects; }
		}
	}
}

