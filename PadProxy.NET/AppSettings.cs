using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadProxy.NET
{
	public class AppSettings
	{
		public string[] AvailableServers { get; set; }
		public bool ForwardRandomly { get; set; }
	}
}
