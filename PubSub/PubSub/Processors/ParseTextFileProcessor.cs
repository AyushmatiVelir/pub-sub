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
		public List<FileDetailModel> ParseData(List<string[]> lines)
		{
			if (lines == null)
			{
				return null;
			}

			var entities = new List<FileDetailModel>();
			foreach (var line in lines)
			{
				if (line.Length != 5) continue;
				DateTime pubDateTime;
				var file = new FileDetailModel
				{
					Topic = line[0],
					Title = line[1],
					Description = line[2],
					Author = line[3],
					PublishDate = DateTime.TryParse(line[4], out pubDateTime) ? pubDateTime : DateTime.MinValue
				};
				entities.Add(file);
			}

			return entities;
		}



	}
}
