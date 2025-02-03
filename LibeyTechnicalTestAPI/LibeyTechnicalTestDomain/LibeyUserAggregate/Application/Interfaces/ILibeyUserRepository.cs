using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        LibeyUserResponse FindResponse(string documentNumber);
        bool Create(LibeyUser libeyUser);
        bool Update(string documentNumber, LibeyUserResponse libeyUser);
        bool Delete(string documentNumber);
        List<LibeyUserResponse> FindAll();
    }
}
