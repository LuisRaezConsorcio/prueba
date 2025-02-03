using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;

namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces
{
    public interface IUbigeoRepository
    {
        UbigeoResponse FindResponse(string UbigeoCode);
        List<UbigeoResponse> GetByRegionAndProvince(string regionCode, string provinceCode);
        List<UbigeoResponse> FindAll();
    }
}
