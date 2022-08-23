using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using soft98.Core.Interface;

namespace soft98.ViewComponents.MainMenuComponent
{
    public class MainMenuComponent : ViewComponent
    {
        private IMainMenuRepository _menuRepository;

        public MainMenuComponent(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync ()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowMenuHeader", await _menuRepository.ShowMainMenu()));
        }
    }
}