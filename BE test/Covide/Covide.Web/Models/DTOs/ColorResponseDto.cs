namespace Covide.Web.Models.DTOs
{
    public class ColorResponseDto
    {
        public string HexTriplet { get; set; }
        public string Name { get; set; }
        public RgbColor RgbDecimal { get; set; }
        public RgbColor RgbPercentage { get; set; }
        public CmykColor Cmyk { get; set; }
        public HslColor Hsl { get; set; }
        public HsvColor Hsv { get; set; }
        public XyzColor Xyz { get; set; }
    }
}
