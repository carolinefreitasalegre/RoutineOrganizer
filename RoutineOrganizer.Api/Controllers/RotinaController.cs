using Application.Dtos.Request;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace RoutineOrganizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotinaController : ControllerBase
    {
        private readonly IRotinaService _service;
        private readonly IValidator<RotinaRequest> _validator;

        public RotinaController(IRotinaService service, IValidator<RotinaRequest> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarRotina(RotinaRequest request)
        {
            var addRotina = await _validator.ValidateAsync(request);

            if (!addRotina.IsValid)
                return BadRequest(addRotina.Errors);

            await _service.CriarRotina(request);

            return Created("", request);
        }

        [HttpPut]
        public async Task<IActionResult> EditarRotina(RotinaRequest request)
        {
            var addRotina = await _validator.ValidateAsync(request);

            if (!addRotina.IsValid)
                return BadRequest(addRotina.Errors);

            await _service.EditarRotina(request);

            return Created("", request);
        }

        [HttpGet]
        public async Task<IActionResult> ListarRotina()
        {
            var lista = await _service.TodosRotinas();
            if (!lista.Any())
                return BadRequest("Ainda não há rotina listada");

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BucarRotina(int id)
        {
            var rotina = await _service.BuscarRotina(id);
            if (rotina == null)
                return BadRequest("Rotina nõ encontrada");

            return Ok(rotina);
        }
    }
}
