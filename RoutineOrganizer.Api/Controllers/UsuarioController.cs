using Application.Dtos.Request;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace RoutineOrganizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IValidator<UsuarioRequest> _validator;
        private readonly IUsuarioService _service;

        public UsuarioController(IValidator<UsuarioRequest> validator, IUsuarioService service)
        {
            _validator = validator;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario(UsuarioRequest request)
        {
            var validadrResultado = await _validator.ValidateAsync(request);

            if (!validadrResultado.IsValid)
                return BadRequest(validadrResultado.Errors);

            var usuario = await _service.CriarUsuario(request);

            return Created("", usuario);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _service.TodosUsuarios();

            return Ok(usuarios);
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(UsuarioRequest request)
        {
            var usuario = await _service.BuscarUsuario(request.Id);
            if (usuario == null)
                return BadRequest("Usuário não encontrado");
            

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.TipoPlano = request.TipoPlano;

            var validar = await _validator.ValidateAsync(request);

            if (!validar.IsValid)
                return BadRequest(validar.Errors);

            var usuarioEditado = await _service.EditarUsuario(request);

            return Created("", request);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> BuscarUsuario(int Id)
        {
            var usuario = await _service.BuscarUsuario(Id);

            if (usuario == null)
                return BadRequest("Usuário não encontrado.");

            return Ok(usuario);
        }
    }
}
