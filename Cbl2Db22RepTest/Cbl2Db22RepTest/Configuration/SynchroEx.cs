using Couchbase.Lite;
using Cbl2Db22RepTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Configuration
{
	public class SynchroEx : BindableObject, ISaveable, ITechnicalKey
	{
		private DateTime _dateException;
		private string _message;
		private string _id;
		public string Table => "synchroex";

		public string Id { get => _id; set => _id=value; }
		public DateTime DateException { get => _dateException; set => _dateException = value; }
		public string Message { get => _message; set => _message = value; }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			dico.SetDate("dateException", DateException);
			dico.SetString("message", Message);
			dico.SetString("id", Id);

			return dico;
		}
	}
}
