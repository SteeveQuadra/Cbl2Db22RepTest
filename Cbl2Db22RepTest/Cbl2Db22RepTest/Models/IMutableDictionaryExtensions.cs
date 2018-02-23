using Couchbase.Lite;
using Cbl2Db22RepTest.Configuration;
using Cbl2Db22RepTest.Dal;
using System;

namespace Cbl2Db22RepTest.Models
{
	public static class IMutableDictionaryExtensions
    {
		public static Adresse ToAdresse(this Couchbase.Lite.IMutableDictionary dico)
		{
			Adresse adresse = new Adresse();

			if (dico.GetString("intitule1") != null)
				adresse.Intitule1 = dico.GetString("intitule1");

			if (dico.GetString("intitule2") != null)
				adresse.Intitule2 = dico.GetString("intitule2");

			if (dico.GetString("intitule3") != null)
				adresse.Intitule3 = dico.GetString("intitule3");

			if (dico.GetString("libelle1") != null)
				adresse.Libelle1 = dico.GetString("libelle1");

			if (dico.GetString("libelle2") != null)
				adresse.Libelle2 = dico.GetString("libelle2");

			if (dico.GetString("libelle3") != null)
				adresse.Libelle3 = dico.GetString("libelle3");

			if (dico.GetString("pays") != null)
				adresse.Pays = dico.GetString("pays");

			if (dico.GetString("payCode") != null)
				adresse.PayCode = dico.GetString("payCode");
			else
				adresse.PayCode = adresse.Pays;

			if (dico.GetString("codePostal") != null)
				adresse.CodePostal = dico.GetString("codePostal");

			if (dico.GetString("ville") != null)
				adresse.Ville = dico.GetString("ville");

			adresse.ComNum = dico.GetLong("comNum");

			return adresse;
		}

		public static Aquereur ToAcquereur(this Couchbase.Lite.IMutableDictionary dico)
		{
			Aquereur aquereur = new Aquereur();

			if (dico.GetString("dateNaissance") != null)
				aquereur.DateNaissance = dico.GetDate("dateNaissance").DateTime;

			if (dico.GetString("email") != null)
				aquereur.Email = dico.GetString("email");

			if (dico.GetString("lieuNaissance") != null)
				aquereur.LieuNaissance = dico.GetString("lieuNaissance");

			if (dico.GetString("lieuTravail") != null)
				aquereur.LieuTravail = dico.GetString("lieuTravail");

			if (dico.GetString("nationalite") != null)
				aquereur.Nationalite = dico.GetString("nationalite");

			if (dico.GetString("nom") != null)
				aquereur.Nom = dico.GetString("nom");

			if (dico.GetString("portable") != null)
				aquereur.Portable = dico.GetString("portable");

			if (dico.GetString("prenom") != null)
				aquereur.Prenom = dico.GetString("prenom");

			if (dico.GetString("profession") != null)
				aquereur.Profession = dico.GetString("profession");

			aquereur.SalaireNetMensuel = dico.GetDouble("salaireNetMensuel");

			if (dico.GetString("telPro") != null)
				aquereur.TelPro = dico.GetString("telPro");

			if (dico.GetString("titreSejour") != null)
				aquereur.TitreSejour = dico.GetString("titreSejour");

			if (dico.GetString("profession") != null)
				aquereur.Profession = dico.GetString("profession");

			if (dico.GetString("civCode") != null)
				aquereur.CivCode = dico.GetString("civCode");

			if (dico.GetString("civLibelle") != null)
				aquereur.CivLibelle = dico.GetString("civLibelle");

			return aquereur;
		}

		public static Civilite ToCivilite(this Couchbase.Lite.IMutableDictionary dico)
		{
			Civilite civilite = new Civilite()
			{
				CivCode = (dico.GetString("civCode") ?? ""),
				CivLibelle = (dico.GetString("civLibelle") ?? ""),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};

			return civilite;
		}

		public static Commune ToCommune(this Couchbase.Lite.MutableDictionaryObject dico)
		{
			Commune commune = new Commune()
			{
				Num = dico.GetInt("num"),
				Libelle = (dico.GetString("libelle") ?? ""),
				CodePostal = (dico.GetString("codePostal") ?? ""),
				PayCode = (dico.GetString("payCode") ?? ""),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};
			return commune;
		}

		public static Constructeur ToConstructeur(this Couchbase.Lite.IMutableDictionary dico)
		{
			Constructeur constructeur = new Constructeur()
			{
				Num = dico.GetInt("num"),
				Nom = dico.GetString("nom"),
				Telephone = dico.GetString("telephone"),
				Email = dico.GetString("email"),
				Actif = dico.GetInt("actif"),
				Adresse = dico.GetDictionary("adresse").ToAdresse(),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};

			return constructeur;
		}

		public static Enfant ToEnfant(this Couchbase.Lite.IMutableDictionary dico)
		{
			Enfant enfant = new Enfant();

			if (dico.GetString("dateNaissance") != null)
				enfant.DateNaissance = dico.GetDate("dateNaissance").Date;

			return enfant;
		}

		public static Financement ToFinancement(this Couchbase.Lite.IMutableDictionary dico)
		{
			Financement financement = new Financement()
			{
				Information = dico.GetString("information"),
				FinCode = dico.GetString("finCode"),
				FinLibelle = dico.GetString("finLibelle"),
				Valeur = dico.GetString("valeur")
			};

			return financement;
		}

		public static FuturAcquereur ToFuturAcquereur(this Couchbase.Lite.IMutableDictionary dico)
		{
			FuturAcquereur fa = App.Injector.GetInstance<FuturAcquereur>();

			fa.Id = dico.GetString("id");
			if (dico.GetDictionary("aquereurPrincipal") != null)
				fa.AquereurPrincipal = dico.GetDictionary("aquereurPrincipal").ToAcquereur();

			if (dico.GetDictionary("aquereurSecondaire") != null)
				fa.AquereurSecondaire = dico.GetDictionary("aquereurSecondaire").ToAcquereur();

			if (dico.GetDictionary("adresse") != null)
				fa.Adresse = dico.GetDictionary("adresse").ToAdresse();

			fa.SfaCode = (dico.GetString("sfaCode") ?? "");
			fa.SfaLibelle = (dico.GetString("sfaLibelle") ?? "");
			fa.LieuSituation = (dico.GetString("lieuSituation") ?? "");
			fa.Commentaires = (dico.GetString("commentaires") ?? "");

			if (dico.GetString("dateSituation") != null)
				fa.DateSituation = dico.GetDate("dateSituation").DateTime;

			if (dico.GetArray("financements") != null)
			{
				foreach (IMutableDictionary element in dico.GetArray("financements"))
				{
					fa.Financements.Add(element.ToFinancement());
				}
			}

			if (dico.GetArray("enfants") != null)
			{
				foreach (IMutableDictionary element in dico.GetArray("enfants"))
				{
					fa.Enfants.Add(element.ToEnfant());
				}
			}

			if (dico.GetString("dateCreation") != null)
				fa.DateCreation = dico.GetDate("dateCreation").DateTime;
			if (dico.GetString("dateModif") != null)
				fa.DateModif = dico.GetDate("dateModif").DateTime;

			return fa;
		}

		public static Lot ToLot(this Couchbase.Lite.IMutableDictionary dico)
		{
			Lot lot = new Lot()
			{
				Num = dico.GetLong("num"),
				PgrNum = dico.GetLong("pgrNum"),
				Code = dico.GetString("code"),
				Surface = dico.GetDouble("surface"),
				SurfacePlancher = dico.GetDouble("surfacePlancher"),
				Facade = dico.GetString("facade"),
				LetCode = dico.GetString("letCode"),
				Etat = dico.GetString("etat"),
				PrixVenteConseille = dico.GetDouble("prixVenteConseille"),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};

			return lot;
		}

		public static Option ToOption(this IMutableDictionary dico)
		{
			Option option = new Option()
			{
				Id = dico.GetString("id"),
				ProgrammeReserve = dico.GetDictionary("programmeReserve").ToProgramme(),
				LotReserve = dico.GetDictionary("lotReserve").ToLot(),
				TiersVendeur = dico.GetDictionary("tiersVendeur").ToVendeur(),
				NomAcquereur = dico.GetString("nomAcquereur"),
				Commentaire = dico.GetString("commentaire"),
				Actif = dico.Contains("actif") ? dico.GetBoolean("actif") : true,
				TiersConstructeur = dico.Contains("tiersConstructeur") ?  dico.GetDictionary("tiersConstructeur").ToConstructeur() : null
		};

			if (dico.GetString("datePoseOption") != null)
				option.DatePoseOption = dico.GetDate("datePoseOption").DateTime;

			if (dico.GetString("dateCreation") != null)
				option.DateCreation = dico.GetDate("dateCreation").DateTime;
			if (dico.GetString("dateModif") != null)
				option.DateModif = dico.GetDate("dateModif").DateTime;


			return option;
		}

		public static Pays ToPays(this Couchbase.Lite.IMutableDictionary dico)
		{
			Pays pays = new Pays()
			{
				PayCode = (dico.GetString("payCode") ?? ""),
				PayLibelle = (dico.GetString("payLibelle") ?? ""),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};
			return pays;
		}

		public static Programme ToProgramme(this Couchbase.Lite.IMutableDictionary dico)
		{
			Programme programme = new Programme
			{
				Num = dico.GetLong("num"),
				Libelle = dico.GetString("libelle"),
				Localite = dico.GetString("localite"),
				DepCode = dico.GetString("depCode"),
				PetNumero = dico.GetLong("petNumero"),
				Etat = dico.GetString("etat"),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};

			return programme;
		}

		public static Reservation ToReservation(this IMutableDictionary dico)
		{
			Reservation reservation = new Reservation()
			{
				Id = dico.GetString("id"),
				ProgrammeReserve = dico.GetDictionary("programmeReserve").ToProgramme(),
				LotReserve = dico.GetDictionary("lotReserve").ToLot(),
				PrixTerrainTtc = dico.GetDouble("prixTerrainTtc"),
				MontantRemise = dico.GetDouble("montantRemise"),
				MontantAcompte = dico.GetDouble("montantAcompte"),
				LieuSignature = dico.GetString("lieuSignature"),
				TiersVendeur = dico.GetDictionary("tiersVendeur").ToVendeur(),
				FuturAcquereurId = dico.GetString("futurAcquereurId"),
				SignatureEffective = dico.Contains("signatureEffective") ? dico.GetBoolean("signatureEffective") : false
			};

			if (dico.GetDictionary("tiersConstructeur") != null)
				reservation.TiersConstructeur = dico.GetDictionary("tiersConstructeur").ToConstructeur();

			if (dico.GetString("dateSignaturePv") != null)
				reservation.DateSignaturePv = dico.GetDate("dateSignaturePv").DateTime;

			if (dico.GetArray("financements") != null)
			{
				foreach (IMutableDictionary element in dico.GetArray("financements"))
				{
					reservation.Financements.Add(element.ToFinancement());
				}
			}

			if (dico.GetString("dateCreation") != null)
				reservation.DateCreation = dico.GetDate("dateCreation").DateTime;
			if (dico.GetString("dateModif") != null)
				reservation.DateModif = dico.GetDate("dateModif").DateTime;
			if (dico.GetString("lastDateEdition") != null)
				reservation.LastDateEdition = dico.GetDate("lastDateEdition").DateTime;

			IFuturAcquereurDal futurAcquereurDal = App.Injector.GetInstance<IFuturAcquereurDal>();
			reservation.FuturAcquereur = futurAcquereurDal.Get(reservation.FuturAcquereurId);

			return reservation;
		}

		public static SituationFamille ToSituationFamille(this Couchbase.Lite.IMutableDictionary dico)
		{
			SituationFamille situationFamille = new SituationFamille()
			{
				SfaCode = (dico.GetString("sfaCode") ?? ""),
				SfaLibelle = (dico.GetString("sfaLibelle") ?? ""),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};
			return situationFamille;
		}

		public static TypeFinancement ToTypeFinancement(this Couchbase.Lite.IMutableDictionary dico)
		{
			TypeFinancement typeFinancement = new TypeFinancement()
			{
				FinCode = (dico.GetString("finCode") ?? ""),
				FinLibelle = (dico.GetString("finLibelle") ?? ""),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};
			return typeFinancement;
		}

		public static Vendeur ToVendeur(this Couchbase.Lite.IMutableDictionary dico)
		{
			Vendeur vendeur = new Vendeur
			{
				Nom = dico.GetString("nom"),
				Email = dico.GetString("email"),
				Telephone = dico.GetString("telephone"),
				Num = dico.GetInt("num"),
				Actif = dico.GetInt("actif"),
				DateCreation = Convert.ToDateTime(dico.GetString("dateCreation")),
				DateModif = Convert.ToDateTime(dico.GetString("dateModif"))
			};

			return vendeur;
		}

		public static DefaultVendeur ToDefaultVendeur(this Couchbase.Lite.IMutableDictionary dico)
		{
			DefaultVendeur defaultVendeur = new DefaultVendeur()
			{
				Nom = dico.GetString("nom"),
				Email = dico.GetString("email"),
				Telephone = dico.GetString("telephone"),
				Num = dico.GetInt("num"),
				Id = dico.GetString("id")
			};

			return defaultVendeur;
		}
	}
}
