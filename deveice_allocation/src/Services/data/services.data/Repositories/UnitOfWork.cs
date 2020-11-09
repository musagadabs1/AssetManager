using services.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAssetRepository Asset { get; }

        public IEmployeeRepository Employee { get; }

        public IDepartmentRepository Department { get; }

        public IAssetSummaryRepository AssetSummary { get; }

        public UnitOfWork()
        {
            Asset = new AssetRepository();
            Employee = new EmployeeRepository();
            Department = new DepartmentRepository();
            AssetSummary = new AssetSummaryRepository();
        }
    }
}
