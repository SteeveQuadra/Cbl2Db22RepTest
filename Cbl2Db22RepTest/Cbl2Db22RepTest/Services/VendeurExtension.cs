using Cbl2Db22RepTest.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
    public static class VendeurExtension
    {
		public static DefaultVendeur ToDefaultVendeur(this Vendeur vendeur)
		{
			DefaultVendeur defaultVendeur = new DefaultVendeur()
			{
				Nom = vendeur.Nom,
				Email = vendeur.Email,
				Telephone = vendeur.Telephone,
				Num = vendeur.Num ?? 0,
				Id = string.Empty
			};

			return defaultVendeur;
		}
	}
}
