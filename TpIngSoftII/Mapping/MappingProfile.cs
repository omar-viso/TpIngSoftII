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
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Cliente.RazonSocial) ? src.Cliente.RazonSocial : src.Cliente.Nombre))                
                .ForMember(dest => dest.ProyectoEstadoDescripcion, opt => opt.MapFrom(src => src.ProyectoEstado.Descripcion));
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<EmpleadoDto, Empleado>().ReverseMap()
                .ForMember(dest => dest.RolDescripcion, opt => opt.MapFrom(src => src.Rol.Descripcion));
            CreateMap<EmpleadoPerfilDto, EmpleadoPerfil>().ReverseMap()
                .ForMember(dest => dest.EmpleadoNombre, opt => opt.MapFrom(src => src.Empleado.Nombre))
                .ForMember(dest => dest.PerfilDescripcion, opt => opt.MapFrom(src => src.Perfil.Descripcion))
                .ForMember(dest => dest.EmpleadoID, opt => opt.MapFrom(src => src.Empleado.ID))
                .ForMember(dest => dest.PerfilID, opt => opt.MapFrom(src => src.Perfil.ID));
            CreateMap<TareaDto, Tarea>().ReverseMap()
                .ForMember(dest => dest.EmpleadoPerfilDescripcion, opt => opt.MapFrom(src => src.EmpleadoPerfil.Perfil.Descripcion))
                .ForMember(dest => dest.EmpleadoPerfilNombreEmplado, opt => opt.MapFrom(src => src.EmpleadoPerfil.Empleado.Nombre))
                .ForMember(dest => dest.ProyectoNombre, opt => opt.MapFrom(src => src.Proyecto.Nombre));
            CreateMap<PerfilDto, Perfil>().ReverseMap();
            CreateMap<HorasTrabajadasDto, HorasTrabajadas>().ReverseMap()
                .ForMember(dest => dest.HorasTrabajadasEstadoDescripcion, opt => opt.MapFrom(src => src.HorasTrabajadasEstado.Descripcion));
            CreateMap<EscalaAumentoxAntiguedadDto, EscalaAumentoxAntiguedad>().ReverseMap();
            CreateMap<EscalaAumentoxHoraDto, EscalaAumentoxHora>().ReverseMap();
            CreateMap<EscalaAumentoxPerfilDto, EscalaAumentoxPerfil>().ReverseMap();
            CreateMap<EscalaHoraOBDto, EscalaHoraOB>().ReverseMap();
            CreateMap<ProyectoEstadoDto, ProyectoEstado>().ReverseMap();
            CreateMap<HorasTrabajadasEstadoDto, HorasTrabajadasEstado>().ReverseMap();
            CreateMap<RolDto, Rol>().ReverseMap()
                .ForMember(dest => dest.RolDescripcion, opt => opt.MapFrom(src => src.Descripcion));

        }
    }
}
