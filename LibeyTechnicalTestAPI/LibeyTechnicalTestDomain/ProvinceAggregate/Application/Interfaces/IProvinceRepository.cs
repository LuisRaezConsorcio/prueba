using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces
{
    public interface IProvinceRepository
    {
        ProvinceResponse FindResponse(string ProvinceCode);
        List<ProvinceResponse> GetByRegion(string regionCode);
        List<ProvinceResponse> FindAll();
    }
}
