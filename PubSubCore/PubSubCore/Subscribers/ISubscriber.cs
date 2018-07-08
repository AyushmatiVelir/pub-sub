using PubSubCore.Models;

namespace PubSubCore.Subscribers
{
	public interface ISubscriber
	{
		void DisplayData(NewsDetailsModel data);
	}
}
