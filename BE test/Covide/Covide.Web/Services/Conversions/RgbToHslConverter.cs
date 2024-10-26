using Covide.Web.Models;
using Covide.Web.Services.Interfaces;
using System;
using Covide.Web.Utilities;

namespace Covide.Web.Services.Conversions
{
    public class RgbToHslConverter : IColorConversionStrategy<HslColor>
    {
        public HslColor Convert(string hexColor)
        {
            var (red, green, blue) = ColorParser.ParseHexToRgb(hexColor);

            double r = red / 255.0;
            double g = green / 255.0;
            double b = blue / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double hue = CalculateHue(r, g, b, max, delta);
            double lightness = (max + min) / 2;
            double saturation = MathUtilities.AreApproximatelyEqual(delta, 0) ? 0 : delta / (1 - Math.Abs(2 * lightness - 1));

            return new HslColor(Math.Round(hue, 1), Math.Round(saturation * 100, 1), Math.Round(lightness * 100, 1));
        }

        private static double CalculateHue(double r, double g, double b, double max, double delta)
        {
            if (MathUtilities.AreApproximatelyEqual(delta, 0)) return 0;

            if (MathUtilities.AreApproximatelyEqual(max, r))
                return ((g - b) / delta) % 6 * 60;

            if (MathUtilities.AreApproximatelyEqual(max, g))
                return ((b - r) / delta + 2) * 60;

            return ((r - g) / delta + 4) * 60;
        }
    }
}
