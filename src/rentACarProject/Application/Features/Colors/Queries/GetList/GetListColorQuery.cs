using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Colors.Queries.GetList;

public class GetListColorQuery : IRequest<GetListResponse<GetListColorListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListColorQueryHandler : IRequestHandler<GetListColorQuery, GetListResponse<GetListColorListItemDto>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetListColorQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListColorListItemDto>> Handle(GetListColorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Color> colors = await _colorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListColorListItemDto> response = _mapper.Map<GetListResponse<GetListColorListItemDto>>(colors);
            return response;
        }
    }
}