using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
	public class Civilite
	{
		[JsonProperty("civCode")]
		public string CivCode { get; set; }

		[JsonProperty("civLibelle")]
		public string CivLibelle { get; set; }

		[JsonProperty("DateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("DateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("Table")]
		public string Table { get => "civilite"; }
	}
}
