using Covide.Web.Models;
using Covide.Web.Services.Interfaces;
using Covide.Web.Utilities;
using System;

namespace Covide.Web.Services.Conversions
{
    public class RgbToXyzConverter : IColorConversionStrategy<XyzColor>
    {
        public XyzColor Convert(string hexColor)
        {
            var (red, green, blue) = ColorParser.ParseHexToRgb(hexColor);

            double r = ConvertToLinear(red / 255.0);
            double g = ConvertToLinear(green / 255.0);
            double b = ConvertToLinear(blue / 255.0);

            double x = r * 0.4124 + g * 0.3576 + b * 0.1805;
            double y = r * 0.2126 + g * 0.7152 + b * 0.0722;
            double z = r * 0.0193 + g * 0.1192 + b * 0.9505;

            return new XyzColor(Math.Round(x * 100, 3), Math.Round(y * 100, 3), Math.Round(z * 100, 3));
        }

        private static double ConvertToLinear(double channel)
        {
            return channel > 0.04045 ? Math.Pow((channel + 0.055) / 1.055, 2.4) : channel / 12.92;
        }
    }
}
