using Couchbase.Lite.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cbl2Db22RepTest.Configuration
{
	public interface IServerDal
	{
		Server Get();
		void Save(Server server);
	}
	public class ServerDal : IServerDal
	{
		private readonly IDbConfigurationGetter _dbConfigurationGetter;
		private readonly IDbConfigurationSaver _dbConfigurationSaver;

		public ServerDal(IDbConfigurationGetter dbConfiguratioGetter,
			IDbConfigurationSaver dbConfigurationSaver)
		{
			_dbConfigurationGetter = dbConfiguratioGetter;
			_dbConfigurationSaver = dbConfigurationSaver;
		}

		public Server Get()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dbConfigurationGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("server")));


			var rows = query.Execute().ToList();
			if (rows.Count() == 0)
				return null;			

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToServer()).FirstOrDefault();
		}

		public void Save(Server server)
		{
			Server saved = Get();
			if (saved == null || (server.Table != saved.Table || server.UrlServer != saved.UrlServer || server.Password != saved.Password ))
				_dbConfigurationSaver.Save(server);
		}
	}
}
