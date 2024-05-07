using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries.GetById;
using Application.Features.Colors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
    {
        CreatedColorResponse response = await Mediator.Send(createColorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColorCommand)
    {
        UpdatedColorResponse response = await Mediator.Send(updateColorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedColorResponse response = await Mediator.Send(new DeleteColorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdColorResponse response = await Mediator.Send(new GetByIdColorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListColorQuery getListColorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListColorListItemDto> response = await Mediator.Send(getListColorQuery);
        return Ok(response);
    }
}