using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Interface
{
    public interface IMainMenuRepository
    {
        Task<List<Category>> ShowMainMenu();
        Task<List<Matlab>> ShowMatlabs();
        Task<BannerFactor> ShowFactorBannerCode(string code);
        Task<List<Product>> ShowProducts();
        Task<Product> ShowProductsById(int id);
        Task<List<ProductDownloadFile>> ShowProductDownloadFiles(int PId);
        Task<ProductDownloadFile> UpdateFileDownloads(int Id);
        Task<List<Product>> ShowProductByCatId(int CId);
        Task<Matlab> ShowMatlabById(int id);
    }
}