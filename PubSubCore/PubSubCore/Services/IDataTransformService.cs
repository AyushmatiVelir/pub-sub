using System;
using System.Collections.Generic;
using System.Text;
using PubSub.Models;

namespace PubSubCore.Services
{
    public interface IDataTransformService
    {
	    void TransformData(NewsDetailsModel newsRecord);
    }
}
