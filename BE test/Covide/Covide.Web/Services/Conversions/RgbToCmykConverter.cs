using Covide.Web.Models;
using Covide.Web.Services.Interfaces;
using Covide.Web.Utilities;
using System;

namespace Covide.Web.Services.Conversions
{
    public class RgbToCmykConverter : IColorConversionStrategy<CmykColor>
    {
        public CmykColor Convert(string hexColor)
        {
            var (red, green, blue) = ColorParser.ParseHexToRgb(hexColor);

            double r = red / 255.0;
            double g = green / 255.0;
            double b = blue / 255.0;

            double k = 1 - Math.Max(r, Math.Max(g, b));
            double c = (1 - r - k) / (1 - k);
            double m = (1 - g - k) / (1 - k);
            double y = (1 - b - k) / (1 - k);

            return new CmykColor((int)(c * 100), (int)(m * 100), (int)(y * 100), (int)(k * 100));
        }
    }
}
