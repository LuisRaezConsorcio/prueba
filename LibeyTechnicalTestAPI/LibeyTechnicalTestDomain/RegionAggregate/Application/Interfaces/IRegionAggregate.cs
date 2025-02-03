using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces
{
    public interface IRegionAggregate
    {
        RegionResponse FindResponse(string RegionCode);
        List<RegionResponse> FindAll();
    }
}