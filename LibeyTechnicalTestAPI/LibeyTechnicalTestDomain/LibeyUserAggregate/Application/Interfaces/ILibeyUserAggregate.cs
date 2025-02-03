﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        LibeyUserResponse FindResponse(string documentNumber);
        bool Create(UserUpdateorCreateCommand command);
        bool Update(string documentNumber, LibeyUserResponse userResponse);
        bool Delete(string documentNumber);
        List<LibeyUserResponse> FindAll();
    }
}