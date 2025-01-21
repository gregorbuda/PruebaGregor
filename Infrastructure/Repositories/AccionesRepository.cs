using Application.Contracts;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccionesRepository : RepositoryBase<Acciones>, IAccionesRepository
    {
        public AccionesRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        ///  Get accion by Id
        /// </summary>
        public async Task<Acciones> GetById(string AccionId)
        {
            var accion = await _context.acciones.Where(x => x.Id == AccionId.ToString()).FirstOrDefaultAsync();

            return accion;
        }

        /// <summary>
        ///  Update Status by Id
        /// </summary>
        public async Task<ResponseUpdateStatus> GetUpdateStatus(string accionId)
        {
            bool result = false;
            ResponseUpdateStatus responseUpdateStatus = new ResponseUpdateStatus();

            try
            {
                var accion = await _context.acciones.Where(x => x.Id == accionId.ToString()).FirstOrDefaultAsync();

                if (!accion.Estado)
                {
                    accion.Estado = false;
                }
                else
                {
                    accion.Estado = true;
                }

                _context.Entry(accion).State = EntityState.Modified;

                _context.SaveChanges();

                responseUpdateStatus.Estado = accion.Estado;
                responseUpdateStatus.Result = true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                responseUpdateStatus.Estado = false;
                responseUpdateStatus.Result = false;
            }

            return responseUpdateStatus;
        }

        /// <summary>
        ///  Update Delete Status by Id
        /// </summary>
        public async Task<ResponseUpdateEliminar> GetUpdateStatusEliminacion(string accionId)
        {
            bool result = false;
            ResponseUpdateEliminar responseUpdateEliminar = new ResponseUpdateEliminar();

            try
            {
                var accion = await _context.acciones.Where(x => x.Id == accionId.ToString()).FirstOrDefaultAsync();

                if (!accion.Eliminar)
                {
                    accion.Eliminar = true;
                }

                _context.Entry(accion).State = EntityState.Modified;

                _context.SaveChanges();

                responseUpdateEliminar.Eliminar = accion.Eliminar;
                responseUpdateEliminar.Result = true;

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                responseUpdateEliminar.Eliminar = false;
                responseUpdateEliminar.Result = false;
            }

            return responseUpdateEliminar;
        }


        /// <summary>
        ///  Get list accion by status
        /// </summary>
        public async Task<List<Acciones>> GetByStatus(bool Status)
        {
            var accion = await _context.acciones.Where(x => x.Estado == Status).ToListAsync();

            return accion;
        }

        /// <summary>
        ///  Get list accion by accion
        /// </summary>
        public async Task<List<Acciones>> GetByAccion(string Accion)
        {
            var accion = await _context.acciones.Where(x => x.DescripcionAccion.Contains(Accion)).ToListAsync();

            return accion;
        }
    }
}
