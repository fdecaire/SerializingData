using Newtonsoft.Json;

namespace SerializingJSONBlogPost2
{
	class Program
	{
		static void Main(string[] args)
		{
			string resultSet = "{\"Address1\":\"123 Main st\",\"Address2\":null,\"City\":\"New York\",\"State\":\"New York\",\"Zip\":\"12345\"}";

			// deserialize object (uncompressed JSON from above was copied from the SerializingJSONBlogPost project).
			AddressClass newObject;
			newObject = JsonConvert.DeserializeObject<AddressClass>(resultSet);
		}
	}
}
