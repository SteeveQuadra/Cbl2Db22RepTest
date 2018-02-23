using Couchbase.Lite.Query;
using System.Collections.Generic;
using System.Linq;

namespace Cbl2Db22RepTest.Configuration
{
	public interface ISynchroExDal
	{
		List<SynchroEx> Gets();
		void Save(SynchroEx synchroEx);
	}

	public class SynchroExDal : ISynchroExDal
	{
		private readonly IDbConfigurationGetter _dbConfigurationGetter;
		private readonly IDbConfigurationSaver _dbConfigurationSaver;

		public SynchroExDal(IDbConfigurationGetter dbConfiguratioGetter,
			IDbConfigurationSaver dbConfigurationSaver)
		{
			_dbConfigurationGetter = dbConfiguratioGetter;
			_dbConfigurationSaver = dbConfigurationSaver;
		}

		public void Save(SynchroEx synchroEx)
		{
			_dbConfigurationSaver.Save(synchroEx);
		}


		public List<SynchroEx> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
			   .From(DataSource.Database(_dbConfigurationGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("synchroex")))
			   .OrderBy(Ordering.Property("dateException").Descending())
			   .Limit(Expression.Int(150));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToSynchroEx()).ToList();
		}
	}
}
