using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Subscribers
{
	public class CultureSubscriber : ISubscriber
	{
		private const string Topic = "Strategy";

		public CultureSubscriber()
		{
			
		}

		public void Notify(string message)
		{
			Console.WriteLine($"{Topic} received: {message}");
		}
	}
}
