using System;
using System.Collections.Generic;
using PubSub.Models;
using PubSub.Subscribers;
using PubSubCore.Services;

namespace PubSubCore
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var entertainmentSubscriber = new EntertainmentNewsSubscriber();
			var economicsSubscriber = new EconomicNewsSubscriber();
			var sportsSubscriber = new SportsNewsSubscriber();

			var subscribeService = new SubscribeService();
			subscribeService.Subscribe("entertainment", new List<ISubscriber> { entertainmentSubscriber });
			subscribeService.Subscribe("news", new List<ISubscriber> { economicsSubscriber });
			subscribeService.Subscribe("sports", new List<ISubscriber> { sportsSubscriber });
			subscribeService.Subscribe("all", new List<ISubscriber> { entertainmentSubscriber, economicsSubscriber, sportsSubscriber });

			Console.WriteLine("Enter news title:");
			string line = Console.ReadLine();
			Console.WriteLine("Enter news category");
			string category = Console.ReadLine();
			Console.WriteLine("Enter author name");
			string authorName = Console.ReadLine();
			Console.WriteLine("Enter description");
			string description = Console.ReadLine();

			if (!string.IsNullOrWhiteSpace(line) && !string.IsNullOrWhiteSpace(category) &&
				!string.IsNullOrWhiteSpace(authorName) && !string.IsNullOrWhiteSpace(description))
			{
				NewsDetailsModel news = new NewsDetailsModel
				{
					Title = line,
					Category = category,
					Author = authorName,
					Description = description,
				};

				IDataTransformService dataTransformService = new DataTransformService();
				dataTransformService.TransformData(news);

				var publishService = new PublishService();
				publishService.Publish(news, news.Category.ToLower());

			}
			else
			{
				Console.WriteLine("Cannot process because this is an incomplete news record");
			}

			Console.ReadLine();
		}
	}
}
