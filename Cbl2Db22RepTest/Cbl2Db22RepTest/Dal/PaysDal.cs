using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cbl2Db22RepTest.Dal
{
	public interface IPaysDal
	{
		List<Pays> Gets();
	}
    public class PaysDal : IPaysDal
	{
		private readonly IDataBaseGetter _dataBaseGetter;

		public PaysDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<Pays> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("pays")));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToPays()).ToList();
		}
	}
}
