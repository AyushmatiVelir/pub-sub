using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSub.Models;

namespace PubSub.Subscribers
{
	public interface ISubscriber
	{
		void DisplayData(List<FileDetailModel> message);
	}
}
