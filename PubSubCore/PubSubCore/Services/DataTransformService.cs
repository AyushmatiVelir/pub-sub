using System;
using System.Collections.Generic;
using System.Text;
using PubSub.Models;
using PubSubCore.Extensions;

namespace PubSubCore.Services
{
	public class DataTransformService : IDataTransformService
	{
		public NewsDetailsModel TransformData(string title, string category, string author, string description)
		{
			return new NewsDetailsModel
			{
				Title = title.ToTitleCase(),
				Category = category.ToLower(),
				Author = author.ToTitleCase(),
				Description = description.TrimLength(100),
				PublishDate = DateTime.Now
			};
		}
	}
}
