using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Subscribers;

namespace PubSub.Publishers
{
	public interface IPublisher
	{
		void Subscribe(ISubscriber subscriber);
		void NotifyAll(string message);
		void Unsubscribe(ISubscriber subscriber);

	}
}
