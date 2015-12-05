using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//http://spazzarama.com/2009/06/25/binary-deserialize-unable-to-find-assembly/
namespace SerializingDataBlogPost
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[] storedData = null;

			// create an instance and put some dummy data into it.
			var addressClass = new AddressClass
			{
				Address1 = "123 Main st",
				City = "New York",
				State = "New York",
				Zip = "12345"
			};

			// serialize the object
			using (var memoryStream = new MemoryStream())
			{
				var binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, addressClass);

				storedData = memoryStream.ToArray();
			}

			//deserialize the object
			AddressClass newObject;
			using (var memoryStream = new MemoryStream())
			{
				var binaryFormatter = new BinaryFormatter();

				memoryStream.Write(storedData, 0, storedData.Length);
				memoryStream.Seek(0, SeekOrigin.Begin);

				newObject = (AddressClass)binaryFormatter.Deserialize(memoryStream);
			}


			// store the binary data as comma delimited ints to a file in bin\debug folder
			// this data will be used in another program to test deserializing using the exact 
			// same code above but from a different dll
			using (var stream = new StreamWriter(@"testoutput.txt"))
			{
				foreach (int item in storedData)
				{
					stream.Write(item + ",");
				}
			}

			Console.Write("");
		}
	}
}
