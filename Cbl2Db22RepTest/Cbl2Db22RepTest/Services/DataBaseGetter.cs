using Couchbase.Lite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cbl2Db22RepTest.Services
{
	public interface IDataBaseGetter
	{
		Database Get();
	}
	public class DataBaseGetter : IDataBaseGetter
	{
		private readonly IConflictResolver _conflictResolver;
		private readonly IDataBaseIndexesCreator _dataBaseIndexesCreator;
		private Database _database = null;
		private List<string> _indexes = null;
		public DataBaseGetter(IDataBaseIndexesCreator dataBaseIndexesCreator)
		{
			_conflictResolver = new DataBaseConfictResolver();
			_dataBaseIndexesCreator = dataBaseIndexesCreator;
		}

		public Database Get()
		{
			try
			{
				if (_database != null)
					return _database;

				string databaseName = "mobilotis";

				DatabaseConfiguration config = new DatabaseConfiguration
				{
					ConflictResolver = _conflictResolver
				};
				_database =  new Database(databaseName, config);

				if (_indexes == null)
				{
					_indexes = _dataBaseIndexesCreator.Create(_database);
				}

				return _database;
			}
			catch (Exception )
			{
				return null;
			}
		}
	}
}
