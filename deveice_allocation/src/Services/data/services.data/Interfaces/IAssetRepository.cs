using services.data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace services.data.Interfaces
{
    public interface IAssetRepository
    {
        void AddAsset(Asset asset);
        Task AddAssetAsync(Asset asset);
        void Save();
        Task SaveAsync();
        void Dispose();
        Asset GetAsset(int id);
        Task<Asset> GetAssetAsync(int id);
        IEnumerable<Asset> GetAssets();
        Task<IEnumerable<Asset>> GetAssetsAsync();
        Task<IEnumerable<Asset>> GetAssetsAsync(Expression<Func<Asset, bool>> expression);
    }
}
