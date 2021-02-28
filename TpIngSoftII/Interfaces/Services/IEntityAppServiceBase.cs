using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIngSoftII.Interfaces.Services
{
    public interface IEntityAppServiceBase<E, D>
        where E : class, IEntityBase, new()
        where D : class, IDto, new()
    {
        IEnumerable<D> GetAll();

        IEnumerable<D> GetAllAsNoTracking();

        D GetById(int id);

        D GetByIdAsNoTracking(int id);

        D Update(D dto);

        void DeleteById(int id);
    }
}
