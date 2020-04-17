using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace ArrayTest
{
	public partial class NDArray<T>
	{
		public static void SerializeToFile(string path, NDArray<T> o, bool gzip = false)
		{
			if (gzip)
			{
				using(Stream s = new GZipStream(File.Open(path, FileMode.Create), CompressionLevel.Optimal))
				{
					new BinaryFormatter().Serialize(s, o);
				}
			}
			else
			{
				using(Stream s = File.Open(path, FileMode.Create))
				{
					new BinaryFormatter().Serialize(s, o);
				}
			}
		}
		public void SerializeToFile(string path, bool gzip = false)
		{
			SerializeToFile(path, this, gzip);
		}
		public static NDArray<T> DeserializeFromFile(string path, bool gzip = false)
		{
			if (gzip)
			{
				using(Stream s = new GZipStream(File.Open(path, FileMode.Open), CompressionMode.Decompress))
				{
					NDArray<T> o = (NDArray<T>)new BinaryFormatter().Deserialize(s);
					return o;
				}
			}
			else
			{
				using(Stream s = File.Open(path, FileMode.Open))
				{
					NDArray<T> o = (NDArray<T>)new BinaryFormatter().Deserialize(s);
					return o;
				}
			}
		}
	}
}
