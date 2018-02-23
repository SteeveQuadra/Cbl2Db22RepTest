using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cbl2Db22RepTest.Dal
{
	public interface ITypeFinancementDal
	{
		List<TypeFinancement> Gets();
	}
	public class TypeFinancementDal : ITypeFinancementDal
	{
		private readonly IDataBaseGetter _dataBaseGetter;

		public TypeFinancementDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<TypeFinancement> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("typefinancement")));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToTypeFinancement()).ToList();
		}
	}
}
