using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cbl2Db22RepTest.Dal
{
	public interface IProgrammeDal
	{
		List<Programme> Gets(string critere, int limit);
	}

	public class ProgrammeDal : IProgrammeDal
    {
		private readonly IDataBaseGetter _dataBaseGetter;

		public ProgrammeDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<Programme> Gets(string critere, int limit)
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where
				(
					Expression.Property("table").EqualTo(Expression.String("programme"))
					.And(Function.Upper(Expression.Property("localite")).Like(Expression.String($"{critere.ToUpper()}%")))
				)
				.OrderBy(Ordering.Property("localite").Ascending())
				.Limit(Expression.Int(limit))
				;


			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToProgramme()).ToList();
		}
	}
}
