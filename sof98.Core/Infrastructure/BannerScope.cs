using System.ComponentModel.Design;
using soft98.Core.Interface;

namespace soft98.Core.Infrastructure
{
    public class BannerScope
    {
        private IMainMenuRepository _menuRepository;

        public BannerScope(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public bool CheckFactor(int Bannerid)
        {
          return  _menuRepository.ShowStatuseBanner(Bannerid);
        }
    }
}