using Cbl2Db22RepTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Configuration
{
    public static class DefaultVendeurExtension
    {
		public static Vendeur ToVendeur(this DefaultVendeur defaultVendeur, Vendeur vendeur = null)
		{
			if (vendeur == null)
				vendeur = new Vendeur();


			vendeur.Nom = defaultVendeur.Nom;
			vendeur.Email = defaultVendeur.Email;
			vendeur.Telephone = defaultVendeur.Telephone;
			vendeur.Num = defaultVendeur.Num;

			return vendeur;
		}
	}
}
