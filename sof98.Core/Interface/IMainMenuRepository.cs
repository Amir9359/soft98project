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
        Task<List<Product>> SearchProduct(string search);
        Task<bool> AddComment(Contact contact);
        Task<List<Banner>> ShowTarefeh(); 
        bool ShowStatuseBanner(int Bid);
        Task<bool> AddBanerFactor(BannerFactor bannerFactor);
        Task<bool> UpdateBannerFactor(int id, string FollowNumber, string StartDate, string EndDate);
        Task<bool> UpdateBannerFactorImage(int id, string ImageName, string Link);
        Task<BannerFactor> ShowBannerFactorById(int id);
        Task<BannerFactor> ShowBannerFactorByBannerId(int Bid, int Uid);
        Task<Banner> ShowBannerById(int id);
        void RemoveBannerFactor();


        Task Save();
    }
}