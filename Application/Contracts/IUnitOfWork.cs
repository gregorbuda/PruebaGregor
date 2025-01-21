using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAccionesRepository accionesRepository { get; }
        IUserRepository userRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class, new();
        Task<int> Complete();
    }
}
