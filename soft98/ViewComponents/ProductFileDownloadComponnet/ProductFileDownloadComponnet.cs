using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using soft98.Core.Interface;

namespace soft98.ViewComponents.ProductFileDownloadComponnet
{
    public class ProductFileDownloadComponnet : ViewComponent
    {
        private IMainMenuRepository _menuRepository;

        public ProductFileDownloadComponnet(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int PId)
        {
            return await Task.FromResult((IViewComponentResult)View("ShowProductDownloadMain", await _menuRepository.ShowProductDownloadFiles(PId)));
        }
  
        
    }
}