using Couchbase.Lite.Query;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cbl2Db22RepTest.Dal
{
	public interface IReservationDal
	{
		Reservation GetInstance();
		void SetInstance(Reservation reservation);
		List<Reservation> Gets();
	}

	public class ReservationDal : IReservationDal
    {
		private Reservation _reservation = null;
		private readonly IDataBaseGetter _dataBaseGetter;

		public ReservationDal(IDataBaseGetter dataBaseGetter)
		{
			_dataBaseGetter = dataBaseGetter;
		}

		public Reservation GetInstance()
		{
			if (_reservation == null)
				return App.Injector.GetInstance<Reservation>();

			Reservation reservation = _reservation;
			_reservation = null;
			return reservation;
		}

		public List<Reservation> Gets()
		{
			IQuery query = QueryBuilder.Select(SelectResult.All())
			   .From(DataSource.Database(_dataBaseGetter.Get()))
			   .Where(Expression.Property("table").EqualTo(Expression.String("reservation")));

			var rows = query.Execute();

			return rows.Select(r => r.GetDictionary(0).ToMutable().ToReservation()).ToList();
		}

		public void SetInstance(Reservation reservation)
		{
			_reservation = reservation;
		}

	}
}
