using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class FilhoService : IFilhoService
    {
        private readonly IFilhoRepository _repository;
        private readonly IMapper _mapper;

        public FilhoService(IFilhoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FilhoResponse?> BuscarFilho(int Id)
        {
            try
            {
                var filho = await _repository.BuscarFilho(Id);

                if (filho == null)
                    throw new Exception("Usuário não encontrado.");

                var reposta = _mapper.Map<FilhoResponse>(filho);

                return reposta;

            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public async Task<FilhoResponse> CriarFilho(FilhoRequest request)
        {
            var addFilho = new Filho
            {
                Nome = request.Nome,
                DataNascimento = request.DataNascimento,
                UsuarioId = request.UsuarioId,

            };

             await _repository.CriarFilho(addFilho);

            return new FilhoResponse
            {
                Nome = request.Nome,
                DataNascimento = request.DataNascimento
            };

        }

        public async Task<FilhoResponse> EditarFilho(FilhoRequest request)
        {
            try
            {
                var filho = await _repository.BuscarFilho(request.Id);

                if (filho == null)
                    throw new Exception("Usuário não encontrado.");
                else
                {
                    filho.Nome = request.Nome;
                    filho.DataNascimento = request.DataNascimento;
                    filho.UsuarioId = request.UsuarioId;

                    await _repository.EditarFilho(filho);

                    return new FilhoResponse
                    {
                        Nome = request.Nome,
                        DataNascimento = request.DataNascimento
                    };
                }                   
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FilhoResponse>> TodosFilhos()
        {
            try
            {
                var filhos = await _repository.TodosFilhos();

                if (!filhos.Any())
                    throw new Exception("Ainda não há registro de filhos");

                else
                    return _mapper.Map<List<FilhoResponse>>(filhos);

            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
