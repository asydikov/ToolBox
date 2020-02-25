using System;
using Microsoft.EntityFrameworkCore;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.EF
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var query = new SqlQuery()
            {
                Name = "sp_databases",
                Query = "sp_databases",
                Description = "List of Database names in a server",
                IsStoredProcedure = true
        };

        modelBuilder.Entity<SqlQuery>().HasData(query);
    }

}
}