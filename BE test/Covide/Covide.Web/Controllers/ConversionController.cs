using Microsoft.AspNetCore.Mvc;
using System;
using Covide.Web.Services.Interfaces;
using Covide.Web.Exceptions;

namespace Covide.Web.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IColorConversionService _colorConversionService;

        public ConversionController(IColorConversionService colorConversionService)
        {
            _colorConversionService = colorConversionService;
        }

        [HttpGet("{hex}")]
        public IActionResult Get([FromRoute] string hex)
        {
            try
            {
                var result = _colorConversionService.ConvertHexToColorRepresentation(hex);
                return Ok(result);
            }
            catch (InvalidHexColorException e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
