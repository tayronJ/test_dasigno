using Application.Features.Colaboradors.Command.Create;
using Application.Features.Colaboradors.Command.Delete;
using Application.Features.Colaboradors.Command.Update;
using Application.Features.Colaboradors.Queries.GetAllColaboradors;
using Application.Features.Colaboradors.Queries.GetColaboradorById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    public class ColaboradorController : BaseApiController
    {
        
        [HttpGet()]
        public async Task<IActionResult> Get(int pageSize,int pageNumber,string search = "")
        {
            return Ok(await Mediator.Send(new GetAllColaboradorsQuery { PageSize = pageSize, PageNumber = pageNumber, SearchText = search }));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetColaboradorByIdQuery { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateColaboradorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateColaboradorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteColaboradorCommand() { Id = id}));
        }
    }
}
