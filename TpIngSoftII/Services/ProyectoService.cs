using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class ProyectoService : EntityAppServiceBase<Proyecto, ProyectoDto>, IProyectoService
    {
        private readonly IEntityBaseRepository<HorasTrabajadas> horasTrabajadasRepository;
        private readonly IEntityBaseRepository<Perfil> perfilRepository;
        private readonly IEntityBaseRepository<Empleado> empleadoRepository;

        public ProyectoService(IEntityBaseRepository<Proyecto> entityRepository,
            IEntityBaseRepository<HorasTrabajadas> horasTrabajadasRepository, 
            IEntityBaseRepository<Perfil> perfilRepository,
            IEntityBaseRepository<Empleado> empleadoRepository,
            IUnitOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
            this.horasTrabajadasRepository = horasTrabajadasRepository;
            this.perfilRepository = perfilRepository;
            this.empleadoRepository = empleadoRepository;
        }

        public decimal HorasTrabajadasPorProyecto(int proyectoID)
        {   //Veo si el proyecto con ese ID existe
            var proyectoTemp = this.entityRepository.AllIncludingAsNoTracking().Where(x => x.ID == proyectoID);
            if (proyectoTemp.Any())
            {
               throw new Exception("No existe proyecto para el id indicado");
            }
            var horasTrabajadasProyecto = this.horasTrabajadasRepository.AllIncludingAsNoTracking().Where(x => x.ProyectoID == proyectoID);
            decimal totalHorasTrabajadas=0;
            if (horasTrabajadasProyecto.Any())
            {
                foreach(var hsProyecto in horasTrabajadasProyecto)
                {
                    totalHorasTrabajadas += hsProyecto.CantHoras;
                }
            }
            return totalHorasTrabajadas;
        }

        public decimal HorasTrabajadasPorProyectoPorPerfil(int proyectoID, int perfilID)
        {   //Veo si el proyecto con ese ID existe
            var proyectoTempSql = this.entityRepository.AllIncludingAsNoTracking(x => x.Tareas,
                                                                                 x => x.Tareas.Select(y => y.EmpleadoPerfil))
                                                                                 .Where(x => x.ID == proyectoID);
            var proyectoTemp = proyectoTempSql.FirstOrDefault();
            if (proyectoTemp == null)
            {
                throw new Exception("No existe proyecto para el id indicado");
            }
            var perfilTemp = this.perfilRepository.AllIncludingAsNoTracking().Where(x => x.ID == perfilID);
            if (perfilTemp.Any())
            {
                throw new Exception("No existe perfil para el id indicado");
            }
            if (proyectoTemp.Tareas == null) throw new Exception("Aún no existen tareas para el Proyecto indicado");
            //if (proyectoTemp.Tareas.Select(x => x.EmpleadoPerfil != null).Any()) throw new Exception("Aún no existen tareas para el Proyecto indicado");

            var horasTrabajadasProyectoPerfil = this.horasTrabajadasRepository.AllIncludingAsNoTracking(x => x.Tarea,
                                                                                                        x => x.Tarea.EmpleadoPerfil)
                                                                                .Where(x => x.ProyectoID == proyectoID &&
                                                                                       x.Tarea.EmpleadoPerfil.PerfilID == perfilID);
            decimal totalHorasTrabajadasProyectoPerfil = 0;
            if (horasTrabajadasProyectoPerfil.Any())
            {
                foreach (var hsProyectoPerfil in horasTrabajadasProyectoPerfil)
                {
                    totalHorasTrabajadasProyectoPerfil += hsProyectoPerfil.CantHoras;
                }
            }
            return totalHorasTrabajadasProyectoPerfil;
        }

        public decimal HorasTrabajadasPorProyectoPorPerfilPorEmpleado(int proyectoID, int perfilID,int empleadoID,DateTime desde,DateTime hasta)
        {   //Veo si el proyecto con ese ID existe
            var proyectoTempSql = this.entityRepository.AllIncludingAsNoTracking(x => x.Tareas,
                                                                                 x => x.Tareas.Select(y => y.EmpleadoPerfil))
                                                                                 .Where(x => x.ID == proyectoID);
            var proyectoTemp = proyectoTempSql.FirstOrDefault();
            if (proyectoTemp == null)
            {
                throw new Exception("No existe proyecto para el id indicado");
            }
            var perfilTemp = this.perfilRepository.AllIncludingAsNoTracking().Where(x => x.ID == perfilID);
            if (perfilTemp.Any())
            {
                throw new Exception("No existe perfil para el id indicado");
            }
            var empleadoTemp = this.empleadoRepository.AllIncludingAsNoTracking().Where(x => x.ID == empleadoID);
            if (empleadoTemp.Any())
            {
                throw new Exception("No existe perfil para el id indicado");
            }
            if (proyectoTemp.Tareas == null) throw new Exception("Aún no existen tareas para el Proyecto indicado");
            //if (proyectoTemp.Tareas.Select(x => x.EmpleadoPerfil != null).Any()) throw new Exception("Aún no existen tareas para el Proyecto indicado");

            desde = desde.Date;
            hasta = hasta.Date;

            var horasTrabajadasProyectoPerfilEmpleado = this.horasTrabajadasRepository.AllIncludingAsNoTracking(x => x.Tarea,
                                                                                                        x => x.Tarea.EmpleadoPerfil)
                                                                                .Where(x => x.ProyectoID == proyectoID &&
                                                                                       x.Tarea.EmpleadoPerfil.PerfilID == perfilID &&
                                                                                       x.Tarea.EmpleadoPerfil.EmpleadoID == empleadoID &&
                                                                                       DbFunctions.TruncateTime(x.Fecha) >= desde && DbFunctions.TruncateTime(x.Fecha) <= hasta);
            decimal totalHorasTrabajadasProyectoPerfilEmpleado = 0;
            if (horasTrabajadasProyectoPerfilEmpleado.Any())
            {
                foreach (var hsProyectoPerfil in horasTrabajadasProyectoPerfilEmpleado)
                {
                    totalHorasTrabajadasProyectoPerfilEmpleado += hsProyectoPerfil.CantHoras;
                }
            }
            return totalHorasTrabajadasProyectoPerfilEmpleado;
        }

        //Por cada proyecto se desea conocer las horas adeudadas
        public decimal ObtenerHorasAdeudadasPorProyecto(int proyectoID)
        {
            //Veo si el proyecto con ese ID existe
            var proyectoTemp = this.entityRepository.AllIncludingAsNoTracking().Where(x => x.ID == proyectoID);
            if (proyectoTemp == null)
            {
                throw new Exception("No existe proyecto para el id indicado");
            }
            //HorasTrabajadasEstadoID == 2 (adeudadas)
            var horasTrabajadasProyecto = this.horasTrabajadasRepository.All.Where(x => x.ProyectoID == proyectoID && x.HorasTrabajadasEstadoID ==2);
            decimal totalHorasTrabajadas = 0;
            if (horasTrabajadasProyecto.Any())
            {
                foreach (var hsProyecto in horasTrabajadasProyecto)
                {
                    totalHorasTrabajadas += hsProyecto.CantHoras;
                }
            }
            return totalHorasTrabajadas;
        }
        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */

    }
}
