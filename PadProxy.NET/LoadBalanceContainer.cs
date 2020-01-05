using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PadProxy.NET
{
	// This class is instantiated once at startup/first call
	// Loads list of available for forwarding servers
	// Stores a list of requests count per server address
	public class LoadBalanceContainer
	{
		private static Dictionary<string, int> RequestsPerServer = new Dictionary<string, int>();

		private readonly AppSettings appSettings;

		public LoadBalanceContainer(IOptions<AppSettings> appSettings)
		{
			this.appSettings = appSettings.Value;

			foreach (var serverAddress in this.appSettings.AvailableServers)
			{
				RequestsPerServer.Add(serverAddress, 0);
			}
		}

		// We have 2 options:
		// - balance randomly
		// - take by least requests №
		public string GetLeastLoaded()
		{
			if (appSettings.ForwardRandomly)
				return RequestsPerServer.ToList()[new Random().Next(0, RequestsPerServer.Count)].Key;

			var leastLoaded = RequestsPerServer.FirstOrDefault(
				f => f.Value == RequestsPerServer.Min(m => m.Value));

			RequestsPerServer[leastLoaded.Key] += 1;

			return leastLoaded.Key;
		}
	}
}