using Covide.Web.Models;
using Covide.Web.Services.Interfaces;
using Covide.Web.Utilities;

namespace Covide.Web.Services.Conversions
{
    public class HexToRgbConverter : IColorConversionStrategy<RgbColor>
    {
        public RgbColor Convert(string hexColor)
        {
            var (red, green, blue) = ColorParser.ParseHexToRgb(hexColor);
            return new RgbColor(red, green, blue);
        }
    }
}
