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

        public bool Update(string documentNumber, LibeyUserResponse userResponse)
        {
            return _repository.Update(documentNumber, userResponse);
        }



        public bool Delete(string documentNumber)
        {
            try
            {
                var user = _repository.FindResponse(documentNumber);

                if (user == null)
                {
                    return false; 
                }

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