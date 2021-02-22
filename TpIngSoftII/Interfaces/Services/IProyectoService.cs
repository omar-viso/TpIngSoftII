using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Interfaces.Services
{
    public interface IProyectoService : IEntityAppServiceBase<Proyecto, ProyectoDto>
    {
        IEnumerable<ProyectoEstadoDto> ProyectoEstados();
        decimal HorasTrabajadasPorProyecto(int proyectoID);
        decimal HorasTrabajadasPorProyectoPorPerfil(int proyectoID, int perfilID);
        decimal HorasTrabajadasPorProyectoPorPerfilPorEmpleado(int proyectoID, int perfilID, int empleadoID, DateTime desde, DateTime hasta);
        decimal ObtenerHorasAdeudadasPorProyecto(int proyectoID);
        LiquidacionDto Liquidacion(SolicitaLiquidacionDto dto);
        IEnumerable<ProyectoPerfilesHorasDto> HorasTrabajadasPorProyectoPorPerfilTotales();
        IEnumerable<ProyectoPerfilesEmpleadosHorasDto> HorasTrabajadasPorProyectoPorPerfilPorEmpleadoTotales(DateTime desde, DateTime hasta);
        IEnumerable<ProyectoEmpleadoHorasAdeudadasDto> HorasAdeudadasPorProyectoPorEmpleadoTotales();
    }
}
