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
			if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(category) ||
				string.IsNullOrWhiteSpace(description))
				return null;
			return new NewsDetailsModel
			{
				Title = title.ToTitleCase(),
				Category = category.ToLower(),
				Author = string.IsNullOrWhiteSpace(author) ? string.Empty : author.ToTitleCase(),
				Description = description.TrimLength(100),
				PublishDate = DateTime.Now
			};
		}
	}
}
