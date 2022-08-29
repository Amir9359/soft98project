using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using soft98.Core.Interface;

namespace soft98.ViewComponents.BannerComponent
{
    public class BannerComponent : ViewComponent
    {
        private IMainMenuRepository _menuRepository;

        public BannerComponent(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(string code)
        {
            return await Task.FromResult((IViewComponentResult) View("ShowBannerFactorCode", await _menuRepository.ShowFactorBannerCode(code)));
        }
    }
}
