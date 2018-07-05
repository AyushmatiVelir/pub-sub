using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Subscribers;

namespace PubSub.Publishers
{
	public class Publisher : IPublisher
	{
		private readonly List<ISubscriber> _subscribers;

		public Publisher()
		{
			_subscribers = new List<ISubscriber>();
		}

		public void Subscribe(ISubscriber subscriber)
		{
			_subscribers.Add(subscriber);
		}

		public void NotifyAll(string message)
		{
			foreach (var subscriber in this._subscribers)
				subscriber.Notify(message);
		}

		public void Unsubscribe(ISubscriber subscriber)
		{
			_subscribers.Remove(subscriber);
		}
	}
}
