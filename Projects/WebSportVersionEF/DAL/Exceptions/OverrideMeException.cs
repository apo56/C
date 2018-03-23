using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class OverrideMeException : Exception
    {
        public OverrideMeException()
        {
            string defaultMessage = "You have to override this method to make it work !";
            throw new OverrideMeException(defaultMessage);
        }

        public OverrideMeException(string message) : base(message)
        {

        }
    }
}
