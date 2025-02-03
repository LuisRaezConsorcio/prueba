namespace LibeyTechnicalTestDomain.RegionAggregate.Application.DTO
{
    public record RegionResponse
    {
        public string RegionCode { get; init; }
        public string RegionDescription { get; init; }
    }
}