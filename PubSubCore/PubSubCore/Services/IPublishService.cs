using System;
using System.Collections.Generic;
using System.Text;
using PubSub.Models;

namespace PubSubCore.Services
{
    interface IPublishService
    {
	    void Publish(NewsDetailsModel data, string topicName);
    }
}
