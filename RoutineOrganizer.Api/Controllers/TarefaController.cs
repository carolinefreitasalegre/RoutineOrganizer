using Application.Dtos.Request;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutineOrganizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaDomesticaService _service;
        private readonly IValidator<TarefaRequest> _validator;

        public TarefaController(ITarefaDomesticaService service, IValidator<TarefaRequest> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTarefas()
        {
            var tarefas = await _service.TodosTarefas();

            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarTarefa(int id)
        {
            var tarefa = await _service.BuscarTarefaDomestica(id);

            if (tarefa == null)
                return BadRequest("Tarefa não registrado.");


            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> AidicionarTarefa(TarefaRequest request)
        {
            var validarRequest = await _validator.ValidateAsync(request);

            if (!validarRequest.IsValid)
                return BadRequest(validarRequest.Errors);

            var addFilho = await _service.CriarTarefaDomestica(request);

            return Created("", addFilho);
        }

        [HttpPut]

        public async Task<IActionResult> EditarTarefa(TarefaRequest request)
        {
            var validarRequest = await _validator.ValidateAsync(request);

            if (!validarRequest.IsValid)
                return BadRequest(validarRequest.Errors);

            var addFilho = await _service.EditarTarefaDomestica(request);

            return Created("", addFilho);
        }
    }
}
