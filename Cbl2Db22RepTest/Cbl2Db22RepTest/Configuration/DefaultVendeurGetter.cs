using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Configuration
{
	public interface IDefaultVendeurGetter
	{
		DefaultVendeur Get();
		void Remove();
		bool IsLogged();
	}

	public class DefaultVendeurGetter : IDefaultVendeurGetter
    {
		private readonly IDefaultVendeurDal _defaultVendeurDal;
		private DefaultVendeur _defaultVendeur=null;

		public DefaultVendeurGetter(IDefaultVendeurDal defaultVendeurDal)
		{
			_defaultVendeurDal = defaultVendeurDal;
		}

		public DefaultVendeur Get()
		{
			if (_defaultVendeur == null)
				_defaultVendeur = _defaultVendeurDal.Get();

			return _defaultVendeur;
		}

		public bool IsLogged()
		{
			return Get() != null;
		}

		public void Remove()
		{
			_defaultVendeurDal.Delete(_defaultVendeur);
			_defaultVendeur = null;
		}
	}
}
