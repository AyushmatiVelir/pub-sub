using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Subscribers
{
	public class NewsSubscriber : ISubscriber
	{
		private const string Topic = "News";

		public NewsSubscriber()
		{
			//_subscriberGuid = Guid.NewGuid();
		}

		public void Notify(string message)
		{
			Console.WriteLine($"{Topic} received: {message}");
		}
	}
}
