/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Xml;

namespace Report.Layout.Complex
{
	[Serializable]
	public class ImageMapped : Mapping, IPrintableItem
	{
		private RectangleF			location;
		private Border				border = null;
		private Metric				metric = new MetricCentimeter();
		private bool				fit = true; // Fit image

		// Design mode
		private bool				designMode = false;
		private string				_memberName = null;
		private string				_typeName = null;

		/// <summary>
		/// Constructs a ImageMapped
		/// </summary>
		public ImageMapped() {}

		/// <summary>
		/// Constructs a ImageMapped
		/// </summary>
		/// <param name="type">Type of object that contains data to be printed</param>
		/// <param name="member">Member containg data to be printed</param>
		public ImageMapped(Type type, string member)
		{
			SetMember(type, member);

			_memberName = member;
			_typeName   = type.FullName;
		}

		/// <summary>
		/// Location of printable item
		/// </summary>
		[System.ComponentModel.Category("Layout")]
		[System.ComponentModel.Browsable(false)]
		public System.Drawing.RectangleF Location
		{
			get { return location; }
			set { location = value; }
		}

		#region Location properties

		public float Top
		{
			get { return metric.Reverse(location.Y); }
			set { location.Y = metric.Convert(value); }
		}

		public float Left
		{
			get { return metric.Reverse(location.X); }
			set { location.X = metric.Convert(value); }
		}

		public float Width
		{
			get { return metric.Reverse(location.Width); }
			set { location.Width = metric.Convert(value); }
		}

		public float Height
		{
			get { return metric.Reverse(location.Height); }
			set { location.Height = metric.Convert(value); }
		}

		#endregion

		/// <summary>
		/// Label's border
		/// </summary>
		[System.ComponentModel.Category("Appearence")]
		public Border Border
		{
			get { return border; }
			set
			{
				border = value;

				if (border != null)
					border.Owner = this;
			}
		}

		/// <summary>
		/// Fit the image in location's area
		/// </summary>
		[System.ComponentModel.Category("Layout")]
		[System.ComponentModel.Browsable(true)]
		[System.ComponentModel.DefaultValue(true)]
		public bool Fit
		{
			get { return fit; }
			set { fit = value; }
		}

		/// <summary>
		/// Print static label
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		public void Print(System.Drawing.Graphics g, object obj)
		{
			if (designMode || MatchTypeObject(obj))
			{
                Image image = GetImage(obj);

                // First, set unit of measure to milimiters
				g.PageUnit = GraphicsUnit.Millimeter;

				// Draws border
				if (border != null)
					border.Print(g, obj);

				// Check if it's on design mode
                if (designMode)
                {
                    g.DrawString(TypeName + "." + MemberName + "\n(ImageMapped)", new Font(FontFamily.GenericSansSerif, 12),
                        Brushes.Black, Location);
                }
                else if (image == null)
                {
                    return;
                }
                else if (fit)
                {
                    float imgProportion = (float)image.Width / image.Height;
                    float locProportion = (float)location.Width / location.Height;
                    SizeF prnSize;

                    if (imgProportion >= locProportion)
                        prnSize = new Size((int)Math.Round(location.Width), (int)Math.Round(location.Width / imgProportion));
                    else
                        prnSize = new Size((int)Math.Round(location.Height * imgProportion), (int)Math.Round(location.Height));

                    g.DrawImage(image,
                        location.Left + (location.Width - prnSize.Width) / 2,
                        location.Top + (location.Height - prnSize.Height) / 2,
                        prnSize.Width,
                        prnSize.Height);
                }
                else
                    g.DrawImage(GetImage(obj), Location);

				if (border != null)
					border.EnsureBorderVisible(g, obj);
			}
		}

		/// <summary>
		/// Get image
		/// </summary>
		/// <returns>Image to print</returns>
		protected virtual Image GetImage(object obj)
		{
			Image image = (Image) GetValue(obj);

			return image;
		}
		
		/// <summary>
		/// Configure layout from xml
		/// </summary>
		public virtual void FromXml(XmlElement element, IDictionary typeDictionary)
		{
			location = new RectangleF(
				metric.Parse(element.GetAttribute("Left")),
				metric.Parse(element.GetAttribute("Top")),
				metric.Parse(element.GetAttribute("Width")),
				metric.Parse(element.GetAttribute("Height")));

			// Gets member
			if (designMode)
			{
				XmlElement member = element["Member"];

				_memberName = member.GetAttribute("Name");
				_typeName = member.GetAttribute("Type");
			}
			else
				SetMember(element["Member"], typeDictionary);

			// Get border
			XmlElement xmlBorder = element["Border"];

			if (xmlBorder != null)
			{
				this.Border = new Border(this);
				this.border.FromXml(xmlBorder, typeDictionary);
			}
		}

		/// <summary>
		/// Save printable item into a xml element
		/// </summary>
		public void SaveXml(XmlDocument doc, XmlElement element)
		{
			Type type;

			type = this.GetType();

			if (!type.FullName.StartsWith("Report.Layout.Complex."))
				element.SetAttribute("Type", this.GetType().FullName);

			element.SetAttribute("Left", metric.Reverse(location.X).ToString(NumberFormatInfo.InvariantInfo));
			element.SetAttribute("Top", metric.Reverse(location.Y).ToString(NumberFormatInfo.InvariantInfo));
			element.SetAttribute("Width", metric.Reverse(location.Width).ToString(NumberFormatInfo.InvariantInfo));
			element.SetAttribute("Height", metric.Reverse(location.Height).ToString(NumberFormatInfo.InvariantInfo));

			XmlElement xmlMember = doc.CreateElement("Member");
			xmlMember.SetAttribute("Name", _memberName);
			xmlMember.SetAttribute("Type", _typeName);
			element.AppendChild(xmlMember);

			if (this.border != null)
			{
				XmlElement xmlBorder = doc.CreateElement("Border");
				border.SaveXml(doc, xmlBorder);
				element.AppendChild(xmlBorder);
			}
		}

		/// <summary>
		/// Set properties to pageLayout's default.
		/// </summary>
		/// <param name="pageLayout">PageLayout containing default properties</param>
		public void SetDefault(ILayout pageLayout)
		{
			this.Border	= (Border) pageLayout.DefaultBorder.Clone();
			this.metric = pageLayout.DefaultMetric;
		}

		/// <summary>
		/// Metric used
		/// </summary>
		public Metric Metric
		{
			get { return metric; }
			set { metric = value; }
		}

		/// <summary>
		/// Design mode
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public bool DesignMode
		{
			get { return designMode; }
			set { designMode = value; }
		}

		/// <summary>
		/// Member's name
		/// </summary>
		public string MemberName
		{
			get { return member != null ? member.Name : _memberName; }
			set { _memberName = value; member = null; }
		}

		/// <summary>
		/// Type member
		/// </summary>
		public string TypeName
		{
			get { return member != null ? member.DeclaringType.Namespace + "." + member.DeclaringType.Name : _typeName; }
			set { _typeName = value; member = null; }
		}
	}
}
