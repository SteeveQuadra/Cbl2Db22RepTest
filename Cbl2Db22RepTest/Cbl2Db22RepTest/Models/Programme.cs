using Couchbase.Lite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
	public class Programme : ISaveable
	{
		[JsonProperty("num")]
		public long? Num { get; set; }

		[JsonProperty("libelle")]
		public string Libelle { get; set; }

		[JsonProperty("localite")]
		public string Localite { get; set; }

		[JsonProperty("depCode")]
		public string DepCode { get; set; }

		[JsonProperty("petNumero")]
		public long PetNumero { get; set; }

		[JsonProperty("etat")]
		public string Etat { get; set; }

		[JsonProperty("dateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("dateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("table")]
		public string Table { get => "programme"; }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			if (Num != null)
				dico.SetLong("num", Num??0);
			dico.SetString("libelle", Libelle);
			dico.SetString("localite", Localite);
			dico.SetString("depCode", DepCode);
			dico.SetLong("petNumero", PetNumero);
			dico.SetString("etat", Etat);

			return dico;
		}
	}
}
