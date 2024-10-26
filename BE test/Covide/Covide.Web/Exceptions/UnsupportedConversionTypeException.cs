using System;

namespace Covide.Web.Exceptions
{
    public class UnsupportedConversionTypeException : Exception
    {
        public UnsupportedConversionTypeException(string conversionType)
            : base($"The conversion type '{conversionType}' is not supported.")
        {
        }

        public UnsupportedConversionTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
