using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System.Collections.Generic;
using System.Linq;

namespace Cbl2Db22RepTest.Dal
{

	public interface ICommuneDal
	{
		List<Commune> Gets(string critereVille, int limit);
		List<Commune> Gets(string libelle, string codePostale, string payCode);
	}
	public class CommuneDal : ICommuneDal
	{
		private readonly IDataBaseGetter _dataBaseGetter;
		private const string LIBELLE_TEST = "Test";
		private const string CP_TEST = "00000";
		private const string PAYCODE_TEST = "FR";

		public CommuneDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<Commune> Gets(string critereVille, int limit)
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where
				(
					Expression.Property("table").EqualTo(Expression.String("commune"))
					.And(Function.Upper(Expression.Property("libelle")).Like(Expression.String($"{critereVille.ToUpper()}%")))
				)
				.OrderBy(Ordering.Property("libelle").Ascending())
				.Limit(Expression.Int(limit));
				

			var rows = query.Execute();

			if (rows.Count() == 0)
			{
				List<Commune> communes = new List<Commune>
				{
					new Commune() { Num = 1, Libelle = LIBELLE_TEST, CodePostal = CP_TEST, PayCode = PAYCODE_TEST }
				};
				return communes;
			}

			rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToCommune()).ToList();
		}

		public List<Commune> Gets(string libelle, string codePostale, string payCode)
		{
			if (libelle == LIBELLE_TEST && codePostale == CP_TEST && payCode == PAYCODE_TEST)
			{
				List<Commune> communes = new List<Commune>();
				communes.Add(new Commune() { Num = 1, Libelle = "Test", CodePostal = "00000", PayCode = "FR" });
				return communes;
			}

			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where(Expression.Property("table").EqualTo(Expression.String("commune"))
				.And(Expression.Property("libelle").EqualTo(Expression.String(libelle))
				.And(Expression.Property("codePostal").EqualTo(Expression.String(codePostale))
				.And(Expression.Property("payCode").EqualTo(Expression.String(payCode))))));


			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToCommune()).ToList();
		}
	}
}
