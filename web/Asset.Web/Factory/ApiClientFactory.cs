using Asset.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asset.Web.Factory
{
    internal static class ApiClientFactory
    {
        private static Uri apiUri;
        static ApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
            //apiUri = new Uri("https://localhost:44359/api/Assets/");
        }


        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(
          () => new ApiClient(apiUri),
          LazyThreadSafetyMode.ExecutionAndPublication);

        
        public static ApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
