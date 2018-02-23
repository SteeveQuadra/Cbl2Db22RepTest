using Couchbase.Lite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Couchbase.Lite.Query;

namespace Cbl2Db22RepTest.Services
{
	public interface IDataBaseIndexesCreator
	{
		List<string> Create(Database database);
	}

	public class DataBaseIndexesCreator : IDataBaseIndexesCreator
	{
		public DataBaseIndexesCreator()
		{

		}

		public List<string> Create(Database database)
		{
			List<string> indexes =  database.GetIndexes().ToList<string>();
			
			if (!indexes.Contains("TableI2"))
				database.CreateIndex("TableI2",  IndexBuilder.ValueIndex(ValueIndexItem.Expression(Expression.Property("table"))));

			if (!indexes.Contains("VilleI1"))
				database.CreateIndex("VilleI1", IndexBuilder.ValueIndex(ValueIndexItem.Expression(Expression.Property("ville"))));


			return database.GetIndexes().ToList<string>();
		}
	}
}
