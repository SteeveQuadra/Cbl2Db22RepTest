using Couchbase.Lite;
using Cbl2Db22RepTest.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Models
{
	public class Reservation : BindableObject, ISaveable, ITechnicalKey, IDateable
	{
		Programme _programmeReserve;
		Lot _lotReserve;
		double _prixTerrainTtc;
		double _montantRemise;
		double _montantAcompte;
		DateTime _dateSignaturePv;
		string _lieuSignature;
		Vendeur _tiersVendeur;
		string _futurAcquereurId;
		ObservableCollection<Financement> _financements;
		string _id;
		FuturAcquereur _futurAcquereur;
		Constructeur _constructeur;
		DateTime _lastDateEdition;
		bool _signatureEffective;

		public Reservation()
		{
			PropertyChanged += Reservation_PropertyChanged;
			Financements = new ObservableCollection<Financement>();
		}

		private void Reservation_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(DateSignaturePv): OnPropertyChanged(nameof(IsDateSignaturePvValid)); break;
				default:
					break;
			}
		}

		[JsonProperty("table")]
		public string Table { get => "reservation"; }

		[JsonProperty("programmeReserve")]
		public Programme ProgrammeReserve { get => _programmeReserve; set { _programmeReserve = value; OnPropertyChanged(); } }

		[JsonProperty("lotReserve")]
		public Lot LotReserve { get => _lotReserve; set { _lotReserve = value; OnPropertyChanged(); } }

		[JsonProperty("prixTerrainTtc")]
		public double PrixTerrainTtc { get => _prixTerrainTtc; set { _prixTerrainTtc = value; OnPropertyChanged(); } }

		[JsonProperty("montantRemise")]
		public double MontantRemise { get => _montantRemise; set { _montantRemise = value; OnPropertyChanged(); } }

		[JsonProperty("montantAcompte")]
		public double MontantAcompte { get => _montantAcompte; set { _montantAcompte = value; OnPropertyChanged(); } }

		[JsonProperty("dateSignaturePV")]
		public DateTime DateSignaturePv { get => _dateSignaturePv; set { _dateSignaturePv = value; OnPropertyChanged(); } }

		[JsonProperty("lieuSignature")]
		public string LieuSignature { get => _lieuSignature; set { _lieuSignature = value; OnPropertyChanged(); } }

		[JsonProperty("tiersConstructeur")]
		public Constructeur TiersConstructeur { get => _constructeur; set { _constructeur = value; OnPropertyChanged(); }  }

		[JsonProperty("tiersVendeur")]
		public Vendeur TiersVendeur { get => _tiersVendeur; set { _tiersVendeur = value; OnPropertyChanged(); } }

		[JsonProperty("futurAcquereurId")]
		public string FuturAcquereurId { get => _futurAcquereurId; set { _futurAcquereurId = value; OnPropertyChanged(); } }

		[JsonProperty("financements")]
		public ObservableCollection<Financement> Financements { get => _financements; set { _financements = value; OnPropertyChanged(); } }

		[JsonProperty("lastDateEdition")]
		public DateTime LastDateEdition { get => _lastDateEdition; set { _lastDateEdition = value; OnPropertyChanged(); } }

		[JsonProperty("id")]
		public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }

		[JsonProperty("dateCreation")]
		public DateTime DateCreation { get; set; }

		[JsonProperty("dateModif")]
		public DateTime DateModif { get; set; }

		[JsonProperty("signatureEffective")]
		public bool SignatureEffective { get => _signatureEffective; set { _signatureEffective = value; OnPropertyChanged(); } }

		[JsonIgnore]
		public FuturAcquereur FuturAcquereur { get=> _futurAcquereur; set { _futurAcquereur = value; OnPropertyChanged(); } }

		public bool IsDateSignaturePvValid
		{
			get
			{
				if (DateSignaturePv != DateTime.MinValue)
					return true;
				return false;
			}
		}

		

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			dico.SetString("id", Id);
			dico.SetDictionary("programmeReserve", ProgrammeReserve.DocumentInitialize());
			dico.SetDictionary("lotReserve", LotReserve.DocumentInitialize());
			dico.SetDouble("prixTerrainTtc", PrixTerrainTtc);
			dico.SetDouble("montantRemise", MontantRemise);
			dico.SetDouble("montantAcompte", MontantAcompte);
			if (DateSignaturePv != DateTime.MinValue)
				dico.SetDate("dateSignaturePv", DateSignaturePv);
			dico.SetString("lieuSignature", LieuSignature);
			if (TiersConstructeur != null)
				dico.SetDictionary("tiersConstructeur", TiersConstructeur.DocumentInitialize());
			dico.SetDictionary("tiersVendeur", TiersVendeur.DocumentInitialize());
			dico.SetString("futurAcquereurId", FuturAcquereurId);

			MutableArrayObject listDictionaryFinancements = new MutableArrayObject();
			foreach (Financement fin in Financements)
				listDictionaryFinancements.AddDictionary(fin.DocumentInitialize());
			dico.SetArray("financements", listDictionaryFinancements);

			if (DateCreation != DateTime.MinValue)
				dico.SetDate("dateCreation", DateCreation);

			if (DateModif != DateTime.MinValue)
				dico.SetDate("dateModif", DateModif);

			if (LastDateEdition != DateTime.MinValue)
				dico.SetDate("lastDateEdition", LastDateEdition);
			dico.SetBoolean("signatureEffective", SignatureEffective);
			return dico;
		}

		public string DonneValeurChampFusion(string colonne)
		{
			string INDISPONIBLE = "Indisponible";
			switch (colonne)
			{
				case "NOM": return $"{FuturAcquereur?.AquereurPrincipal.Nom} / {FuturAcquereur?.AquereurSecondaire.Nom}";
				case "INTITULE_1": return FuturAcquereur?.Adresse.Intitule1;
				case "INTITULE_2": return FuturAcquereur?.Adresse.Intitule2;
				case "INTITULE_3": return FuturAcquereur?.Adresse.Intitule3;
				case "ADRESSE_1": return FuturAcquereur?.Adresse.Libelle1;
				case "ADRESSE_2": return FuturAcquereur?.Adresse.Libelle2;
				case "ADRESSE_3": return FuturAcquereur?.Adresse.Libelle3;
				case "DEPARTEMENT": return FuturAcquereur?.Adresse.CodePostal?.Substring(0,2);
				case "CODE_POSTALE": return FuturAcquereur?.Adresse.CodePostal;
				case "LOCALITE": return FuturAcquereur?.Adresse.Ville;
				case "POLITESSE": return INDISPONIBLE;
				case "POLITESSE_2": return INDISPONIBLE;
				case "TITRE": return INDISPONIBLE;
				case "PREFIXE": return INDISPONIBLE;
				case "DESCRIPTION": return INDISPONIBLE;
				case "ACQ_PRIN_CIVILITE": return FuturAcquereur?.AquereurPrincipal.CivLibelle;
				case "ACQ_PRIN_NOM": return FuturAcquereur?.AquereurPrincipal.Nom;
				case "ACQ_PRIN_PRENOM": return FuturAcquereur?.AquereurPrincipal.Prenom;
				case "ACQ_PRIN_TEL_FIXE": return INDISPONIBLE;
				case "ACQ_PRIN_PORTABLE": return FuturAcquereur?.AquereurPrincipal.Portable;
				case "ACQ_PRIN_EMAIL": return FuturAcquereur?.AquereurPrincipal.Email;
				case "ACQ_PRIN_DATE_NAISSANCE": return FuturAcquereur?.AquereurPrincipal.DateNaissance == DateTime.MinValue ? string.Empty : FuturAcquereur?.AquereurPrincipal.DateNaissance.ToShortDateString();
				case "ACQ_PRIN_LIEU_NAISSANCE": return FuturAcquereur?.AquereurPrincipal.LieuNaissance;
				case "ACQ_PRIN_NATIONALITE": return INDISPONIBLE;
				case "ACQ_SEC_CIVILITE": return FuturAcquereur?.AquereurSecondaire?.CivLibelle;
				case "ACQ_SEC_NOM": return FuturAcquereur?.AquereurSecondaire?.Nom;
				case "ACQ_SEC_PRENOM": return FuturAcquereur?.AquereurSecondaire?.Prenom;
				case "ACQ_SEC_TEL_FIXE": return INDISPONIBLE;
				case "ACQ_SEC_PORTABLE": return FuturAcquereur?.AquereurSecondaire?.Portable;
				case "ACQ_SEC_EMAIL": return FuturAcquereur?.AquereurSecondaire?.Email;
				case "ACQ_SEC_DATE_NAISSANCE": return FuturAcquereur?.AquereurSecondaire?.DateNaissance == DateTime.MinValue ? string.Empty : FuturAcquereur?.AquereurSecondaire?.DateNaissance.ToShortDateString();
				case "ACQ_SEC_LIEU_NAISSANCE": return FuturAcquereur?.AquereurSecondaire?.LieuNaissance;
				case "ACQ_SEC_NATIONALITE": return INDISPONIBLE;
				case "MNT_VENTE_HT": return INDISPONIBLE;
				case "MNT_VENTE_TVA": return INDISPONIBLE;
				case "MNT_VENTE_TTC": return PrixTerrainTtc.ToString("c");
				case "MNT_VENTE_TAUX TVA": return INDISPONIBLE;
				case "MONTANT ACOMPTE": return MontantAcompte.ToString("c");
				case "DATE_ACOMPTE": return INDISPONIBLE;
				case "DATE_OFFRE": return DateSignaturePv == DateTime.MinValue ? string.Empty : DateSignaturePv.ToShortDateString();
				case "DATE_EDITION": return DateTime.Today.ToShortDateString();
				case "LIBELLE_PROGRAMME": return ProgrammeReserve.Libelle;
				case "VILLE_PROGRAMME": return ProgrammeReserve.Localite;
				case "DEPARTEMENT_PROGRAMME": return ProgrammeReserve.DepCode;
				case "NUMERO_LOT": return LotReserve.Code;
				case "NATURE_LOT": return INDISPONIBLE;
				case "DATE_FIN_CS":	return INDISPONIBLE;
				case "DATE_FIN_PV_": return INDISPONIBLE;
				case "MONTANT_HONO_TTC": return INDISPONIBLE;
				case "VENDEUR": return TiersVendeur.Nom;
				case "DATE_SITUATION": return FuturAcquereur?.DateSituation == DateTime.MinValue ? string.Empty : FuturAcquereur?.DateSituation.ToShortDateString();
				case "LIEU_SITUATION": return FuturAcquereur?.LieuSituation;
				case "SITUATION": return FuturAcquereur?.SfaLibelle;
				case "NB_ENFANTS":return FuturAcquereur?.Enfants == null ? string.Empty : FuturAcquereur?.Enfants.Count.ToString();
				case "REGIME": return INDISPONIBLE;
				default: return string.Empty;
			}
		}

		public string DonneValeurChampFusionGenerique(string colonne)
		{
			return string.Empty;
		}

		public IList<string> DonneValeurChampFusionTableGenerique(string colonne)
		{
			return null;
		}
	}
}
