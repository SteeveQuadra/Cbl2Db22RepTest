using Couchbase.Lite;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Configuration
{

	public interface IDbConfigurationGetter
	{
		Database Get();
	}
	public class DbConfigurationGetter : IDbConfigurationGetter
	{
		private readonly IConflictResolver _conflictResolver;

		private Database _database = null;

		public DbConfigurationGetter()
		{
			_conflictResolver = new DataBaseConfictResolver();
		}

		public Database Get()
		{
			try
			{
				if (_database != null)
					return _database;

				string databaseName = "mobiconfig";

				DatabaseConfiguration config = new DatabaseConfiguration();
				config.ConflictResolver = _conflictResolver;
				_database = new Database(databaseName, config);

				return _database;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
