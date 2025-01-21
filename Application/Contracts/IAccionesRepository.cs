using Models.Models;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAccionesRepository : IAsyncRepository<Acciones>
    {
        Task<Acciones> GetById(string AccionId);
        Task<ResponseUpdateStatus> GetUpdateStatus(string AccionId);
        Task<ResponseUpdateEliminar> GetUpdateStatusEliminacion(string accionId);
        Task<List<Acciones>> GetByStatus(bool Status);
        Task<List<Acciones>> GetByAccion(string Accion);
    }
}
