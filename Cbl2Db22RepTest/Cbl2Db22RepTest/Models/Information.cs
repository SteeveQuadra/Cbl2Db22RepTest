using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Models
{
    public class Information : BindableObject
    {
		private string _info;
		private int _quantite;
		private string _remarque;

		public string Info { get => _info; set { _info = value; OnPropertyChanged(); } }

		public int Quantite { get => _quantite; set { _quantite = value; OnPropertyChanged(); } }

		public string Remarque { get => _remarque; set { _remarque = value; OnPropertyChanged(); }}
	}
}
