using Cbl2Db22RepTest.Configuration;
using Cbl2Db22RepTest.Services;
using Couchbase.Lite.Sync;
using Plugin.Connectivity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cbl2Db22RepTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeaderStackLayout : StackLayout
	{
		public static readonly BindableProperty HeaderTextProperty =
			BindableProperty.Create("HeaderText", typeof(string), typeof(HeaderStackLayout), null, propertyChanged: HeaderTextChanged);

		private static void HeaderTextChanged(BindableObject bindable, object oldValue, object newValue)
		{
		}

		public string HeaderText { get => (string)GetValue(HeaderTextProperty); set => SetValue(HeaderTextProperty, value); }

		public static readonly BindableProperty BackButtonVisibilityProperty =
			BindableProperty.Create("BackButtonVisibility", typeof(bool), typeof(HeaderStackLayout), false, propertyChanged: BackButtonVisibilityChanged);

		private static void BackButtonVisibilityChanged(BindableObject bindable, object oldValue, object newValue)
		{
		}

		public bool BackButtonVisibility { get => (bool)GetValue(BackButtonVisibilityProperty); set => SetValue(BackButtonVisibilityProperty, value); }

		private string _imageStatusReplication = "antenna_red.png";
		private string _imageConnection;

		public string ImageStatusReplication { get => _imageStatusReplication; set { _imageStatusReplication = value; OnPropertyChanged(); } }

		public string Avancement { get => _avancement; set { _avancement = value; OnPropertyChanged(); } }

		public string ImageConnection { get => _imageConnection; set { _imageConnection = value; OnPropertyChanged(); } }

		public string VendeurActif { get => _vendeurActif; set { _vendeurActif = value; OnPropertyChanged(); } }

		public string ImageLogin { get => _imageLogin; set { _imageLogin = value; OnPropertyChanged(); } }

		private string _avancement;

		private string _vendeurActif;

		private string _imageLogin;
		private readonly IDefaultVendeurGetter _defaultVendeurGetter;

		public HeaderStackLayout ()
		{
			ImageStatusReplication = "antenna_red.png";
			InitializeComponent ();
			MessagingCenter.Subscribe<ReplicatorStatusMessage>(this, "REPLICATOR_STATUS", OnStatusChanged);
			MessagingCenter.Subscribe<ConnectivityMessage>(this, "CONNECTIVITY_STATUS", OnConnectivityChanged);
			MessagingCenter.Subscribe<DefaultVendeurMessage>(this, "DEFAULT_VENDEUR", OnDefaultVendeurChanged);
			
			if (CrossConnectivity.IsSupported && CrossConnectivity.Current.IsConnected)
				ImageConnection = "wifi_on.png";
			else
				ImageConnection = "wifi_off.png";
			VendeurActif = string.Empty;
			_defaultVendeurGetter = App.Injector.GetInstance<DefaultVendeurGetter>();
			if (_defaultVendeurGetter.IsLogged())
				VendeurActif = _defaultVendeurGetter.Get().Nom;
			ManageImageLogin();
		}

		private void OnDefaultVendeurChanged(DefaultVendeurMessage obj)
		{
			VendeurActif = obj.Vendeur == null ? string.Empty : obj.Vendeur.Nom;
			ManageImageLogin();
		}

		private void ManageImageLogin()
		{
			if (_defaultVendeurGetter.IsLogged())
				ImageLogin = "deconnexion.png";
			else
				ImageLogin = "perm_identity_white.png";
		}

		private void OnConnectivityChanged(ConnectivityMessage message)
		{
			if (message.IsConnected)
				ImageConnection = "wifi_on.png";
			else
				ImageConnection = "wifi_off.png";
		}

		private void OnStatusChanged(ReplicatorStatusMessage message)
		{
			Avancement = $"{message.Status.Progress.Completed} / {message.Status.Progress.Total} / {message.LastError}";
			switch (message.Status.Activity)
			{
				case ReplicatorActivityLevel.Offline:
					ImageStatusReplication = "antenna_gray.png";
					break;
				case ReplicatorActivityLevel.Connecting:
					ImageStatusReplication = "import_export.png";
					break;
				case ReplicatorActivityLevel.Busy:
					ImageStatusReplication = "cached.png";
					break;
				case ReplicatorActivityLevel.Idle:
					ImageStatusReplication = "antenna_green.png";
					break;
				case ReplicatorActivityLevel.Stopped:
					ImageStatusReplication = "antenna_red.png";
					break;
			}
		}

		private void BtnBack_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}

		private void BtnReplicator_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(App.Injector.GetInstance<ServerConnection>());
		}

		private void BtnLogin_Clicked(object sender, EventArgs e)
		{
			if (_defaultVendeurGetter.IsLogged())
			{
				_defaultVendeurGetter.Remove();
				VendeurActif = string.Empty;
			}
			else
				Navigation.PushModalAsync(App.Injector.GetInstance<ListVendeur>());
			ManageImageLogin();
		}

		private void BtnInfo_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(App.Injector.GetInstance<ListInformations>());
		}
	}	
}