using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ArrayTest
{
	public partial class NDArray<T>
	{
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.ObjectArray.GetEnumerator();
		}
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.ObjectArray.ToList().GetEnumerator();
		}
		public int LinearIndexOf(T item) => this.ObjectArray.ToList().IndexOf(item);
		public NDArray.Index IndexOf(T item) => NDArray.DimensionalIndex(this.Shape, LinearIndexOf(item));
		public void Clear()
		{
			this.ObjectArray = new T[this.Size];
		}
		public bool Contains(T item)
		{
			return this.ObjectArray.Contains(item);
		}
		public NDArray<TOut> Cast<TOut>() where TOut : struct
		{
			try
			{
				return new NDArray<TOut>(this.Select(v => (TOut)Convert.ChangeType(v, typeof(TOut))), this.Shape);
			}
			catch (InvalidCastException)
			{
				return new NDArray<TOut>(this.Select(v => (TOut)(dynamic)v), this.Shape);
			}
		}
		public void ForEach(Action<T> action) => this.ObjectArray.ToList().ForEach(action);
		public List<NDArray.Index> IndexOf(Func<T,bool> function)
		{
			var indices = new List<int>();
			return this.Where((x, i) => { if (function(x)) { indices.Add(i); return true; } else return false; }).Select((x,i) => NDArray.DimensionalIndex(this.Shape, indices[i])).ToList();
		}
	}
}
