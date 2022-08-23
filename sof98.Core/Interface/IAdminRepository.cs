using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Interface
{
    public interface IAdminRepository
    {
        Task<User> ShowUserById(int id);
        Task<IEnumerable<User>> ShowUsers();
        Task<bool> UpdateUser(int id, bool IsActive);
        Task<bool> RemoveUser(int id);
        Task<bool> SaveChanges();

        //////////////////////////////
        
        Task<List<Category>> getCategories();
        Task<Category> GetCategory(int id);
        Task<int> AddCategory(Category category);
        Task<bool> UpdateCategory(int id, string name, int? Parent);
        Task<bool> RemoveCategory(int id);
    }
}