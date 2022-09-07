using System.Threading.Tasks;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Infrastructure
{
    public class showbannerFactorDe
    {
        private IMainMenuRepository _menuRepository;

        public showbannerFactorDe(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<BannerFactor> showbannerFactor(int id , int userid)
        {
          return  await _menuRepository.ShowBannerFactorByBannerId(id , userid);
        }
    }
}