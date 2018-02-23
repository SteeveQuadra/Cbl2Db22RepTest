using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
    interface IDateable
    {
		DateTime DateCreation { get; set; }
		DateTime DateModif { get; set; }
	}
}
