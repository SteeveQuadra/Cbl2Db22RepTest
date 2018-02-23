using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cbl2Db22RepTest.Dal
{
	public interface IOptionDal
	{
		Option GetInstance();
		void SetInstance(Option reservation);
		List<Option> Gets();
	}
    public class OptionDal : IOptionDal
    {
		private Option _option = null;
		private readonly IDataBaseGetter _dataBaseGetter;

		public OptionDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public Option GetInstance()
		{
			if (_option == null)
				return App.Injector.GetInstance<Option>();

			Option option  = _option;
			_option = null;
			return option;
		}

		public List<Option> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
			   .From(DataSource.Database(_dataBaseGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("option"))
			   .And(Expression.Property("actif").EqualTo(Expression.Boolean(true))));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToOption()).ToList();
		}

		public void SetInstance(Option option)
		{
			_option = option;
		}
	}
}
