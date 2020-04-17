using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayTest
{
	public partial class NDArray<T>
	{
		public static implicit operator T[](NDArray<T> a) => a.ObjectArray;
		public static implicit operator List<T>(NDArray<T> a) => a.ObjectArray.ToList();

		public static NDArray<TOut> Operation<TIn, TOut>(NDArray<TIn> a, Func<TIn, TOut> func) where TIn : struct where TOut : struct => new NDArray<TOut>(a.ObjectArray.Select(v => func(v)), a.Shape);

		public NDArray<TOut> Operation<TOut>(Func<T, TOut> func) where TOut : struct => new NDArray<TOut>(this.ObjectArray.Select(v => func(v)), this.Shape);

		public void OpEquals(Func<T, T> func) => this.ObjectArray = this.ObjectArray.Select(v => func(v)).ToArray();
		public static NDArray<TOut> Operation<T1, T2, TOut>(NDArray<T1> a, NDArray<T2> b, Func<T1, T2, TOut> func) where T1 : struct where T2 : struct where TOut : struct
		{
			if (a.Shape != b.Shape)
				throw new NDArray.BadShapeException($"Cannot apply operation between array of shape {a.Shape} and {b.Shape}");
			return new NDArray<TOut>(a.ObjectArray.Select((v, i) => func(v, b[i])), a.Shape);
		}
		public NDArray<TOut> Operation<T1, TOut>(NDArray<T1> other, Func<T, T1, TOut> func) where T1 : struct where TOut : struct
		{
			if (this.Shape != other.Shape)
				throw new NDArray.BadShapeException($"Cannot apply operation between array of shape {this.Shape} and {other.Shape}");
			return new NDArray<TOut>(this.ObjectArray.Select((v, i) => func(v, other[i])), this.Shape);
		}
		public static NDArray<T> Operation<T1, T2>(NDArray<T1> array, T2 val, Func<T1, T2, T> func) where T1 : struct where T2 : struct => new NDArray<T>(array.ObjectArray.Select(v => func(v, val)), array.Shape);
		public NDArray<TOut> Operation<T1, TOut>(T1 val, Func<T, T1, TOut> func) where T1 : struct where TOut : struct => new NDArray<TOut>(this.Select(v => func(v, val)), this.Shape);

		public void OpEquals(NDArray<T> b, Func<T, T, T> func)
		{
			if (this.Shape != b.Shape)
				throw new NDArray.BadShapeException($"Cannot apply operation between array of shape {this.Shape} and {b.Shape}");
			this.ObjectArray = this.ObjectArray.Select((v, i) => func(v, b[i])).ToArray();
		}
		public static NDArray<T> operator +(NDArray<T> a) => a;
		public static NDArray<T> operator -(NDArray<T> a) => new NDArray<T>(a.ObjectArray.Select(v => (T)(-(dynamic)v)), a.Shape);
		public static NDArray<T> operator +(NDArray<T> a, T b) => new NDArray<T>(a.Select(v => (T)((dynamic)v + b)), a.Shape); //Operation(a, v => (dynamic)v + b);
		public static NDArray<T> operator -(NDArray<T> a, T b) => new NDArray<T>(a.Select(v => (T)((dynamic)v - b)), a.Shape);
		public static NDArray<T> operator *(NDArray<T> a, T b) => new NDArray<T>(a.Select(v => (T)((dynamic)v * b)), a.Shape);
		public static NDArray<T> operator /(NDArray<T> a, T b) => new NDArray<T>(a.Select(v => (T)((dynamic)v / b)), a.Shape);
		public static NDArray<T> operator +(NDArray<T> a, NDArray<T> b)
		{
			if (a.Shape != b.Shape)
				throw new NDArray.BadShapeException($"Cannot apply operation between array of shape {a.Shape} and {b.Shape}");
			return new NDArray<T>(a.Select((v, i) => (T)((dynamic)v + b[i])),a.Shape);
		}
		public static NDArray<T> operator -(NDArray<T> a, NDArray<T> b)
		{
			if (a.Shape != b.Shape)
				throw new NDArray.BadShapeException($"Cannot apply operation between array of shape {a.Shape} and {b.Shape}");
			return new NDArray<T>(a.Select((v, i) => (T)((dynamic)v - b[i])), a.Shape);
		}
		public static NDArray<T> operator *(NDArray<T> a, NDArray<T> b)
		{
			if (a.Shape != b.Shape)
				throw new NDArray.BadShapeException($"Cannot apply operation between array of shape {a.Shape} and {b.Shape}");
			return new NDArray<T>(a.Select((v, i) => (T)((dynamic)v * b[i])), a.Shape);
		}
		public static NDArray<T> operator /(NDArray<T> a, NDArray<T> b)
		{
			if (a.Shape != b.Shape)
				throw new NDArray.BadShapeException($"Cannot apply operation between array of shape {a.Shape} and {b.Shape}");
			return new NDArray<T>(a.Select((v, i) => (T)((dynamic)v / b[i])), a.Shape);
		}
		public static bool operator ==(NDArray<T> a, NDArray<T> b) => a.Equals(b);
		public static bool operator !=(NDArray<T> a, NDArray<T> b) => !(a == b);
		public override bool Equals(object other) => base.Equals(other);
		public override int GetHashCode() => base.GetHashCode();
	}
}
