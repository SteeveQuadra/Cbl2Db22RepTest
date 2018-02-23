using Cbl2Db22RepTest.Services;
using Cbl2Db22RepTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cbl2Db22RepTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ServerConnection : ContentPage
	{
		private readonly VM_ServerConnection _vM_ServerConnection;
		private readonly IReplicatorGetter _replicatorGetter;

		public ServerConnection (VM_ServerConnection vM_ServerConnection,
			IReplicatorGetter replicatorGetter)
		{
			InitializeComponent ();
			_replicatorGetter = replicatorGetter;
			_vM_ServerConnection = vM_ServerConnection;
			_vM_ServerConnection.Navigation = Navigation;

			BindingContext = _vM_ServerConnection;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			_replicatorGetter.Get();
		}
	}
}