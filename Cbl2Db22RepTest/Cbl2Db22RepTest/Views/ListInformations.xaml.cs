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
	public partial class ListInformations : ContentPage
	{
		private readonly IReplicatorGetter _replicatorGetter;
		private readonly VM_Informations _vM_Informations;

		public ListInformations (IReplicatorGetter replicatorGetter,
			VM_Informations vM_Informations)
		{
			_replicatorGetter = replicatorGetter;
			_vM_Informations = vM_Informations;
			InitializeComponent ();

			BindingContext = _vM_Informations;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			_vM_Informations.Load();
			_replicatorGetter.Get();
		}
	}
}