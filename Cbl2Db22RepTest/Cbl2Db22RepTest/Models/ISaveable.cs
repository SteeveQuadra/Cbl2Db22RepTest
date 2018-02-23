using Couchbase.Lite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cbl2Db22RepTest.Models
{
    public interface ISaveable
    {
		MutableDictionaryObject DocumentInitialize();
		string Table { get; }
    }
}
