using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            try
            {
                var row = _aggregate.FindResponse(documentNumber);

                if (row.DocumentNumber == null)
                    return NotFound(new { message="El Usuario no fue encontrado." });
                
                
                return Ok(new { Datos= row, message="Usuario     obtenido correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un errror inesperado.", error= ex });
            }
            
        }


        [HttpPost]       
        public IActionResult Create(UserUpdateorCreateCommand command)
        {
             
            try 
            {
                bool respuesta = _aggregate.Create(command);

                    if (!respuesta)
                {
                    return BadRequest(new { message = "No se pudo crear el usuario." });
                }

                return Ok(new { message = "Usuario creado correctamente." });
                
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
                    return NotFound(new { message = "No se encontraron usuarios." });
                }

                return Ok(new { Datos = rows, message = "Usuarios obtenidos correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error inesperado.", error = ex });
            }
        }

        [HttpPut("{documentNumber}")]
        public IActionResult Update(string documentNumber, [FromBody] LibeyUserResponse command)
        {
            try
            {
                bool respuesta = _aggregate.Update(documentNumber, command);

                if (!respuesta)
                {
                    return NotFound(new { message = "El Usuario no fue encontrado." });
                }

                return Ok(new { message = "Usuario actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error inesperado.", error = ex });
            }
        }


        [HttpDelete]
        [Route("{documentNumber}")]
        public IActionResult Delete(string documentNumber)
        {
            try
            {
                var respuesta = _aggregate.Delete(documentNumber);

                if (!respuesta)
                {
                    return BadRequest(new { message = "No se pudo eliminar el usuario." });
                }

                return Ok(new { message = "Usuario eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error inesperado.", error = ex });
            }
        }


    }
}