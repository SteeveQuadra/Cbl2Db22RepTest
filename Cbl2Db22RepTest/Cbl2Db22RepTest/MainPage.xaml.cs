using Cbl2Db22RepTest.Configuration;
using Cbl2Db22RepTest.Services;
using Cbl2Db22RepTest.ViewModels;
using Cbl2Db22RepTest.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cbl2Db22RepTest
{
	public partial class MainPage : ContentPage
	{
		private readonly IReplicatorGetter _replicationGetter;
		private readonly IDefaultVendeurGetter _defaultVendeurGetter;
		private readonly VM_MainPage _vM_MainPage;

		public MainPage(VM_MainPage vM_MainPage,
						IReplicatorGetter replicationGetter,
						IDefaultVendeurGetter defaultVendeurGetter)
		{
			_replicationGetter = replicationGetter;
			_defaultVendeurGetter = defaultVendeurGetter;
			_vM_MainPage = vM_MainPage;
			InitializeComponent();

			BindingContext = _vM_MainPage;
		}

		private async void BtnAddOption_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(App.Injector.GetInstance<ServerConnection>());
		}

		private void BtnOptions_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(App.Injector.GetInstance<ListInformations>());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_replicationGetter.Get();
		}
	}
}
