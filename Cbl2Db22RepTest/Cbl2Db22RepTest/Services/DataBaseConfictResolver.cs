﻿using Couchbase.Lite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Services
{

	public class DataBaseConfictResolver : IConflictResolver
	{
		public Document Resolve(Conflict conflict) // db20
		//public ReadOnlyDocument Resolve(Conflict conflict) // db19
		{
			var baseProperties = conflict.Base;
			var mine = conflict.Mine;
			var theirs = conflict.Theirs;

			return theirs;
		}
	}
}
