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
        int ValidarCredenciales(LoginRequest login);
        decimal Antiguedad(int empleadoID);
        EmpleadoDto DameMisDatos();
        int GetEmpleadoUsuarioPassword(string nombreUsuario, string passwordUsuario);
        IEnumerable<PerfilDto> GetPerfilesDeEmpleado(int empleadoID);
        IEnumerable<EmpleadoDto> GetEmpleadosDePerfil(int perfilID);
        int GetEmpleadoPerfilID(int empleadoID, int perfilID);
    }
}
