using System.Globalization;
using System;
using Covide.Web.Exceptions;

namespace Covide.Web.Utilities
{
    public static class ColorParser
    {
        public static (int red, int green, int blue) ParseHexToRgb(string hexColor)
        {
            if (string.IsNullOrWhiteSpace(hexColor) || hexColor.Length != 6)
            {
                throw new InvalidHexColorException(hexColor);
            }

            int red = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            int green = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            int blue = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            return (red, green, blue);
        }
    }
}
