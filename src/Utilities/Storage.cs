using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrisMyAss.src.Utilities
{
    public class Storage
    {
        private Storage() { }

        private static readonly Storage _storage = new Storage();

        public static Storage GetInstance()
        {
            return _storage;
        }
    }
}
