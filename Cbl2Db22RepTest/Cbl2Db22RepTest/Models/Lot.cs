using Couchbase.Lite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
	public class Lot : ISaveable
	{
		[JsonProperty("num")]
		public long? Num { get; set; }

		[JsonProperty("pgrNum")]
		public long PgrNum { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("surface")]
		public double Surface { get; set; }

		[JsonProperty("surfacePlancher")]
		public double SurfacePlancher { get; set; }

		[JsonProperty("facade")]
		public string Facade { get; set; }

		[JsonProperty("letCode")]
		public string LetCode { get; set; }

		[JsonProperty("etat")]
		public string Etat { get; set; }

		[JsonProperty("dateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("dateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("table")]
		public string Table { get => "lot"; }

		[JsonProperty("prixVenteConseille")]
		public double? PrixVenteConseille { get; set; }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			if (Num != null)
				dico.SetLong("num", Num ?? 0);
			dico.SetLong("pgrNum", PgrNum);
			dico.SetString("code", Code);
			dico.SetDouble("surface", Surface);
			dico.SetDouble("surfacePlancher", SurfacePlancher);
			dico.SetString("facade", Facade);
			dico.SetString("letCode", LetCode);
			dico.SetString("etat", Etat);
			dico.SetDouble("prixVenteConseille", PrixVenteConseille??0);

			return dico;
		}
	}
}
