using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ArrayTest
{
	class Program
	{
		public static void Main()
		{
			var timer = Stopwatch.StartNew();
			var GC_MemoryStart = System.GC.GetTotalMemory(true);

			var size = 32;
			var s = new NDArray.Shape(size + 1, size + 1);
			var values = new NDArray<Complex>(s);
			for (int i = 0; i < s.Size; i++)
			{
				var ind = NDArray.DimensionalIndex(s, i);
				values[ind] = new Complex(ind[0], ind[1]);
			}
			values = values.Sub(new Complex(size / 2, size / 2)).Div(size / 2);
			//Console.WriteLine(values);
			Console.WriteLine(values[x => true].ListString());

			var GC_MemoryEnd = System.GC.GetTotalMemory(true);
			timer.Stop();
			Console.WriteLine($"Completed in {timer.ElapsedMilliseconds / 1000.0}s");
			Console.WriteLine($"Used {(GC_MemoryEnd - GC_MemoryStart) / 1024 } KiB ({GC_MemoryEnd - GC_MemoryStart}b) of memory");

		}
	}
}
