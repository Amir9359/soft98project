using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Context;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Services
{
    public class AdminRepository : IAdminRepository
    {
        private ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ShowUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> ShowUsers()
        {
            var users = await _context.Users.Include(r => r.Role).Where(s => s.RoleId == 2 ).
                OrderBy(s => s.Phone).ToListAsync();
            return users;
        }

        public async Task<bool> UpdateUser(int id, bool IsActive)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsActive = IsActive;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SaveChanges()
        {
          return  await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Category>> getCategories()
        {
            var Categories = await _context.Categories.Include(s => s.Parent)
                .ToListAsync();
            return Categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var Category = await _context.Categories.Include(s => s.Parent)
                .SingleOrDefaultAsync(o => o.Id == id);
            if (Category != null)
            {
                return Category;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            return category.Id;
        }

        public async Task<bool> UpdateCategory(int id, string name, int? Parent)
        {
            var Category = await _context.Categories.SingleOrDefaultAsync(o => o.Id == id);

            if (Category != null)
            {
                Category.Name = name;
                Category.ParentId = Parent;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveCategory(int id)
        {
            var Category = await _context.Categories.SingleOrDefaultAsync(o => o.Id == id);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}