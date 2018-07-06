using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Models;

namespace PubSub.Subscribers
{
	public class EconomicNewsSubscriber : ISubscriber
	{
		private const string Topic = "Economics";
		public void DisplayData(NewsDetailsModel news)
		{
			Console.WriteLine($"In subscriber {Topic}.");
			Console.WriteLine($"News for {news.Category}: {news.Title} by {news.Author}");
			Console.WriteLine(news.Description);
		}
	}
}
