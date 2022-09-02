using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Context;
using soft98.DataAccessLayer.Entities;
using soft98.DataAccessLayer.Migrations;

namespace soft98.Core.Services
{
    public class AdminRepository : IAdminRepository
    {
        private ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ShowUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> ShowUsers()
        {
            var users = await _context.Users.Include(r => r.Role).Where(s => s.RoleId == 2 ).
                OrderBy(s => s.Phone).ToListAsync();
            return users;
        }

        public async Task<bool> UpdateUser(int id, bool IsActive)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsActive = IsActive;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SaveChanges()
        {
          return  await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Category>> getCategories()
        {
            var Categories = await _context.Categories.Include(s => s.Parent)
                .ToListAsync();
            return Categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var Category = await _context.Categories.Include(s => s.Parent)
                .SingleOrDefaultAsync(o => o.Id == id);
            if (Category != null)
            {
                return Category;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            return category.Id;
        }

        public async Task<bool> UpdateCategory(int id, string name, int? Parent)
        {
            var Category = await _context.Categories.SingleOrDefaultAsync(o => o.Id == id);

            if (Category != null)
            {
                Category.Name = name;
                Category.ParentId = Parent;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveCategory(int id)
        {
            var Category = await _context.Categories.SingleOrDefaultAsync(o => o.Id == id);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// /Matlab
        /// </summary>
        /// <returns></returns>
        public async Task<List<Matlab>> ShowMatlabs()
        {
            var matlabs = await _context.Matlabs.OrderBy(d => d.Date).ToListAsync();
            return matlabs;
        }

        public async Task<Matlab> ShowMatlabbyId(int id)
        {
            var matlab = await _context.Matlabs.SingleOrDefaultAsync(s => s.Id == id);
            return matlab;
        }

        public async Task<bool> UpdateMatlab(int id, string title, string description, bool show, bool isSoft, bool isMobile, bool isTech)
        {
            var matlab = await _context.Matlabs.FindAsync(id);
            if (matlab != null)
            {
                matlab.Title = title;
                matlab.Description = description;
                matlab.Show = show;
                matlab.IsSoft = isSoft;
                matlab.IsMobile = isMobile;
                matlab.IsTech = isTech;

                return true;
            }
            else
            {
                return false;
            }

            
        }

        public async Task<bool> DeleteMatlab(int id)
        {
            var matlab = await _context.Matlabs.FindAsync(id);
            if (matlab != null)
            {
                _context.Matlabs.Remove(matlab);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task  AddMatlab(Matlab matlab)
        {
 
            await _context.Matlabs.AddAsync(matlab);
 
        }

        public async Task<List<Banner>> ShowBanner()
        {
            var Banner = await _context.Banners.OrderBy(d => d.PlaceCode).ToListAsync();
            return Banner;
        }

        public async Task<bool> AddBanner(Banner banner)
        {
           var res = await _context.Banners.AddAsync(banner);
           return true;
        }

        public async Task<bool> RemoveBanner(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner != null)
            {
                 _context.Remove(banner);
                 return true;
            }
            else
            {
                 return false;
            }
        }

        public async Task<bool> UpdateBanner(int id, string placeCode, string description, int price, bool IsActive)
        {

            var banner = await _context.Banners.FindAsync(id);
            if (banner != null)
            {

                banner.PlaceCode = placeCode;
                banner.Description = description;
                banner.Price = price;
                banner.IsActive = IsActive;

                _context.Banners.Update(banner);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Banner> ShowBannerById(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner != null)
            {
                return banner;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<BannerFactor>> ShowFactorBanner()
        {
            var factorBanners = await _context.BannerFactors.OrderBy(o => o.RentDate).ToListAsync();
            return factorBanners;
        }

        public async Task<BannerFactor> ShowFactorById(int id)
        {
            var factorBanner = await _context.BannerFactors.FindAsync(id);
            return factorBanner;
        }

        public async Task<bool> RemoveFactorBanner(int id)
        {
            var bannerFactor = await _context.BannerFactors.FindAsync(id);
            if (bannerFactor != null)
            {
                _context.BannerFactors.Remove(bannerFactor);
                return true;
            }

            return false;
        }

        public async Task<List<Product>> ShowProduct()
        {
            var Products = await _context.Products.OrderBy(s => s.Category).Include(d => d.Category)
                .ToListAsync();
            return Products;
        }
        public async Task<Product> ShowProductById(int id)
        {
            var Product = await _context.Products.Include(d => d.Category)
                .SingleOrDefaultAsync(s => s.Id == id);
            return Product;
        }
        public async Task<bool> AddProduct(Product product)
        {
            if (product != null)
            {
                await _context.Products.AddAsync(product);
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveProduct(int id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product != null)
            {
                _context.Products.Remove(Product);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProduct(int id, int CatId, string name, string description, string picName, string InstallDescription)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product != null)
            {
                Product.CategoryId = CatId;
                Product.Name = name;
                Product.Description = description;
                Product.PicName = picName;
                Product.UpdateDate = PersianDateTime.Now.ToString("yyyy/MM/dd");
                Product.InstallDescription = InstallDescription;

                _context.Products.Update(Product);
                return true;
            }
            return false;
        }

        public async Task<List<ProductDownloadFile>> ShowProductDownload()
        {
            var ProductDownloads = await _context.ProductDownloadFiles.Include(d => d.Product)
                .ToListAsync();
            return ProductDownloads;
        }

        public async Task<ProductDownloadFile> ShowProductDownloadById(int id)
        {
            var ProductDownload = await _context.ProductDownloadFiles.Include(d => d.Product).
                SingleOrDefaultAsync(s => s.Id == id);
  
            return ProductDownload;
        }

        public async Task<bool> AddProductDownload(ProductDownloadFile productDownload)
        {
           var res = await _context.ProductDownloadFiles.AddAsync(productDownload);
           return true;
        }

        public async Task<bool> RemoveProductDownload(int id)
        {
            var ProductDownload = await _context.ProductDownloadFiles.FindAsync(id);
            if (ProductDownload != null)
            {
                _context.ProductDownloadFiles.Remove(ProductDownload);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateProductDownload(int id, int ProductId, string Productink, string fileName, string volume)
        {
            var ProductDownload = await _context.ProductDownloadFiles.FindAsync(id);
            if (ProductDownload != null)
            {
                ProductDownload.ProductId = ProductId;
                ProductDownload.Productlink = Productink;
                ProductDownload.FileName = fileName;
                ProductDownload.Volume = volume;

                _context.ProductDownloadFiles.Update(ProductDownload);
                return true;
            }
            return false;
        }
    }
}