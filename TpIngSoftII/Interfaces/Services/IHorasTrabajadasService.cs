using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Interfaces.Services
{
    public interface IHorasTrabajadasService : IEntityAppServiceBase<HorasTrabajadas, HorasTrabajadasDto>
    {
        InformeSemanalHsOBDto InformeSemanalHsOB();
        decimal CantidadHsOB(HorasTrabajadasDto dto);
        IEnumerable<HorasTrabajadasEstadoDto> GetHorasTrabajadasEstado();
        void PagarHoraTrabajada(int horaTrabajadaID);
    }
}
