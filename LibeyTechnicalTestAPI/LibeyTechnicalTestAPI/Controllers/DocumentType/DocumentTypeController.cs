using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.DocumentType
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeAggregate _aggregate;
        public DocumentTypeController(IDocumentTypeAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        [Route("{DocumentTypeId}")]
        public IActionResult FindResponse(int DocumentTypeId)
        {
            try
            {
                var row = _aggregate.FindResponse(DocumentTypeId);

                if (row.DocumentTypeId == 0)
                    return NotFound(new { message = "El Tipo de documento no fue encontrado." });


                return Ok(new { Datos = row, message = "Tipo de Documento obtenido correctamente." });
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
                    return NotFound(new { message = "No se encontro el tipo de documento." });
                }

                    return Ok(new { Datos = rows, message = "Tipo de Documento obtenido correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error inesperado.", error = ex });
            }
        }
    }
}
