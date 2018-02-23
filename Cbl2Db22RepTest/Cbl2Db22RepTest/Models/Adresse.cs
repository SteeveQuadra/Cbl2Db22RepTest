using Couchbase.Lite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Models
{
	public class Adresse : BindableObject, ISaveable
	{
		private string _codePostal;
		private string _intitule1;
		private string _intitule2;
		private string _intitule3;
		private string _libelle1;
		private string _libelle2;
		private string _libelle3;
		private string _payCode;
		private string _pays;
		private string _ville;
		private long? _comNum;

		[JsonProperty("codePostal")]
		public string CodePostal { get => _codePostal; set { _codePostal = value; OnPropertyChanged(); } }

		[JsonProperty("intitule1")]
		public string Intitule1 { get => _intitule1; set { _intitule1 = value; OnPropertyChanged(); } }

		[JsonProperty("intitule2")]
		public string Intitule2 { get => _intitule2; set { _intitule2 = value; OnPropertyChanged(); } }

		[JsonProperty("intitule3")]
		public string Intitule3 { get => _intitule3; set { _intitule3 = value; OnPropertyChanged(); } }

		[JsonProperty("libelle1")]
		public string Libelle1 { get => _libelle1; set { _libelle1 = value; OnPropertyChanged(); } }

		[JsonProperty("libelle2")]
		public string Libelle2 { get => _libelle2; set { _libelle2 = value; OnPropertyChanged(); } }

		[JsonProperty("libelle3")]
		public string Libelle3 { get => _libelle3; set { _libelle3 = value; OnPropertyChanged(); } }

		[JsonProperty("pays")]
		public string Pays { get => _pays; set { _pays = value; OnPropertyChanged(); } }

		[JsonProperty("payCode")]
		public string PayCode { get => _payCode; set { _payCode = value; OnPropertyChanged(); } }

		[JsonProperty("table")]
		public string Table { get => "adresse"; }

		[JsonProperty("ville")]
		public string Ville { get => _ville; set { _ville = value; OnPropertyChanged(); } }

		[JsonProperty("comNum")]
		public long? ComNum { get => _comNum; set { _comNum = value; OnPropertyChanged(); } }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			dico.SetString("intitule1", Intitule1);
			dico.SetString("intitule2", Intitule2);
			dico.SetString("intitule3", Intitule3);
			dico.SetString("libelle1", Libelle1);
			dico.SetString("libelle2", Libelle2);
			dico.SetString("libelle3", Libelle3);
			dico.SetString("pays", Pays);
			dico.SetString("payCode", PayCode);
			dico.SetString("codePostal", CodePostal);
			dico.SetString("ville", Ville);
			dico.SetLong("comNum", ComNum ?? 0);

			return dico;
		}
	}
}
