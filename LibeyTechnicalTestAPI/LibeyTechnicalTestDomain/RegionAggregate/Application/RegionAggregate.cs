using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;
namespace LibeyTechnicalTestDomain.RegionAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository _repository;
        public RegionAggregate(IRegionRepository repository)
        {
            _repository = repository;
        }

        public RegionResponse FindResponse(string RegionCode)
        {
            var row = _repository.FindResponse(RegionCode);
            return row;
        }

        public List<RegionResponse> FindAll()
        {
            try
            {
                var regions = _repository.FindAll();
                return regions;
            }
            catch (Exception)
            {
                return new List<RegionResponse>();
            }
        }



    }
}