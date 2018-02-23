using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
	public class Pays
	{
		[JsonProperty("PayCode")]
		public string PayCode { get; set; }

		[JsonProperty("PayLibelle")]
		public string PayLibelle { get; set; }

		[JsonProperty("DateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("DateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("Table")]
		public string Table { get => "pays"; }
	}
}
