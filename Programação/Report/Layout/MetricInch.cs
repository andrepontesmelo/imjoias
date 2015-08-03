/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Globalization;

namespace Report.Layout
{
	public class MetricHInch : Metric
	{
		public override float Parse(string hInchs)
		{
			//return 1 / 2.54f * 100 * float.Parse(centimeters, NumberFormatInfo.InvariantInfo);
			return float.Parse(hInchs, NumberFormatInfo.InvariantInfo) * 2.54f / 10f;
		}

		public override float Reverse(float value)
		{
			return value * 2.54f / 10f;
		}

		public override float Convert(float value)
		{
			return value / 2.54f * 10f;
		}
		
		public override string ToString()
		{
			return "hinch";
		}
	}
}
