using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;


namespace ArrayTest
{

	[Serializable]
	public class NDArray
	{
		public class BadShapeException : Exception
		{
			public BadShapeException(string message) : base(message)
			{
			}
			public BadShapeException(string message, Exception innerException) : base(message, innerException)
			{
			}
		}
		public enum CompareMode
		{
			Equal = 0,
			NotEqual = 1,
			GreaterThan = 2,
			LessThan = 3,
			GreaterThanOrEqual = 4,
			LessThanOrEqual = 5
		}
		[Serializable]
		public struct Shape
		{
			public int Dimension { get { return this.Sizes.Length; } }
			public int Size { get { return SizeFromShape(this); } }
			public int[] Sizes { get; set; }
			public Shape(params int[] sizes)
			{
				this.Sizes = sizes;
			}
			public int this[int dim] { get => this.Sizes[dim]; }
			private static int SizeFromShape(Shape shape)
			{
				int size = 1;
				foreach (int i in shape.Sizes)
					size *= i;
				return size;
			}
			public int[] ToArray() => this.Sizes;
			public List<int> ToList() => this.Sizes.ToList();
			public static bool operator ==(Shape a, Shape b)
			{
				if (a.Dimension != b.Dimension) return false;
				for (int i = 0; i < a.Dimension; i++)
					if (a[i] != b[i])
						return false;
				return true;
			}
			public static bool operator !=(Shape a, Shape b) => !(a == b);
			public override bool Equals(object obj) => base.Equals(obj);
			public override int GetHashCode() => base.GetHashCode();
			public override string ToString() => GetShapeString(this);
			private static string GetShapeString(Shape shape)
			{
				string shapestring = "(";
				for (int i = 0; i < shape.Dimension - 1; i++)
					shapestring += shape[i] + ",";
				shapestring += shape[shape.Dimension - 1] + ")";
				return shapestring;
			}
		}
		[Serializable]
		public struct Index
		{
			public int Dimension { get => this.Indices.Length; }
			public int[] Indices { get; private set; }
			public static readonly Index Empty = new Index() { Indices = null };
			public Index(int dimension) { this.Indices = new int[dimension]; }
			public Index(params int[] indices) { this.Indices = indices; }
			public int this[int index] { get => Indices[index]; }
			public int[] ToArray() => this.Indices;
			public List<int> ToList() => this.Indices.ToList();
			public static bool operator ==(Index a, Index b)
			{
				if (a.Dimension != b.Dimension) return false;
				for (int i = 0; i < a.Dimension; i++)
					if (a[i] != b[i])
						return false;
				return true;
			}
			private static int ToLinear(Index index, Shape shape)
			{
				if (index.Dimension == shape.Dimension)
				{
					if (ValidIndex(index, shape))
					{
						int newIndex = 0;
						for (int i = index.Dimension - 1; i >= 1; i--)
						{
							newIndex = shape[index.Dimension - 1 - i] * (newIndex + index[i]);
						}
						newIndex += index[0];
						return newIndex;
					}
					else
						throw new IndexOutOfRangeException();
				}
				else
					throw new BadShapeException($"Index of dimension {index.Dimension} cannot be applied to Shape of dimension {shape.Dimension}");
			}
			public int ToLinear(Shape shape) => ToLinear(this, shape);
			public static bool operator !=(Index a, Index b) => !(a == b);
			public override bool Equals(object obj) => base.Equals(obj);
			public override int GetHashCode() => base.GetHashCode();
			public override string ToString() => GetIndexString(this);
			private static string GetIndexString(Index index)
			{
				if (index.Equals(Index.Empty))
					return "()";
				string indexstring = "(";
				for (int i = 0; i < index.Dimension - 1; i++)
					indexstring += index[i] + ",";
				indexstring += index[index.Dimension - 1] + ")";
				return indexstring;
			}
		}
		public static Index DimensionalIndex(Shape shape, int linearIndex)
		{
			if (linearIndex == -1)
				return Index.Empty;
			if (ValidLinearIndex(shape, linearIndex))
				throw new IndexOutOfRangeException();
			int[] index = new int[shape.Dimension];
			int size = 1;
			for (int i = 0; i < shape.Dimension; i++)
			{
				index[i] = (linearIndex / size) % shape[i];
				size *= shape[i];
			}
			return new Index(index);
		}
		public static bool ValidLinearIndex(Shape shape, int linearIndex) => linearIndex > shape.Size - 1;
		public static bool ValidIndex(Index index, Shape shape)
		{
			for (int i = 0; i < index.Dimension; i++)
				if (index[i] >= shape[i])
					return false;
			return true;

		}
	}
}