using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Configuration
{
    public static class SynchroExExtension
    {
		public static SynchroEx ToSynchroEx(this Couchbase.Lite.IMutableDictionary dico)
		{
			SynchroEx synchroEx = new SynchroEx();

			if (!string.IsNullOrEmpty(dico.GetString("dateException")))
				synchroEx.DateException = dico.GetDate("dateException").DateTime;
			synchroEx.Id = dico.GetString("id");
			synchroEx.Message = dico.GetString("message");

			return synchroEx;
		}
	}
}
