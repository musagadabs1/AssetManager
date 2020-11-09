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
    public class AssetSummaryRepository:IAssetSummaryRepository
    {
        private AssetDbContext _context;
        public AssetSummaryRepository()
        {
            _context = new AssetDbContext();
        }

        public void AddAssetSummary(AssetSummary assetSummary)
        {
            try
            {
                _context.assetsummaries.Add(assetSummary);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddAssetSummaryAsync(AssetSummary assetSummary)
        {
            try
            {
                await _context.assetsummaries.AddAsync(assetSummary);
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

        public AssetSummary GetAssetSummary(int id)
        {
            try
            {
                return _context.assetsummaries.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AssetSummary> GetAssetSummaryAsync(int id)
        {
            try
            {
                return await _context.assetsummaries.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<AssetSummary> GetAssetSummaries()
        {
            try
            {
                return _context.assetsummaries.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<AssetSummary>> GetAssetSummariesAsync()
        {
            try
            {
                return await _context.assetsummaries.ToListAsync();
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

        public async Task<IEnumerable<AssetSummary>> GetAssetSummariesAsync(Expression<Func<AssetSummary, bool>> expression)
        {
            try
            {
                return await _context.assetsummaries.Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
