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
        private readonly IEntityBaseRepository<EscalaHoraOB> escalaHoraOB;
        private readonly IEntityBaseRepository<ProyectoEstado> proyectoEstadoRepository;

        private readonly IEmpleadoService empleadoService;
        private readonly IHorasTrabajadasService horasTrabajadasService;

        public ProyectoService(IEntityBaseRepository<Proyecto> entityRepository,
            IEntityBaseRepository<HorasTrabajadas> horasTrabajadasRepository,
            IEntityBaseRepository<Perfil> perfilRepository,
            IEntityBaseRepository<Empleado> empleadoRepository,
            IEntityBaseRepository<EscalaAumentoxAntiguedad> escalaAumentoxAntiguedad,
            IEntityBaseRepository<EscalaAumentoxPerfil> escalaAumentoxPerfil,
            IEntityBaseRepository<EscalaAumentoxHora> escalaAumentoxhora,
            IEntityBaseRepository<EscalaHoraOB> escalaHoraOB,
            IUnitOfWork unitOfWork,
            IEmpleadoService empleadoService,
            IHorasTrabajadasService horasTrabajadasService,
            IAppContext appContext,
            IEntityBaseRepository<ProyectoEstado> proyectoEstadoRepository) : base(entityRepository, unitOfWork, appContext)
        {
            this.horasTrabajadasRepository = horasTrabajadasRepository;
            this.perfilRepository = perfilRepository;
            this.empleadoRepository = empleadoRepository;
            this.escalaAumentoxAntiguedad = escalaAumentoxAntiguedad;
            this.escalaAumentoxPerfil = escalaAumentoxPerfil;
            this.escalaAumentoxhora = escalaAumentoxhora;
            this.proyectoEstadoRepository = proyectoEstadoRepository;
            this.escalaHoraOB = escalaHoraOB;

            this.empleadoService = empleadoService;
            this.horasTrabajadasService = horasTrabajadasService;
        }

        public IEnumerable<ProyectoEstadoDto> ProyectoEstados()
        {
            var proyectoEstados = this.proyectoEstadoRepository.AllIncludingAsNoTracking();
            var proyectoEstadosDto = Mapper.Map<IEnumerable<ProyectoEstado>, IEnumerable<ProyectoEstadoDto>>(proyectoEstados);

            return proyectoEstadosDto;
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
        /* Funcion que Paga las Horas y devuelve el monto, cantidad de horas totales, cantidad de hs ob, cantidad de tareas y cantidad de proyectos que liquida */
        public LiquidacionDto Liquidacion(SolicitaLiquidacionDto dto)
        {   // METER SCOPE PARA ROLLBACK SI ALGO PINCHA!! (para que no queden horas pagadas sin haber liquidado)
            decimal costoLiquidacion = 0;
            Empleado empleadoTmp = new Empleado();
            //Obtengo la cantidad de horas trabajadas por tipo de perfil por empleado y la multipluco por el valor perfil
            var desde = dto.Desde.Date;
            var hasta = dto.Hasta.Date;
            var empleadoTemp = this.empleadoRepository.AllIncludingAsNoTracking(x => x.Perfiles).Where(x => x.ID == dto.EmpleadoID);
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
            var valorEscalaHsOB = escalaHoraOB.AllIncludingAsNoTracking().LastOrDefault().PorcentajeAumento;
            /* variables para usar en la rta */
            decimal cantidadHsNoOBLiquidados = 0;
            decimal cantidadHsOBLiquidados = 0;
            var cantidadProyectosLiquidados = 0;
            var cantidadTareasLiquidados = 0;
            decimal? porcentajeAplicadoAntiguedad = null;
            decimal? porcentajeAplicadoCantidadHoras = null;
            decimal? porcentajeAplicadoCantidadPerfiles = null;

            //decimal horasOB = 0;
            //Obtengo todos los perfiles del empleado

            //Para cada perfil obtengo la cantidad de horas trabajadas de ese empleado adeudadas en un periodo de tiempo
            foreach (EmpleadoPerfil empleadoPerfil in empleadoTmp.Perfiles)
            {
                var horasTrabajadasPerfilEmpleado = this.horasTrabajadasRepository.AllIncludingAsNoTracking(x => x.Tarea,
                                                                                                        x => x.Tarea.EmpleadoPerfil)
                                                                                .Where(x => 
                                                                                       x.Tarea.EmpleadoPerfil.PerfilID == empleadoPerfil.PerfilID &&
                                                                                       x.Tarea.EmpleadoPerfil.EmpleadoID == dto.EmpleadoID &&
                                                                                       DbFunctions.TruncateTime(x.Fecha) >= desde && DbFunctions.TruncateTime(x.Fecha) <= hasta &&
                                                                                       x.HorasTrabajadasEstadoID == Const.HoraTrabajadaEstado.Adeudada);
                /* Seteamos la cantidad de proyectos que se van a liquidar hs */
                cantidadProyectosLiquidados += horasTrabajadasPerfilEmpleado.Select(x => x.ProyectoID)?.Distinct()?.Count() ?? 0;
                /* Seteamos la cantidad de tareas que se van a liquidar hs */
                cantidadTareasLiquidados += horasTrabajadasPerfilEmpleado.Select(x => x.TareaID)?.Distinct()?.Count() ?? 0;

                /* Separamos las hs trabajadas OB */
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
                /* Sumo la cantidad de hs totales por perfil para incrementar hasta llegar al total de los perfiles */
                horasTotales += totalHorasTrabajadasPerfilEmpleado;

                decimal totalHorasTrabajadasPerfilEmpleadoOB = 0;
                if (horasTrabajadasPerfilEmpleadoOB.Any())
                {
                    totalHorasTrabajadasPerfilEmpleadoOB = horasTrabajadasPerfilEmpleadoOB.Sum(x => x.CantHoras);
                }
                /* Sumo la cantidad de hs OB por perfil para incrementar hasta llegar al total de los perfiles */
                cantidadHsOBLiquidados += totalHorasTrabajadasPerfilEmpleadoOB;

                decimal totalHorasTrabajadasPerfilEmpleadoSinOB = totalHorasTrabajadasPerfilEmpleado - totalHorasTrabajadasPerfilEmpleadoOB;
                
                /* Sumo la cantidad de hs NO OB por perfil para incrementar hasta llegar al total de los perfiles */
                cantidadHsNoOBLiquidados += totalHorasTrabajadasPerfilEmpleadoSinOB;
                
                //Calculamos el costo = las horas trabajadas que no son OB x el valor del perfil
                costoLiquidacion += empleadoPerfil.Perfil.ValorHorario * totalHorasTrabajadasPerfilEmpleadoSinOB;
                
                //Calculamos el costo = las horas trabajadas que  son OB x el valor del perfil(se pagan al 50%)
                costoLiquidacion += empleadoPerfil.Perfil.ValorHorario * totalHorasTrabajadasPerfilEmpleadoOB * valorEscalaHsOB /100;

                /* Pasamos todas las Horas liquidadas a Pagadas */
                var horasTrabajadasPerfilEmpleadoDto = Mapper.Map<IEnumerable<HorasTrabajadas>, IEnumerable<HorasTrabajadasDto>>(horasTrabajadasPerfilEmpleado);
                foreach (var horaTrabajada in horasTrabajadasPerfilEmpleadoDto)
                {
                    /* Pagamos la hora trabajada */
                    this.horasTrabajadasService.PagarHoraTrabajada(horaTrabajada.ID);
                }
            }

            cantPerfiles = empleadoTmp.Perfiles.Count;


            //existe una escala en la que se indica un porcentaje de aumento x hora

            // ordenamos la escala de mayor a menor
            var escalaxhora=  this.escalaAumentoxhora.AllIncludingAsNoTracking().OrderByDescending(escalaHoras => escalaHoras.LimiteHoras);
            // tomamos la prmer escala que cumpla con la condicion
            var porcentajeAumentoCantHorasAplica = escalaxhora.FirstOrDefault(x => x.LimiteHoras <= horasTotales)?.PorcentajeAumento ?? 0;
            // aplicamos el aumento x hora
            if (porcentajeAumentoCantHorasAplica != 0)
            {
                // aplicamos el aumento x hora
                costoLiquidacion += costoLiquidacion * porcentajeAumentoCantHorasAplica / 100;
                /* Seteamos el Porcentaje por Antiguedad aplicado */
                porcentajeAplicadoCantidadHoras = porcentajeAumentoCantHorasAplica;
            }

            //si cumplio funciones en mas de un perfil tambien tendra un porcentaje de aumento
            var escalaxperfil = this.escalaAumentoxPerfil.AllIncludingAsNoTracking().OrderByDescending(escalaPerfil => escalaPerfil.LimitecantPerfiles);
            // tomamos la prmer escala que cumpla con la condicion
            var porcentajeAumentoPerfilAplica = escalaxhora.FirstOrDefault(x => x.LimiteHoras <= cantPerfiles)?.PorcentajeAumento ?? 0;

            if (porcentajeAumentoPerfilAplica != 0)
            {
                // aplicamos el aumento x hora
                costoLiquidacion += costoLiquidacion * porcentajeAumentoPerfilAplica / 100;
                /* Seteamos el Porcentaje por Antiguedad aplicado */
                porcentajeAplicadoAntiguedad = porcentajeAumentoPerfilAplica;
            }

            //Habra una escala de incremento en los valores horas por antiguedad
            var escalaXantiguedad = this.escalaAumentoxAntiguedad.AllIncludingAsNoTracking().OrderByDescending(escalaAntiguedad => escalaAntiguedad.Limiteanios);
            // tomamos la prmer escala que cumpla con la condicion
            int antiguedad = empleadoService.Antiguedad(dto.EmpleadoID);
            var porcentajeEscalaXantiguedadAplica = escalaXantiguedad.FirstOrDefault(x => x.Limiteanios <= antiguedad)?.PorcentajeAumento ?? 0;
            // aplicamos el aumento x hora, si el porcentaje es distinto de cero
            if (porcentajeEscalaXantiguedadAplica != 0)
            {
                costoLiquidacion += costoLiquidacion * porcentajeEscalaXantiguedadAplica / 100;
                /* Seteamos el Porcentaje por Antiguedad aplicado */
                porcentajeAplicadoAntiguedad = porcentajeEscalaXantiguedadAplica;
            }

            var perfilesExistentes = this.perfilRepository.AllIncludingAsNoTracking();
            var infoPerfilesExistentes = Mapper.Map<IEnumerable<Perfil>, IEnumerable<PerfilDto>> (perfilesExistentes);

            var rta = new LiquidacionDto
            {
                AntiguedadEmpleado = antiguedad,
                CantidadHsNoOBLiquidados = cantidadHsNoOBLiquidados,
                CantidadHsOBLiquidados = cantidadHsOBLiquidados,
                CantidadHsTotalesLiquidados = horasTotales,
                CantidadPerfiles = cantPerfiles,
                CantidadProyectosLiquidados = cantidadProyectosLiquidados,
                CantidadTareasLiquidados = cantidadTareasLiquidados,
                PorcentajeAplicadoAntiguedad = porcentajeAplicadoAntiguedad,
                PorcentajeAplicadoCantidadHoras = porcentajeAplicadoCantidadHoras,
                PorcentajeAplicadoCantidadPerfiles = porcentajeAplicadoCantidadPerfiles,
                TotalLiquidado = costoLiquidacion,
                ValoresInformativosPerfilHora = infoPerfilesExistentes,
                ValorPorcentajeDeHoraOB = valorEscalaHsOB
            };

            return rta;
        }
    }
}
