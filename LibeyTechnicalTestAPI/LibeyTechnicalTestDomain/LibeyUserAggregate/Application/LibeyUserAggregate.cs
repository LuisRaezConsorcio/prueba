using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public bool Create(UserUpdateorCreateCommand command)
        {
            try
            {
                // Convertir el DTO a la entidad
                var libeyUser = new LibeyUser(
                    command.DocumentNumber,
                    command.DocumentTypeId,
                    command.Name,
                    command.FathersLastName,
                    command.MothersLastName,
                    command.Address,
                    command.UbigeoCode,
                    command.Phone,
                    command.Email,
                    command.Password
                );

                // Llamar al repositorio para crear el usuario
                return _repository.Create(libeyUser);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public bool Update(string documentNumber, UserUpdateorCreateCommand command)
        {
            // Buscar el usuario en el repositorio
            var existingUser = _repository.FindResponse(documentNumber);

            if (existingUser == null)
                return false;

            var updatedUser = new LibeyUserResponse
            {
                Name = command.Name ?? existingUser.Name,
                FathersLastName = command.FathersLastName ?? existingUser.FathersLastName,
                MothersLastName = command.MothersLastName ?? existingUser.MothersLastName,
                Address = command.Address ?? existingUser.Address,
                UbigeoCode = command.UbigeoCode ?? existingUser.UbigeoCode,
                Phone = command.Phone ?? existingUser.Phone,
                Email = command.Email ?? existingUser.Email,
                Password = command.Password ?? existingUser.Password
            };

            // Pasar la lógica al repositorio para que guarde los cambios
            return _repository.Update(updatedUser);
        }



        public bool Delete(string documentNumber)
        {
            try
            {
                var user = _repository.FindResponse(documentNumber);

                if (user == null)
                {
                    return false;  // Usuario no encontrado
                }

                // Eliminar el usuario del repositorio
                return _repository.Delete(documentNumber);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<LibeyUserResponse> FindAll()
        {
            try
            {
                var users = _repository.FindAll();
                return users;
            }
            catch (Exception)
            {
                return new List<LibeyUserResponse>();
            }
        }



    }
}