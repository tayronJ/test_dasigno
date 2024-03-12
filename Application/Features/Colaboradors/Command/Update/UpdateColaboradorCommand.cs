using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;


namespace Application.Features.Colaboradors.Command.Update
{
    public class UpdateColaboradorCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string PrimerNombre { get; set; } = null!;

        public string? SegundoNombre { get; set; }

        public string PrimerApellido { get; set; } = null!;

        public string? SegundoApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public decimal Sueldo { get; set; }

    }

    public class UpdateColaboradorCommandHandler : IRequestHandler<UpdateColaboradorCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Colaborador> _repositoryAsync;

        public UpdateColaboradorCommandHandler(IRepositoryAsync<Colaborador> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateColaboradorCommand request, CancellationToken cancellationToken)
        {
            Colaborador colaborador = await _repositoryAsync.GetByIdAsync(request.Id);
            if (colaborador == null)
            {
                throw new KeyNotFoundException($"El id({request.Id}) no existe");
            }
            else
            {
                colaborador.PrimerApellido = request.PrimerApellido;
                colaborador.SegundoApellido = request.SegundoApellido;
                colaborador.PrimerNombre = request.PrimerNombre;
                colaborador.SegundoNombre = request.SegundoNombre;
                colaborador.Sueldo = request.Sueldo;
                colaborador.FechaNacimiento = request.FechaNacimiento;
                colaborador.FechaModificacion = DateTime.Now;
                 await _repositoryAsync.UpdateAsync(colaborador);
            }
            return new Response<int>(colaborador.Id);
        }
    }
}
