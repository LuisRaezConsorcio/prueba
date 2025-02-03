using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.UbigeoAggregate.Infrastructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;
        public UbigeoRepository(Context context)
        {
            _context = context;
        }
        
        public UbigeoResponse FindResponse(string UbigeoCode)
        {

            var q = from Ubigeo in _context.Ubigeos.Where(x => x.UbigeoCode.Equals(UbigeoCode))
                    select new UbigeoResponse()
                    {
                        UbigeoCode = Ubigeo.UbigeoCode,
                        ProvinceCode = Ubigeo.ProvinceCode,
                        RegionCode = Ubigeo.RegionCode,
                        UbigeoDescription = Ubigeo.UbigeoDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new UbigeoResponse();
        }

        public List<UbigeoResponse> GetByRegionAndProvince(string regionCode, string provinceCode)
        {
            var users = from Ubigeo in _context.Ubigeos
                        .Where(u => u.RegionCode == regionCode && u.ProvinceCode == provinceCode)
                        select new UbigeoResponse()
                        {
                            UbigeoCode = Ubigeo.UbigeoCode,
                            ProvinceCode = Ubigeo.ProvinceCode,
                            RegionCode = Ubigeo.RegionCode,
                            UbigeoDescription = Ubigeo.UbigeoDescription
                        };

            return users.ToList();
        }

        public List<UbigeoResponse> FindAll()
        {
            var users = from Ubigeo in _context.Ubigeos
                        select new UbigeoResponse()
                        {
                            UbigeoCode = Ubigeo.UbigeoCode,
                            ProvinceCode = Ubigeo.ProvinceCode,
                            RegionCode = Ubigeo.RegionCode,
                            UbigeoDescription = Ubigeo.UbigeoDescription
                        };

            return users.ToList();
        }


    }
}