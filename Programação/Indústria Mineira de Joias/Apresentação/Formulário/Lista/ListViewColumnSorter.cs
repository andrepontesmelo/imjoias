
    using System;
    using System.Collections;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Globalization;

namespace Apresentação.Formulários
{
    public class ListViewColumnSorter : IComparer
    {
        public enum SortModifiers
        {
            SortByImage,
            SortByCheckbox,
            SortByText
        }

        public int ColumnToSort;
        public SortOrder OrderOfSort;
        private NumberCaseInsensitiveComparer ObjectCompare;
        private ImageTextComparer FirstObjectCompare;
        private CheckboxTextComparer FirstObjectCompare2;

        private SortModifiers mySortModifier = SortModifiers.SortByText;
        public SortModifiers _SortModifier
        {
            set
            {
                mySortModifier = value;
            }
            get
            {
                return mySortModifier;
            }
        }

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;

            ObjectCompare = new NumberCaseInsensitiveComparer();
            FirstObjectCompare = new ImageTextComparer();
            FirstObjectCompare2 = new CheckboxTextComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult = 0;
            ListViewItem listviewX, listviewY;

            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            ListView listViewMain = listviewX.ListView;

            if (listViewMain.Sorting != SortOrder.Ascending &&
                listViewMain.Sorting != SortOrder.Descending)
            {
                return compareResult;
            }

            if (mySortModifier.Equals(SortModifiers.SortByText) || ColumnToSort > 0)
            {
                if (listviewX.SubItems.Count <= ColumnToSort &&
                    listviewY.SubItems.Count <= ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(null, null);
                }
                else if (listviewX.SubItems.Count <= ColumnToSort &&
                         listviewY.SubItems.Count > ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(null, listviewY.SubItems[ColumnToSort].Text.Trim());
                }
                else if (listviewX.SubItems.Count > ColumnToSort && listviewY.SubItems.Count <= ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text.Trim(), null);
                }
                else
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text.Trim(), listviewY.SubItems[ColumnToSort].Text.Trim());
                }
            }
            else
            {
                switch (mySortModifier)
                {
                    case SortModifiers.SortByCheckbox:
                        compareResult = FirstObjectCompare2.Compare(x, y);
                        break;
                    case SortModifiers.SortByImage:
                        compareResult = FirstObjectCompare.Compare(x, y);
                        break;
                    default:
                        compareResult = FirstObjectCompare.Compare(x, y);
                        break;
                }
            }

            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }


        internal void OnClick(ListView listView, ColumnClickEventArgs e)
        {
            if (listView.Sorting == SortOrder.None)
                listView.Sorting = SortOrder.Ascending;

            if (e.Column == SortColumn)
            {
                if (Order == SortOrder.Ascending)
                {
                    Order = SortOrder.Descending;
                }
                else
                {
                    Order = SortOrder.Ascending;
                }
            }
            else
            {
                SortColumn = e.Column;
                Order = SortOrder.Ascending;
            }

            listView.Sort();
        }
    }

    public class ImageTextComparer : IComparer
    {
        private NumberCaseInsensitiveComparer ObjectCompare;

        public ImageTextComparer()
        {
            ObjectCompare = new NumberCaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int image1, image2;
            ListViewItem listviewX, listviewY;

            listviewX = (ListViewItem)x;
            image1 = listviewX.ImageIndex;
            listviewY = (ListViewItem)y;
            image2 = listviewY.ImageIndex;

            if (image1 < image2)
            {
                return -1;
            }
            else if (image1 == image2)
            {
                return ObjectCompare.Compare(listviewX.Text.Trim(), listviewY.Text.Trim());
            }
            else
            {
                return 1;
            }
        }
    }

    public class CheckboxTextComparer : IComparer
    {
        private NumberCaseInsensitiveComparer ObjectCompare;

        public CheckboxTextComparer()
        {
            ObjectCompare = new NumberCaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            ListViewItem listviewX = (ListViewItem)x;
            ListViewItem listviewY = (ListViewItem)y;

            if (listviewX.Checked && !listviewY.Checked)
            {
                return -1;
            }
            else if (listviewX.Checked.Equals(listviewY.Checked))
            {
                if (listviewX.ImageIndex < listviewY.ImageIndex)
                {
                    return -1;
                }
                else if (listviewX.ImageIndex == listviewY.ImageIndex)
                {
                    return ObjectCompare.Compare(listviewX.Text.Trim(), listviewY.Text.Trim());
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
    }

    public class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
    {
        private static readonly string currencySymbol = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;

        public NumberCaseInsensitiveComparer()
        {

        }

        public new int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null && y != null)
            {
                return -1;
            }
            else if (x != null && y == null)
            {
                return 1;
            }

            if ((x is System.String) && ((string)x).Contains(currencySymbol))
            {
                try
                {
                    decimal xx = decimal.Parse((string)x, NumberStyles.Currency);
                    decimal yy = decimal.Parse((string)y, NumberStyles.Currency);

                    return base.Compare(xx, yy);
                } catch
                {
                    return -1;
                }

            }

            DateTime timeX;
            DateTime timeY;

            if ((x is String) && DateTime.TryParse(((string) x), out timeX)
            && (y is String) && DateTime.TryParse(((string) y), out timeY))
            {
                return timeX.CompareTo(timeY);
            }


            if ((x is System.String) && IsDecimalNumber((string)x) && (y is System.String) && IsDecimalNumber((string)y))
            {
                try
                {
                    decimal xx = Decimal.Parse(((string)x).Trim());
                    decimal yy = Decimal.Parse(((string)y).Trim());

                    return base.Compare(xx, yy);
                }
                catch
                {
                    return -1;
                }
            }
            else
            {
                return base.Compare(x, y);
            }
        }

        private string GetNumberDecimalSeparator()
        {
            return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }

        private bool IsDecimalNumber(string strNumber)
        {
            string regex = @"^-?(\d+|(\d{1,3}((,|\.)\d{3})*))((,|\.)\d+)?$";

            Regex wholePattern = new Regex(regex);
            return wholePattern.IsMatch(strNumber);
        }
    }
}