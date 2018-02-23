using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cbl2Db22RepTest.Dal
{
	public interface IVendeurDal
	{
		List<Vendeur> Gets();
	}

    public class VendeurDal : IVendeurDal
    {
		private readonly IDataBaseGetter _dataBaseGetter;

		public VendeurDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<Vendeur> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("vendeur")));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToVendeur()).ToList();
		}
	}
}
