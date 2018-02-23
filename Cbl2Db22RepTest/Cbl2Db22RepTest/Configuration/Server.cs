using Couchbase.Lite;
using Cbl2Db22RepTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Configuration
{
    public class Server: BindableObject, ISaveable, ITechnicalKey
	{
		private string _login;
		private string _password;
		private string _urlServer;

		[JsonProperty("login")]
		public string Login { get => _login; set { _login = value; OnPropertyChanged(); } }
		[JsonProperty("password")]
		public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
		[JsonProperty("urlServer")]
		public string UrlServer { get => _urlServer; set { _urlServer = value; OnPropertyChanged(); } }
		[JsonProperty("table")]
		public string Table { get => "server"; }
		public string Id { get; set; }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			dico.SetString("login", Login);
			dico.SetString("password", Password);
			dico.SetString("urlServer", UrlServer);
			dico.SetString("id", Id);		

			return dico;
		}
	}
}
