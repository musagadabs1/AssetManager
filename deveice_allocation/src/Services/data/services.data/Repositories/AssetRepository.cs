using Microsoft.EntityFrameworkCore;
using services.data.Interfaces;
using services.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace services.data.Repositories
{
    public class AssetRepository:IAssetRepository
    {
        private AssetDbContext _context;
        public AssetRepository()
        {
            _context = new AssetDbContext();
        }

        public void AddAsset(Asset asset)
        {
            try
            {
                _context.assets.Add(asset);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddAssetAsync(Asset asset)
        {
            try
            {
                await _context.assets.AddAsync(asset);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                _context.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Asset GetAsset(int id)
        {
            try
            {
                return _context.assets.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Asset> GetAssetAsync(int id)
        {
            try
            {
                return await _context.assets.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Asset> GetAssets()
        {
            try
            {
                return _context.assets.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync()
        {
            try
            {
                return await _context.assets.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync(Expression<Func<Asset, bool>> expression)
        {
            try
            {
                return await _context.assets.Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
