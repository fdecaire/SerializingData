using System.Text;
using Newtonsoft.Json;
using System.IO.Compression;
using System.IO;

namespace SerializingJSONBlogPost
{
	class Program
	{
		static void Main(string[] args)
		{
			// create an instance and put some dummy data into it.
			var addressClass = new AddressClass
			{
				Address1 = "123 Main st",
				City = "New York",
				State = "New York",
				Zip = "12345"
			};

			// serialize the object
			JsonSerializer serializer = new JsonSerializer();
			string resultSet = JsonConvert.SerializeObject(addressClass);

			// compress text
			byte[] compressedResult = Compress(resultSet);

			// decompress text
			resultSet = Decompress(compressedResult);

			// deserialize object
			AddressClass newObject;
			newObject = JsonConvert.DeserializeObject<AddressClass>(resultSet);


		}

		private static byte[] Compress(string input)
		{
			byte[] inputData = Encoding.ASCII.GetBytes(input);
			byte[] result;

			using (var memoryStream = new MemoryStream())
			{
				using (var zip = new GZipStream(memoryStream, CompressionMode.Compress))
				{
					zip.Write(inputData, 0, inputData.Length);
				}

				result = memoryStream.ToArray();
			}

			return result;
		}

		private static string Decompress(byte[] input)
		{
			byte[] result;

			using (var outputMemoryStream = new MemoryStream())
			{
				using (var inputMemoryStream = new MemoryStream(input))
				{
					using (var zip = new GZipStream(inputMemoryStream, CompressionMode.Decompress))
					{
						zip.CopyTo(outputMemoryStream);
					}
				}

				result = outputMemoryStream.ToArray();
			}

			return Encoding.Default.GetString(result);
		}
	}
}
