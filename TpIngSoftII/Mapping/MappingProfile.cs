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
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente.Nombre));
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<EmpleadoDto, Empleado>().ReverseMap();
            CreateMap<TareaDto, Tarea>().ReverseMap();
            CreateMap<PerfilDto, Perfil>().ReverseMap();
            CreateMap<HorasTrabajadasDto, HorasTrabajadas>();
        }
    }
}
