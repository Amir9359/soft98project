using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Interface
{
    public interface IAdminRepository
    {
        Task<User> ShowUserById(int id);
        Task<IEnumerable<User>> ShowUsers();
        Task<bool> UpdateUser(int id, bool IsActive);
        Task<bool> RemoveUser(int id);
        Task<bool> SaveChanges();

        //////////////////////////////

        Task<List<Category>> getCategories();
        Task<Category> GetCategory(int id);
        Task<int> AddCategory(Category category);
        Task<bool> UpdateCategory(int id, string name, int? Parent);
        Task<bool> RemoveCategory(int id);


        //////////////////////////////
        Task<List<Matlab>> ShowMatlabs();
        Task<Matlab> ShowMatlabbyId(int id);

        Task<bool> UpdateMatlab(int id, string title, string description, bool show, bool isSoft, bool isMobile,
            bool isTech);

        Task<bool> DeleteMatlab(int id);
        Task AddMatlab(Matlab matlab);

        ////////////////////////////

        Task<List<Banner>> ShowBanner();
        Task<bool> AddBanner(Banner banner);
        Task<bool> RemoveBanner(int id);
        Task<bool> UpdateBanner(int id, string placeCode, string description, int price, bool IsActive);
        Task<Banner> ShowBannerById(int id);

        ///////////////////////////////////
        Task<List<BannerFactor>> ShowFactorBanner();
        Task<BannerFactor> ShowFactorById(int id);
        Task<bool> RemoveFactorBanner(int id);

        ////////////////////Product////////////
        Task<List<Product>> ShowProduct();
        Task<bool> AddProduct(Product product);
        Task<bool> RemoveProduct(int id);

        Task<bool> UpdateProduct(int id, int CatId, string name, string description, string picName,
            string InstallDescription);
        Task<Product> ShowProductById(int id);

        ///////////////////////////////////
        Task<List<ProductDownloadFile>> ShowProductDownload();
        Task<ProductDownloadFile> ShowProductDownloadById(int id);
        Task<bool> AddProductDownload(ProductDownloadFile productDownload);
        Task<bool> RemoveProductDownload(int id);

        Task<bool> UpdateProductDownload(int id, int ProductId, string Productink, string fileName, string volume);

    }
}