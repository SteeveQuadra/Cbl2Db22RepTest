using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;
using Xamarin.Forms;
using Cbl2Db22RepTest.Models;
using Couchbase.Lite;
using System.Collections.ObjectModel;

namespace Cbl2Db22RepTest.Models
{
	public class FuturAcquereur: BindableObject, ISaveable, ITechnicalKey, IDateable
	{
		private Adresse _adresse;
		private Aquereur _aquereurPrincipal;
		private Aquereur _aquereurSecondaire;
		private ObservableCollection<Financement> _financements;
		private string _sfaCode;
		private string _sfaLibelle;
		private DateTime _dateSituation;
		private string _lieuSituation;
		private string _commentaires;
		private ObservableCollection<Enfant> _enfants;
		private string _id;


		public FuturAcquereur(Aquereur principal, Aquereur secondaire, Adresse adresse)
		{
			AquereurPrincipal = principal;
			AquereurSecondaire = secondaire;
			Financements = new ObservableCollection<Financement>();
			Enfants = new ObservableCollection<Enfant>();
			Adresse = adresse;

			PropertyChanged += FuturAcquereur_PropertyChanged;
		}

		private void FuturAcquereur_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(DateSituation): OnPropertyChanged(nameof(IsDateSituationValid)); break;
				default:
					break;
			}
		}

		[JsonProperty("adresse")]
		public Adresse Adresse { get=>_adresse; set{ _adresse = value; OnPropertyChanged(); } }

		[JsonProperty("aquereurPrincipal")]
		public Aquereur AquereurPrincipal { get => _aquereurPrincipal; set { _aquereurPrincipal = value; OnPropertyChanged(); } }

		[JsonProperty("aquereurSecondaire")]
		public Aquereur AquereurSecondaire { get => _aquereurSecondaire; set { _aquereurSecondaire = value; OnPropertyChanged(); } }

		[JsonProperty("sfaCode")]
		public string SfaCode { get => _sfaCode; set { _sfaCode = value; OnPropertyChanged(); } }

		[JsonProperty("sfaLibelle")]
		public string SfaLibelle { get => _sfaLibelle; set { _sfaLibelle = value; OnPropertyChanged(); } }

		[JsonProperty("dateSituation")]
		public DateTime DateSituation { get => _dateSituation; set { _dateSituation = value; OnPropertyChanged(); } }

		[JsonProperty("lieuSituation")]
		public string LieuSituation { get => _lieuSituation; set { _lieuSituation = value; OnPropertyChanged(); } }

		[JsonProperty("commentaires")]
		public string Commentaires { get => _commentaires; set { _commentaires = value; OnPropertyChanged(); } }

		[JsonProperty("enfants")]
		public ObservableCollection<Enfant> Enfants { get => _enfants; set { _enfants = value; OnPropertyChanged(); } }

		[JsonProperty("financements")]
		public ObservableCollection<Financement> Financements { get => _financements; set { _financements = value; OnPropertyChanged(); } }

		[JsonProperty("table")]
		public string Table { get=>"futuracquereur"; }

		[JsonProperty("id")]
		public string Id { get => _id; set => _id = value; }

		[JsonProperty("dateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("dateModif")]
		public DateTime DateModif { get; set; }

		public bool IsDateSituationValid
		{
			get
			{
				if (DateSituation != DateTime.MinValue)
					return true;
				return false;
			}
		}

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			dico.SetString("id", Id);
			dico.SetDictionary("aquereurPrincipal", AquereurPrincipal.DocumentInitialize());
			dico.SetDictionary("aquereurSecondaire", AquereurSecondaire.DocumentInitialize());
			dico.SetDictionary("adresse", Adresse.DocumentInitialize());
			dico.SetString("sfaCode", SfaCode);
			dico.SetString("sfaLibelle", SfaLibelle);
			if (DateSituation!= DateTime.MinValue)
				dico.SetDate("dateSituation", DateSituation);
			dico.SetString("lieuSituation", LieuSituation);
			dico.SetString("commentaires", Commentaires);

			MutableArrayObject listDictionaryFinancements = new MutableArrayObject();
			foreach (Financement fin in Financements)
				listDictionaryFinancements.AddDictionary(fin.DocumentInitialize());
			dico.SetArray("financements", listDictionaryFinancements);

			MutableArrayObject listDictionaryEnfants = new MutableArrayObject();
			foreach (Enfant enfant in Enfants)
				listDictionaryEnfants.AddDictionary(enfant.DocumentInitialize());
			dico.SetArray("enfants", listDictionaryEnfants);

			if (DateCreation != DateTime.MinValue)
				dico.SetDate("dateCreation", DateCreation);

			if (DateModif != DateTime.MinValue)
				dico.SetDate("dateModif", DateModif);

			return dico;
		}
	}
}
