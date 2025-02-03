using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces
{
    public interface IProvinceAggregate
    {
        ProvinceResponse FindResponse(string ProvinceCode);
        List<ProvinceResponse> GetByRegion(string regionCode);
        List<ProvinceResponse> FindAll();
    }
}