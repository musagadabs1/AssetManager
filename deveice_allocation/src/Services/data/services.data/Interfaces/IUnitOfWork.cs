using System;
using System.Collections.Generic;
using System.Text;

namespace services.data.Interfaces
{
    public interface IUnitOfWork
    {
        public IAssetRepository Asset { get;}
        public IEmployeeRepository Employee { get;}
        public IDepartmentRepository Department { get;}
        public IAssetSummaryRepository AssetSummary { get; }
    }
}
