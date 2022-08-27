using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using soft98.Core.Interface;

namespace soft98.ViewComponents.MatalebComponent
{
    public class MatalebComponent : ViewComponent
    {
        private IMainMenuRepository _menuRepository;

        public MatalebComponent(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("ShowMatalebMain",
                await _menuRepository.ShowMatlabs()));
        }
    }
}
