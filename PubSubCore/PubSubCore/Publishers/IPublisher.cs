using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Models;
using PubSub.Subscribers;

namespace PubSub.Publishers
{
	public interface IPublisher
	{
		void Publish(List<FileDetailModel> entitiesList, List<ISubscriber> subscribers);
	}
}
