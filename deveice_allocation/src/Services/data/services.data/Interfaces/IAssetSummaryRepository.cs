using services.data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace services.data.Interfaces
{
    public interface IAssetSummaryRepository
    {
        void AddAssetSummary(AssetSummary assetSummary);
        Task AddAssetSummaryAsync(AssetSummary assetSummary);
        void Save();
        Task SaveAsync();
        void Dispose();
        AssetSummary GetAssetSummary(int id);
        Task<AssetSummary> GetAssetSummaryAsync(int id);
        IEnumerable<AssetSummary> GetAssetSummaries();
        Task<IEnumerable<AssetSummary>> GetAssetSummariesAsync();
        Task<IEnumerable<AssetSummary>> GetAssetSummariesAsync(Expression<Func<AssetSummary, bool>> expression);
    }
}
