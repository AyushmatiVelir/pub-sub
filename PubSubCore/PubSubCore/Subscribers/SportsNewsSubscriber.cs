using System;
using PubSubCore.Models;

namespace PubSubCore.Subscribers
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
