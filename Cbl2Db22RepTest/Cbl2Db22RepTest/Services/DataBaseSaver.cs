using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Cbl2Db22RepTest.Models;
using Couchbase.Lite;
using System.Diagnostics;

namespace Cbl2Db22RepTest.Services
{
	public interface IDataBaseSaver
	{
		bool Save(ISaveable aSauver);
	}

	public class DataBaseSaver: IDataBaseSaver
	{
		private readonly IDataBaseGetter _dataBaseGiver;

		public DataBaseSaver(IDataBaseGetter dataBaseGiver)
		{
			_dataBaseGiver = dataBaseGiver;
		}

		public bool Save(ISaveable aSauver)
		{
			string docId = $"{aSauver.Table}_{Guid.NewGuid()}";

			ITechnicalKey technicalKey = aSauver as ITechnicalKey;
			IDateable dateable = aSauver as IDateable;

			if (technicalKey == null || dateable == null)
				return false;

			MutableDocument document = null;

			if (string.IsNullOrEmpty(technicalKey.Id))
			{
				technicalKey.Id = docId;
				dateable.DateCreation = DateTime.Now;
			}
			else
			{
				if (dateable.DateCreation == DateTime.MinValue)
					dateable.DateCreation = DateTime.Now;
				dateable.DateModif = DateTime.Now;
				document = _dataBaseGiver.Get().GetDocument(technicalKey.Id).ToMutable();
			}

			MutableDictionaryObject dico = aSauver.DocumentInitialize();

			document = dico.ToDocument(docId, document);

			_dataBaseGiver.Get().Save(document);

			return true;
		}
	}
}
