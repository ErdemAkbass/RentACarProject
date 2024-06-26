using NArchitecture.Core.Application.Responses;

namespace Application.Features.Models.Commands.Create;

public class CreatedModelResponse : IResponse
{
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
}