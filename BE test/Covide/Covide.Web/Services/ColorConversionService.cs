using Covide.Web.Data.DbContexts;
using Covide.Web.Models;
using Covide.Web.Services.Interfaces;
using System;
using System.Linq;
using Covide.Web.Services.Conversions;
using Microsoft.Extensions.Caching.Memory;
using Covide.Web.Utilities;
using Covide.Web.Models.DTOs;
using Covide.Web.Exceptions;

namespace Covide.Web.Services
{
    public class ColorConversionService : IColorConversionService
    {
        private readonly ColorConversionFactory _conversionFactory;
        private readonly CovideDataContext _db;
        private readonly IMemoryCache _cache;

        public ColorConversionService(ColorConversionFactory conversionFactory, CovideDataContext db, IMemoryCache cache)
        {
            _conversionFactory = conversionFactory;
            _db = db;
            _cache = cache;
        }

        public ColorResponseDto ConvertHexToColorRepresentation(string hexColor)
        {
            if (!IsValidHexColor(hexColor))
            {
                throw new InvalidHexColorException(hexColor);
            }

            return new ColorResponseDto
            {
                HexTriplet = hexColor.ToLower(),
                Name = GetColorName(hexColor),
                RgbDecimal = GetRgbColorFromHex(hexColor, isPercentage: false),
                RgbPercentage = GetRgbColorFromHex(hexColor, isPercentage: true),
                Cmyk = GetCmykColor(hexColor),
                Hsl = GetHslColor(hexColor),
                Hsv = GetHsvColor(hexColor),
                Xyz = GetXyzColor(hexColor)
            };
        }

        private string GetColorName(string hexColor)
        {
            return _cache.GetOrCreate(hexColor.ToUpper(), entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                return _db.ColorCodes.FirstOrDefault(cc => cc.HexTriplet == hexColor.ToUpper())?.Name;
            });
        }

        private RgbColor GetRgbColorFromHex(string hexColor, bool isPercentage)
        {
            var rgbConverter = _conversionFactory.GetStrategy<RgbColor>(ConversionType.HexToRgb);
            var rgbResult = rgbConverter.Convert(hexColor);
            return isPercentage ? ConvertToPercentage(rgbResult) : rgbResult;
        }

        private static RgbColor ConvertToPercentage(RgbColor color)
        {
            return new RgbColor(
                color.Red * 100 / 255,
                color.Green * 100 / 255,
                color.Blue * 100 / 255
            );
        }

        private CmykColor GetCmykColor(string hexColor)
        {
            var cmykConverter = _conversionFactory.GetStrategy<CmykColor>(ConversionType.RgbToCmyk);
            return cmykConverter.Convert(hexColor);
        }

        private HslColor GetHslColor(string hexColor)
        {
            var hslConverter = _conversionFactory.GetStrategy<HslColor>(ConversionType.RgbToHsl);
            return hslConverter.Convert(hexColor);
        }

        private HsvColor GetHsvColor(string hexColor)
        {
            var hsvConverter = _conversionFactory.GetStrategy<HsvColor>(ConversionType.RgbToHsv);
            return hsvConverter.Convert(hexColor);
        }

        private XyzColor GetXyzColor(string hexColor)
        {
            var xyzConverter = _conversionFactory.GetStrategy<XyzColor>(ConversionType.RgbToXyz);
            return xyzConverter.Convert(hexColor);
        }

        private static bool IsValidHexColor(string hexColor)
        {
            return !string.IsNullOrEmpty(hexColor) && System.Text.RegularExpressions.Regex.IsMatch(hexColor, "^[0-9a-fA-F]{6}$");
        }
    }

}
