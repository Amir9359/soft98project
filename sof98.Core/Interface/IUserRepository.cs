using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Interface
{
    public interface IUserRepository
    {
        Task<User> Login(string phone, string Password);
        bool PhoneExist(string Phone);
        Task AddUser(User user);
        Task SaveShanges();
        Task<User> ActiveUser(string ActiveCode);
        Task<User> ForgetPassword(string Phone);
        Task<User> ResetPassword(string code, string Password);
        Task<int> GetUserId(string phone);
        Task<bool> ProfileUser(string phone, int id);
        Task<bool> ChangePassword(string phone,string curentPassword , string Password);
        Task<bool> ChenckUserRole(string RoleName, string Phone);
        Task<String> GetRoleName(int id);
    }
}
