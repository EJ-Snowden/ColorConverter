using System;

namespace Covide.Web.Exceptions
{
    public class InvalidHexColorException : ArgumentException
    {
        public InvalidHexColorException(string hexColor)
            : base($"The provided hex color '{hexColor}' is invalid. A valid hex color should be a 6-character string in hexadecimal format.")
        {
        }

        public InvalidHexColorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
