using System;
using Report.Layout.Complex;

namespace Report.Layout
{
	/// <summary>
	/// Group of repeated objects
	/// </summary>
	public class RepeatedObject : GroupObjects
	{
		private object obj;
		private int	   printCount = 0;
		private int    times;

		/// <summary>
		/// Constructs a group of objects to a layout
		/// </summary>
		/// <param name="layout">Layout used to print objects</param>
		/// <param name="obj">Object to print</param>
		/// <param name="times">Times to print</param>
		public RepeatedObject(ILayout layout, object obj, int times) : base(layout)
		{
			if (times < 0)
				throw new ArgumentException("Times cannot be negative!", "times");

			this.obj   = obj;
			this.times = times;
		}

		/// <summary>
		/// Next object to print
		/// </summary>
		internal override object Next
		{
			get { return printCount++ < times ? obj : null; }
		}

		internal override bool HasNext
		{
			get { return printCount < times; }
		}

		/// <summary>
		/// Object to print
		/// </summary>
		public object Object
		{
			get { return obj; }
		}
	}
}

