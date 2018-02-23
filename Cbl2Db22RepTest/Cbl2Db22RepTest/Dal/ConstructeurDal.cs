using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cbl2Db22RepTest.Dal
{
	public interface IConstructeurDal
	{
		List<Constructeur> Gets(string critere, int limit);
	}

	public class ConstructeurDal : IConstructeurDal
    {
		private readonly IDataBaseGetter _dataBaseGetter;

		public ConstructeurDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<Constructeur> Gets(string critere, int limit)
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where
				(
					Expression.Property("table").EqualTo(Expression.String("constructeur"))
					.And(Function.Upper(Expression.Property("nom")).Like(Expression.String($"{critere.ToUpper()}%")))
					.And(Expression.Property("actif").EqualTo(Expression.Int(1)))
				)
				.OrderBy(Ordering.Property("nom").Ascending())
				.Limit(Expression.Int(limit));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToConstructeur()).ToList();
		}
	}
}
