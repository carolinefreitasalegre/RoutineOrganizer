using Application.Dtos.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<Filho, FilhoResponse>();
            CreateMap<Lembrete, LembreteResponse>();
            CreateMap<Rotina, RotinaResponse>();
            CreateMap<TarefaDomestica, TarefaResponse>();
        }
    }
}
