using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Colaboradors.Queries.GetAllColaboradors
{
    public class GetAllColaboradorsQuery : IRequest<Response<List<ColaboradorDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
    }

    public class GetAllColaboradorsQueryHandler :IRequestHandler<GetAllColaboradorsQuery, Response<List<ColaboradorDTO>>>
    {
        private readonly IRepositoryAsync<Colaborador> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllColaboradorsQueryHandler(IRepositoryAsync<Colaborador> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<List<ColaboradorDTO>>> Handle(GetAllColaboradorsQuery request, CancellationToken cancellationToken)
        {
            var colaboradors = await _repositoryAsync.ListAsync(new PageColaboradorSpecification(request.PageSize, request.PageNumber, request.SearchText));
            var colaboradorsDto = _mapper.Map<List<ColaboradorDTO>>(colaboradors);
            return new Response<List<ColaboradorDTO>>(colaboradorsDto);

        }
    }
}
