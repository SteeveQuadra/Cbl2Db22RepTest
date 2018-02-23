using Couchbase.Lite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Models
{
	public class Constructeur : BindableObject, ISaveable
	{
		private int? _num;
		private string _nom;
		private string _email;
		private string _telephone;
		private int _actif;
		private Adresse _adresse;

		[JsonProperty("nom")]
		public string Nom { get => _nom; set { _nom = value; OnPropertyChanged(); } }

		[JsonProperty("table")]
		public string Table { get => "constructeur"; }

		[JsonProperty("email")]
		public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

		[JsonProperty("telephone")]
		public string Telephone { get => _telephone; set { _telephone = value; OnPropertyChanged(); } }

		[JsonProperty("dateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("dateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("num")]
		public int? Num { get => _num; set { _num = value; OnPropertyChanged(); } }

		[JsonProperty("actif")]
		public int Actif { get => _actif; set { _actif = value; OnPropertyChanged(); } }

		[JsonProperty("adresse")]
		public Adresse Adresse { get => _adresse; set { _adresse = value; OnPropertyChanged(); } }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();
			dico.SetString("table", Table);
			dico.SetString("nom", Nom);
			dico.SetInt("num", Num??0);
			dico.SetString("email", Email);
			dico.SetString("telephone", Telephone);
			dico.SetInt("actif", Actif);
			dico.SetDictionary("adresse", Adresse.DocumentInitialize());

			return dico;
		}
	}
}
