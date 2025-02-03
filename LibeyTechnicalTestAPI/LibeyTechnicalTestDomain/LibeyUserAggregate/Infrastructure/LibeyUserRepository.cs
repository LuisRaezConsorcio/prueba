using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public bool Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
            return true;
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        RegionCode = libeyUser.UbigeoCode.PadRight(2).Substring(0, 2),
                        ProvinceCode = libeyUser.UbigeoCode.PadRight(4).Substring(0, 4),
                        UbigeoCode = libeyUser.UbigeoCode,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public bool Update(string documentNumber, LibeyUserResponse userResponse)
        {
            var existingUser = _context.Set<LibeyUser>().FirstOrDefault(x => x.DocumentNumber == documentNumber);

            if (existingUser == null)
                return false; 

            existingUser.Update(
                userResponse.Name,
                userResponse.FathersLastName,
                userResponse.MothersLastName,
                userResponse.Address,
                userResponse.UbigeoCode,
                userResponse.Phone,
                userResponse.Email,
                userResponse.Password,
                userResponse.Active
            );

            _context.SaveChanges();

            return true; 
        }


        public bool Delete(string documentNumber)
        {
            var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);

            if (user == null)
                return false;

            user.Deactivate();

            _context.SaveChanges();
            return true;
        }

        public List<LibeyUserResponse> FindAll()
        {
            var users = from libeyUser in _context.LibeyUsers
                        select new LibeyUserResponse()
                        {
                            DocumentNumber = libeyUser.DocumentNumber,
                            Active = libeyUser.Active,
                            Address = libeyUser.Address,
                            DocumentTypeId = libeyUser.DocumentTypeId,
                            Email = libeyUser.Email,
                            FathersLastName = libeyUser.FathersLastName,
                            MothersLastName = libeyUser.MothersLastName,
                            RegionCode = libeyUser.UbigeoCode.PadRight(2).Substring(0, 2),
                            ProvinceCode = libeyUser.UbigeoCode.PadRight(4).Substring(0, 4),
                            UbigeoCode =libeyUser.UbigeoCode,
                            Name = libeyUser.Name,
                            Password = libeyUser.Password,
                            Phone = libeyUser.Phone
                        };

            return users.ToList();
        }






    }
}