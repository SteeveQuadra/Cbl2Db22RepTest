using Couchbase.Lite;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Configuration
{
	public interface IDbConfigurationSaver
	{
		bool Save(ISaveable aSauver);
	}

	public class DbConfigurationSaver : IDbConfigurationSaver
	{
		private readonly IDbConfigurationGetter _dbConfigurationGetter;

		public DbConfigurationSaver(IDbConfigurationGetter dbConfigurationGetter)
		{
			_dbConfigurationGetter = dbConfigurationGetter;
		}

		public bool Save(ISaveable aSauver)
		{
			string docId = $"{aSauver.Table}_{Guid.NewGuid()}";

			ITechnicalKey technicalKey = aSauver as ITechnicalKey;

			if (technicalKey == null)
				return false;

			MutableDocument document=null;

			if (string.IsNullOrEmpty(technicalKey.Id))
				technicalKey.Id = docId;
			else
				document = _dbConfigurationGetter.Get().GetDocument(technicalKey.Id).ToMutable();

			MutableDictionaryObject dico = aSauver.DocumentInitialize();

			document = dico.ToDocument(docId, document);			

			_dbConfigurationGetter.Get().Save(document);

			return true;
		}
	}
}
