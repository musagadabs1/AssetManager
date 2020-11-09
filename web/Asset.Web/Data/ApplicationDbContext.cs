using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Asset.Web.Models;

namespace Asset.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Asset.Web.Models.AssetViewModel> AssetViewModel { get; set; }
        public DbSet<Asset.Web.Models.AssetSummaryViewModel> AssetSummaryViewModel { get; set; }
    }
}
