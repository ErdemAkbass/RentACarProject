using NArchitecture.Core.Application.Dtos;


namespace Application.Features.Cars.Queries.GetList;

public class GetListCarListItemDto : IDto
{
    public Guid ModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindeksCreditRate { get; set; }
}