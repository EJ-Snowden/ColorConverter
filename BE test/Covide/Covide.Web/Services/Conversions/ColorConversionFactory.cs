using Covide.Web.Services.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;
using Covide.Web.Utilities;
using Covide.Web.Exceptions;

namespace Covide.Web.Services.Conversions
{
    public class ColorConversionFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ColorConversionFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IColorConversionStrategy<T> GetStrategy<T>(ConversionType type)
        {
            var strategy = _serviceProvider.GetService<IColorConversionStrategy<T>>();

            if (strategy == null)
            {
                throw new UnsupportedConversionTypeException($"No strategy found for conversion type '{type}'.");
            }

            return strategy;
        }
    }
}
