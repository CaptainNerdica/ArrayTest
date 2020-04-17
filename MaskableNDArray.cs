using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayTest
{
	public class MaskableArray<T> : NDArray<T> where T : struct
	{
		private NDArray<bool> _mask { get; set; }
		public NDArray<bool> Mask 
		{ 
			get => this._mask;
			set 
			{
				if (this.Shape != value.Shape)
					throw new NDArray.BadShapeException($"Cannot apply mask of shape {value.Shape} to an array of shape {this.Shape}");
				this._mask = value;
				if(value == null)
					this.HasMask = false;
				else
					this.HasMask = true;
			}
		}
		public bool HasMask { get; private set; }

		public MaskableArray(NDArray<T> array)
		{
			var copy = array.Copy();
			this.ObjectArray = copy.ObjectArray;
			this.Shape = copy.Shape;
			this.Mask = null;
		}
		public MaskableArray(NDArray<T> array, NDArray<bool> mask)
		{
			var copy = array.Copy();
			this.ObjectArray = copy.ObjectArray;
			this.Shape = copy.Shape;
			this.Mask = mask;
		}
		public MaskableArray(NDArray.Shape shape, NDArray<bool> mask)
		{
			this.ObjectArray = Enumerable.Repeat(default(T), shape.Size).ToArray();
			this.Shape = shape;
			this.Mask = mask;
		}
		public MaskableArray()
		{
			this.ObjectArray = new T[0];
		}
		public MaskableArray(int size)
		{
			this.ObjectArray = Enumerable.Repeat(default(T), size).ToArray();
			this._shape = new NDArray.Shape(size);
		}
		public MaskableArray(NDArray.Shape shape)
		{
			this.ObjectArray = Enumerable.Repeat(default(T), shape.Size).ToArray();
			this.Shape = shape;
		}
		public MaskableArray(T[] array, NDArray.Shape shape)
		{
			this.ObjectArray = array.ToArray();
			this.Shape = shape;
		}
		public MaskableArray(IEnumerable<T> enumerable, NDArray.Shape shape)
		{
			this.ObjectArray = enumerable.ToArray();
			this.Shape = shape;
		}
		public MaskableArray(IEnumerable<T> enumerable)
		{
			this.ObjectArray = enumerable.ToArray();
			this._shape = new NDArray.Shape(ObjectArray.Length);
		}
		public MaskableArray(T fillValue, NDArray.Shape shape)
		{
			this.ObjectArray = Enumerable.Repeat(fillValue, shape.Size).ToArray();
			this.Shape = shape;
		}
		public void ClearMask()
		{
			this.Mask = null;
		}
	}
}