using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Plugins;

namespace PubSub.Processors
{
	public class ReadTextFileProcessor
	{
		public List<string[]> ReadData(TextFileSettings settings)
		{
			if (settings == null)
			{
				return null;
			}
			if (string.IsNullOrWhiteSpace(settings.Path))
			{
				return null;
			}
			if (!File.Exists(settings.Path))
			{
				return null;
			}
			//
			//read the file, one line at a time
			var separator = new string[] { settings.ColumnSeparator };
			var lines = new List<string[]>();
			using (var reader = new StreamReader(File.OpenRead(settings.Path)))
			{
				var firstLine = true;
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (firstLine && settings.ColumnHeadersInFirstLine)
					{
						firstLine = false;
						continue;
					}
					if (string.IsNullOrWhiteSpace(line))
					{
						continue;
					}
					//
					//split the line into an array, using the separator
					var values = line.Split(separator, StringSplitOptions.None);
					lines.Add(values);
				}
			}
			return lines;
			//
			//add the data that was read from the file to a plugin
			//var dataSettings = new IterableDataSettings(lines);


		}
	}
}
