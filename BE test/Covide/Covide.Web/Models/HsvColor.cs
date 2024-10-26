namespace Covide.Web.Models
{
    public class HsvColor
    {
        public double Hue { get; }
        public double Saturation { get; }
        public double Value { get; }

        public HsvColor(double hue, double saturation, double value)
        {
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }
    }
}
