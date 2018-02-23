using Couchbase.Lite;
using Cbl2Db22RepTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Configuration
{
    public class DefaultVendeur : BindableObject, ISaveable, ITechnicalKey
	{
		private int _num;
		private string _nom;
		private string _email;
		private string _telephone;
		private int _actif;

		[JsonProperty("nom")]
		public string Nom { get => _nom; set { _nom = value; } }

		[JsonProperty("email")]
		public string Email { get => _email; set { _email = value; } }

		[JsonProperty("telephone")]
		public string Telephone { get => _telephone; set { _telephone = value; } }

		[JsonProperty("num")]
		public int Num { get => _num; set => _num = value; }

		public string Table { get => "defaultvendeur"; }
		public string Id { get; set; }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			dico.SetString("nom", Nom);
			dico.SetInt("num", Num);
			dico.SetString("email", Email);
			dico.SetString("telephone", Telephone);
			dico.SetString("id", Id);

			return dico;

		}
	}
}
