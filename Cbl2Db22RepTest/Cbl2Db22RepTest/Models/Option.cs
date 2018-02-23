using System;
using System.Collections.Generic;
using System.Text;
using Couchbase.Lite;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Models
{
	public class Option : BindableObject, ISaveable, ITechnicalKey, IDateable
	{
		Programme _programmeReserve;
		Lot _lotReserve;
		Vendeur _tiersVendeur;
		Constructeur _constructeur;
		DateTime _datePoseOption;
		string _nomAcquereur;
		string _commentaire;
		string _id;
		bool _actif;

		public Option()
		{
			PropertyChanged += Option_PropertyChanged;
			DatePoseOption = DateTime.Now;
			Actif = true;
		}

		private void Option_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(DatePoseOption): OnPropertyChanged(nameof(IsDatePoseValid)); break;
				default:
					break;
			}
		}

		[JsonProperty("table")]
		public string Table => "option";

		[JsonProperty("programmeReserve")]
		public Programme ProgrammeReserve { get => _programmeReserve; set { _programmeReserve = value; OnPropertyChanged(); } }

		[JsonProperty("lotReserve")]
		public Lot LotReserve { get => _lotReserve; set { _lotReserve = value; OnPropertyChanged(); } }

		[JsonProperty("tiersConstructeur")]
		public Constructeur TiersConstructeur { get => _constructeur; set { _constructeur = value; OnPropertyChanged(); } }

		[JsonProperty("tiersVendeur")]
		public Vendeur TiersVendeur { get => _tiersVendeur; set { _tiersVendeur = value; OnPropertyChanged(); } }

		[JsonProperty("id")]
		public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }

		[JsonProperty("dateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("dateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("datePoseOption")]
		public DateTime DatePoseOption { get => _datePoseOption; set { _datePoseOption = value; OnPropertyChanged(); } }

		[JsonProperty("nomAcquereur")]
		public string NomAcquereur { get => _nomAcquereur; set { _nomAcquereur = value; OnPropertyChanged(); } }

		[JsonProperty("commentaire")]
		public string Commentaire { get => _commentaire; set { _commentaire = value; OnPropertyChanged();} }

		public bool IsDatePoseValid
		{
			get
			{
				if (DatePoseOption != DateTime.MinValue)
					return true;
				return false;
			}
		}

		public bool Actif { get => _actif; set { _actif = value; OnPropertyChanged(); } }

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			dico.SetString("id", Id);
			dico.SetString("nomAcquereur", NomAcquereur);
			dico.SetString("commentaire", Commentaire);
			dico.SetDictionary("programmeReserve", ProgrammeReserve.DocumentInitialize());
			dico.SetDictionary("lotReserve", LotReserve.DocumentInitialize());
			if (TiersConstructeur != null)
				dico.SetDictionary("tiersConstructeur", TiersConstructeur.DocumentInitialize());
			dico.SetDictionary("tiersVendeur", TiersVendeur.DocumentInitialize());

			if (DateCreation != DateTime.MinValue)
				dico.SetDate("dateCreation", DateCreation);

			if (DateModif != DateTime.MinValue)
				dico.SetDate("dateModif", DateModif);

			if (DatePoseOption != DateTime.MinValue)
				dico.SetDate("datePoseOption", DatePoseOption);

			dico.SetBoolean("actif", Actif);

			return dico;
		}
	}
}
