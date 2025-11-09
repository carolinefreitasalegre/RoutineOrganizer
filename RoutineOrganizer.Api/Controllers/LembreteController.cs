using Application.Dtos.Request;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace RoutineOrganizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LembreteController : ControllerBase
    {
        private readonly ILembreteService _service;
        private readonly IValidator<LembreteRequest> _validator;

        public LembreteController(ILembreteService service, IValidator<LembreteRequest> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarLembretes()
        {
            var lembretes = await _service.TodosLembretes();

            return Ok(lembretes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarLembrete(int id)
        {
            var lembrete = await _service.BuscarLembrete(id);

            if (lembrete == null)
                return BadRequest("Lembrete não registrado.");


            return Ok(lembrete);
        }

        [HttpPost]
        public async Task<IActionResult> AidicionarLembrete(LembreteRequest request)
        {
            
             var validarRequest = await _validator.ValidateAsync(request);

            if (!validarRequest.IsValid)
                return BadRequest(validarRequest.Errors);

            var lembrete = await _service.CriarLembrete(request);

            return Created("", lembrete);
             
        }

        [HttpPut]

        public async Task<IActionResult> EditarLembrete(LembreteRequest request)
        {
           
             var validarRequest = await _validator.ValidateAsync(request);

            if (!validarRequest.IsValid)
                return BadRequest(validarRequest.Errors);

            var lembrete = await _service.EditarLembrete(request);

            return Created("", lembrete);
            
        }
    }
}
