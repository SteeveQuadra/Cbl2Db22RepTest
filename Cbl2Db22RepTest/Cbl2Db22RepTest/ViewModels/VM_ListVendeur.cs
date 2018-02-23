using Cbl2Db22RepTest.Dal;
using Cbl2Db22RepTest.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.ViewModels
{
	public class VM_ListVendeur : BindableObject
	{
		private ObservableCollection<Vendeur> _vendeurs;
		private readonly IVendeurDal _vendeurDal;

		public ObservableCollection<Vendeur> Vendeurs { get => _vendeurs; set { _vendeurs = value; OnPropertyChanged(); } }

		public VM_ListVendeur(IVendeurDal vendeurDal)
		{
			_vendeurDal = vendeurDal;
			Vendeurs = new ObservableCollection<Vendeur>();
		}

		internal void Load()
		{
			Vendeurs.Clear();
			_vendeurDal.Gets().ForEach(Vendeurs.Add);
		}
	}
}
