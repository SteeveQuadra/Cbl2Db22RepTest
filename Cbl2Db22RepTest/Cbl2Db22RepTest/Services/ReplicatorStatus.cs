using Couchbase.Lite.Sync;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cbl2Db22RepTest.Services
{
	public interface IReplicatorStatus
	{
		string Image { get; }
		ReplicatorActivityLevel Activity { get; }
		Couchbase.Lite.Sync.ReplicatorStatus Status { get; }
	}

	public class ReplicatorStatus : IReplicatorStatus
	{
		private string _imageStatusReplication;
		private Couchbase.Lite.Sync.ReplicatorStatus _status;

		public ReplicatorStatus()
		{
			MessagingCenter.Subscribe<ReplicatorStatusMessage>(this, "REPLICATOR_STATUS", OnStatusChanged);
		}

		public string Image => _imageStatusReplication;

		public ReplicatorActivityLevel Activity => _status.Activity;

		public Couchbase.Lite.Sync.ReplicatorStatus Status => _status;

		private void OnStatusChanged(ReplicatorStatusMessage message)
		{
			_status = message.Status;
			switch (message.Status.Activity)
			{
				case ReplicatorActivityLevel.Offline:
					_imageStatusReplication = "antenna_gray.png";
					break;
				case ReplicatorActivityLevel.Connecting:
					_imageStatusReplication = "import_export.png";
					break;
				case ReplicatorActivityLevel.Busy:
					_imageStatusReplication = "cached.png";
					break;
				case ReplicatorActivityLevel.Idle:
					_imageStatusReplication = "antenna_green.png";
					break;
				case ReplicatorActivityLevel.Stopped:
					_imageStatusReplication = "puce_gray_black.png";
					break;
			}
		}
	}
}
