using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ArrayTest
{
	public static class NDArrayMath
	{
		private static double ToDouble(object o) => (double)Convert.ChangeType(o, typeof(double));

		public static NDArray<Complex> Sin(NDArray<Complex> array) => array.Operation(Complex.Sin);
		public static NDArray<Complex> Cos(NDArray<Complex> array) => array.Operation(Complex.Cos);
		public static NDArray<Complex> Tan(NDArray<Complex> array) => array.Operation(Complex.Tan);
		public static NDArray<Complex> Asin(NDArray<Complex> array) => array.Operation(Complex.Asin);
		public static NDArray<Complex> Acos(NDArray<Complex> array) => array.Operation(Complex.Acos);
		public static NDArray<Complex> Atan(NDArray<Complex> array) => array.Operation(Complex.Atan);
		public static NDArray<Complex> Sinh(NDArray<Complex> array) => array.Operation(Complex.Sinh);
		public static NDArray<Complex> Tanh(NDArray<Complex> array) => array.Operation(Complex.Tanh);
		public static NDArray<Complex> Cosh(NDArray<Complex> array) => array.Operation(Complex.Cosh);

		public static NDArray<double> Sin(NDArray<double> array) => array.Operation(Math.Sin);
		public static NDArray<double> Cos(NDArray<double> array) => array.Operation(Math.Cos);
		public static NDArray<double> Tan(NDArray<double> array) => array.Operation(Math.Tan);
		public static NDArray<double> Asin(NDArray<double> array) => array.Operation(Math.Asin);
		public static NDArray<double> Acos(NDArray<double> array) => array.Operation(Math.Acos);
		public static NDArray<double> Atan(NDArray<double> array) => array.Operation(Math.Atan);
		public static NDArray<double> Sinh(NDArray<double> array) => array.Operation(Math.Sinh);
		public static NDArray<double> Cosh(NDArray<double> array) => array.Operation(Math.Cosh);
		public static NDArray<double> Tanh(NDArray<double> array) => array.Operation(Math.Tanh);
		public static NDArray<double> Asinh(NDArray<double> array) => array.Operation(Math.Asinh);
		public static NDArray<double> Acosh(NDArray<double> array) => array.Operation(Math.Acosh);
		public static NDArray<double> Atanh(NDArray<double> array) => array.Operation(Math.Atanh);

		public static NDArray<double> Sin<T>(NDArray<T> array) where T : struct => Sin(array.Cast<double>());
		public static NDArray<double> Cos<T>(NDArray<T> array) where T : struct => Cos(array.Cast<double>());
		public static NDArray<double> Tan<T>(NDArray<T> array) where T : struct => Tan(array.Cast<double>());
		public static NDArray<double> Asin<T>(NDArray<T> array) where T : struct => Asin(array.Cast<double>());
		public static NDArray<double> Acos<T>(NDArray<T> array) where T : struct => Acos(array.Cast<double>());
		public static NDArray<double> Atan<T>(NDArray<T> array) where T : struct => Atan(array.Cast<double>());
		public static NDArray<double> Sinh<T>(NDArray<T> array) where T : struct => Sinh(array.Cast<double>());
		public static NDArray<double> Cosh<T>(NDArray<T> array) where T : struct => Cosh(array.Cast<double>());
		public static NDArray<double> Tanh<T>(NDArray<T> array) where T : struct => Tanh(array.Cast<double>());
		public static NDArray<double> Asinh<T>(NDArray<T> array) where T : struct => Asinh(array.Cast<double>());
		public static NDArray<double> Acosh<T>(NDArray<T> array) where T : struct => Acosh(array.Cast<double>());
		public static NDArray<double> Atanh<T>(NDArray<T> array) where T : struct => Atanh(array.Cast<double>());

		public static NDArray<double> Atan2(NDArray<double> array, NDArray<double> other) => array.Operation(other,Math.Atan2);
		public static NDArray<double> Atan2<T1,T2>(NDArray<T1> array, NDArray<T2> other) where T1 : struct where T2 : struct => array.Cast<double>().Operation(other.Cast<double>(), Math.Atan2);

		public static NDArray<bool> And(this NDArray<bool> array, NDArray<bool> other) => array.Operation(other, (u, v) => u && v);
		public static NDArray<bool> And(this NDArray<bool> array, bool other) => array.Operation(u => u && other);
		public static NDArray<bool> Or(this NDArray<bool> array, NDArray<bool> other) => array.Operation(other, (u, v) => u || v);
		public static NDArray<bool> Or(this NDArray<bool> array, bool other) => array.Operation(u => u || other);
		public static NDArray<bool> Xor(this NDArray<bool> array, NDArray<bool> other) => array.Operation(other, (u, v) => u ^ v);
		public static NDArray<bool> Xor(this NDArray<bool> array, bool other) => array.Operation(u => u ^ other);
		public static NDArray<bool> Equal(this NDArray<bool> array, NDArray<bool> other) => array.Operation(other, (u, v) => u == v);
		public static NDArray<bool> Equal(this NDArray<bool> array, bool other) => array.Operation(u => u == other);
		public static NDArray<bool> NotEqual(this NDArray<bool> array, NDArray<bool> other) => array.Operation(other, (u, v) => u != v);
		public static NDArray<bool> NotEqual(this NDArray<bool> array, bool other) => array.Operation(u => u != other);
		public static NDArray<bool> Not(this NDArray<bool> array) => new NDArray<bool>(array.Select(v => !v), array.Shape);

		public static NDArray<byte> Max(NDArray<byte> array, NDArray<byte> other) => array.Operation(other, Math.Max);
		public static NDArray<decimal> Max(NDArray<decimal> array, NDArray<decimal> other) => array.Operation(other, Math.Max);
		public static NDArray<double> Max(NDArray<double> array, NDArray<double> other) => array.Operation(other, Math.Max);
		public static NDArray<short> Max(NDArray<short> array, NDArray<short> other) => array.Operation(other, Math.Max);
		public static NDArray<int> Max(NDArray<int> array, NDArray<int> other) => array.Operation(other, Math.Max);
		public static NDArray<sbyte> Max(NDArray<sbyte> array, NDArray<sbyte> other) => array.Operation(other, Math.Max);
		public static NDArray<long> Max(NDArray<long> array, NDArray<long> other) => array.Operation(other, Math.Max);
		public static NDArray<float> Max(NDArray<float> array, NDArray<float> other) => array.Operation(other, Math.Max);
		public static NDArray<uint> Max(NDArray<uint> array, NDArray<uint> other) => array.Operation(other, Math.Max);
		public static NDArray<ulong> Max(NDArray<ulong> array, NDArray<ulong> other) => array.Operation(other, Math.Max);

		public static NDArray<byte> Min(NDArray<byte> array, NDArray<byte> other) => array.Operation(other, Math.Min);
		public static NDArray<decimal> Min(NDArray<decimal> array, NDArray<decimal> other) => array.Operation(other, Math.Min);
		public static NDArray<double> Min(NDArray<double> array, NDArray<double> other) => array.Operation(other, Math.Min);
		public static NDArray<short> Min(NDArray<short> array, NDArray<short> other) => array.Operation(other, Math.Min);
		public static NDArray<int> Min(NDArray<int> array, NDArray<int> other) => array.Operation(other, Math.Min);
		public static NDArray<sbyte> Min(NDArray<sbyte> array, NDArray<sbyte> other) => array.Operation(other, Math.Min);
		public static NDArray<long> Min(NDArray<long> array, NDArray<long> other) => array.Operation(other, Math.Min);
		public static NDArray<float> Min(NDArray<float> array, NDArray<float> other) => array.Operation(other, Math.Min);
		public static NDArray<uint> Min(NDArray<uint> array, NDArray<uint> other) => array.Operation(other, Math.Min);
		public static NDArray<ulong> Min(NDArray<ulong> array, NDArray<ulong> other) => array.Operation(other, Math.Min);

		public static NDArray<decimal> Abs(NDArray<decimal> array) => array.Operation(Math.Abs);
		public static NDArray<double> Abs(NDArray<double> array) => array.Operation(Math.Abs);
		public static NDArray<short> Abs(NDArray<short> array) => array.Operation(Math.Abs);
		public static NDArray<int> Abs(NDArray<int> array) => array.Operation(Math.Abs);
		public static NDArray<long> Abs(NDArray<long> array) => array.Operation(Math.Abs);
		public static NDArray<sbyte> Abs(NDArray<sbyte> array) => array.Operation(Math.Abs);
		public static NDArray<float> Abs(NDArray<float> array) => array.Operation(Math.Abs);
		public static NDArray<double> Abs(NDArray<Complex> array) => array.Magnitude();

		public static NDArray<long> BigMul(NDArray<int> array, NDArray<int> other) => new NDArray<long>(array.Select((v, i) => Math.BigMul(v, other[i])));

		public static NDArray<double> Cbrt(NDArray<double> array) => array.Operation(Math.Cbrt);
		public static NDArray<Complex> Cbrt(NDArray<Complex> array) => array.Operation(v => Complex.Pow(v, 1.0 / 3));
		public static NDArray<double> Cbrt<T>(NDArray<T> array) where T : struct => Cbrt(array.Cast<double>());

		public static NDArray<double> Ceiling(NDArray<double> array) => array.Operation(Math.Ceiling);
		public static NDArray<decimal> Ceiling(NDArray<decimal> array) => array.Operation(Math.Ceiling);
		public static NDArray<double> Ceiling<T>(NDArray<T> array) where T : struct => Ceiling(array.Cast<double>());

		public static NDArray<double> Floor(NDArray<double> array) => array.Operation(Math.Floor);
		public static NDArray<decimal> Floor(NDArray<decimal> array) => array.Operation(Math.Floor);
		public static NDArray<double> Floor<T>(NDArray<T> array) where T : struct => Floor(array.Cast<double>());

		public static NDArray<ulong> Clamp(NDArray<ulong> array, ulong min, ulong max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<uint> Clamp(NDArray<uint> array, uint min, uint max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<ushort> Clamp(NDArray<ushort> array, ushort min, ushort max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<float> Clamp(NDArray<float> array, float min, float max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<sbyte> Clamp(NDArray<sbyte> array, sbyte min, sbyte max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<decimal> Clamp(NDArray<decimal> array, decimal min, decimal max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<int> Clamp(NDArray<int> array, int min, int max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<short> Clamp(NDArray<short> array, short min, short max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<double> Clamp(NDArray<double> array, double min, double max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<long> Clamp(NDArray<long> array, long min, long max) => array.Operation(v => Math.Clamp(v, min, max));
		public static NDArray<byte> Clamp(NDArray<byte> array, byte min, byte max) => array.Operation(v => Math.Clamp(v, min, max));

		// public static NDArray<double> CopySign(NDArray<double> array, NDArray<double> other) => array.Operation(other, Math.CopySign);
		// public static NDArray<double> CopySign<T1,T2>(NDArray<T1> array, NDArray<T2> other) where T1 : struct where T2 : struct => array.Cast<double>().Operation(other.Cast<double>(), Math.CopySign);
		// public static NDArray<double> CopySign<T1,T2>(NDArray<T1> array, T2 other) where T1 : struct where T2 : struct => array.Cast<double>().Operation(ToDouble(other), Math.CopySign);

		public static NDArray<double> Sqrt(NDArray<double> array) => array.Operation(Math.Sqrt);
		public static NDArray<Complex> Sqrt(NDArray<Complex> array) => array.Operation(Complex.Sqrt);
		public static NDArray<double> Sqrt<T>(NDArray<T> array) where T : struct => array.Cast<double>().Operation(Math.Sqrt);

		public static NDArray<double> Pow(NDArray<double> array, double pow) => array.Operation(pow, Math.Pow);
		public static NDArray<Complex> Pow(NDArray<Complex> array, Complex pow) => array.Operation(pow, Complex.Pow);
		public static NDArray<Complex> Pow(NDArray<Complex> array, double pow) => array.Operation(pow, Complex.Pow);
		public static NDArray<Complex> Pow<T1>(NDArray<Complex> array, T1 pow) where T1 : struct => array.Operation(ToDouble(pow), Complex.Pow);
		public static NDArray<Complex> Pow<T1>(NDArray<T1> array, Complex pow) where T1 : struct => array.Cast<Complex>().Operation(pow, Complex.Pow);
		public static NDArray<double> Pow<T1,T2>(NDArray<T1> array, T2 pow) where T1 : struct where T2 : struct => array.Cast<double>().Operation(ToDouble(pow), Math.Pow);

		public static NDArray<double> Pow(NDArray<double> array, NDArray<double> pow) => array.Operation(pow, Math.Pow);
		public static NDArray<Complex> Pow(NDArray<Complex> array, NDArray<Complex> pow) => array.Operation(pow, Complex.Pow);
		public static NDArray<Complex> Pow(NDArray<Complex> array, NDArray<double> pow) => array.Operation(pow, Complex.Pow);
		public static NDArray<Complex> Pow<T1>(NDArray<Complex> array, NDArray<T1> pow) where T1 : struct => array.Operation(pow.Cast<double>(), Complex.Pow);
		public static NDArray<Complex> Pow<T1>(NDArray<T1> array, NDArray<Complex> pow) where T1 : struct => array.Cast<Complex>().Operation(pow, Complex.Pow);
		public static NDArray<double> Pow<T1,T2>(NDArray<T1> array, NDArray<T2> pow) where T1 : struct where T2 : struct => array.Cast<double>().Operation(pow.Cast<double>(), Math.Pow);

		public static NDArray<double> Exp(NDArray<double> array) => array.Operation(Math.Exp);
		public static NDArray<Complex> Exp(NDArray<Complex> array) => array.Operation(Complex.Exp);
		public static NDArray<double> Exp<T>(NDArray<T> array) where T : struct => array.Cast<double>().Operation(Math.Exp);

		public static NDArray<double> Log(NDArray<double> array) => array.Operation(Math.Log);
		public static NDArray<Complex> Log(NDArray<Complex> array) => array.Operation(Complex.Log);
		public static NDArray<double> Log<T>(NDArray<T> array) where T : struct => array.Cast<double>().Operation(Math.Log);

		public static NDArray<double> Log(NDArray<double> array, double newBase) => array.Operation(newBase, Math.Log);
		public static NDArray<Complex> Log(NDArray<Complex> array, Complex newBase) => array.Operation(newBase, Complex.Log);
		public static NDArray<Complex> Log(NDArray<Complex> array, double newBase) => array.Operation(newBase, Complex.Log);
		public static NDArray<double> Log<T1,T2>(NDArray<T1> array, T2 newBase) where T1 : struct where T2 : struct => array.Cast<double>().Operation(ToDouble(newBase),Math.Log);

		public static NDArray<int> Sign(NDArray<float> array) => array.Operation(Math.Sign);
		public static NDArray<int> Sign(NDArray<sbyte> array) => array.Operation(Math.Sign);
		public static NDArray<int> Sign(NDArray<long> array) => array.Operation(Math.Sign);
		public static NDArray<int> Sign(NDArray<double> array) => array.Operation(Math.Sign);
		public static NDArray<int> Sign(NDArray<short> array) => array.Operation(Math.Sign);
		public static NDArray<int> Sign(NDArray<decimal> array) => array.Operation(Math.Sign);
		public static NDArray<int> Sign(NDArray<int> array) => array.Operation(Math.Sign);

		public static NDArray<int> Add(this NDArray<int> array, int value) => array.Operation(x => x + value);
		public static NDArray<int> Add(this NDArray<int> array, NDArray<int> other) => array.Operation(other,(x, y) => x + y);
		public static NDArray<int> Sub(this NDArray<int> array, int value) => array.Operation(x => x - value);
		public static NDArray<int> Sub(this NDArray<int> array, NDArray<int> other) => array.Operation(other, (x, y) => x - y);
		public static NDArray<int> Mul(this NDArray<int> array, int value) => array.Operation(x => x * value);
		public static NDArray<int> Mul(this NDArray<int> array, NDArray<int> other) => array.Operation(other, (x, y) => x * y);
		public static NDArray<int> Div(this NDArray<int> array, int value) => array.Operation(x => x / value);
		public static NDArray<int> Div(this NDArray<int> array, NDArray<int> other) => array.Operation(other, (x, y) => x / y);

		public static NDArray<uint> Add(this NDArray<uint> array, uint value) => array.Operation(x => (uint)(x + value));
		public static NDArray<uint> Add(this NDArray<uint> array, NDArray<uint> other) => array.Operation(other, (x, y) => (uint)(x + y));
		public static NDArray<uint> Sub(this NDArray<uint> array, uint value) => array.Operation(x => (uint)(x - value));
		public static NDArray<uint> Sub(this NDArray<uint> array, NDArray<uint> other) => array.Operation(other, (x, y) => (uint)(x - y));
		public static NDArray<uint> Mul(this NDArray<uint> array, uint value) => array.Operation(x => (uint)(x * value));
		public static NDArray<uint> Mul(this NDArray<uint> array, NDArray<uint> other) => array.Operation(other, (x, y) => (uint)(x * y));
		public static NDArray<uint> Div(this NDArray<uint> array, uint value) => array.Operation(x => (uint)(x / value));
		public static NDArray<uint> Div(this NDArray<uint> array, NDArray<uint> other) => array.Operation(other, (x, y) => (uint)(x / y));

		public static NDArray<sbyte> Add(this NDArray<sbyte> array, sbyte value) => array.Operation(x => (sbyte)(x + value));
		public static NDArray<sbyte> Add(this NDArray<sbyte> array, NDArray<sbyte> other) => array.Operation(other, (x, y) => (sbyte)(x + y));
		public static NDArray<sbyte> Sub(this NDArray<sbyte> array, sbyte value) => array.Operation(x => (sbyte)(x - value));
		public static NDArray<sbyte> Sub(this NDArray<sbyte> array, NDArray<sbyte> other) => array.Operation(other, (x, y) => (sbyte)(x - y));
		public static NDArray<sbyte> Mul(this NDArray<sbyte> array, sbyte value) => array.Operation(x => (sbyte)(x * value));
		public static NDArray<sbyte> Mul(this NDArray<sbyte> array, NDArray<sbyte> other) => array.Operation(other, (x, y) => (sbyte)(x * y));
		public static NDArray<sbyte> Div(this NDArray<sbyte> array, sbyte value) => array.Operation(x => (sbyte)(x / value));
		public static NDArray<sbyte> Div(this NDArray<sbyte> array, NDArray<sbyte> other) => array.Operation(other, (x, y) => (sbyte)(x / y));

		public static NDArray<byte> Add(this NDArray<byte> array, byte value) => array.Operation(x => (byte)(x + value));
		public static NDArray<byte> Add(this NDArray<byte> array, NDArray<byte> other) => array.Operation(other, (x, y) =>(byte)(x + y));
		public static NDArray<byte> Sub(this NDArray<byte> array, byte value) => array.Operation(x => (byte)(x - value));
		public static NDArray<byte> Sub(this NDArray<byte> array, NDArray<byte> other) => array.Operation(other, (x, y) => (byte)(x - y));
		public static NDArray<byte> Mul(this NDArray<byte> array, byte value) => array.Operation(x => (byte)(x * value));
		public static NDArray<byte> Mul(this NDArray<byte> array, NDArray<byte> other) => array.Operation(other, (x, y) => (byte)(x * y));
		public static NDArray<byte> Div(this NDArray<byte> array, byte value) => array.Operation(x => (byte)(x / value));
		public static NDArray<byte> Div(this NDArray<byte> array, NDArray<byte> other) => array.Operation(other, (x, y) => (byte)(x / y));

		public static NDArray<short> Add(this NDArray<short> array, short value) => array.Operation(x => (short)(x + value));
		public static NDArray<short> Add(this NDArray<short> array, NDArray<short> other) => array.Operation(other, (x, y) => (short)(x + y));
		public static NDArray<short> Sub(this NDArray<short> array, short value) => array.Operation(x => (short)(x - value));
		public static NDArray<short> Sub(this NDArray<short> array, NDArray<short> other) => array.Operation(other, (x, y) => (short)(x - y));
		public static NDArray<short> Mul(this NDArray<short> array, short value) => array.Operation(x => (short)(x * value));
		public static NDArray<short> Mul(this NDArray<short> array, NDArray<short> other) => array.Operation(other, (x, y) => (short)(x * y));
		public static NDArray<short> Div(this NDArray<short> array, short value) => array.Operation(x => (short)(x / value));
		public static NDArray<short> Div(this NDArray<short> array, NDArray<short> other) => array.Operation(other, (x, y) => (short)(x / y));

		public static NDArray<ushort> Add(this NDArray<ushort> array, ushort value) => array.Operation(x => (ushort)(x + value));
		public static NDArray<ushort> Add(this NDArray<ushort> array, NDArray<ushort> other) => array.Operation(other, (x, y) => (ushort)(x + y));
		public static NDArray<ushort> Sub(this NDArray<ushort> array, ushort value) => array.Operation(x => (ushort)(x - value));
		public static NDArray<ushort> Sub(this NDArray<ushort> array, NDArray<ushort> other) => array.Operation(other, (x, y) => (ushort)(x - y));
		public static NDArray<ushort> Mul(this NDArray<ushort> array, ushort value) => array.Operation(x => (ushort)(x * value));
		public static NDArray<ushort> Mul(this NDArray<ushort> array, NDArray<ushort> other) => array.Operation(other, (x, y) => (ushort)(x * y));
		public static NDArray<ushort> Div(this NDArray<ushort> array, ushort value) => array.Operation(x => (ushort)(x / value));
		public static NDArray<ushort> Div(this NDArray<ushort> array, NDArray<ushort> other) => array.Operation(other, (x, y) => (ushort)(x / y));

		public static NDArray<ulong> Add(this NDArray<ulong> array, ulong value) => array.Operation(x => (ulong)(x + value));
		public static NDArray<ulong> Add(this NDArray<ulong> array, NDArray<ulong> other) => array.Operation(other, (x, y) => (ulong)(x + y));
		public static NDArray<ulong> Sub(this NDArray<ulong> array, ulong value) => array.Operation(x => (ulong)(x - value));
		public static NDArray<ulong> Sub(this NDArray<ulong> array, NDArray<ulong> other) => array.Operation(other, (x, y) => (ulong)(x - y));
		public static NDArray<ulong> Mul(this NDArray<ulong> array, ulong value) => array.Operation(x => (ulong)(x * value));
		public static NDArray<ulong> Mul(this NDArray<ulong> array, NDArray<ulong> other) => array.Operation(other, (x, y) => (ulong)(x * y));
		public static NDArray<ulong> Div(this NDArray<ulong> array, ulong value) => array.Operation(x => (ulong)(x / value));
		public static NDArray<ulong> Div(this NDArray<ulong> array, NDArray<ulong> other) => array.Operation(other, (x, y) => (ulong)(x / y));

		public static NDArray<long> Add(this NDArray<long> array, long value) => array.Operation(x => (long)(x + value));
		public static NDArray<long> Add(this NDArray<long> array, NDArray<long> other) => array.Operation(other, (x, y) => (long)(x + y));
		public static NDArray<long> Sub(this NDArray<long> array, long value) => array.Operation(x => (long)(x - value));
		public static NDArray<long> Sub(this NDArray<long> array, NDArray<long> other) => array.Operation(other, (x, y) => (long)(x - y));
		public static NDArray<long> Mul(this NDArray<long> array, long value) => array.Operation(x => (long)(x * value));
		public static NDArray<long> Mul(this NDArray<long> array, NDArray<long> other) => array.Operation(other, (x, y) => (long)(x * y));
		public static NDArray<long> Div(this NDArray<long> array, long value) => array.Operation(x => (long)(x / value));
		public static NDArray<long> Div(this NDArray<long> array, NDArray<long> other) => array.Operation(other, (x, y) => (long)(x / y));

		public static NDArray<float> Add(this NDArray<float> array, float value) => array.Operation(x => (float)(x + value));
		public static NDArray<float> Add(this NDArray<float> array, NDArray<float> other) => array.Operation(other, (x, y) => (float)(x + y));
		public static NDArray<float> Sub(this NDArray<float> array, float value) => array.Operation(x => (float)(x - value));
		public static NDArray<float> Sub(this NDArray<float> array, NDArray<float> other) => array.Operation(other, (x, y) => (float)(x - y));
		public static NDArray<float> Mul(this NDArray<float> array, float value) => array.Operation(x => (float)(x * value));
		public static NDArray<float> Mul(this NDArray<float> array, NDArray<float> other) => array.Operation(other, (x, y) => (float)(x * y));
		public static NDArray<float> Div(this NDArray<float> array, float value) => array.Operation(x => (float)(x / value));
		public static NDArray<float> Div(this NDArray<float> array, NDArray<float> other) => array.Operation(other, (x, y) => (float)(x / y));

		public static NDArray<double> Add(this NDArray<double> array, double value) => array.Operation(x => (double)(x + value));
		public static NDArray<double> Add(this NDArray<double> array, NDArray<double> other) => array.Operation(other, (x, y) => (double)(x + y));
		public static NDArray<double> Sub(this NDArray<double> array, double value) => array.Operation(x => (double)(x - value));
		public static NDArray<double> Sub(this NDArray<double> array, NDArray<double> other) => array.Operation(other, (x, y) => (double)(x - y));
		public static NDArray<double> Mul(this NDArray<double> array, double value) => array.Operation(x => (double)(x * value));
		public static NDArray<double> Mul(this NDArray<double> array, NDArray<double> other) => array.Operation(other, (x, y) => (double)(x * y));
		public static NDArray<double> Div(this NDArray<double> array, double value) => array.Operation(x => (double)(x / value));
		public static NDArray<double> Div(this NDArray<double> array, NDArray<double> other) => array.Operation(other, (x, y) => (double)(x / y));

		public static NDArray<decimal> Add(this NDArray<decimal> array, decimal value) => array.Operation(x => (decimal)(x + value));
		public static NDArray<decimal> Add(this NDArray<decimal> array, NDArray<decimal> other) => array.Operation(other, (x, y) => (decimal)(x + y));
		public static NDArray<decimal> Sub(this NDArray<decimal> array, decimal value) => array.Operation(x => (decimal)(x - value));
		public static NDArray<decimal> Sub(this NDArray<decimal> array, NDArray<decimal> other) => array.Operation(other, (x, y) => (decimal)(x - y));
		public static NDArray<decimal> Mul(this NDArray<decimal> array, decimal value) => array.Operation(x => (decimal)(x * value));
		public static NDArray<decimal> Mul(this NDArray<decimal> array, NDArray<decimal> other) => array.Operation(other, (x, y) => (decimal)(x * y));
		public static NDArray<decimal> Div(this NDArray<decimal> array, decimal value) => array.Operation(x => (decimal)(x / value));
		public static NDArray<decimal> Div(this NDArray<decimal> array, NDArray<decimal> other) => array.Operation(other, (x, y) => (decimal)(x / y));

		public static NDArray<Complex> Add(this NDArray<Complex> array, Complex value) => array.Operation(x => (Complex)(x + value));
		public static NDArray<Complex> Add(this NDArray<Complex> array, NDArray<Complex> other) => array.Operation(other, (x, y) => (Complex)(x + y));
		public static NDArray<Complex> Sub(this NDArray<Complex> array, Complex value) => array.Operation(x => (Complex)(x - value));
		public static NDArray<Complex> Sub(this NDArray<Complex> array, NDArray<Complex> other) => array.Operation(other, (x, y) => (Complex)(x - y));
		public static NDArray<Complex> Mul(this NDArray<Complex> array, Complex value) => array.Operation(x => (Complex)(x * value));
		public static NDArray<Complex> Mul(this NDArray<Complex> array, NDArray<Complex> other) => array.Operation(other, (x, y) => (Complex)(x * y));
		public static NDArray<Complex> Div(this NDArray<Complex> array, Complex value) => array.Operation(x => (Complex)(x / value));
		public static NDArray<Complex> Div(this NDArray<Complex> array, NDArray<Complex> other) => array.Operation(other, (x, y) => (Complex)(x / y));

		public static NDArray<TOut> Add<T1, T2, TOut>(this NDArray<T1> array, T2 value) where T1 : struct where T2 : struct where TOut : struct => NDArray<TOut>.Operation(array, x => (TOut)((dynamic)x + value));
		public static NDArray<TOut> Add<T1, T2, TOut>(this NDArray<T1> array, NDArray<T2> other) where T1 : struct where T2 : struct where TOut : struct => NDArray<TOut>.Operation<T1,T2,TOut>(array, other, (x, y) => (TOut)((dynamic)x + y));
		public static NDArray<TOut> Sub<T1, T2, TOut>(this NDArray<T1> array, T2 value) where T1 : struct where T2 : struct where TOut : struct => NDArray<TOut>.Operation(array, x => (TOut)((dynamic)x - value));
		public static NDArray<TOut> Sub<T1, T2, TOut>(this NDArray<T1> array, NDArray<T2> other) where T1 : struct where T2 : struct where TOut : struct => NDArray<TOut>.Operation<T1,T2,TOut>(array, other, (x, y) => (TOut)((dynamic)x - y));
		public static NDArray<TOut> Mul<T1, T2, TOut>(this NDArray<T1> array, T2 value) where T1 : struct where T2 : struct where TOut : struct => NDArray<TOut>.Operation(array, x => (TOut)((dynamic)x * value));
		public static NDArray<TOut> Mul<T1, T2, TOut>(this NDArray<T1> array, NDArray<T2> other) where T1 : struct where T2 : struct where TOut : struct => NDArray<TOut>.Operation<T1,T2,TOut>(array, other, (x, y) => (TOut)((dynamic)x * y));
		public static NDArray<TOut> Div<T1, T2, TOut>(this NDArray<T1> array, T2 value) where T1 : struct where T2 : struct where TOut : struct => NDArray<TOut>.Operation(array, x => (TOut)((dynamic)x / value));
		public static NDArray<TOut> Div<T1, T2, TOut>(this NDArray<T1> array, NDArray<T2> other) where T1 : struct where T2 : struct where TOut : struct => NDArray<TOut>.Operation<T1,T2,TOut>(array, other, (x, y) => (TOut)((dynamic)x / y));

		public static double Mean<T>(this NDArray<T> array) where T : struct
		{
			double sum = 0;
			var newArray = array.Cast<double>();
			newArray.ForEach(x => sum += x);
			return sum / array.Size;
		}
		public static double Mean(this NDArray<double> array)
		{
			double sum = 0;
			array.ForEach(x => sum += x);
			return sum / array.Size;
		}
		public static double StandardDeviation(this NDArray<double> array)
		{
			double total = 0;
			double mean = array.Mean();
			array.ForEach(x => total += (x - mean) * (x - mean));
			return Math.Sqrt(1 / (array.Size - 1) * total);
		}
		public static double StandardDeviation<T>(this NDArray<T> array) where T : struct
		{
			double total = 0;
			var newArray = array.Cast<double>();
			var mean = newArray.Mean();
			newArray.ForEach(x => total += (x - mean) * (x - mean));
			return Math.Sqrt(1 / (array.Size - 1) * total);
		}
		public static double Variance<T>(this NDArray<T> array) where T : struct
		{
			double total = 0;
			var newArray = array.Cast<double>();
			var mean = newArray.Mean();
			newArray.ForEach(x => total += (x - mean) * (x - mean));
			return 1 / (array.Size - 1) * total;
		}
		public static double Variance(this NDArray<double> array)
		{
			double total = 0;
			var mean = array.Mean();
			array.ForEach(x => total += (x - mean) * (x - mean));
			return 1 / (array.Size) * total;
		}
	}
}