using Couchbase.Lite;
using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using System.Linq;

namespace Cbl2Db22RepTest.Configuration
{
	public interface IDefaultVendeurDal
	{
		DefaultVendeur Get();
		void Save(DefaultVendeur defaultVendeur);
		void Delete(DefaultVendeur defaultVendeur);
	}

	public class DefaultVendeurDal : IDefaultVendeurDal
	{
		private readonly IDbConfigurationGetter _dbConfigurationGetter;
		private readonly IDbConfigurationSaver _dbConfigurationSaver;

		public DefaultVendeurDal(IDbConfigurationGetter dbConfiguratioGetter,
			IDbConfigurationSaver dbConfigurationSaver)
		{
			_dbConfigurationGetter = dbConfiguratioGetter;
			_dbConfigurationSaver = dbConfigurationSaver;
		}

		public void Delete(DefaultVendeur defaultVendeur)
		{
			Document document = _dbConfigurationGetter.Get().GetDocument(defaultVendeur.Id);
			if (document != null)
				_dbConfigurationGetter.Get().Delete(document);
		}

		public DefaultVendeur Get()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dbConfigurationGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("defaultvendeur")));


			var rows = query.Execute().ToList();
			if (rows.Count() == 0)
				return null;

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToDefaultVendeur()).FirstOrDefault();
		}

		public void Save(DefaultVendeur defaultVendeur)
		{
			_dbConfigurationSaver.Save(defaultVendeur);
		}
	}
}
