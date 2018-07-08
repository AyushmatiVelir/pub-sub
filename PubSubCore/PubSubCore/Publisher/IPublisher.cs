using PubSubCore.Models;

namespace PubSubCore.Publisher
{
    public interface IPublisher
    {
	    void Publish(NewsDetailsModel data, string topicName);
    }
}
