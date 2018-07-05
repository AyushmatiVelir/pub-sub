using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Publishers;
using PubSub.Subscribers;

namespace PubSub
{
	class Program
	{
		static void Main(string[] args)
		{
			var publisher = new Publisher();

			var strategySubscriber = new StrategySubscriber();
			var newsSubscriber = new NewsSubscriber();
			var cultureSubscriber = new CultureSubscriber();

			publisher.Subscribe(strategySubscriber);
			publisher.Subscribe(newsSubscriber);

			publisher.NotifyAll("Strategy and News!");

			publisher.Subscribe(cultureSubscriber);
			publisher.Unsubscribe(strategySubscriber);

			publisher.NotifyAll("News and Culture");

			Console.ReadLine();
		}
	}
}
