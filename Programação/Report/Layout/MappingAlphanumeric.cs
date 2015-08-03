/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Drawing;
using System.Reflection;
using System.Globalization;

namespace Report.Layout
{
	public abstract class MappingAlphanumeric : Mapping
	{
		protected IFormatProvider	formatProvider		= CultureInfo.CurrentCulture;
		protected StringFormat		stringFormat		= new StringFormat(StringFormat.GenericDefault);
		protected string			format				= null;

		/// <summary>
		/// Set member which contains the data to be printed.
		/// </summary>
		/// <param name="member">Member which contains the data</param>
		/// <param name="memberType">Data type</param>
		protected override void SetMember(MemberInfo member, Type memberType)
		{
			base.SetMember (member, memberType);

			SetAlphanumeric();
		}

		/// <summary>
		/// Set member which contains the data to be printed.
		/// </summary>
		/// <param name="type">Type which contains data to be printed</param>
		/// <param name="member">Member's name which contains the data</param>
		protected override void SetMember(Type type, string member)
		{
			base.SetMember (type, member);

			SetAlphanumeric();
		}

		/// <summary>
		/// Set alphanumeric, also setting member's string format
		/// </summary>
		private void SetAlphanumeric()
		{
			// Check member's type, identifying the string format
			if (memberType == typeof(int) ||
				memberType == typeof(long))
			{
				stringFormat.Alignment	= StringAlignment.Far;
				formatProvider			= NumberFormatInfo.CurrentInfo;
				format					= "{0:###,###,###,###,##0}";
			}
			else if (memberType == typeof(double) ||
				memberType == typeof(float))
			{
				stringFormat.Alignment	= StringAlignment.Far;
				formatProvider			= NumberFormatInfo.CurrentInfo;
				format					= "{0:###,###,###,###,##0.00}";
			}
			else if (memberType == typeof(DateTime) ||
				memberType == typeof(TimeSpan))
			{
				stringFormat.Alignment	= StringAlignment.Near;
				formatProvider			= DateTimeFormatInfo.CurrentInfo;
				format					= null;
			}
			else
			{
				stringFormat.Alignment	= StringAlignment.Near;
				formatProvider			= CultureInfo.CurrentCulture;
				format					= null;
			}
		}

		/// <summary>
		/// Convert data to formatted string
		/// </summary>
		/// <param name="obj">Object to be printed</param>
		protected virtual string GetString(object obj)
		{
			object data = null;

			// Get value data
			data = GetValue(obj);
			
			// Check if data does exist
			if (data == null)
				return "";

			// Check if there is a format to be used
			if (format == null)
				return data.ToString();

			return String.Format(formatProvider, format, data);
		}

		/// <summary>
		/// Data's alignment
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public StringAlignment Alignment
		{
			get { return stringFormat.Alignment; }
			set { stringFormat.Alignment = value; }
		}

		/// <summary>
		/// String's format
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public string Format
		{
			get { return format; }
			set { format = value; }
		}

		/// <summary>
		/// Format provider
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public IFormatProvider FormatProvider
		{
			get { return formatProvider; }
			set { formatProvider = value; }
		}
	}
}
