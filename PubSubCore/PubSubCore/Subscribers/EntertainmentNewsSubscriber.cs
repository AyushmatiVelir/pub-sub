using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Models;

namespace PubSub.Subscribers
{
	public class EntertainmentNewsSubscriber : ISubscriber
	{
		private const string Topic = "Entertainment";
		public void DisplayData(NewsDetailsModel news)
		{
			Console.WriteLine($"In subscriber {Topic}.");
			Console.WriteLine($"{news.Title} on {news.PublishDate.ToShortDateString()} by {news.Author}");
			Console.WriteLine(news.Description);
		}
	}
}
