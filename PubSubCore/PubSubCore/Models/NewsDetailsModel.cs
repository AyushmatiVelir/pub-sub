using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Models
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
