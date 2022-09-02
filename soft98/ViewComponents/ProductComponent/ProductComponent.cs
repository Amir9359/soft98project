using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using soft98.Core.Interface;

namespace soft98.ViewComponents.ProductComponent
{
    public class ProductComponent : ViewComponent
    {
        private IMainMenuRepository _menuRepository;

        public ProductComponent(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("ShowProductMain", await _menuRepository.ShowProducts()));
        }
    }
}
