using Couchbase.Lite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Models
{
	public class Financement : BindableObject, ISaveable
	{
		public string _information;
		public string _finCode;
		public string _finLibelle;
		public string _valeur;

		[JsonProperty("information")]
		public string Information { get => _information; set { _information = value; OnPropertyChanged(); } }

		[JsonProperty("table")]
		public string Table { get => "financement"; }

		[JsonProperty("finCode")]
		public string FinCode { get => _finCode; set { _finCode = value; OnPropertyChanged(); } }

		[JsonProperty("finLibelle")]
		public string FinLibelle { get => _finLibelle; set { _finLibelle = value; OnPropertyChanged(); } }

		[JsonProperty("valeur")]
		public string Valeur { get => _valeur; set { _valeur = value; OnPropertyChanged(); } }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			dico.SetString("information", Information);
			dico.SetString("finCode", FinCode);
			dico.SetString("finLibelle", FinLibelle);
			dico.SetString("valeur", Valeur);

			return dico;
		}
	}
}
