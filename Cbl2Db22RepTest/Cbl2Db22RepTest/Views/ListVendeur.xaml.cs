using Cbl2Db22RepTest.Configuration;
using Cbl2Db22RepTest.Dal;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using Cbl2Db22RepTest.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cbl2Db22RepTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListVendeur : ContentPage
	{
		private readonly VM_ListVendeur _vM_ListVendeur;
		private readonly IReplicatorGetter _replicatorGetter;
		private readonly IVendeurDal _vendeurDal;
		private readonly IDefaultVendeurDal _defaultVendeurDal;

		public ListVendeur (VM_ListVendeur vM_ListVendeur,
							IReplicatorGetter replicatorGetter,
							IVendeurDal vendeurDal,
							IDefaultVendeurDal defaultVendeurDal)
		{
			InitializeComponent ();
			_vM_ListVendeur = vM_ListVendeur;
			_replicatorGetter = replicatorGetter;
			_vendeurDal = vendeurDal;
			_defaultVendeurDal = defaultVendeurDal;

			BindingContext = _vM_ListVendeur;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			_vM_ListVendeur.Load();
			_replicatorGetter.Get();
		}

		private void ListFuturAcquereur_ItemTapped(object serder, ItemTappedEventArgs e)
		{
			Vendeur vendeur = e.Item as Vendeur;
			DefaultVendeur defaultVendeur = _defaultVendeurDal.Get();
			if (defaultVendeur != null && vendeur.Num != defaultVendeur.Num)
				_defaultVendeurDal.Delete(defaultVendeur);
			defaultVendeur = vendeur.ToDefaultVendeur();
			_defaultVendeurDal.Save(defaultVendeur);

			MessagingCenter.Send(new DefaultVendeurMessage(defaultVendeur), "DEFAULT_VENDEUR");

			Navigation.PopModalAsync();
		}
	}
}