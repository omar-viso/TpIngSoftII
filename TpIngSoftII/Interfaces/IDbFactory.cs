using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIngSoftII.Interfaces
{
    public interface IDbFactory<TDbContext> : IDisposable
    {
        TDbContext Init();
        TDbContext Limpiar();
    }
}
