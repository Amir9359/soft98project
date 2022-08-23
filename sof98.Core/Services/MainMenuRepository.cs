using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Context;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Services
{
    public class MainMenuRepository : IMainMenuRepository
    {
        private ApplicationDbContext _context;

        public MainMenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> ShowMainMenu()
        {
            return await _context.Categories.Where(s => s.ParentId == null).ToListAsync();
        }
    }
}