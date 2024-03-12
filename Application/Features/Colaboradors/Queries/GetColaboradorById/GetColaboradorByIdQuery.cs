using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colaboradors.Queries.GetColaboradorById
{
    public class GetColaboradorByIdQuery : IRequest<Response<ColaboradorDTO>>
    {
        public int Id { get; set; }
    }


    public class GetColaboradorByIdQueryHandler : IRequestHandler<GetColaboradorByIdQuery, Response<ColaboradorDTO>>
    {
        private readonly IRepositoryAsync<Colaborador> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetColaboradorByIdQueryHandler(IRepositoryAsync<Colaborador> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<ColaboradorDTO>> Handle(GetColaboradorByIdQuery request, CancellationToken cancellationToken)
        {
            var colaborador = await _repositoryAsync.GetByIdAsync(request.Id);
            var colaboradorDto = _mapper.Map<ColaboradorDTO>(colaborador);
            return new Response<ColaboradorDTO>(colaboradorDto);
        }
    }
}
