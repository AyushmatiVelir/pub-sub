using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Models;

namespace PubSub.Processors
{
	public class ParseTextFileProcessor
	{
		public List<NewsDetailsModel> ParseData(List<string[]> lines)
		{
			if (lines == null)
			{
				return null;
			}

			var entities = new List<NewsDetailsModel>();
			foreach (var line in lines)
			{
				if (line.Length != 5) continue;
				var file = new NewsDetailsModel
				{
					Category = line[0],
					Title = line[1],
					Description = line[2],
					Author = line[3],
					PublishDate = DateTime.TryParse(line[4], out var pubDateTime) ? pubDateTime : DateTime.MinValue
				};
				entities.Add(file);
			}

			return entities;
		}



	}
}
