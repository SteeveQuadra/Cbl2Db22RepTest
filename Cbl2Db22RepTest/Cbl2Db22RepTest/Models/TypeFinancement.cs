using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
	public class TypeFinancement
	{
		[JsonProperty("finCode")]
		public string FinCode { get; set; }

		[JsonProperty("finLibelle")]
		public string FinLibelle { get; set; }

		[JsonProperty("dateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("dateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("table")]
		public string Table { get => "typefinancement"; }
	}
}
