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
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public bool Update(string documentNumber, LibeyUserResponse updatedUser)
        {
            // Buscar el usuario existente en la base de datos
            var existingUser = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);

            if (existingUser == null)
                return false;

            // Actualizar solo las propiedades que no sean null
            existingUser.Name = updatedUser.Name ?? existingUser.Name;
            existingUser.FathersLastName = updatedUser.FathersLastName ?? existingUser.FathersLastName;
            existingUser.MothersLastName = updatedUser.MothersLastName ?? existingUser.MothersLastName;
            existingUser.Address = updatedUser.Address ?? existingUser.Address;
            existingUser.UbigeoCode = updatedUser.UbigeoCode ?? existingUser.UbigeoCode;
            existingUser.Phone = updatedUser.Phone ?? existingUser.Phone;
            existingUser.Email = updatedUser.Email ?? existingUser.Email;
            existingUser.Password = updatedUser.Password ?? existingUser.Password;
            existingUser.Active = updatedUser.Active ?? existingUser.Active; // Para el caso de booleanos

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
            return true;
        }



        public bool Delete(string documentNumber)
        {
            var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);

            if (user == null)
                return false;

            // Cambiar el estado de 'Active' a false en lugar de eliminar el registro
            user.Deactivate();

            // Guardar los cambios en la base de datos
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
                            Name = libeyUser.Name,
                            Password = libeyUser.Password,
                            Phone = libeyUser.Phone
                        };

            return users.ToList();
        }






    }
}