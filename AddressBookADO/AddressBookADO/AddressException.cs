using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO
{
    public class AddressException : Exception
    {
        ExceptionType exceptionType;
        public enum ExceptionType
        {
            CONNECTION_FAILED, CONTACT_NOT_FOUND
        }
        public AddressException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
