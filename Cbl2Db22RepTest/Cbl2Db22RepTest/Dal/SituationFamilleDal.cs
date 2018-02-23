using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cbl2Db22RepTest.Dal
{
	public interface ISituationFamilleDal
	{
		List<SituationFamille> Gets();
	}
	public class SituationFamilleDal : ISituationFamilleDal
	{
		private readonly IDataBaseGetter _dataBaseGetter;

		public SituationFamilleDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<SituationFamille> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("situationfamille")));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToSituationFamille()).ToList();
		}
	}
}
