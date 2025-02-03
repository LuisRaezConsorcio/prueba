namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO
{
    public record ProvinceResponse
    {
        public string ProvinceCode { get; init; }
        public string RegionCode { get; init; }
        public string ProvinceDescription { get; init; }
    }
}