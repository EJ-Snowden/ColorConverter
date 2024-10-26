using Covide.Web.Models.DTOs;

namespace Covide.Web.Services.Interfaces
{
    public interface IColorConversionService
    {
        ColorResponseDto ConvertHexToColorRepresentation(string hexColor);
    }
}
