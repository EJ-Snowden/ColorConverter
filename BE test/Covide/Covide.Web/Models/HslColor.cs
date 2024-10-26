namespace Covide.Web.Models
{
    public class HslColor
    {
        public double Hue { get; }
        public double Saturation { get; }
        public double Lightness { get; }

        public HslColor(double hue, double saturation, double lightness)
        {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
        }
    }
}
