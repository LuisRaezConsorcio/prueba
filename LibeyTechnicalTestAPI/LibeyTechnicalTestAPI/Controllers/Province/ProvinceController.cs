using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Province
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceAggregate _aggregate;
        public ProvinceController(IProvinceAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        [Route("FindResponse")]
        public IActionResult FindResponse(string ProvinceId)
        {
            try
            {
                var row = _aggregate.FindResponse(ProvinceId);

                if (row.ProvinceCode == null)
                    return NotFound(new { message = "La Provincia no fue encontrado." });


                return Ok(new { Datos = row, message = "Provincia obtenida correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un errror inesperado.", error = ex });
            }

        }

        [HttpGet]
        [Route("GetByRegion")]
        public IActionResult GetByRegion(string RegionCode)
        {
            try
            {
                var rows = _aggregate.GetByRegion(RegionCode);

                if (rows == null || !rows.Any())
                {
                    return NotFound(new { message = "No se encontro la Provincia." });
                }

                return Ok(new { Datos = rows, message = "Provincia obtenido correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error inesperado.", error = ex });
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
                    return NotFound(new { message = "No se encontro la Provincia." });
                }

                return Ok(new { Datos = rows, message = "Provincia obtenida correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error inesperado.", error = ex });
            }
        }
    }
}
