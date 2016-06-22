using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTransfer
{
    [Serializable]
    public class NoAvailableFundException : Exception
    {
        public NoAvailableFundException() : base() { }

        public NoAvailableFundException(string message) : base(message) { }
    }
}
