using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using soft98.Core.Infrastructure;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Context;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Services
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string phone, string Password)
        {
          var hashedPass =  HashGenrator.EncondingPassWithMd5(Password);

          return await _context.Users.FirstOrDefaultAsync(s => s.Phone == phone && s.Password == hashedPass);
        }

        public bool PhoneExist(string Phone)
        {
           return _context.Users.Any(s => s.Phone == Phone);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);

        }

        public async Task SaveShanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> ActiveUser(string ActiveCode)
        {
            var user = await _context.Users.SingleOrDefaultAsync(s => s.Code == ActiveCode && s.IsActive == false);
            if (user != null)
            {
                if (user.Code == ActiveCode)
                {
                    user.Code = CodeGenrators.ActiveCode();
                    user.IsActive = true;
                    await SaveShanges();

                  
                }
            
            }
            return user;
        }

        public async Task<User> ForgetPassword(string Phone)
        {
            return await _context.Users.SingleOrDefaultAsync(s => s.Phone == Phone);
        }

        public async Task<User> ResetPassword(string code, string Password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(s => s.Code == code);
            if (user != null)
            {

                var hashpass = HashGenrator.EncondingPassWithMd5(Password);
                user.Password = hashpass;
                user.Code = CodeGenrators.ActiveCode();
                await SaveShanges();
 
            }

            return user;
        }

        public async Task<int> GetUserId(string phone)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Phone == phone);
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<bool> ProfileUser(string phone , int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.IsActive ==  true && s.Id == id);
            if (user != null)
            {
                if (!await _context.Users.AnyAsync(s => s.Phone == phone))
                {
                    user.Phone = phone;
                    await SaveShanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ChangePassword(string phone, string curentPassword, string Password)
        {
            string HashCurrentPass = HashGenrator.EncondingPassWithMd5(curentPassword);

            var user =await  _context.Users.FirstOrDefaultAsync(u => u.Phone == phone && u.Password == HashCurrentPass);

            if (user != null)
            {
                string HashNewPass = HashGenrator.EncondingPassWithMd5(Password);
                user.Password = HashNewPass;

                await SaveShanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ChenckUserRole(string RoleName, string Phone)
        {
            var result = await _context.Users.Include(s => s.Role)
                .AnyAsync(u => u.Phone == Phone && u.Role.Name == RoleName);
            return result;
        }

        public async Task<string> GetRoleName(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role.Name;
        }
    }
}