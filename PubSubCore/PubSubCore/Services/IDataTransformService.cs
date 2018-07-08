using System;
using System.Collections.Generic;
using System.Text;
using PubSubCore.Models;

namespace PubSubCore.Services
{
	public interface IDataTransformService
	{
		NewsDetailsModel TransformData(string title, string category, string author, string description);
	}
}
