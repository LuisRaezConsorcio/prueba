using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;
namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application
{
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly IUbigeoRepository _repository;
        public UbigeoAggregate(IUbigeoRepository repository)
        {
            _repository = repository;
        }
       
        public UbigeoResponse FindResponse(string UbigeoCode)
        {
            var row = _repository.FindResponse(UbigeoCode);
            return row;
        }

        public List<UbigeoResponse> GetByRegionAndProvince(string regionCode, string provinceCode)
        {
            try
            {
                var ubigeos = _repository.GetByRegionAndProvince(regionCode, provinceCode);
                return ubigeos;
            }
            catch (Exception)
            {
                return new List<UbigeoResponse>();
            }
        }

        public List<UbigeoResponse> FindAll()
        {
            try
            {
                var users = _repository.FindAll();
                return users;
            }
            catch (Exception)
            {
                return new List<UbigeoResponse>();
            }
        }



    }
}