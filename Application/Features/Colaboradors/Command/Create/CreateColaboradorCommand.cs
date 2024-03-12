using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colaboradors.Command.Create
{
    public class CreateColaboradorCommand : IRequest<Response<int>> 
    {
        public string PrimerNombre { get; set; } 

        public string? SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public decimal Sueldo { get; set; }
        public DateTime FechaNacimiento { get; set; }
 
    }

    public class CreateColaboradorCommandHandler : IRequestHandler<CreateColaboradorCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Colaborador> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateColaboradorCommandHandler(IRepositoryAsync<Colaborador> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateColaboradorCommand request, CancellationToken cancellationToken)
        {
            Colaborador colaborador = _mapper.Map<Colaborador>(request);
            colaborador.FechaCreacion = DateTime.Now;
            Colaborador colaboradorRegistered = await _repositoryAsync.AddAsync(colaborador);
            return new Response<int>(colaboradorRegistered.Id);
        }
    }
}
