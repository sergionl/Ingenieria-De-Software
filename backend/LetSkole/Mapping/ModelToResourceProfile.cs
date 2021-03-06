using AutoMapper;
using LetSkole.Dto;
using LetSkole.Entities;

namespace LetSkole.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        // ENTITY to DTO
        public ModelToResourceProfile()
        {
            CreateMap<User, UserDto>();
            // CreateMap<Costo, CostoResource>();
            // CreateMap<CostosOperacion, CostosOperacionResource>();
            // CreateMap<Letra, LetraResource>();
            // CreateMap<OperacionCartera, OperacionCarteraResource>();
            // CreateMap<OperacionLetra, OperacionLetraResource>();
            // CreateMap<Operacion, OperacionResource>();
            // CreateMap<Perfil, PerfilResource>();
            // CreateMap<Periodo, PeriodoResource>();
            // CreateMap<Tasa, TasaResource>();
            // CreateMap<Usuario, AuthenticationResponse>();
            // CreateMap<Usuario, UsuarioResource>();
        }
    }
}
