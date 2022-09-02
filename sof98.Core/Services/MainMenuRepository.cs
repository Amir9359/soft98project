using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Context;
using soft98.DataAccessLayer.Entities;

namespace soft98.Core.Services
{
    public class MainMenuRepository : IMainMenuRepository
    {
        private ApplicationDbContext _context;

        public MainMenuRepository(ApplicationDbContext context)
        {
            _context = context;
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
            var product = await _context.Products.FindAsync(id);
            product.SeenCount += 1;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<ProductDownloadFile>> ShowProductDownloadFiles(int PId)
        {
            var ProductDownloadFiles = await _context.ProductDownloadFiles
                    .Where(d => d.ProductId == PId).ToListAsync();
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
            var Products = await _context.Products.Where(s => s.CategoryId == CId).OrderBy(o => o.UpdateDate)
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
    }
}