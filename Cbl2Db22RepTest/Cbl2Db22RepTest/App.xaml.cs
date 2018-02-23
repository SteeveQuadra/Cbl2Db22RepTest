using Cbl2Db22RepTest.Configuration;
using Cbl2Db22RepTest.Services;
using Plugin.Connectivity;
using SimpleInjector;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace Cbl2Db22RepTest
{
	public partial class App : Application
	{
		private readonly Startup _startup = null;
		private static readonly SimpleInjector.Container _container = new SimpleInjector.Container();

		public static Container Injector => _container;

		public App ()
		{
			InitializeComponent();

			var userSelectedCulture = new CultureInfo("fr-FR");

			Thread.CurrentThread.CurrentCulture = userSelectedCulture;

			if (_startup == null)
			{
				_startup = new Startup();
				_startup.ConfigureServices(_container);
			}

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			MainPage = _container.GetInstance<Cbl2Db22RepTest.MainPage>();
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			
		}

		protected override void OnStart()
		{
			if (CrossConnectivity.IsSupported)
				CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
		}

		private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
		{
			MessagingCenter.Send(new ConnectivityMessage(e.IsConnected), "CONNECTIVITY_STATUS");
		}

		protected override void OnSleep()
		{
			if (CrossConnectivity.IsSupported)
				CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
		}

		protected override void OnResume()
		{
			if (CrossConnectivity.IsSupported)
				CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
		}
	}
}
