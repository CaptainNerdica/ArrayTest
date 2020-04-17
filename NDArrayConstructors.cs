using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayTest
{
	[Serializable]
	public partial class NDArray<T> : IReadOnlyList<T> where T : struct
	{
		public T[] ObjectArray { get; set; }
		public int Size { get { return this.ObjectArray.Length; } }
		protected NDArray.Shape _shape;
		public NDArray.Shape Shape { get { return this._shape; } set { this._shape = TryShape(value, this.Size); } }
		public int Dimension { get { return this._shape.Dimension; } }
		public int Count { get => this.Size; }
		public Type ValueType { get => typeof(T); }

		public NDArray()
		{
			this.ObjectArray = new T[0];
		}
		public NDArray(int size)
		{
			this.ObjectArray = Enumerable.Repeat(default(T), size).ToArray();
			this._shape = new NDArray.Shape(size);
		}
		public NDArray(NDArray.Shape shape)
		{
			this.ObjectArray = Enumerable.Repeat(default(T), shape.Size).ToArray();
			this.Shape = shape;
		}
		public NDArray(T[] array, NDArray.Shape shape)
		{
			this.ObjectArray = array.ToArray();
			this.Shape = shape;
		}
		public NDArray(IEnumerable<T> enumerable, NDArray.Shape shape)
		{
			this.ObjectArray = enumerable.ToArray();
			this.Shape = shape;
		}
		public NDArray(IEnumerable<T> enumerable)
		{
			this.ObjectArray = enumerable.ToArray();
			this._shape = new NDArray.Shape(ObjectArray.Length);
		}
		public NDArray(T fillValue, NDArray.Shape shape)
		{
			this.ObjectArray = Enumerable.Repeat(fillValue, shape.Size).ToArray();
			this.Shape = shape;
		}
	}
}
