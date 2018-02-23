using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cbl2Db22RepTest.Dal
{
	public interface ICiviliteDal
	{
		List<Civilite> Gets();
	}
    public class CiviliteDal : ICiviliteDal
    {
		private readonly IDataBaseGetter _dataBaseGetter;

		public CiviliteDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<Civilite> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("civilite")));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToCivilite()).ToList();
		}
	}
}
