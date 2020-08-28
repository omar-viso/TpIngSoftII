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
    public class ProyectoService : EntityAppServiceBase<Proyecto, ProyectoDto>, IProyectoService
    {
        //protected readonly IUnitOfWork unitOfWork;
        /*  VER TODO ESTE ARCHIVO !!!! */
        //private readonly IEntityBaseRepository<Proyecto> proyectoRepository;

        //public ProyectoService(IUnitOfWork unitOfWork,
        //    IEntityBaseRepository<Proyecto> proyectoRepository)
        public ProyectoService(IUnitOfWork unitOfWork, IEntityBaseRepository<Proyecto> entityRepository) : base(entityRepository, unitOfWork)
        {
            //this.proyectoRepository = entityRepository;
        }

        public override IEnumerable<ProyectoDto> GetAll()
        {
            var query = this.entityRepository.GetAll();
            var entities = query.ToList();
            IEnumerable<ProyectoDto> dtos = Mapper.Map<IEnumerable<Proyecto>, IEnumerable<ProyectoDto>>(entities);

            return dtos;
        }
        /*
        public override IEnumerable<ProyectoDto> GetById(int id)
        {
            var enti = this.entityRepository.GetSingle(id);
            var dtos = Mapper.Map<IEnumerable<Proyecto>, IEnumerable<ProyectoDto>>(enti);

            return dtos;
        }
        
        public virtual void DeleteById(int id)
        {
            using (var scope = new TransactionScope())
            {
                this.ValidarEntityDeleting(id);
                this.entityRepository.DeleteById(id);
                this.unitOfWork.Commit(); // aca commitear el borrado en base
                scope.Complete();
            }
        }
        */
        public override ProyectoDto Update(ProyectoDto dto)
        {
           using (var scope = new TransactionScope())
           {
                Proyecto entity = null;
                entity = Mapper.Map<ProyectoDto, Proyecto>(dto);
                var isNew = (dto.ID == 0);

                this.ValidarEntityUpdating(entity, dto, isNew);

                if (dto.ID == 0)
                {
                    this.entityRepository.Add(entity);
                }
                else
                {
                    entity = this.entityRepository.GetSingle(dto.ID);
                    entity.ClienteID = dto.ClienteID;
                    entity.Nombre = dto.Nombre;
                    entity.EstadoProyecto = (Estado) dto.EstadoProyecto;
                }
                this.unitOfWork.Commit(); // aca commitear el update o insert de base

                if (entity != null)
                {
                    dto.ID = entity.ID;
                    dto = Mapper.Map<Proyecto, ProyectoDto>(entity);
                }

                this.ValidarEntityUpdated(entity, dto, isNew);

                scope.Complete();
            }
                return dto;
            
        }
        
    }
}
