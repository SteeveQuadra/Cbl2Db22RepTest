using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Connectivity;

namespace Cbl2Db22RepTest.Services
{
	internal class ConnectivityMessage
	{
		public bool  IsConnected { get; set; }

		public ConnectivityMessage(bool isConnected)
		{
			IsConnected = isConnected;
		}
	}
}
