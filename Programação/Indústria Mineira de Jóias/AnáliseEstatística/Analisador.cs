using System;
using System.Globalization;

namespace Indústria_Mineira_de_Jóias.AnáliseEstatística
{
	public abstract class Analisador : MarshalByRefObject
	{
		#region Transformação de dados

		public static string DbTransformar(DateTime dt)
		{
			if (dt == DateTime.MinValue)
				return "null";
			else
				return "'" + dt.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo) + "'";
		}

		public static string DbTransformar(string s)
		{
			if (s == null)
				return "null";
			
			s = s.Replace("\\", "\\\\");
			s = s.Replace("'", "\\'");
			s = s.Replace("%", "\\%");

			return "'" + s + "'";
		}

		public static string DbTransformar(double d)
		{
			return "'" + d.ToString(NumberFormatInfo.InvariantInfo) + "'";
		}

		public static string DbTransformar(long l)
		{
			return "'" + l.ToString(NumberFormatInfo.InvariantInfo) + "'";
		}

		public static string DbTransformar(int i)
		{
			return "'" + i.ToString(NumberFormatInfo.InvariantInfo) + "'";
		}

		public static string DbTransformar(bool b)
		{
			return b ? "'1'" : "'0'";
		}

		public static string DbTransformar(System.Reflection.MethodBase mb)
		{
			try
			{
				return mb == null ? "null" : "'" + mb.ToString() + "'";
			}
			catch
			{
				return "null";
			}
		}
		/*
					public string DbTransformar(byte [] bv)
					{
						string valor = "";

						foreach (byte b in bv)
						{
							if ((char) b == '\'')
								valor += "\\";
							valor += (char) b;
						}

						return valor;
					}
			*/
		#endregion

	}
}
