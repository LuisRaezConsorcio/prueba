using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.ProvinceAggregate.Infrastructure
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context _context;
        public ProvinceRepository(Context context)
        {
            _context = context;
        }
        
        public ProvinceResponse FindResponse(string provinceCode)
        {

            var q = from Province in _context.Provinces
                    .Where(p => p.ProvinceCode == provinceCode)
                    select new ProvinceResponse()
                    {
                        ProvinceCode = Province.ProvinceCode,
                        RegionCode = Province.RegionCode,
                        ProvinceDescription = Province.ProvinceDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new ProvinceResponse();
        }

        public List<ProvinceResponse> GetByRegion(string regionCode)
        {
            var users = from Province in _context.Provinces
                        .Where(p => p.RegionCode == regionCode)
                        select new ProvinceResponse()
                        {
                            ProvinceCode = Province.ProvinceCode,
                            RegionCode = Province.RegionCode,
                            ProvinceDescription = Province.ProvinceDescription
                        };

            return users.ToList();
        }

        public List<ProvinceResponse> FindAll()
        {
            var users = from Province in _context.Provinces
                        select new ProvinceResponse()
                        {
                            ProvinceCode = Province.ProvinceCode,
                            RegionCode = Province.RegionCode,
                            ProvinceDescription = Province.ProvinceDescription
                        };

            return users.ToList();
        }






    }
}