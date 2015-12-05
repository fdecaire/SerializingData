using System;

namespace SerializaingDataBlogPost2
{
	[Serializable]
	public class AddressClass
	{
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
	}
}
