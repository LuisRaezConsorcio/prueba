using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionAggregate _aggregate;
        public RegionController(IRegionAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        [Route("{RegionCode}")]
        public IActionResult FindResponse(string RegionCode)
        {
            try
            {
                var row = _aggregate.FindResponse(RegionCode);

                if (row.RegionCode == null)
                    return NotFound(new { message = "La region no fue encontrada." });


                return Ok(new { Datos = row, message = "Region obtenida correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un errror inesperado.", error = ex });
            }

        }

        [HttpGet]
        public IActionResult FindAll()
        {
            try
            {
                var rows = _aggregate.FindAll();

                if (rows == null || !rows.Any())
                {
                    return NotFound(new { message = "No se encontro la region." });
                }

                return Ok(new { Datos = rows, message = "Region obtenida correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error inesperado.", error = ex });
            }
        }
    }
}
