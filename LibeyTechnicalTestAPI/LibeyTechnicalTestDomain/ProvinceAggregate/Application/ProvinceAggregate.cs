using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository _repository;
        public ProvinceAggregate(IProvinceRepository repository)
        {
            _repository = repository;
        }
        
        public ProvinceResponse FindResponse(string ProvinceCode)
        {
            var row = _repository.FindResponse(ProvinceCode);
            return row;
        }

        public List<ProvinceResponse> GetByRegion(string RegionCode)
        {
            try
            {
                var provinces = _repository.GetByRegion(RegionCode);
                return provinces;
            }
            catch (Exception)
            {
                return new List<ProvinceResponse>();
            }
        }

        public List<ProvinceResponse> FindAll()
        {
            try
            {
                var users = _repository.FindAll();
                return users;
            }
            catch (Exception)
            {
                return new List<ProvinceResponse>();
            }
        }



    }
}