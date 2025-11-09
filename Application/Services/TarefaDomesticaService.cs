using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class TarefaDomesticaService : ITarefaDomesticaService
    {
        private readonly ITarefaDomesticaRepository _repository;
        private readonly IMapper _mapper;

        public TarefaDomesticaService(ITarefaDomesticaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TarefaResponse?> BuscarTarefaDomestica(int Id)
        {
            try
            {
                var tarefa = await _repository.BuscarTarefaDomestica(Id);

                if (tarefa == null)
                    throw new Exception("Tarefa não encontrada.");

                else
                {
                    return _mapper.Map<TarefaResponse>(tarefa);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public async Task<TarefaResponse> CriarTarefaDomestica(TarefaRequest tarefa)
        {
            var addTarefa = new TarefaDomestica
            {
                Descricao = tarefa.Descricao,
                Prioridade = tarefa.Prioridade,
                DataPrevista = tarefa.DataPrevista,
                Status = tarefa.Status,
                UsuarioId = tarefa.UsuarioId,
            };

            await _repository.CriarTarefaDomestica(addTarefa);

            return new TarefaResponse
            {
                Descricao = tarefa.Descricao,
                Prioridade = tarefa.Prioridade,
                DataPrevista = tarefa.DataPrevista,
                Status = tarefa.Status,
                UsuarioId = tarefa.UsuarioId,
            };
        }

        public async Task<TarefaResponse> EditarTarefaDomestica(TarefaRequest tarefa)
        {
            try
            {
                var editTarefa = await _repository.BuscarTarefaDomestica(tarefa.Id);
                if (editTarefa == null)
                    throw new Exception("Trefa não encontrada.");
                else
                {
                    editTarefa.Descricao = tarefa.Descricao;
                    editTarefa.Prioridade = tarefa.Prioridade;
                    editTarefa.DataPrevista = tarefa.DataPrevista;
                    editTarefa.Status = tarefa.Status;
                    editTarefa.UsuarioId = tarefa.UsuarioId;

                    await _repository.EditarTarefaDomestica(editTarefa);

                    return new TarefaResponse
                    {
                        Descricao = tarefa.Descricao,
                        Prioridade = tarefa.Prioridade,
                        DataPrevista = tarefa.DataPrevista,
                        Status = tarefa.Status,
                        UsuarioId = tarefa.UsuarioId,
                    };
                }
            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
            
        }

        public async Task<List<TarefaResponse>> TodosTarefas()
        {
            var tarefas = await _repository.TodosTarefas();
            if (!tarefas.Any())
                throw new Exception("Não há tarefaas registradas no momento.");
            else
            {
                return _mapper.Map<List<TarefaResponse>>(tarefas);
            }
                
        }
    }
}
