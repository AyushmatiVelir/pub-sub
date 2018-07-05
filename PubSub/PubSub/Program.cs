using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Filters;
using PubSub.Plugins;
using PubSub.Processors;
using PubSub.Publishers;
using PubSub.Subscribers;

namespace PubSub
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 3)
			{
				System.Console.WriteLine("Please invoke with all the 3 arguments.");
				return;
			}
			bool hasHeaders = false;
			var settings = new TextFileSettings
			{

				ColumnHeadersInFirstLine = bool.TryParse(args[0], out hasHeaders) && hasHeaders,
				ColumnSeparator = args[1],
				Path = args[2]
			};

			ReadTextFileProcessor readFileProcessor = new ReadTextFileProcessor();
			var lines = readFileProcessor.ReadData(settings);
			ParseTextFileProcessor parseFileProcessor = new ParseTextFileProcessor();
			var entities = parseFileProcessor.ParseData(lines);

			var publisher = new Publisher();

			var strategySubscriber = new StrategySubscriber();
			var newsSubscriber = new NewsSubscriber();
			var cultureSubscriber = new CultureSubscriber();
			
			Filter.AddSubscriber("all", strategySubscriber);
			Filter.AddSubscriber("all", newsSubscriber);
			publisher.Publish(entities, Filter.GetSubscribers("all"));
			Filter.RemoveSubscriber("all", strategySubscriber);
			Filter.AddSubscriber("all", cultureSubscriber);
			publisher.Publish(entities, Filter.GetSubscribers("all"));

			Console.ReadLine();
		}
	}
}
