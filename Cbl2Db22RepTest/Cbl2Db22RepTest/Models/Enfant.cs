using Couchbase.Lite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Models
{
	public class Enfant : BindableObject, ISaveable
	{
		public Enfant()
		{
			PropertyChanged += Enfant_PropertyChanged;
		}

		private void Enfant_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(DateNaissance): OnPropertyChanged(nameof(IsDateNaissanceValid)); break;
				default:
					break;
			}
		}

		private DateTime _dateNaissance;
		[JsonProperty("dateNaissance")]
		public DateTime DateNaissance { get => _dateNaissance; set { _dateNaissance = value; OnPropertyChanged(); } }
		[JsonProperty("table")]
		public string Table { get => "enfant"; }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			if (DateNaissance != DateTime.MinValue)
				dico.SetDate("dateNaissance", DateNaissance);

			return dico;
		}

		public bool IsDateNaissanceValid
		{
			get
			{
				if (DateNaissance != DateTime.MinValue)
					return true;
				return false;
			}
		}
	}
}
