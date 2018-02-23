using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cbl2Db22RepTest.Services
{
	public interface IDataBaseLoader
	{
		List<Information> Gets();
	}

	public class DataBaseLoader : IDataBaseLoader
	{
		private readonly IDataBaseGetter _dataBaseGetter;

		public DataBaseLoader(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public List<Information> Gets()
		{
			List<Information> informations = new List<Information>();

			IQuery query = QueryBuilder.Select(SelectResult.Expression(Expression.Property("payCode")))
			   .From(DataSource.Database(_dataBaseGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("pays")));

			var rows = query.Execute();

			query = QueryBuilder.Select(SelectResult.Expression(Expression.Property("finCode")))
			   .From(DataSource.Database(_dataBaseGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("typefinancement")));

			var rowsFin = query.Execute();

			query = QueryBuilder.Select(SelectResult.Expression(Expression.Property("sfaCode")))
			   .From(DataSource.Database(_dataBaseGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("situationfamille")));

			var rowsSit = query.Execute();

			query = QueryBuilder.Select(SelectResult.Expression(Expression.Property("Num")))
			   .From(DataSource.Database(_dataBaseGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("commune")));

			var rowsCom = query.Execute();

			query = QueryBuilder.Select(SelectResult.All())
			  .From(DataSource.Database(_dataBaseGetter.Get()))
			  .Where(Expression.Property("table").EqualTo(Expression.String("futuracquereur")));

			var rowsAq = query.Execute();

			query = QueryBuilder.Select(SelectResult.All())
			  .From(DataSource.Database(_dataBaseGetter.Get()))
			  .Where(Expression.Property("table").EqualTo(Expression.String("programme")));

			var rowsProg = query.Execute();

			query = QueryBuilder.Select(SelectResult.All())
			  .From(DataSource.Database(_dataBaseGetter.Get()))
			  .Where(Expression.Property("table").EqualTo(Expression.String("lot")));

			var rowsLot = query.Execute();

			query = QueryBuilder.Select(SelectResult.All())
			  .From(DataSource.Database(_dataBaseGetter.Get()))
			  .Where(Expression.Property("table").EqualTo(Expression.String("vendeur")));

			var rowsVdr = query.Execute();

			query = QueryBuilder.Select(SelectResult.All())
			  .From(DataSource.Database(_dataBaseGetter.Get()))
			  .Where(Expression.Property("table").EqualTo(Expression.String("constructeur")));

			var rowsCtr = query.Execute();

			query = QueryBuilder.Select(SelectResult.All())
			  .From(DataSource.Database(_dataBaseGetter.Get()))
			  .Where(Expression.Property("table").EqualTo(Expression.String("civilite")));

			var rowsCiv = query.Execute();

			query = QueryBuilder.Select(SelectResult.All())
			  .From(DataSource.Database(_dataBaseGetter.Get()))
			  .Where(Expression.Property("table").EqualTo(Expression.String("reservation")));

			var rowsRes = query.Execute();

			query = QueryBuilder.Select(SelectResult.All())
			  .From(DataSource.Database(_dataBaseGetter.Get()))
			  .Where(Expression.Property("table").EqualTo(Expression.String("option")));

			var rowsOpt = query.Execute();

			informations.Add(new Information() { Info = "Civilités", Quantite = rowsCiv.Count() });
			informations.Add(new Information() { Info = "Communes", Quantite = rowsCom.Count() });
			informations.Add(new Information() { Info = "Constructeurs", Quantite = rowsCtr.Count() });
			informations.Add(new Information() { Info = "Futurs Acquéreurs", Quantite = rowsAq.Count() });
			informations.Add(new Information() { Info = "Lots", Quantite = rowsLot.Count() });
			informations.Add(new Information() { Info = "Options", Quantite = rowsOpt.Count() });
			informations.Add(new Information() { Info = "Pays", Quantite = rows.Count() });
			informations.Add(new Information() { Info = "Programmes", Quantite = rowsProg.Count() });
			informations.Add(new Information() { Info = "Réservations", Quantite = rowsRes.Count() });
			informations.Add(new Information() { Info = "Situations Familiales", Quantite = rowsSit.Count() });
			informations.Add(new Information() { Info = "Types de financements", Quantite = rowsFin.Count() });
			informations.Add(new Information() { Info = "Vendeurs", Quantite = rowsVdr.Count() });

			return informations;
		}
	}
}
