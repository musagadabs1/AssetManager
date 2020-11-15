using Asset.Web.APIUtilities;
using Asset.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asset.Web
{
    public partial class ApiClient
    {
        public async Task<List<AssetSummaryViewModel>> GetAssetSummaries()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "GetAssetSummaries"));
            return await GetAsync<List<AssetSummaryViewModel>>(requestUrl);
        }

        public async Task<List<AssetViewModel>> GetAssetDetails(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "GetAssetsByEmployeeId/" + id));
            return await GetAsync<List<AssetViewModel>>(requestUrl);
        }
        public async Task<Message<AssetViewModel>> SaveAsset(AssetViewModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "PostAsset"));
            return await PostAsync(requestUrl, model);
        }
    }
}
