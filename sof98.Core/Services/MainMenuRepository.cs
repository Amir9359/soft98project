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
    public class MainMenuRepository : IMainMenuRepository
    {
        private ApplicationDbContext _context;
        private IUserRepository _userRepository;

        public MainMenuRepository(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<List<Category>> ShowMainMenu()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Matlab>> ShowMatlabs()
        {
            return  await _context.Matlabs.ToListAsync();
        }

        public async Task<BannerFactor> ShowFactorBannerCode(string code)
        {
            var FactorBanner = await _context.BannerFactors.Include(d => d.Banner)
                .FirstOrDefaultAsync(s => s.Banner.PlaceCode == code && s.IsExpire == false);
            return FactorBanner;
        }

        public async Task<List<Product>> ShowProducts()
        {
            var product = await _context.Products.Include(d => d.Category).ToListAsync();
            return product;
        }

        public async Task<Product> ShowProductsById(int id)
        {
            var product = await _context.Products.Include(d => d.Category).FirstOrDefaultAsync(s=> s.Id == id);
            product.SeenCount += 1;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<ProductDownloadFile>> ShowProductDownloadFiles(int PId)
        {
            var ProductDownloadFiles = await _context.ProductDownloadFiles
                .Include(d => d.Product).Where(d => d.ProductId == PId).ToListAsync();
            return ProductDownloadFiles;
        }

        public async Task<ProductDownloadFile> UpdateFileDownloads(int Id)
        {
            var file = await _context.ProductDownloadFiles.FindAsync(Id);
            file.DownloadCount += 1;
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<List<Product>> ShowProductByCatId(int CId)
        {
            var Products = await _context.Products.Include(d => d.Category)
                .Where(s => s.CategoryId == CId).OrderBy(o => o.UpdateDate)
                .ToListAsync();
            return Products;
        }

        public async Task<Matlab> ShowMatlabById(int id)
        {
            var Matlab = await _context.Matlabs.FindAsync(id);
            Matlab.NumberSeen += 1;
            await _context.SaveChangesAsync();

            return Matlab;
        }
        public async Task<List<Product>> SearchProduct(string search)
        {
            var products = await _context.Products.Where(s => s.Name.Contains(search)).OrderByDescending(d => d.Id)
                .ToListAsync();
            return products;
        }

        public async Task<bool> AddComment(Contact contact)
        {
            if (contact != null)
            {
                await _context.Contacts.AddAsync(contact);
                return true;
            }

            return false;
        }

        public async Task<List<Banner>> ShowTarefeh()
        {
            var banners = await _context.Banners.Where(d => d.IsActive == true)
                .OrderBy(s => s.PlaceCode).ToListAsync();

            return banners;
        }

        public  bool ShowStatuseBanner(int Bid)
        {
            return  _context.BannerFactors.Any(s => s.BannerId == Bid && s.IsExpire == false);
        }

        public async Task<bool> AddBanerFactor(BannerFactor bannerFactor)
        {
            if (bannerFactor != null)
            {
                await _context.BannerFactors.AddAsync(bannerFactor);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateBannerFactor(int id, string FollowNumber, string StartDate, string EndDate)
        {
            var bannerf = await _context.BannerFactors.FindAsync(id);
            if (bannerf != null)
            {
                bannerf.FollowNumber = FollowNumber;
                bannerf.RentDate = StartDate;
                bannerf.ExpireDate= EndDate;

                _context.BannerFactors.Update(bannerf);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateBannerFactorImage(int id, string ImageName, string Link)
        {
            var bannerf = await _context.BannerFactors.FindAsync(id);
            if (bannerf != null)
            {
                bannerf.PicName = ImageName;
                bannerf.PicLink = Link;

                _context.BannerFactors.Update(bannerf);
                return true;
            }

            return false;
        }

        public async Task<BannerFactor> ShowBannerFactorById(int id)
        {
            var bannerFactor = await _context.BannerFactors.Include(d => d.Banner)
                .SingleOrDefaultAsync(i => i.Id == id);
            return bannerFactor;
        }

        public async Task<BannerFactor> ShowBannerFactorByBannerId(int Bid , int Uid)
        {
            var user = await _context.Users.FindAsync(Uid);
            var bannerFactor = await _context.BannerFactors.Include(d => d.Banner)
                .SingleOrDefaultAsync(i => i.BannerId == Bid && i.IsExpire == false  &&   user != null);
            return bannerFactor;
        }

        public async Task<Banner> ShowBannerById(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            return banner;
        }

        public async void RemoveBannerFactor()
        {
            int lastId = _context.BannerFactors.Max(b => b.Id);
            var bannerFactor = await _context.BannerFactors.FindAsync(lastId);
            _context.BannerFactors.Remove(bannerFactor);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}