using Couchbase.Lite;
using Couchbase.Lite.Sync;
using Cbl2Db22RepTest.Configuration;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Services
{
	public interface IReplicatorGetter
	{
		Replicator Get();
	}

	public class ReplicatorGetter : IReplicatorGetter
	{
		private readonly IDataBaseGetter _dataBaseGetter;
		private readonly IServerDal _serverDal;
		private readonly ISynchroExDal _synchroExDal;
		private Replicator _replicator = null;
		private ListenerToken _token;
		private Server _serverInfo = null;

		public ReplicatorGetter(IDataBaseGetter dataBaseGetter,
								IServerDal serverDal,
								ISynchroExDal synchroExDal)
		{
			_dataBaseGetter = dataBaseGetter;
			_synchroExDal = synchroExDal;
			_serverDal = serverDal;
			MessagingCenter.Subscribe<ConnectivityMessage>(this, "CONNECTIVITY_STATUS", OnConnectivityChanged);
			MessagingCenter.Subscribe<ReplicatorStatusMessage>(this, "REPLICATOR_RESTART", Restart);
			_serverInfo = _serverDal.Get();
		}

		private void Restart(ReplicatorStatusMessage obj)
		{
			try
			{
				_replicator.RemoveChangeListener(_token);
				_replicator.Stop();
				_replicator.Dispose();
				_replicator = null;

				Connect();
			}
			catch(Exception e)
			{
#if DEBUG
				
#endif
			}

			

		}

		private void OnConnectivityChanged(ConnectivityMessage message)
		{
			if (_replicator != null)
			{
				MessagingCenter.Send(new ReplicatorStatusMessage(_replicator.Status, _replicator.Status.Error?.Message), "REPLICATOR_STATUS");
				return;
			}

			Connect();

			MessagingCenter.Send(new ReplicatorStatusMessage(_replicator.Status, _replicator.Status.Error?.Message), "REPLICATOR_STATUS");
		}

		public Replicator Get()
		{
			try
			{
				if (_replicator != null)
				{
					MessagingCenter.Send(new ReplicatorStatusMessage(_replicator.Status, _replicator.Status.Error?.Message), "REPLICATOR_STATUS");
					return _replicator;
				}

				Connect();

				return _replicator;
			}
			catch (Exception e) 
			{
#if DEBUG
				
#endif

				return null;
			}
		}

		private void Connect()
		{
			try
			{
			if (_serverInfo == null)
				_serverInfo = _serverDal.Get();
			if (_serverInfo == null)
				return;
			Uri target = new Uri($"ws://{_serverInfo.UrlServer}");
			IEndpoint endpoint = new URLEndpoint(target);
			ReplicatorConfiguration replicationConfig = new ReplicatorConfiguration(_dataBaseGetter.Get(), endpoint)
			{
				Continuous = true,
				ReplicatorType = ReplicatorType.PushAndPull,
				Authenticator = new BasicAuthenticator(_serverInfo.Login, _serverInfo.Password)
			};
			_replicator = new Replicator(replicationConfig);
			if (CrossConnectivity.IsSupported && CrossConnectivity.Current.IsConnected)
				_replicator.Start();
			_token = _replicator.AddChangeListener(_replicator_StatusChanged);
			}
			catch (Exception e)
			{
#if DEBUG
				
#endif
			}
		}

		private void _replicator_StatusChanged(object sender, ReplicatorStatusChangedEventArgs e)
		{
			MessagingCenter.Send(new ReplicatorStatusMessage(e.Status, _replicator.Status.Error?.Message), "REPLICATOR_STATUS");
			if (_replicator.Status.Error != null)
			{
#if DEBUG
				
#endif
				MessagingCenter.Send(new ReplicatorStatusMessage(e.Status, _replicator.Status.Error?.Message), "REPLICATOR_RESTART");
			}
		}
	}
}
