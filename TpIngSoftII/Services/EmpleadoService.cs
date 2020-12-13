using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class EmpleadoService : EntityAppServiceBase<Empleado, EmpleadoDto>, IEmpleadoService
    {

        public EmpleadoService(IEntityBaseRepository<Empleado> entityRepository, IUnitOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(Empleado entity, EmpleadoDto dto, bool isNew)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre)) throw new System.ArgumentException("El Nombre es obligatorio");
            if (dto.FechaIngreso == null || dto.FechaIngreso == DateTime.MinValue) throw new System.ArgumentException("La Fecha de Ingreso es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.Usuario)) throw new System.ArgumentException("El Usuario es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.Clave)) throw new System.ArgumentException("La Clave es obligatoria");

            if (dto.Perfiles != null)
            {
                if (dto.Perfiles.Count > 0)
                {

                }
            }
        }

        public bool ValidarCredenciales(LoginRequest login)
        {
            // CAMBIAR POR AllIncludinAsNoTracking!!!!
            var credencialEncontrada = this.entityRepository.AllIncluding().Any(x => x.Usuario == login.Username
                                                                                     && x.Clave == login.Password);

            return credencialEncontrada;
        }

        public decimal Antiguedad(int empleadoID)
        {
            decimal antiguedad = 0;
            var empleadoTemp = this.entityRepository.AllIncludingAsNoTracking().Where(x => x.ID == empleadoID);
            if (empleadoTemp.Any())
            {
               var empleadoTmp = empleadoTemp.FirstOrDefault();
                antiguedad = DateTime.Today.Year - empleadoTmp.FechaIngreso.Year;
            }
            return antiguedad;
        }
    }
}
