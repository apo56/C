using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    class OupsException : Exception
    {
        public OupsException()
        {
            string defaultMessage = "Oups";
            throw new OupsException(defaultMessage);
        }

        public OupsException(string message) : base(message)
        {

        }
    }
}
