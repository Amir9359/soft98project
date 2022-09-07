using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using soft98.Core.Interface;

namespace soft98.ViewComponents.TarefehComponent
{
    public class TarefehComponent : ViewComponent
    {
        private IMainMenuRepository _menuRepository;

        public TarefehComponent(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("ShowTarefehTable", await _menuRepository.ShowTarefeh()));
        }
    }
}