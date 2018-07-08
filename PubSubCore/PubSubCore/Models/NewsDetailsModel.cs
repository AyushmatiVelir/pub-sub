using System;

namespace PubSubCore.Models
{
	public class NewsDetailsModel
	{
		public string Title { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public string Author { get; set; }
		public DateTime PublishDate { get; set; }
	}
}
