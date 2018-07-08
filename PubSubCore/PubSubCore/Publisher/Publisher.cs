using PubSubCore.Filters;
using PubSubCore.Models;

namespace PubSubCore.Publisher
{
	public class Publisher : IPublisher
	{
		public void Publish(NewsDetailsModel data, string topicName)
		{
			Filter.PushToSubscribers(data, topicName);
		}
	}
}
