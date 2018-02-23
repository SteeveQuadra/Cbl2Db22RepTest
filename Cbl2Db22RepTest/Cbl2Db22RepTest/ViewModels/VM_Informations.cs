using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.ViewModels
{
	public class VM_Informations : BindableObject
	{
		private ObservableCollection<Information> _informations;

		public ObservableCollection<Information> Informations { get => _informations; set { _informations = value; OnPropertyChanged(); } }
		public Command RefreshCommand { get; set; }

		private readonly IDataBaseLoader _dataBaseLoader;

		public VM_Informations(IDataBaseLoader dataBaseLoader)
		{
			_dataBaseLoader = dataBaseLoader;
			Informations = new ObservableCollection<Information>();
			RefreshCommand = new Command(RefreshManager);
		}

		internal void Load()
		{
			Informations.Clear();
			_dataBaseLoader.Gets().ForEach(Informations.Add);			
		}

		private void RefreshManager(object obj)
		{
			Load();
		}
	}
}
