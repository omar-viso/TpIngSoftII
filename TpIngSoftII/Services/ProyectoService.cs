using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Services
{
    public class ProyectoService : EntityAppServiceBase<Proyecto, ProyectoDto>, IProyectoService
    {
        //protected readonly IUnitOfWork unitOfWork;
        /*  VER TODO ESTE ARCHIVO !!!! */
        private readonly IEntityBaseRepository<Proyecto> proyectoRepository;

        //public ProyectoService(IUnitOfWork unitOfWork,
        //    IEntityBaseRepository<Proyecto> proyectoRepository)
        public ProyectoService(IEntityBaseRepository<Proyecto> entityRepository) : base(entityRepository)
        {
            this.proyectoRepository = entityRepository;
        }

        public override IEnumerable<ProyectoDto> GetAll()
        {
            var query = this.entityRepository.GetAll();
            var entities = query.ToList();
            IEnumerable<ProyectoDto> dtos = Mapper.Map<IEnumerable<Proyecto>, IEnumerable<ProyectoDto>>(query.ToList());

            return dtos;
        }
        /*
        public IEnumerable<ProyectoDto>(int id)
        {
            var enti = this.entityRepository.GetSingle(id);
            var dtos = Mapper.Map<E, D>(enti);

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

        public virtual D Update(D dto)
        {
            using (var scope = new TransactionScope())
            {
                E entity = null;
                entity = Mapper.Map<D, E>(dto);
                var isNew = (dto.ID == 0);

                this.ValidarEntityUpdating(entity, dto, isNew);

                if (dto.ID == 0)
                {
                    this.entityRepository.Add(entity);
                }
                else
                {
                    this.entityRepository.Edit(entity);
                }

                this.unitOfWork.Commit(); // aca commitear el update o insert de base
            }
        }
        */
    }
}