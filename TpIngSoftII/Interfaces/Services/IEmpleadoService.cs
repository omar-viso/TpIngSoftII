using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Interfaces.Services
{
    public interface IEmpleadoService : IEntityAppServiceBase<Empleado, EmpleadoDto>
    {
        bool ValidarCredenciales(LoginRequest login);
        decimal Antiguedad(int empleadoID);
    }
}
