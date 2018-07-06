using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Models;
using PubSub.Subscribers;

namespace PubSub.Publishers
{
	public class Publisher : IPublisher
	{
		public void Publish(NewsDetailsModel newsDetails, List<ISubscriber> subscribers)
		{
			foreach (var subscriber in subscribers)
			{
				subscriber.DisplayData(newsDetails);
			}
		}
	}
}
