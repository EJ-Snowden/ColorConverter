namespace Covide.Web.Services.Interfaces
{
    public interface IColorConversionStrategy<out T>
    {
        T Convert(string hexColor);
    }

}