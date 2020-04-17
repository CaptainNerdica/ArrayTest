using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ArrayTest
{
	public static class NDArrayExtensions
	{
		public static NDArray<double> Real(this NDArray<Complex> array) => new NDArray<double>(array.ObjectArray.Select(v => v.Real), array.Shape);
		public static NDArray<double> Imag(this NDArray<Complex> array) => new NDArray<double>(array.ObjectArray.Select(v => v.Imag), array.Shape);
		public static NDArray<double> Arg(this NDArray<Complex> array) => new NDArray<double>(array.Select(v => v.Arg), array.Shape);
		public static NDArray<double> Magnitude(this NDArray<Complex> array) => new NDArray<double>(array.Select(v => v.Magnitude), array.Shape);
		public static NDArray<Complex> Conj(this NDArray<Complex> array) => new NDArray<Complex>(array.Select(v => v.Conj), array.Shape);
		public static bool Any(this NDArray<bool> array) => array.Any(v => v);
		public static bool All(this NDArray<bool> array) => array.All(v => v);
		public static NDArray<bool> MaskOf<T>(this NDArray<T> array, Func<T,bool> func) where T : struct
		{
			NDArray<bool> newArray = new NDArray<bool>(array.Shape);
			List<NDArray.Index> indices = array.IndexOf(func);
			newArray[indices] = Enumerable.Repeat(true, indices.Count).ToList();
			return newArray;
		}

		public static string StringifyNestedList(IEnumerable list, int entrynumber = 0, int totalWidth = 0)
		{
			if(((IList)list).Count == 0)
				return "[]";
			string outstring = "[";
			foreach (var val in list)
			{
				if (typeof(IEnumerable).IsInstanceOfType(val))
					outstring += StringifyNestedList((IEnumerable)val, entrynumber + 1).PadLeft(totalWidth) + $",";
				else
					outstring += $"{val.ToString().PadLeft(totalWidth)},";
			}
			outstring = outstring.Substring(0,outstring.Length-1) + "]";
			return outstring;
		}
		public static string ListString<T>(this List<T> list)
		{
			return StringifyNestedList(list);
		}
	}
}