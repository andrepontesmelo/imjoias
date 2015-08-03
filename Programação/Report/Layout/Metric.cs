/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;

namespace Report.Layout
{
	public abstract class Metric
	{
		public enum Metrics { inch, cm }
		public abstract float Parse(string data);
		public abstract float Reverse(float value);
		public abstract float Convert(float value);

		public static Metric GetMetricParser(string metric)
		{
			if (metric == "cm")
				return new MetricCentimeter();
			
			if (metric == "inch")
				return new MetricHInch();

			return null;
		}

		public override string ToString()
		{
			return this.GetType().Name;
		}
	}
}
