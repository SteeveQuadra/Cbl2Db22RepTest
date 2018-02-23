using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Configuration
{
    public static class ServerExtension
    {
		public static Server ToServer(this Couchbase.Lite.IMutableDictionary dico)
		{
			Server server = new Server
			{
				Login = dico.GetString("login"),
				Id = dico.GetString("id"),
				Password = dico.GetString("password"),
				UrlServer = dico.GetString("urlServer")
			};

			return server;
		}
	}
}
