using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System.Collections.Generic;
using System.Linq;

namespace Cbl2Db22RepTest.Dal
{
	public interface IFuturAcquereurDal
	{
		List<FuturAcquereur> Gets();
		List<FuturAcquereur> Gets(string critere, int limit);
		FuturAcquereur GetInstance();
		void SetInstance(FuturAcquereur futurAcquereur);
		FuturAcquereur Get(string id);
	}
	public class FuturAcquereurDal : IFuturAcquereurDal
	{
		private FuturAcquereur _futurAcquereur = null;

		private readonly IDataBaseGetter _dataBaseGetter;

		public FuturAcquereurDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<FuturAcquereur> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
			   .From(DataSource.Database(_dataBaseGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("futuracquereur")));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToFuturAcquereur()).ToList();
		}

		public List<FuturAcquereur> Gets(string critere, int limit)
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
				.From(DataSource.Database(_dataBaseGetter.Get()))
				.Where
				(
					Expression.Property("table").EqualTo(Expression.String("futuracquereur"))
					.And(Function.Upper(Expression.Property("aquereurPrincipal.nom")).Like(Expression.String($"{critere.ToUpper()}%")))
				)
				.OrderBy(Ordering.Property("aquereurPrincipal.nom").Ascending())
				.Limit(Expression.Int(limit));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToFuturAcquereur()).ToList();
		}

		public FuturAcquereur GetInstance()
		{
			if (_futurAcquereur == null)
				return App.Injector.GetInstance<FuturAcquereur>();

			FuturAcquereur futurAcquereur = _futurAcquereur;
			_futurAcquereur = null;
			return futurAcquereur;
		}

		public void SetInstance(FuturAcquereur futurAcquereur)
		{
			_futurAcquereur = futurAcquereur;
		}

		public FuturAcquereur Get(string id)
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
			   .From(DataSource.Database(_dataBaseGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("futuracquereur"))
			   .And(Expression.Property("id").EqualTo(Expression.String(id))));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToFuturAcquereur()).FirstOrDefault();
		}
	}
}
