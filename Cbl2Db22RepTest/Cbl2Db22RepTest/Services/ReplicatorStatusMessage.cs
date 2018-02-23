using Couchbase.Lite.Sync;

namespace Cbl2Db22RepTest.Services
{
	internal class ReplicatorStatusMessage
	{
		public Couchbase.Lite.Sync.ReplicatorStatus Status { get; set; }
		public string LastError { get; set; }

		public ReplicatorStatusMessage(Couchbase.Lite.Sync.ReplicatorStatus status, string le)
		{
			Status = status;
			LastError = le;
		}
	}
}