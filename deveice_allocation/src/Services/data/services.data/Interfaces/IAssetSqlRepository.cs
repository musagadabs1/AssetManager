using services.data.Models;
using System.Collections.Generic;

namespace services.data.Interfaces
{
    public interface IAssetSqlRepository
    {
        string SaveAsset(Asset asset,string connString);
        Asset GetAsset(string connString);
        IList<Asset> GetAssets(string connString);
        string DeleteAsset(int id,string connString);
    }
}
