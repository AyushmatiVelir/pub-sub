using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Models;

namespace PubSub.Subscribers
{
	public class SportsNewsSubscriber : ISubscriber
	{
		private const string Topic = "Sports";
		public void DisplayData(NewsDetailsModel news)
		{
			Console.WriteLine($"In subscriber {Topic}.");
			Console.WriteLine($"{news.Title} on {news.PublishDate.ToShortDateString()}");
			Console.WriteLine(news.Description);
		}
	}
}
