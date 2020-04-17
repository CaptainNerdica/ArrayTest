using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;

namespace ArrayTest
{
	public partial class NDArray<T>
	{
		public NDArray<T> Slice1D(int axis, int[] index)
		{
			if (axis >= this.Dimension || axis + index.Length > this.Dimension)
				throw new IndexOutOfRangeException();
			int _reached = 0;
			for (int i = 0; i < this.Dimension; i++)
			{
				if (i != axis)
				{
					if (index[i - _reached] >= this.Shape[i])
						throw new IndexOutOfRangeException();
				}
				else
					_reached = 1;
			}
			var _newArray = new NDArray<T>(this.Shape[axis]);
			for (int i = 0; i < this.Shape[axis]; i++)
			{
				int[] _newIndex = new int[this.Dimension];
				_reached = 0;
				for (int j = 0; j < this.Dimension; j++)
				{
					if (j != axis)
						_newIndex[j] = index[j - _reached];
					else
					{
						_reached += 1;
						_newIndex[j] = i;
					}
				}
				_newArray[i] = this[_newIndex];
			}
			return _newArray;
		}
		public NDArray<T> Copy() => new NDArray<T>((from v in this.ObjectArray.ToList() select v), this.Shape);
		public static bool ElementsEqual(NDArray<T> a, NDArray<T> b)
		{
			if (ReferenceEquals(a, b))
				return true;
			if (a.Shape != b.Shape)
				return false;
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < a.Size; i++)
				if (!comparer.Equals(a[i], b[i]))
					return false;
			return true;
		}
		public bool ElementsEqual(NDArray<T> other) => NDArray<T>.ElementsEqual(this, other);
		public static NDArray<bool> ElementWiseCompare(NDArray<T> a, NDArray<T> b, NDArray.CompareMode mode)
		{
			if (a.Shape != b.Shape)
				throw new NDArray.BadShapeException($"Cannot apply operation between array of shape {a.Shape} and {b.Shape}");
			return mode switch
			{
				NDArray.CompareMode.Equal => new NDArray<bool>(a.ObjectArray.Select((v, i) => (bool)(v == (dynamic)b[i])), a.Shape),
				NDArray.CompareMode.NotEqual => new NDArray<bool>(a.ObjectArray.Select((v, i) => (bool)(v != (dynamic)b[i])), a.Shape),
				NDArray.CompareMode.GreaterThan => new NDArray<bool>(a.ObjectArray.Select((v, i) => (bool)(v > (dynamic)b[i])), a.Shape),
				NDArray.CompareMode.LessThan => new NDArray<bool>(a.ObjectArray.Select((v, i) => (bool)(v < (dynamic)b[i])), a.Shape),
				NDArray.CompareMode.GreaterThanOrEqual => new NDArray<bool>(a.ObjectArray.Select((v, i) => (bool)(v >= (dynamic)b[i])), a.Shape),
				NDArray.CompareMode.LessThanOrEqual => new NDArray<bool>(a.ObjectArray.Select((v, i) => (bool)(v <= (dynamic)b[i])), a.Shape),
				_ => new NDArray<bool>(a.ObjectArray.Select((v, i) => (bool)(v == (dynamic)b[i])), a.Shape)
			};
			;
		}
		public NDArray<bool> ElementWiseCompare(NDArray<T> other, NDArray.CompareMode mode) => ElementWiseCompare(this, other, mode);
		public T Max()
		{
			return this.ObjectArray.Max();
		}
		public T Min()
		{
			return this.ObjectArray.Min();
		}
		public static NDArray<T> Fill(T val, NDArray.Shape shape)
		{
			return new NDArray<T>(Enumerable.Repeat(val, shape.Size), shape);
		}
		public void Fill(T val)
		{
			this.ObjectArray = Enumerable.Repeat(val, this.Size).ToArray();
		}

		public static List<NDArray<T>> SliceDimension(NDArray<T> array, int dimension)
		{
			if (dimension > array.Dimension)
				throw new IndexOutOfRangeException();
			var list = new List<NDArray<T>>();
			var newShape = new NDArray.Shape(array.Shape.ToList().Where((val, index) => index != dimension).ToArray());
			foreach (int i in Enumerable.Range(0, array.Shape[dimension]))
			{
				var newArray = array.Where((val, index) => NDArray.DimensionalIndex(array.Shape, index)[dimension] == i).ToArray();
				list.Add(new NDArray<T>(newArray, newShape));
			}
			return list;
		}
		public static NDArray<T> SliceDimension(NDArray<T> array, int dimension, int index)
		{
			if (dimension > array.Dimension)
				throw new IndexOutOfRangeException();
			if (index > array.Shape[dimension])
				throw new IndexOutOfRangeException();
			var newShape = new NDArray.Shape(array.Shape.ToList().Where((val, i) => i != dimension).ToArray());
			var newArray = array.Where((val, i) => NDArray.DimensionalIndex(array.Shape, index)[dimension] == i).ToArray();
			return new NDArray<T>(newArray, newShape);
		}
		public NDArray<T> SliceDimension(int dimension, int index) => NDArray<T>.SliceDimension(this, dimension, index);
		public List<NDArray<T>> SliceDimension(int dimension) => NDArray<T>.SliceDimension(this, dimension);
		public NDArray<T> Flatten() => new NDArray<T>(this.ObjectArray);
		private static string StringBuilder(NDArray<T> array)
		{
			string stringbuilder;
			List<object> listbuilder;
			if (array.Dimension > 1)
				listbuilder = RecursiveBuilder(SliceDimension(array, array.Dimension - 1).Cast<object>().ToList());
			else
				listbuilder = array.ToList().Cast<object>().ToList();
			stringbuilder = NDArrayExtensions.StringifyNestedList(listbuilder);
			return stringbuilder;
		}
		private static List<object> RecursiveBuilder(List<object> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (typeof(NDArray<T>).IsInstanceOfType(list[i]))
				{
					if (((NDArray<T>)list[i]).Dimension > 1)
					{
						list[i] = SliceDimension((NDArray<T>)list[i], ((NDArray<T>)list[i]).Dimension - 1);
					}
				}
				if (typeof(List<NDArray<T>>).IsInstanceOfType(list[i]))
				{
					list[i] = RecursiveBuilder(((IList)list[i]).Cast<object>().ToList());

				}
			}

			return list;
		}
		public override string ToString()
		{
			if (this.Dimension > 1)
				return StringBuilder(this);
			else
				return NDArrayExtensions.StringifyNestedList(this);
		}
		public static NDArray<T> MaskArray(NDArray<T> array, NDArray<bool> mask)
		{
			if (array.Shape != mask.Shape)
			{
				var indices = mask.IndexOf(v => v);
				var outArray = new NDArray<T>(array.Shape) { [indices] = array[indices] };
				return outArray;
			}
			else
				throw new NDArray.BadShapeException($"Cannot apply mask of shape {mask.Shape} to an array of shape {array.Shape}");
		}
		public static NDArray<T> MaskArray(NDArray<T> array, Func<T, bool> func)
		{
			var indices = array.IndexOf(func);
			var outArray = new NDArray<T>(array.Shape) { [indices] = array[indices] };
			return outArray;
		}
		public NDArray<T> MaskArray(NDArray<bool> mask) => MaskArray(this, mask);
		public NDArray<T> MaskArray(Func<T, bool> func) => MaskArray(this, func);
	}
}
