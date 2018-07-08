using System;
using PubSub.Subscribers;
using PubSubCore.Models;

namespace PubSubCore.Subscribers
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
