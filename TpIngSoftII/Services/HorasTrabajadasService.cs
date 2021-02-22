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
using TpIngSoftII.Models.Constantes;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class HorasTrabajadasService : EntityAppServiceBase<HorasTrabajadas, HorasTrabajadasDto>, IHorasTrabajadasService
    {
        private bool actualizarHsOBTareaFlag = false;
        private bool pagandoFlag = false;

        private readonly IEntityBaseRepository<Tarea> tareaRepository;
        private readonly IEntityBaseRepository<HorasTrabajadasEstado> horasTrabajadasEstadoRepository;
        private readonly ITareaService tareaService;

        public HorasTrabajadasService(IEntityBaseRepository<HorasTrabajadas> entityRepository,
                                      IUnitOfWork unitOfWork,
                                      IAppContext appContext,
                                      IEntityBaseRepository<Tarea> tareaRepository,
                                      IEntityBaseRepository<HorasTrabajadasEstado> horasTrabajadasEstadoRepository,
                                      ITareaService tareaService) : base(entityRepository, unitOfWork, appContext)
        {
            this.tareaRepository = tareaRepository;
            this.horasTrabajadasEstadoRepository = horasTrabajadasEstadoRepository;
            this.tareaService = tareaService;
        }

        public IEnumerable<HorasTrabajadasEstadoDto> GetHorasTrabajadasEstado()
        {
            var entity = this.horasTrabajadasEstadoRepository.AllIncludingAsNoTracking();
            var estadosDto = Mapper.Map<IEnumerable<HorasTrabajadasEstado>, IEnumerable<HorasTrabajadasEstadoDto>> (entity);
            return estadosDto;
        }

        public override HorasTrabajadasDto Update(HorasTrabajadasDto dto)
        {
            var tmp = dto;

            if (!actualizarHsOBTareaFlag)
            {
                dto.Fecha = DateTime.Now;
                this.ValidacionesUpdate(dto);
            } else
            {

            }

            return tmp;
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        private void ValidacionesUpdate(HorasTrabajadasDto dto)
        {
            if (dto.CantHoras < 0) throw new System.ArgumentException("La cantidad de horas no puede ser negativo");
            if (dto.CantHoras > 10) throw new System.ArgumentException("La cantidad de horas no puede ser superior a 10 horas");

            //if (dto.Fecha == null || dto.Fecha == DateTime.MinValue) throw new System.ArgumentException("La Fecha es obligatoria");
            if (dto.ProyectoID == 0) throw new System.ArgumentException("El id de proyecto es obligatorio");
            if (dto.TareaID == 0) throw new System.ArgumentException("La id de tarea es obligatoria");
            if (dto.HorasTrabajadasEstadoID == 0) throw new System.ArgumentException("La id del estado de horas trabajadas es obligatoria");

            var registrosHsTrabajadasDelDia = this.entityRepository.AllIncludingAsNoTracking(x => x.Tarea,
                                                                                             x => x.Tarea.EmpleadoPerfil)
                                                                   .Where(x => DbFunctions.TruncateTime(x.Fecha) == DbFunctions.TruncateTime(dto.Fecha.Date)
                                                                       && x.Tarea.EmpleadoPerfil.EmpleadoID == this.appContext.EmpleadoID)
                                                                   .ToList();
 
            decimal cantHsTrabajadasDelDia = 0;
            if (registrosHsTrabajadasDelDia.Count() > 0)
            {
                cantHsTrabajadasDelDia = registrosHsTrabajadasDelDia.Select(x => x.CantHoras).Sum();
            }              
            
            /* Si se quiere cargar mas de 10hs de trabajo en un mismo dia, el sistema no lo permite */
            if (cantHsTrabajadasDelDia + dto.CantHoras > 10) throw new System.ArgumentException("No se permiten cargas de horas superiores a las 10hs diarias.");

            this.LogicaCantidadHorasTarea(dto);
        }

        private void LogicaCantidadHorasTarea(HorasTrabajadasDto dto)
        {
            decimal hsTotalesTarea;
            // esto tiene todas las horas trabajadas asociadas a la tarea q viene en el dto
            var hsTotalesTareaTmp = this.entityRepository.AllIncludingAsNoTracking()
                                                         .Where(x => x.TareaID == dto.TareaID)
                                                         .ToList();
            // si no está vacío (su largo es mayor a 0), sumo sus miembros y obtengo el total de horas, si no, lo dejo en cero
            hsTotalesTarea = (hsTotalesTareaTmp.Count() > 0) ? hsTotalesTareaTmp.Sum(x => x.CantHoras) : 0;
            // obtengo las horas estimadas de la tarea q vino en el dto
            var tarea = this.tareaRepository.AllIncludingAsNoTracking().ToList().FirstOrDefault(x => x.ID == dto.TareaID);
            var hsEstimadas = tarea.HorasEstimadas;
            // calculo las horas over budget
            var hayHsOB = dto.CantHoras + hsTotalesTarea > hsEstimadas;
            /* Variable para saber si se cargan hs OB por desdoble */
            bool seDesdoblaCarga = false;
            bool todasOB = false;
            // si hay horas over budget
            if (hayHsOB)
            {
                // preparo variables de horas ob y horas normales
                decimal hsOBACargar = 0;
                decimal hsNoOBACargar = 0;
                /* Si ya se superaron las hs totales a las estimadas, las hs a cargar son todas OB */
                if (hsTotalesTarea > hsEstimadas)
                {
                    hsOBACargar = dto.CantHoras;
                    hsNoOBACargar = 0;

                    todasOB = true;
                }
                /* Si no son todas OB hay que separar en 2 cargas */
                else
                {
                    hsOBACargar = dto.CantHoras + hsTotalesTarea - hsEstimadas;
                    hsNoOBACargar = dto.CantHoras - hsOBACargar;

                    seDesdoblaCarga = true;
                }

                /* Valido si hay que desdoblar la carga de Hs */
                if (seDesdoblaCarga)
                {
                    if (hsNoOBACargar != 0)
                    {
                        base.Update(new HorasTrabajadasDto
                        {
                            ID = 0,
                            CantHoras = hsNoOBACargar,
                            Fecha = dto.Fecha,
                            HorasTrabajadasEstadoID = dto.HorasTrabajadasEstadoID,
                            ProyectoID = dto.ProyectoID,
                            TareaID = dto.TareaID
                        });
                    }

                    if (hsOBACargar != 0)
                    {
                        HorasTrabajadasDto hsTrabajadasOBDto = new HorasTrabajadasDto
                        {
                            ID = 0,
                            CantHoras = hsOBACargar,
                            Fecha = dto.Fecha,
                            HorasTrabajadasEstadoID = dto.HorasTrabajadasEstadoID,
                            ProyectoID = dto.ProyectoID,
                            TareaID = dto.TareaID
                        };
                        /* Se cargan las hs OB */
                        hsTrabajadasOBDto = base.Update(hsTrabajadasOBDto);
                        using (var scope = new TransactionScope())
                        {
                            /* Se marcan las mismas como Hs OB */
                            var hsTrabajadasOBentity = this.entityRepository.AllIncluding()
                                                                            .ToList()
                                                                            .FirstOrDefault(x => x.ID == hsTrabajadasOBDto.ID);
                            hsTrabajadasOBentity.EsOB = true;

                            this.entityRepository.Edit(hsTrabajadasOBentity);
                            this.unitOfWork.Commit();
                            scope.Complete();
                        }

                        //if (!actualizarHsOBTareaFlag) {
                        //    var actualizarHsOB = tareaRepository.GetSingle(dto.TareaID);

                        //    actualizarHsOB.HorasOB = actualizarHsOB.HorasOB + hsOBACargar;

                        //    using (var scope = new TransactionScope())
                        //    {
                        //        tareaRepository.Edit(actualizarHsOB);
                        //        this.unitOfWork.Commit();
                        //        scope.Complete();
                        //    }

                        //    actualizarHsOBTareaFlag = false;
                        //}
                    }

                    /* Se modifican las hs para cargar las hs NO OB restantes de la carga de hora mandada */
                    dto.CantHoras = hsNoOBACargar;
                }

                if (todasOB)
                {
                    if (hsOBACargar != 0)
                    {
                        HorasTrabajadasDto hsTrabajadasOBDto = new HorasTrabajadasDto
                        {
                            ID = 0,
                            CantHoras = hsOBACargar,
                            Fecha = dto.Fecha,
                            HorasTrabajadasEstadoID = dto.HorasTrabajadasEstadoID,
                            ProyectoID = dto.ProyectoID,
                            TareaID = dto.TareaID
                        };
                        /* Se cargan las hs OB */
                        hsTrabajadasOBDto = base.Update(hsTrabajadasOBDto);
                        using (var scope = new TransactionScope())
                        {
                            /* Se marcan las mismas como Hs OB */
                            var hsTrabajadasOBentity = this.entityRepository.AllIncluding()
                                                                            .ToList()
                                                                            .FirstOrDefault(x => x.ID == hsTrabajadasOBDto.ID);
                            hsTrabajadasOBentity.EsOB = true;

                            this.entityRepository.Edit(hsTrabajadasOBentity);
                            this.unitOfWork.Commit();
                            scope.Complete();
                        }
                    }

                    //if (!actualizarHsOBTareaFlag)
                    //{
                    //    var actualizarHsOB = tareaRepository.GetSingle(dto.TareaID);

                    //    actualizarHsOB.HorasOB = actualizarHsOB.HorasOB + hsOBACargar;

                    //    using (var scope = new TransactionScope())
                    //    {
                    //        tareaRepository.Edit(actualizarHsOB);
                    //        this.unitOfWork.Commit();
                    //        scope.Complete();
                    //    }

                    //    actualizarHsOBTareaFlag = false;
                    //}
                    /* Se modifican las hs para cargar las hs NO OB restantes de la carga de hora mandada */
                    dto.CantHoras = hsNoOBACargar;
                }
            } 
            else
            {
                if (dto.CantHoras != 0)
                {
                    base.Update(new HorasTrabajadasDto
                    {
                        ID = 0,
                        CantHoras = dto.CantHoras,
                        Fecha = dto.Fecha,
                        HorasTrabajadasEstadoID = dto.HorasTrabajadasEstadoID,
                        ProyectoID = dto.ProyectoID,
                        TareaID = dto.TareaID
                    });
                }
            }
        }

        /* Metodo para Front, antes de llamar al Update para alertar si hay HS OB en la carga a realizar */
        public decimal CantidadHsOB(HorasTrabajadasDto dto)
        {
            var hsTotalesTareaTmp = this.entityRepository.AllIncludingAsNoTracking()
                                          .Where(x => x.TareaID == dto.TareaID)
                                          .ToList();

            var hsTotalesTarea = (hsTotalesTareaTmp != null) ? hsTotalesTareaTmp.Sum(x => x.CantHoras) : 0;

            var tarea = this.tareaRepository.AllIncludingAsNoTracking().FirstOrDefault(x => x.ID == dto.TareaID);
            var hsEstimadas = tarea.HorasEstimadas;

            var hayHsOB = dto.CantHoras + hsTotalesTarea > hsEstimadas;

            decimal hsOBACargar = 0;

            if (hayHsOB)
            {

                /* Si ya se superaron las hs totales a las estimadas, las hs a cargar son todas OB */
                if (hsTotalesTarea > hsEstimadas)
                {
                    hsOBACargar = dto.CantHoras;
                }
                else
                {
                    hsOBACargar = dto.CantHoras + hsTotalesTarea - hsEstimadas;
                }
            }
            return hsOBACargar;
        }
        // PROBAR ESTE INFORME CUANDO NO HAY HS OB VER QUE NO ROMPA!!
        public InformeSemanalHsOBDto InformeSemanalHsOB()
        {
            var fechaDesde = DateTime.Now.AddDays(-7).Date;
            var fechaDeHoy = DateTime.Now.Date;

            var registrosHsTrabajadasOBSemanales = this.entityRepository.AllIncludingAsNoTracking(x => x.Tarea, x => x.Tarea.Proyecto)
                                                                        .Where(x => DbFunctions.TruncateTime(x.Fecha) >= DbFunctions.TruncateTime(fechaDesde) &&
                                                                                    DbFunctions.TruncateTime(x.Fecha) <= DbFunctions.TruncateTime(fechaDeHoy) && x.EsOB)
                                                                        .ToList();

            //var subTotalesHsOBporTarea = registrosHsTrabajadasOBSemanales.GroupBy(x => new { TareaID = x.TareaID })
            //                                                             .Select(TareaSubTotalHsOB => new
            //                                                             {
            //                                                                 TareadID = TareaSubTotalHsOB.Key,
            //                                                                 SubTotalHsOB = TareaSubTotalHsOB.Sum(x => x.CantHoras)
            //                                                             }).ToList();
            // VER QUE AGRUPE LA TareaID con su Subtotal de HS OB !!!!
            IEnumerable<SubtotalHsOBDto> subTotalesHsOBporTarea = registrosHsTrabajadasOBSemanales
                                                            .GroupBy(t => t.TareaID)
                                                            .SelectMany(ths => ths.Select(
                                                                TareaSubTotalHsOB => new SubtotalHsOBDto
                                                                {
                                                                    ProyectoNombre = TareaSubTotalHsOB.Tarea.Proyecto.Nombre,
                                                                    TareaID = TareaSubTotalHsOB.TareaID,
                                                                    TareaNombre = TareaSubTotalHsOB.Tarea.Nombre,
                                                                    SubtotalHsOB = ths.Sum(hs => hs.CantHoras),
                                                                }))
                                                            .OrderBy(x => x.ProyectoNombre)
                                                            .ToList();


            decimal hsTotalesOB = 0;
            if (registrosHsTrabajadasOBSemanales.Any())
            {
                hsTotalesOB = registrosHsTrabajadasOBSemanales.Select(x => x.CantHoras).Sum();
            }

            InformeSemanalHsOBDto resultado = new InformeSemanalHsOBDto
            {
                TareasSubtotalesHsOB = subTotalesHsOBporTarea,
                HsOBTotales = hsTotalesOB
            };;

            return resultado;
        }


        public void PagarHoraTrabajada(int horaTrabajadaID)
        {
            var horaTrabajada = entityRepository.GetSingle(horaTrabajadaID);
            if (horaTrabajada == null) throw new Exception("No existe la hora trabajada indicada para Pagar.");
            if (horaTrabajada.HorasTrabajadasEstadoID != Const.HoraTrabajadaEstado.Adeudada) throw new Exception("La hora trabajada indicada ya se encuentra Paga.");
            /* Si esta todo OK, se modifica a Pagada y se actualiza en BD */
            

            using (var scope = new TransactionScope())
            {
                horaTrabajada.HorasTrabajadasEstadoID = Const.HoraTrabajadaEstado.Pagada;

                this.entityRepository.Edit(horaTrabajada);
                this.unitOfWork.Commit();
                scope.Complete();
            }
        }

        private void Update2(HorasTrabajadasDto dto)
        {
            actualizarHsOBTareaFlag = true;

            this.Update(dto);
        }
    }
}
