using NArchitecture.Core.Application.Responses;


namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarResponse : IResponse
{

    public Guid ModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindeksCreditRate { get; set; }
}