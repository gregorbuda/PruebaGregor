using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<Boolean> GetToken(string Email, string Password);
    }
}
