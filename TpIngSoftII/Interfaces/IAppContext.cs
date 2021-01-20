using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIngSoftII.Interfaces
{
    public interface IAppContext
    {
        int EmpleadoID { get; set; }
        void SetEmpleado(int empleadoId);
    }
}
