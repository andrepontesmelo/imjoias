using System;
using Report.Layout.Complex;

namespace Report.Layout
{
	/// <summary>
	/// Group of objects
	/// </summary>
	public abstract class GroupObjects
	{
		private ILayout   layout;

		/// <summary>
		/// Constructs a group of objects to a layout
		/// </summary>
		/// <param name="layout">Layout used to print objects</param>
		public GroupObjects(ILayout layout)
		{
			this.layout  = layout;
		}

		/// <summary>
		/// Next object to print
		/// </summary>
		abstract internal object Next { get; }
	
		abstract internal bool HasNext { get; }

		/// <summary>
		/// Layout to print objects
		/// </summary>
		public ILayout Layout
		{
			get { return layout; }
		}
	}
}
