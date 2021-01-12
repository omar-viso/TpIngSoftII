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
using TpIngSoftII.Models.Constantes;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class ProyectoService : EntityAppServiceBase<Proyecto, ProyectoDto>, IProyectoService
    {
        private readonly IEntityBaseRepository<HorasTrabajadas> horasTrabajadasRepository;
        private readonly IEntityBaseRepository<Perfil> perfilRepository;
        private readonly IEntityBaseRepository<Empleado> empleadoRepository;
        private readonly IEntityBaseRepository<EscalaAumentoxAntiguedad> escalaAumentoxAntiguedad;
        private readonly IEntityBaseRepository<EscalaAumentoxPerfil> escalaAumentoxPerfil;
        private readonly IEntityBaseRepository<EscalaAumentoxHora> escalaAumentoxhora;

        private readonly IEmpleadoService empleadoService;

        public ProyectoService(IEntityBaseRepository<Proyecto> entityRepository,
            IEntityBaseRepository<HorasTrabajadas> horasTrabajadasRepository,
            IEntityBaseRepository<Perfil> perfilRepository,
            IEntityBaseRepository<Empleado> empleadoRepository,
            IEntityBaseRepository<EscalaAumentoxAntiguedad> escalaAumentoxAntiguedad,
            IEntityBaseRepository<EscalaAumentoxPerfil> escalaAumentoxPerfil,
            IEntityBaseRepository<EscalaAumentoxHora> escalaAumentoxhora,
            IUnitOfWork unitOfWork,
            IEmpleadoService empleadoService, 
            IAppContext appContext) : base(entityRepository, unitOfWork, appContext)
        {
            this.horasTrabajadasRepository = horasTrabajadasRepository;
            this.perfilRepository = perfilRepository;
            this.empleadoRepository = empleadoRepository;
            this.escalaAumentoxAntiguedad = escalaAumentoxAntiguedad;
            this.escalaAumentoxPerfil = escalaAumentoxPerfil;
            this.escalaAumentoxhora = escalaAumentoxhora;

            this.empleadoService = empleadoService;
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
            var horasTrabajadasProyecto = this.horasTrabajadasRepository.AllIncludingAsNoTracking().Where(x => x.ProyectoID == proyectoID && x.HorasTrabajadasEstadoID ==2);
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

        public decimal Liquidacion(int empleadoID, DateTime desde, DateTime hasta)
        {
            decimal costoLiquidacion = 0;
            Empleado empleadoTmp = new Empleado();
            //Obtengo la cantidad de horas trabajadas por tipo de perfil por empleado y la multipluco por el valor perfil
            desde = desde.Date;
            hasta = hasta.Date;
            var empleadoTemp = this.empleadoRepository.AllIncludingAsNoTracking(x => x.Perfiles).Where(x => x.ID == empleadoID);
            if (empleadoTemp.Any())
            {
                empleadoTmp = empleadoTemp.FirstOrDefault();
                if (!empleadoTmp.Perfiles.Any()) throw new Exception("No existe perfil para el empleado indicado");
            }
            else
            {
                throw new Exception("No existe el empleado indicado");
            }

            decimal horasTotales = 0;
            int cantPerfiles = 0;
            //decimal horasOB = 0;
            //Obtengo todos los perfiles del empleado

            //Para cada perfil obtengo la cantidad de horas trabajadas de ese empleado adeudadas en un periodo de tiempo
            foreach (EmpleadoPerfil empleadoPerfil in empleadoTmp.Perfiles)
            {
                var horasTrabajadasPerfilEmpleado = this.horasTrabajadasRepository.AllIncludingAsNoTracking(x => x.Tarea,
                                                                                                        x => x.Tarea.EmpleadoPerfil)
                                                                                .Where(x => 
                                                                                       x.Tarea.EmpleadoPerfil.PerfilID == empleadoPerfil.PerfilID &&
                                                                                       x.Tarea.EmpleadoPerfil.EmpleadoID == empleadoID &&
                                                                                       DbFunctions.TruncateTime(x.Fecha) >= desde && DbFunctions.TruncateTime(x.Fecha) <= hasta &&
                                                                                       x.HorasTrabajadasEstadoID == Const.HoraTrabajadaEstado.Adeudada);
                var horasTrabajadasPerfilEmpleadoOB = horasTrabajadasPerfilEmpleado.Where(x => x.EsOB == true);

                decimal totalHorasTrabajadasPerfilEmpleado = 0;
                if (horasTrabajadasPerfilEmpleado.Any())
                {
                    totalHorasTrabajadasPerfilEmpleado = horasTrabajadasPerfilEmpleado.Sum(x => x.CantHoras);
                    //foreach (var hsProyecto in horasTrabajadasPerfilEmpleado)
                    //{
                    //    totalHorasTrabajadasPerfil += hsProyecto.CantHoras;
                    //}
                }
                decimal totalHorasTrabajadasPerfilEmpleadoOB = 0;
                if (horasTrabajadasPerfilEmpleadoOB.Any())
                {
                    totalHorasTrabajadasPerfilEmpleadoOB = horasTrabajadasPerfilEmpleadoOB.Sum(x => x.CantHoras);
                }
                decimal totalHorasTrabajadasPerfilEmpleadoSinOB = totalHorasTrabajadasPerfilEmpleado - totalHorasTrabajadasPerfilEmpleadoOB;
                //Calculamos el costo = las horas trabajadas que no son OB x el valor del perfil
                costoLiquidacion += empleadoPerfil.Perfil.ValorHorario * totalHorasTrabajadasPerfilEmpleadoSinOB;
                //Calculamos el costo = las horas trabajadas que  son OB x el valor del perfil(se pagan al 50%)
                costoLiquidacion += empleadoPerfil.Perfil.ValorHorario * totalHorasTrabajadasPerfilEmpleadoOB*50/100;
                
            }

            cantPerfiles = empleadoTmp.Perfiles.Count;


            //existe una escala en la que se indica un porcentaje de aumento x hora

            // ordenamos la escala de mayor a menor
            var escalaxhora=  this.escalaAumentoxhora.AllIncludingAsNoTracking().OrderByDescending(escalaHoras => escalaHoras.LimiteHoras);
            // tomamos la prmer escala que cumpla con la condicion
            var escalaAumentoAplica = escalaxhora.FirstOrDefault(x => x.LimiteHoras <= horasTotales);
            // aplicamos el aumento x hora
            costoLiquidacion += costoLiquidacion * escalaAumentoAplica.PorcentajeAumento / 100;

            //si cumplio funciones en mas de un perfil tambien tendra un porcentaje de aumento
            var escalaxperfil = this.escalaAumentoxPerfil.AllIncludingAsNoTracking().OrderByDescending(escalaPerfil => escalaPerfil.LimitecantPerfiles);
            // tomamos la prmer escala que cumpla con la condicion
            var escalaAumentoPerfilAplica = escalaxhora.FirstOrDefault(x => x.LimiteHoras <= cantPerfiles);
            // aplicamos el aumento x hora
            costoLiquidacion += costoLiquidacion * escalaAumentoPerfilAplica.PorcentajeAumento / 100;


            //Habra una escala de incremento en los valores horas por antiguedad
            var escalaXantiguedad = this.escalaAumentoxAntiguedad.AllIncludingAsNoTracking().OrderByDescending(escalaAntiguedad => escalaAntiguedad.Limiteanios);
            // tomamos la prmer escala que cumpla con la condicion
            decimal antiguedad = empleadoService.Antiguedad(empleadoID);
            var escalaXantiguedadAplica = escalaXantiguedad.FirstOrDefault(x => x.Limiteanios <= antiguedad);
            // aplicamos el aumento x hora
            costoLiquidacion += costoLiquidacion * escalaXantiguedadAplica.PorcentajeAumento / 100;

            return costoLiquidacion;
        }
    }
}
