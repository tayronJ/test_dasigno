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

namespace Application.Features.Colaboradors.Command.Delete
{
    public class DeleteColaboradorCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteColaboradorCommandHandler : IRequestHandler<DeleteColaboradorCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Colaborador> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteColaboradorCommandHandler(IRepositoryAsync<Colaborador> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteColaboradorCommand request, CancellationToken cancellationToken)
        {
            Colaborador colaborador = await _repositoryAsync.GetByIdAsync(request.Id);
            if (colaborador == null)
            {
                throw new KeyNotFoundException($"El id({request.Id}) no existe");
            }
            else
            {

                await _repositoryAsync.DeleteAsync(colaborador);
            }
            return new Response<int>(colaborador.Id);
        }
    }
}
