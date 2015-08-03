/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;

namespace Report.Layout.Simple
{
	/// <summary>
	/// Section which has to be printed, but can not be printed
	/// on every page.
	/// </summary>
	public abstract class SectionVersátil : Section
	{
		protected bool		printCompleted = false;

		/// <summary>
		/// Section has already been printed completaly
		/// </summary>
		public bool PrintCompleted
		{
			get { return printCompleted; }
		}
	}
}
