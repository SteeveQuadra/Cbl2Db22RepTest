using Couchbase.Lite.Sync;
using Cbl2Db22RepTest.Configuration;
using Cbl2Db22RepTest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace Cbl2Db22RepTest.ViewModels
{
    public class VM_ServerConnection : BindableObject, IDisposable
	{
		private readonly IServerDal _serverDal;
		private readonly IReplicatorGetter _replicatorGetter;
		private readonly IReplicatorStatus _replicatorStatus;
		private readonly ISynchroExDal _synchroExDal;

		private Server _serverInfo;
		public Command ConnectCommand { get; set; }
		public Command RestartCommand { get; set; }
		public Command LoadExCommand { get; set; }

		public INavigation Navigation { get; set; }

		private ObservableCollection<SynchroEx> _synchroExs;

		public ObservableCollection<SynchroEx> SynchroExs
		{
			get => _synchroExs;
			set
			{
				_synchroExs = value;
				OnPropertyChanged();
			}
		}

		public VM_ServerConnection(	IServerDal serverDal,
									IReplicatorGetter replicatorGetter,
									IReplicatorStatus replicatorStatus,
									ISynchroExDal synchroExDal)
		{
			_serverDal = serverDal;
			_replicatorGetter = replicatorGetter;
			_replicatorStatus = replicatorStatus;
			_synchroExDal = synchroExDal;

			ServerInfo = _serverDal.Get();
			if (ServerInfo == null)
				ServerInfo = App.Injector.GetInstance<Server>();

			ConnectCommand = new Command(ConnectManager, IsAbleToConnect);
			RestartCommand = new Command(RestartManager, IsAbleToRestart);
			LoadExCommand = new Command(LoadExManager);

			_serverInfo.PropertyChanged += _serverInfo_PropertyChanged;
			SynchroExs = new ObservableCollection<SynchroEx>();
			LoadSynchroEx();

		}

		private void LoadExManager(object obj)
		{
			LoadSynchroEx();
		}

		private void LoadSynchroEx()
		{
			SynchroExs.Clear();
			List<SynchroEx> synchroExs = _synchroExDal.Gets();
			if (synchroExs.Count > 0)
				synchroExs.ForEach(SynchroExs.Add);
		}

		private bool IsAbleToRestart(object arg)
		{
			return _replicatorStatus.Activity == ReplicatorActivityLevel.Busy || _replicatorStatus.Activity == ReplicatorActivityLevel.Stopped || _replicatorStatus.Activity == ReplicatorActivityLevel.Idle;
		}

		private void RestartManager(object obj)
		{
			MessagingCenter.Send(new ReplicatorStatusMessage(_replicatorStatus.Status, string.Empty), "REPLICATOR_RESTART");
		}

		private void _serverInfo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			ConnectCommand.ChangeCanExecute();
		}

		private bool IsAbleToConnect(object arg)
		{
			return !(string.IsNullOrEmpty(ServerInfo.Login) ||
				string.IsNullOrEmpty(ServerInfo.Password) ||
				string.IsNullOrEmpty(ServerInfo.UrlServer));
		}

		private void ConnectManager(object obj)
		{
			_serverDal.Save(_serverInfo);
			_replicatorGetter.Get();
			Navigation.PopModalAsync();
		}

		public Server ServerInfo { get => _serverInfo; set { _serverInfo = value; OnPropertyChanged(); } }

		public void Dispose()
		{
			
		}
	}
}
