using Microsoft.EntityFrameworkCore;
using RollOff_Test4API.Data;
using RollOff_Test4API.Models.Domain;
using System;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    public class UserRepository : IUser
    {

        private RollOff4DbContext _context;

        public UserRepository(RollOff4DbContext context)
        {
            _context = context;
        }

        #region AddLoginDetailsAsync
        public async Task<Login> AddLoginDetailsAsync(Login loginTable)
        {
            try
            {
                await _context.login.AddAsync(loginTable);
                await _context.SaveChangesAsync();
                return loginTable;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        #endregion

        #region
        public async Task<Login> AuthenticateUserAsync(string email, string password,string department)
        {
            try
            {
                var user = await _context.login.FirstOrDefaultAsync(x => x.Email == email && x.Password == password && x.Department == department);
                return user;
            }
            catch(Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}
