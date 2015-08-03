/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Globalization;

namespace Report.Layout
{
	public class MetricCentimeter : Metric
	{
		public override float Parse(string centimeters)
		{
			//return 1 / 2.54f * 100 * float.Parse(centimeters, NumberFormatInfo.InvariantInfo);
			return float.Parse(centimeters, NumberFormatInfo.InvariantInfo) * 10f;
		}

		public override float Reverse(float value)
		{
			return value / 10f;
		}

		public override float Convert(float value)
		{
			return value * 10f;
		}

		public override string ToString()
		{
			return "cm";
		}

	}
}
