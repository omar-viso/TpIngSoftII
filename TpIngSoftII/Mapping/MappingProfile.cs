using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /* Definir los Mapeos por Cada Dto con su Entity */
            CreateMap<ProyectoDto, Proyecto>().ReverseMap()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente.Nombre))
                .ForMember(dest => dest.ProyectoEstadoDescripcion, opt => opt.MapFrom(src => src.ProyectoEstado.Descripcion));
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<EmpleadoDto, Empleado>().ReverseMap();
            CreateMap<EmpleadoPerfilDto, EmpleadoPerfil>().ReverseMap()
                .ForMember(dest => dest.EmpleadoNombre, opt => opt.MapFrom(src => src.Empleado.Nombre))
                .ForMember(dest => dest.TipoPerfilDescripcion, opt => opt.MapFrom(src => src.Perfil.PerfilTipo.Descripcion));
            CreateMap<TareaDto, Tarea>().ReverseMap()
                .ForMember(dest => dest.EmpleadoPerfilDescripcionPerfil, opt => opt.MapFrom(src => src.EmpleadoPerfil.Perfil.PerfilTipo.Descripcion))
                .ForMember(dest => dest.EmpleadoPerfilNombreEmplado, opt => opt.MapFrom(src => src.EmpleadoPerfil.Empleado.Nombre))
                .ForMember(dest => dest.ProyectoNombre, opt => opt.MapFrom(src => src.Proyecto.Nombre));
            CreateMap<PerfilTipoDto, PerfilTipo>().ReverseMap();
            CreateMap<PerfilDto, Perfil>().ReverseMap()
                .ForMember(dest => dest.PerfilTipoDescripcion, opt => opt.MapFrom(src => src.PerfilTipo.Descripcion));
            CreateMap<HorasTrabajadasDto, HorasTrabajadas>().ReverseMap()
                .ForMember(dest => dest.HorasTrabajadasEstadoDescripcion, opt => opt.MapFrom(src => src.HorasTrabajadasEstado.Descripcion));
            CreateMap<EscalaAumentoxAntiguedadDto, EscalaAumentoxAntiguedad>().ReverseMap();
            CreateMap<EscalaAumentoxHoraDto, EscalaAumentoxHora>().ReverseMap();
            CreateMap<EscalaAumentoxPerfilDto, EscalaAumentoxPerfil>().ReverseMap();
            CreateMap<EscalaHoraOBDto, EscalaHoraOB>().ReverseMap();
            CreateMap<ProyectoEstadoDto, ProyectoEstado>().ReverseMap();
            CreateMap<HorasTrabajadasEstadoDto, HorasTrabajadasEstado>().ReverseMap();

        }
    }
}
