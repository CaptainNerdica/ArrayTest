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
		private static NDArray.Shape TryShape(NDArray.Shape newShape, int size)
		{
			int newSize = 1;
			foreach (int i in newShape.Sizes)
				newSize *= i;
			if (newSize == size)
				return newShape;
			else
			{
				throw new NDArray.BadShapeException($"Shape {newShape} cannot be applied to array of size {size}");
			}
		}
	}
}
