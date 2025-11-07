using Application.Dtos.Request;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace RoutineOrganizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilhoController : ControllerBase
    {
        private readonly IFilhoService _service;
        private readonly IValidator<FilhoRequest> _validator;

        public FilhoController(IFilhoService service, IValidator<FilhoRequest> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarFilhos()
        {
            var filhos = await _service.TodosFilhos();

            return Ok(filhos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarFilho(int id)
        {
            var filho = await _service.BuscarFilho(id);

            if (filho == null)
                return BadRequest("Ainda não há filhos registrados");


            return Ok(filho);
        }

        [HttpPost]
        public async Task<IActionResult> AidicionarFilho(FilhoRequest request) 
        {
            var validarRequest = await _validator.ValidateAsync(request);

            if (!validarRequest.IsValid)
                return BadRequest(validarRequest.Errors);

            var addFilho = await _service.CriarFilho(request);

            return Created("", addFilho);
        }

        [HttpPut]

        public async Task<IActionResult> EditarFilho(FilhoRequest request)
        {
            var validarRequest = await _validator.ValidateAsync(request);

            if (!validarRequest.IsValid)
                return BadRequest(validarRequest.Errors);

            var addFilho = await _service.EditarFilho(request);

            return Created("", addFilho);
        }


    }
}
