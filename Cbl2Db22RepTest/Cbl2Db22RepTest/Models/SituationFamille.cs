using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Cbl2Db22RepTest.Models
{
	public class SituationFamille
	{
		[JsonProperty("SfaCode")]
		public string SfaCode { get; set; }

		[JsonProperty("SfaLibelle")]
		public string SfaLibelle { get; set; }

		[JsonProperty("DateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("DateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("Table")]
		public string Table { get => "situationfamille"; }
	}
}
