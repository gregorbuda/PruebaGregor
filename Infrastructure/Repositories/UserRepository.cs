using Application.Contracts;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Boolean> GetToken(string Email, string Password)
        {
            var user = await _context.users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefaultAsync();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
