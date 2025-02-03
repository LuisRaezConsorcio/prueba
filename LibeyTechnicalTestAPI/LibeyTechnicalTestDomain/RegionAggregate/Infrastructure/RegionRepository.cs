using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.RegionAggregate.Infrastructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;
        public RegionRepository(Context context)
        {
            _context = context;
        }
        
        public RegionResponse FindResponse(string RegionCode)
        {

            var q = from Region in _context.Regions.Where(x => x.RegionCode.Equals(RegionCode))
                    select new RegionResponse()
                    {
                        RegionCode = Region.RegionCode,
                        RegionDescription = Region.RegionDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new RegionResponse();
        }

        public List<RegionResponse> FindAll()
        {
            var users = from Region in _context.Regions
                        select new RegionResponse()
                        {
                            RegionCode = Region.RegionCode,
                            RegionDescription = Region.RegionDescription
                        };

            return users.ToList();
        }
    }
}