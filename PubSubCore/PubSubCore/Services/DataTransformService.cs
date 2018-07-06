using System;
using System.Collections.Generic;
using System.Text;
using PubSub.Models;
using PubSubCore.Extensions;

namespace PubSubCore.Services
{
	public class DataTransformService : IDataTransformService
	{
		public void TransformData(NewsDetailsModel newsRecord)
		{
			newsRecord.Author = newsRecord.Author.ToTitleCase();
			newsRecord.Title = newsRecord.Title.ToTitleCase();
			newsRecord.Description = newsRecord.Description.TrimLength(100);
			newsRecord.PublishDate = DateTime.Now;
		}
	}
}
