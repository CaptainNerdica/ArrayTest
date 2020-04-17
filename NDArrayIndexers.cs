using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayTest
{
	public partial class NDArray<T>
	{
		public T this[int index]
		{
			get => this.ObjectArray[index];
			set => this.ObjectArray[index] = value;
		}
		public T this[NDArray.Index index]
		{
			get => this.ObjectArray[index.ToLinear(this.Shape)];
			set => this.ObjectArray[index.ToLinear(this.Shape)] = value;
		}
		public T this[List<int> index]
		{
			get => this[new NDArray.Index(index.ToArray())];
			set => this[new NDArray.Index(index.ToArray())] = value;
		}
		public T this[params int[] index]
		{
			get => this[new NDArray.Index(index)];
			set => this[new NDArray.Index(index)] = value;
		}
		public List<T> this[List<NDArray.Index> indices]
		{
			get
			{
				var outlist = new List<T>();
				indices.ForEach(index => outlist.Add(this[index]));
				return outlist;
			}
			set
			{
				for(int i = 0; i < indices.Count; i++)
					this[indices[i]] = value[i];
			}
		}
		public List<T> this[Func<T,bool> function]
		{
			get => this[this.IndexOf(function)];
			set => this[this.IndexOf(function)] = value;
		}
	}
}