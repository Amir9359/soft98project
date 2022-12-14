using System.Collections.Generic;
using System.Threading.Tasks;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Interface
{
    public interface IMainMenuRepository
    {
        Task<List<Category>> ShowMainMenu();
    }
}