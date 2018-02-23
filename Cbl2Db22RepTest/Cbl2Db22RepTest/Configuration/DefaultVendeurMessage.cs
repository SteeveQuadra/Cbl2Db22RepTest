using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Configuration
{
    internal class DefaultVendeurMessage
    {
		private readonly DefaultVendeur _defaultVendeur;

		public DefaultVendeurMessage(DefaultVendeur defaultVendeur)
		{
			_defaultVendeur = defaultVendeur;
		}

		public DefaultVendeur Vendeur => _defaultVendeur;
	}
}
