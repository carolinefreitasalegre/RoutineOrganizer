using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse?> BuscarUsuario(int Id)
        {
            try
            {
                var usuario = await _repository.BuscarUsuario(Id);
                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");
                else
                {
                    return _mapper.Map<UsuarioResponse>(usuario);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
            

        }

        public async Task<UsuarioResponse> CriarUsuario(UsuarioRequest usuario)
        {
            try
            {
                var novoUsuario = new Usuario
                {
                    Nome = usuario.Nome.ToLower(),
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    TipoPlano = usuario.TipoPlano
                };

                var verificarEmail = await _repository.BuscarPorEmail(novoUsuario.Email);
                if (verificarEmail == null)
                {
                    await _repository.CriarUsuario(novoUsuario);

                    return new UsuarioResponse
                    {
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        TipoPlano = usuario.TipoPlano
                    };
                }

                else
                    throw new Exception("Email já cadastrado");
                                   
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }          
        }

        public async Task<UsuarioResponse> EditarUsuario(UsuarioRequest usuario)
        {
            try
            {
                var editarUsuario = await _repository.BuscarUsuario(usuario.Id);

                if (editarUsuario == null)
                    throw new Exception("Usuário não encontrado");

                else
                {
                    editarUsuario.Nome = usuario.Nome;
                    editarUsuario.Email = usuario.Email;
                    editarUsuario.Senha = usuario.Senha;
                    editarUsuario.TipoPlano = usuario.TipoPlano;

                    await _repository.EditarUsuario(editarUsuario);

                    return new UsuarioResponse
                    {
                        Nome = editarUsuario.Nome,
                        Email = editarUsuario.Email,
                        TipoPlano = editarUsuario.TipoPlano
                    };

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UsuarioResponse>> TodosUsuarios()
        {
            try
            {
                var usuarios = await _repository.TodosUsuarios();
                if (!usuarios.Any())
                    throw new Exception("Não há usuários salvos no momento!.");
                else
                {
                    return _mapper.Map<List<UsuarioResponse>>(usuarios);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
