using Couchbase.Lite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Cbl2Db22RepTest.Services
{
	public static class MutableDocumentExtension
	{
		public static MutableDocument ToDocument(this Couchbase.Lite.MutableDictionaryObject dico, string id, MutableDocument document=null)
		{
			if (document == null)
				document = new MutableDocument(id);

			foreach (string key in dico.Keys)
			{
				string typeOfObject = dico.GetValue(key)?.GetType().ToString();
				switch (typeOfObject)
				{
					case "System.Int64": document.SetLong(key, dico.GetLong(key)); break;
					case "System.Int32": document.SetInt(key, dico.GetInt(key)); break;
					case "Couchbase.Lite.IMutableDictionary":
					case "Couchbase.Lite.MutableDictionaryObject": document.SetDictionary(key, dico.GetDictionary(key)); break;
					case "System.String": document.SetString(key, dico.GetString(key)); break;
					case "System.DateTime": document.SetDate(key, dico.GetDate(key)); break;
					case "Couchbase.Lite.MutableArrayObject": document.SetArray(key, dico.GetArray(key)); break;
					default:
						document.SetValue(key, dico.GetValue(key));
						break;
				}
			}

			return document;
		}
	}
}
