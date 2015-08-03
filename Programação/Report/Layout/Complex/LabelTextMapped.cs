/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using System.ComponentModel;

namespace Report.Layout.Complex
{
	/// <summary>
	/// A pair of static label and text
	/// </summary>
	[Serializable]
	public class LabelTextMapped : PrintableItem
	{
		private StaticLabel		staticLabel;
		private TextMapped		textMapped;
		private Border			border;

		/// <summary>
		/// Constructs a label and a textmapped basend on a type's member
		/// </summary>
		/// <param name="type">Type containing member with data to be printed</param>
		/// <param name="member">Member containing data to be printed</param>
		public LabelTextMapped(Type type, string member)
		{
			textMapped		 = new TextMapped(type, member);
			staticLabel		 = new StaticLabel();
			staticLabel.Text = member;
			border			 = new Border(this);

			staticLabel.Alignment = ContentAlignment.TopCenter;
			textMapped.Alignment  = ContentAlignment.BottomCenter;

			textMapped.Brush = Brushes.Blue;
		}

		public LabelTextMapped()
		{
			staticLabel		 = new StaticLabel();
			textMapped		 = new TextMapped();
		}

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

		protected override void ChangingLocation()
		{
			staticLabel.Location = new RectangleF(
				0,
				0,
				Location.Width,
				Location.Height / 2);
			textMapped.Location = new RectangleF(
				0,
				Location.Height / 2,
				Location.Width,
				Location.Height / 2);
		}

		/// <summary>
		/// Print static label
		/// </summary>
		/// <param name="g">Graphics where this item will be printed</param>
		/// <param name="obj">Object containing data to be printed</param>
		public override void Print(Graphics g, object obj)
		{
			if (DesignMode || textMapped.MatchTypeObject(obj))
			{
				// First, set unit of measure to milimiters
				g.PageUnit = GraphicsUnit.Millimeter;

				if (border != null)
					border.Print(g, obj);

				// Backup and change locations
				RectangleF [] backup = new RectangleF[2]
					{ staticLabel.Location, textMapped.Location };

				try
				{
					staticLabel.Location = new RectangleF(
						staticLabel.Location.X + this.Location.X,
						staticLabel.Location.Y + this.Location.Y,
						Math.Min(staticLabel.Location.Width, this.Location.Width - staticLabel.Location.Left),
						Math.Min(staticLabel.Location.Height, this.Location.Height - staticLabel.Location.Top));

					textMapped.Location = new RectangleF(
						textMapped.Location.X + this.Location.X,
						textMapped.Location.Y + this.Location.Y,
						Math.Min(textMapped.Location.Width, this.Location.Width - textMapped.Location.Left),
						Math.Min(textMapped.Location.Height, this.Location.Height - textMapped.Location.Top));

					staticLabel.Print(g, obj);
					textMapped.Print(g, obj);
				}
				finally
				{
					staticLabel.Location = backup[0];
					textMapped.Location = backup[1];
				}
			}
		}

		/// <summary>
		/// Configure layout from xml
		/// </summary>
		public override void FromXml(System.Xml.XmlElement element, IDictionary typeDictionary)
		{
			base.FromXml (element, typeDictionary);

			// Get border
			XmlElement xmlBorder = element["Border"];

			if (xmlBorder != null)
			{
				this.Border = new Border(this);
				this.border.FromXml(xmlBorder, typeDictionary);
			}

			// Get StaticLabel
			staticLabel.FromXml(element["StaticLabel"], typeDictionary);

			// Get TextMapped
			textMapped.FromXml(element["TextMapped"], typeDictionary);
		}

		public override void SaveXml(XmlDocument doc, XmlElement element)
		{
			base.SaveXml (doc, element);

			if (this.border != null)
			{
				XmlElement xmlBorder = doc.CreateElement("Border");
				border.SaveXml(doc, xmlBorder);
				element.AppendChild(xmlBorder);
			}

			XmlElement xmlStaticLabel = doc.CreateElement("StaticLabel");
			staticLabel.SaveXml(doc, xmlStaticLabel);
			element.AppendChild(xmlStaticLabel);

			XmlElement xmlTextMapped = doc.CreateElement("TextMapped");
			textMapped.SaveXml(doc, xmlTextMapped);
			element.AppendChild(xmlTextMapped);
		}


		public StaticLabel StaticLabel
		{
			get { return staticLabel; }
		}

		public TextMapped TextMapped
		{
			get { return textMapped; }
		}

		/// <summary>
		/// Set properties to pageLayout's default.
		/// </summary>
		/// <param name="pageLayout">PageLayout containing default properties</param>
		public override void SetDefault(ILayout pageLayout)
		{
			base.SetDefault(pageLayout);

			this.Border						= (Border) pageLayout.DefaultBorder.Clone();

			this.staticLabel.SetDefault(pageLayout);
			this.textMapped.SetDefault(pageLayout);

			this.staticLabel.Border = null;
			this.textMapped.Border = null;
		}

		[System.ComponentModel.Browsable(false)]
		public override bool DesignMode
		{
			get
			{
				return base.DesignMode;
			}
			set
			{
				base.DesignMode = value;
				staticLabel.DesignMode = value;
				textMapped.DesignMode = value;
			}
		}


	}
}
