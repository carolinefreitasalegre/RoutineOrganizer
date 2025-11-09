using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class LembreteService : ILembreteService
    {
        private readonly ILembreteRepository _repository;
        private readonly IMapper _mapper;

        public LembreteService(ILembreteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LembreteResponse?> BuscarLembrete(int Id)
        {
            try
            {
                var lembrete = await _repository.BuscarLembrete(Id);
                if (lembrete == null)
                    throw new Exception("Lembrete nao registrado");
                else
                    return _mapper.Map<LembreteResponse>(lembrete);
                
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public async Task<LembreteResponse> CriarLembrete(LembreteRequest request)
        {
            try
            {
                var lembrete = new Lembrete
                {
                    Mensagem = request.Mensagem,
                    DataHora = request.DataHora,
                    Visto = request.Visto,
                    UsuarioId = request.UsuarioId,
                };

                await _repository.CriarLembrete(lembrete);

                return new LembreteResponse
                {
                    Mensagem = request.Mensagem,
                    DataHora = request.DataHora,
                    Visto = request.Visto,
                    UsuarioId = request.UsuarioId,
                };
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public async Task<LembreteResponse> EditarLembrete(LembreteRequest request)
        {
            try
            {
                var lembrete = await _repository.BuscarLembrete(request.Id);
                if (lembrete == null)
                    throw new Exception("Usuário não encontrado");

                else
                {
                    lembrete.Mensagem = request.Mensagem;
                    lembrete.DataHora = request.DataHora;
                    lembrete.Visto = request.Visto;
                    lembrete.UsuarioId = request.UsuarioId;

                    await _repository.EditarLembrete(lembrete);

                    return new LembreteResponse
                    {
                        Mensagem = request.Mensagem,
                        DataHora = request.DataHora,
                        Visto = request.Visto,
                        UsuarioId = request.UsuarioId,
                    };
                }
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public async Task<List<LembreteResponse>> TodosLembretes()
        {
            try
            {
                var lembretes = await _repository.TodosLembretes();
                if (!lembretes.Any())
                    throw new Exception("Não há lembrtes salvos");
                else
                    return _mapper.Map<List<LembreteResponse>>(lembretes);
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
