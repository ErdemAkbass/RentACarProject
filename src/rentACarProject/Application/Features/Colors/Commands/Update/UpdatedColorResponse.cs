using NArchitecture.Core.Application.Responses;

namespace Application.Features.Colors.Commands.Update;

public class UpdatedColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}