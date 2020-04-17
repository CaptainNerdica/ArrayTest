using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Xml.Serialization;

namespace ArrayTest
{
	[Serializable]
	public struct Complex : IEquatable<Complex>
	{
		public double Real { get; set; }
		public double Imag { get; set; }
		public double Magnitude { get { return Math.Sqrt(this.Real * this.Real + this.Imag * this.Imag); } }
		public double Arg { get { return Math.Atan2(this.Imag, this.Real); } }
		public Complex Conj { get { return Conjugate(this); } }

		public static readonly Complex i = new Complex(0, 1);
		public static readonly Complex j = new Complex(0, 1);

		public Complex(double real = 0, double imag = 0)
		{
			this.Real = real;
			this.Imag = imag;
		}
		public Complex(int real = 0, int imag = 0)
		{
			this.Real = (double)real;
			this.Imag = (double)imag;
		}

		public Complex FromPolar(double r, double phi)
		{
			return r * Exp(phi * i);
		}

		public Complex FromPolar(Tuple<double, double> polar)
		{
			return FromPolar(polar.Item1, polar.Item2);
		}

		public Tuple<double, double> ToPolar(Complex z)
		{
			return new Tuple<double, double>(z.Magnitude, z.Arg);
		}


		//
		//Mathematical Operators
		//
		public static Complex operator +(Complex z) => z;
		public static Complex operator -(Complex z) => new Complex(-z.Real, -z.Imag);
		public static Complex operator +(Complex a, Complex b) => new Complex(a.Real + b.Real, a.Imag + b.Imag);
		public static Complex operator -(Complex a, Complex b) => new Complex(a.Real - b.Real, a.Imag - b.Imag);
		public static Complex operator *(Complex a, Complex b) => new Complex(a.Real * b.Real - a.Imag * b.Imag, a.Imag * b.Real + a.Real * b.Imag);
		public static Complex operator /(Complex a, Complex b)
		{
			double u = a.Real;
			double v = a.Imag;
			double x = b.Real;
			double y = b.Imag;
			double r = 1 / (x * x + y * y);
			return new Complex(r * (u * x + v * y), r * (v * x - u * y));
		}
		public static bool operator ==(Complex a, Complex b) => (a.Real == b.Real) && (a.Imag == b.Imag);
		public static bool operator !=(Complex a, Complex b) => (a.Real != b.Real) || (a.Imag != b.Imag);
		public static bool operator <(Complex a, Complex b) => a.Magnitude < b.Magnitude;
		public static bool operator >(Complex a, Complex b) => a.Magnitude > b.Magnitude;
		public static bool operator <=(Complex a, Complex b) => a.Magnitude <= b.Magnitude;
		public static bool operator >=(Complex a, Complex b) => a.Magnitude >= b.Magnitude;
		//
		//Complex mathematical functions
		//
		public static Complex Sqrt(Complex z) => Math.Sqrt((z.Magnitude + z.Real) / 2) + i * Math.Sqrt((z.Magnitude - z.Real) / 2);
		public static Complex Log(Complex z) => Math.Log(z.Magnitude) + i * z.Arg;
		public static Complex Exp(Complex z) => Math.Exp(z.Real) * (Math.Cos(z.Imag) + i * Math.Sin(z.Imag));
		public static Complex Pow(Complex a, Complex b) => Exp(b.Real * Log(a)) * Exp(b.Imag * i * Log(a));
		public static Complex Pow(Complex z, double n) => Exp(n * Log(z));
		public static Complex Log(Complex z, Complex n) => Log(z) / Log(n);
		public static Complex Log(Complex z, double n) => Log(z) / Math.Log(n);
		public static Complex Sin(Complex z) => (Exp(z * i) - Exp(-z * i)) / (2 * i);
		public static Complex Cos(Complex z) => (Exp(z * i) + Exp(-z * i)) / 2;
		public static Complex Tan(Complex z) => (Exp(z * i) - Exp(-z * i)) / (i * Exp(z * i) + i * Exp(-z * i));
		public static Complex Sinh(Complex z) => (Exp(z) - Exp(-z)) / 2;
		public static Complex Cosh(Complex z) => (Exp(z) + Exp(-z)) / 2;
		public static Complex Tanh(Complex z) => (Exp(z) - Exp(-z)) / (Exp(z) + Exp(-z));
		public static Complex Asin(Complex z) => -i * Log(i * z + Sqrt(1 - z * z));
		public static Complex Acos(Complex z) => -i * Log(z + Sqrt(z * z - 1));
		public static Complex Atan(Complex z) => i / 2 * Log((i + z) / (i - z));
		public static Complex Conjugate(Complex z) => new Complex(z.Real, -z.Imag);
		//
		//Complex number casting
		//
		public static implicit operator Complex(int a) => new Complex(a, 0);
		public static implicit operator Complex(double a) => new Complex(a, 0);
		public static explicit operator Complex(Tuple<double, double> t) => new Complex(t.Item1, t.Item2);
		public static explicit operator Tuple<double, double>(Complex z) => new Tuple<double, double>(z.Real, z.Imag);


		public override bool Equals(object obj) => base.Equals(obj);
		public bool Equals(Complex a) => a == this;

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public override string ToString()
		{
			if (this.Real == 0)
			{
				if (this.Imag == 1)
					return "i";
				else if (this.Imag == -1)
					return "-i";
				else if (this.Imag == 0)
					return "0";
				else
					return $"{this.Imag}i";
			}
			else
			{
				if (this.Imag > 0)
					return $"{this.Real}+{this.Imag}i";
				else if (this.Imag < 0)
					return $"{this.Real}-{-this.Imag}i";
				else
					return $"{this.Real}";
			}
		}
	}
}
