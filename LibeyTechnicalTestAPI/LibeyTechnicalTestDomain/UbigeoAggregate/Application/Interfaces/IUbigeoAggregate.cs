using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces
{
    public interface IUbigeoAggregate
    {
        UbigeoResponse FindResponse(string UbigeoCode);
        List<UbigeoResponse> GetByRegionAndProvince(string regionCode, string provinceCode);
        List<UbigeoResponse> FindAll();
    }
}