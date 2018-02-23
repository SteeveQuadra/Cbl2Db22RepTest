using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cbl2Db22RepTest.Dal
{
	public interface ILotDal
	{
		List<Lot> Gets(long? pgrNum);
	}
    public  class LotDal : ILotDal
    {
		private readonly IDataBaseGetter _dataBaseGetter;

		public LotDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<Lot> Gets(long? pgrNum)
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("lot")).And(Expression.Property("pgrNum").EqualTo(Expression.Long(pgrNum??0))));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToLot()).OrderBy(l=>l.Code).OrderBy(l => Regex.IsMatch(l.Code, @"^\d+$") ? Convert.ToInt32(l.Code):0 ).ToList();
		}
	}
}
