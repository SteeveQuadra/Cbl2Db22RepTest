using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
	public class Commune
	{
		[JsonProperty("num")]
		public long Num { get; set; }

		[JsonProperty("libelle")]
		public string Libelle { get; set; }

		[JsonProperty("codePostal")]
		public string CodePostal { get; set; }

		[JsonProperty("payCode")]
		public string PayCode { get; set; }

		[JsonProperty("dateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("dateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("table")]
		public string Table { get => "commune"; }
	}
}
