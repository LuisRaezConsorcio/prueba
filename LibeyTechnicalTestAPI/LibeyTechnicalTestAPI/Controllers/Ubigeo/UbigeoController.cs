using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Ubigeo
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoAggregate _aggregate;
        public UbigeoController(IUbigeoAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        [Route("{UbigeoId}")]
        public IActionResult FindResponse(string UbigeoId)
        {
            try
            {
                var row = _aggregate.FindResponse(UbigeoId);

                if (row.UbigeoCode == null)
                    return NotFound(new { message = "El Ubigeo no fue encontrado." });


                return Ok(new { Datos = row, message = "Ubigeo obtenido correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un errror inesperado.", error = ex });
            }

        }

        [HttpGet]
        [Route("{regionCode}, {provinceCode}")]

        public IActionResult GetByRegionAndProvince(string regionCode, string provinceCode)
        {
            try
            {
                var rows = _aggregate.GetByRegionAndProvince(regionCode, provinceCode);

                if (rows == null || !rows.Any())
                {
                    return NotFound(new { message = "No se encontro el Ubigeo." });
                }

                return Ok(new { Datos = rows, message = "Ubigeo obtenido correctamente." });
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
                    return NotFound(new { message = "No se encontro el Ubigeo." });
                }

                return Ok(new { Datos = rows, message = "Ubigeo obtenido correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error inesperado.", error = ex });
            }
        }
    }
}
