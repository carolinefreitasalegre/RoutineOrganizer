using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Application.Validator;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Security.AccessControl;

namespace Application.Services
{
    public class RotinaService : IRotinaService
    {
        private readonly IRotinaRepository _repository;
        private readonly IMapper _mapper;

        public RotinaService(IRotinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RotinaResponse?> BuscarRotina(int id)
        {
            try
            {
                var rotina = await _repository.BuscarRotina(id);

                if (rotina == null)
                    throw new Exception("Rotina não registrada.");

                else
                {
                    return _mapper.Map<RotinaResponse>(rotina);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }

        }

        public async Task<RotinaResponse> CriarRotina(RotinaRequest request)
        {
            var novaRotina = new Rotina
            {
                Titulo = request.Titulo,
                Horario = request.Horario,
                NotificacaoAtiva = request.NotificacaoAtiva,
                FilhoId = request.FilhoId,
            };
            await _repository.CriarRotina(novaRotina);
            
            return new RotinaResponse
            {
                Titulo = request.Titulo,
                Horario = request.Horario,
                NotificacaoAtiva = request.NotificacaoAtiva,
                FilhoId = request.FilhoId,
            };
        }

        public async Task<RotinaResponse> EditarRotina(RotinaRequest request)
        {
            try
            {
                var rotina = await _repository.BuscarRotina(request.Id);
                if (rotina == null)
                    throw new Exception("Rotina não registrada.");

                else
                {
                    rotina.Titulo = request.Titulo;
                    rotina.Horario = request.Horario;
                    rotina.NotificacaoAtiva = request.NotificacaoAtiva;
                    rotina.FilhoId = request.FilhoId;

                    await _repository.EditarRotina(rotina);

                    return new RotinaResponse
                    {
                        Titulo = request.Titulo,
                        Horario = request.Horario,
                        NotificacaoAtiva = request.NotificacaoAtiva,
                        FilhoId = request.FilhoId,
                    };
                }
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public async Task<List<RotinaResponse>> TodosRotinas()
        {
            try
            {
                var listaRotina = await _repository.TodosRotinas();
                if (!listaRotina.Any())
                    throw new Exception("Ainda não há rotina registrada.");
                else
                {
                    return _mapper.Map<List<RotinaResponse>>(listaRotina);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
            
        }
    }
}
