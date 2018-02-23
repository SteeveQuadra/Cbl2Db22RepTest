using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Services
{
	internal class RefreshMessage
	{
		public bool Refresh { get; set; }

		public RefreshMessage(bool refresh)
		{
			Refresh = refresh;
		}
	}
}
