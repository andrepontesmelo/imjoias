/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Globalization;
using System.Drawing;
using System.Reflection;
using Report.Layout;

namespace Report.Layout.Simple
{
	public class Column : MappingAlphanumeric
	{
		// Relationship
		private Line			line;		// Line which contains this column
		private int				index;

		// Identification
		private string			label;

		// Layout
		private float			x;			// Absolute X position
		private float			width;
		protected Font			font		= new Font(FontFamily.GenericSansSerif, 12);
		protected Brush			brush		= Brushes.Black;

		// Data properties
		private bool			toSum		= false;
		private double			sumPage		= 0;
		private double			sumTotal	= 0;

		/// <summary>
		/// Constructs from a property
		/// </summary>
		public Column(PropertyInfo prop)
		{
			SetMember(prop, prop.PropertyType);
			label = CreateLabelFromMemberName(prop.Name);
		}

		/// <summary>
		/// Constructs from a filed
		/// </summary>
		public Column(FieldInfo field)
		{
			SetMember(field, field.FieldType);
			label = CreateLabelFromMemberName(field.Name);
		}

		/// <summary>
		/// Constructs from a label, a type and a member
		/// </summary>
		/// <param name="label">Column's label</param>
		/// <param name="type">Type which contains the data to be printed</param>
		/// <param name="member">Member which contains the data to be printed</param>
		public Column(string label, Type type, string member)
		{
			SetMember(type, member);
			this.label = label;
		}

		/// <summary>
		/// Label
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public string Label
		{
			get { return label; }
			set { label = value; }
		}

		/// <summary>
		/// Create a label from member's name
		/// </summary>
		private static string CreateLabelFromMemberName(string name)
		{
			bool	separate		= false;
			string	label			= "";

			foreach (char c in name)
			{
				if (char.IsLower(c))
					separate = true;

				else if (separate)
				{
					label  += " ";
					separate = false;
				}

				label += c;
			}

			// Make sure that first letter's labe is upper
			if (char.IsLower(label[0]))
				label = char.ToUpper(label[0]) + label.Substring(1);

			return label;
		}

		/// <summary>
		/// Line which contains this column
		/// </summary>
		internal Line Line
		{
			get { return line; }
			set
			{
				line = value;
				index = value.Columns.Count;
			}
		}

		/// <summary>
		/// Absolute X position
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public float X
		{
			get { return x; }
			set { x = value; }
		}

		/// <summary>
		/// Tamanho horizontal da column
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public float Width
		{
			get { return width; }
			set { width = value; }
		}

		/// <summary>
		/// Gets a double value from object
		/// </summary>
		/// <param name="obj">Object that contains the double value data</param>
		protected double GetDouble(object obj)
		{
			object data = null;

			// Verificar se o member é um atributo ou property
			switch (member.MemberType)
			{
				case MemberTypes.Property:
					data = ((PropertyInfo) member).GetValue(
						obj, null);
					break;

				case MemberTypes.Field:
					data = ((FieldInfo) member).GetValue(obj);
					break;
			}
			
			if (memberType == typeof(double))
				return (double) data;
			else if (memberType == typeof(float))
				return (double) ((float) data);
			else if (memberType == typeof(long))
				return (double) ((float) data);
			else if (memberType == typeof(int))
				return (double) ((int) data);

			return double.NaN;
		}

		/// <summary>
		/// Print a data
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="obj">Object that contains data to be printed</param>
		public void Print(Graphics g, object obj, float y)
		{
			string data;

			// Check the object's type
			if (MatchTypeObject(obj))
			{
				// Get data
				data = GetString(obj);

				// Drawn
				PrintData(g, data, y);

				// Sum, if necessary
				if (toSum)
				{
					sumPage  += GetDouble(obj);
					sumTotal += GetDouble(obj);
				}
			}
		}

		/// <summary>
		/// Print data
		/// </summary>
		public void PrintData(Graphics g, string data, float y)
		{
			// Desenhar
			g.DrawString(
				data,
				this.font,
				this.brush,
				new RectangleF(
					new PointF(x, y),
					new SizeF(width, 999999)),
				this.stringFormat);
		}

		/// <summary>
		/// Calculates the data printed size
		/// </summary>
		/// <param name="g">Graphics object where the data will be drawn</param>
		/// <param name="obj">Object that contains data to be printed</param>
		/// <returns>Area needed to print data</returns>
		public SizeF MeasureDataPrint(Graphics g, object obj)
		{
			SizeF	size;
			string	data;
			
			if (MatchTypeObject(obj))
			{
				// Get data
				data = GetString(obj);
			
				// Calculate size
				size = g.MeasureString(
					data,
					this.font,
					(int) this.width,
					this.stringFormat);

				return size;
			}
			else
				return new SizeF(0, 0);
		}

		/// <summary>
		/// Is data to be summed?
		/// </summary>
		public bool ToSum
		{
			get { return toSum; }
			set { toSum = value; }
		}

		/// <summary>
		/// Page's sum
		/// </summary>
		internal double SumPage
		{
			get { return sumPage; }
			set { sumPage = value; }
		}

		/// <summary>
		/// Total sum
		/// </summary>
		internal double SumTotal
		{
			get { return sumTotal; }
			set { sumTotal = value; }
		}

		/// <summary>
		/// Font used to print data
		/// </summary>
		public Font Font
		{
			get { return font; }
			set { font = value; }
		}

		/// <summary>
		/// Brush used to print data
		/// </summary>
		public Brush Brush
		{
			get { return brush; }
			set { brush = value; }
		}
	}
}
