using Couchbase.Lite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Models
{
	public class Aquereur : BindableObject, ISaveable
	{
		private DateTime _dateNaissance;
		private string _email;
		private string _lieuNaissance;
		private string _lieuTravail;
		private string _nationalite;
		private string _nom;
		private string _portable;
		private string _prenom;
		private string _profession;
		private double? _salaireNetMensuel;
		private string _telPro;
		private string _titreSejour;
		private string _civCode = "M.";
		private string _civLibelle = "M.";

		public Aquereur()
		{
			PropertyChanged += Aquereur_PropertyChanged;
		}

		private void Aquereur_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(Email): OnPropertyChanged(nameof(IsEmailValid)); break;
				case nameof(DateNaissance):OnPropertyChanged(nameof(IsDateNaissanceValid)); break;
				default:
					break;
			}
		}

		public MutableDictionaryObject DocumentInitialize()
		{
			MutableDictionaryObject dico = new MutableDictionaryObject();

			dico.SetString("table", Table);
			if (DateNaissance != DateTime.MinValue)
				dico.SetDate("dateNaissance", DateNaissance);
			dico.SetString("email", Email);
			dico.SetString("lieuNaissance", LieuNaissance);
			dico.SetString("lieuTravail", LieuTravail);
			dico.SetString("nationalite", Nationalite);
			dico.SetString("nom", Nom);
			dico.SetString("portable", Portable);
			dico.SetString("prenom", Prenom);
			dico.SetString("profession", Profession);
			dico.SetDouble("salaireNetMensuel", SalaireNetMensuel??0);
			dico.SetString("telPro", TelPro);
			dico.SetString("titreSejour", TitreSejour);
			dico.SetString("profession", Profession);
			dico.SetString("civCode", CivCode);
			dico.SetString("civLibelle", CivLibelle);

			return dico;
		}

		[JsonProperty("dateNaissance")]
		public DateTime DateNaissance { get => _dateNaissance; set { _dateNaissance = value; OnPropertyChanged(); } }

		[JsonProperty("email")]
		public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

		[JsonProperty("lieuNaissance")]
		public string LieuNaissance { get => _lieuNaissance; set { _lieuNaissance = value; OnPropertyChanged(); } }

		[JsonProperty("lieuTravail")]
		public string LieuTravail { get => _lieuTravail; set { _lieuTravail = value; OnPropertyChanged(); } }

		[JsonProperty("nationalite")]
		public string Nationalite { get => _nationalite; set { _nationalite = value; OnPropertyChanged(); } }

		[JsonProperty("nom")]
		public string Nom { get => _nom; set { _nom = value; OnPropertyChanged(); } }

		[JsonProperty("portable")]
		public string Portable { get => _portable; set { _portable = value; OnPropertyChanged(); } }

		[JsonProperty("prenom")]
		public string Prenom { get => _prenom; set { _prenom = value; OnPropertyChanged(); } }

		[JsonProperty("profession")]
		public string Profession { get => _profession; set { _profession = value; OnPropertyChanged(); } }

		[JsonProperty("salaireNetMensuel")]
		public double? SalaireNetMensuel { get => _salaireNetMensuel; set { _salaireNetMensuel = value; OnPropertyChanged(); } }

		[JsonProperty("table")]
		public string Table { get => "aquereur"; }

		[JsonProperty("telPro")]
		public string TelPro { get => _telPro; set { _telPro = value; OnPropertyChanged(); } }

		[JsonProperty("titreSejour")]
		public string TitreSejour { get => _titreSejour; set { _titreSejour = value; OnPropertyChanged(); } }

		public bool IsEmailValid { get => Email != null && Email.IndexOf("@") != -1; }

		public bool IsDateNaissanceValid
		{
			get
			{
				if (DateNaissance != DateTime.MinValue)
					return true;
				return false;
			}
		}
		[JsonProperty("civCode")]
		public string CivCode { get => _civCode; set { _civCode = value; OnPropertyChanged(); } }
		
		[JsonProperty("civLibelle")]
		public string CivLibelle { get => _civLibelle; set { _civLibelle = value; OnPropertyChanged(); } }
	}
}
