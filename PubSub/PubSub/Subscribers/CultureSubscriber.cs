﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Models;

namespace PubSub.Subscribers
{
	public class CultureSubscriber : ISubscriber
	{
		private const string Topic = "Culture";
		public void DisplayData(List<FileDetailModel> entities)
		{
			Console.WriteLine($"In subscriber {Topic}.");
			foreach (var entity in entities)
			{
				Console.WriteLine(entity.Topic, entity.Title, entity.Author, entity.Description);
			}
		}
	}
}
