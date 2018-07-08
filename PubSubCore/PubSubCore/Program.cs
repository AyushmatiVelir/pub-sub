using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using PubSub.Subscribers;
using publisher = PubSubCore.Publisher;
using PubSubCore.Services;
using PubSubCore.Subscribers;

namespace PubSubCore
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var entertainmentSubscriber = new EntertainmentNewsSubscriber();
			var economicsSubscriber = new EconomicNewsSubscriber();
			var sportsSubscriber = new SportsNewsSubscriber();

			var serviceProvider = new ServiceCollection()
				.AddSingleton<ISubscribeService, SubscribeService>()
				.AddSingleton<publisher.IPublisher, publisher.Publisher>()
				.AddSingleton<IDataTransformService, DataTransformService>()
				.BuildServiceProvider();

			var subscribeService = serviceProvider.GetService<ISubscribeService>();
			subscribeService.Subscribe("entertainment", new List<ISubscriber> { entertainmentSubscriber });
			subscribeService.Subscribe("economics", new List<ISubscriber> { economicsSubscriber });
			subscribeService.Subscribe("sports", new List<ISubscriber> { sportsSubscriber });
			subscribeService.Subscribe("all", new List<ISubscriber> { entertainmentSubscriber, economicsSubscriber, sportsSubscriber });

			Console.WriteLine("Enter news title:");
			string title = Console.ReadLine();
			Console.WriteLine("Enter news category");
			string category = Console.ReadLine();
			Console.WriteLine("Enter author name");
			string authorName = Console.ReadLine();
			Console.WriteLine("Enter description");
			string description = Console.ReadLine();

			if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(category) &&
				!string.IsNullOrWhiteSpace(authorName) && !string.IsNullOrWhiteSpace(description))
			{
				var dataTransformService = serviceProvider.GetService<IDataTransformService>();
				var news = dataTransformService.TransformData(title, category, authorName, description);
				var publisher = serviceProvider.GetService<publisher.IPublisher>();
				publisher.Publish(news, news.Category.ToLower());
			}
			else
			{
				Console.WriteLine("Cannot process because this is an incomplete news record");
			}

			Console.ReadLine();
		}
	}
}
