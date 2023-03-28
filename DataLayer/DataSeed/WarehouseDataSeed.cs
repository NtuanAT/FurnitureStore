using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataSeed
{
    public static class WarehouseDataSeed
    {
        public static void SeedWarehouse(this ModelBuilder modelBuilder)
        {
            var warehouses = new List<Warehouse>();

            #region Warehouse Data
            var warehouseName = new List<string>() { "Chicago South Warehouse #9", "Miami Dock Warehouse" };
            var locations = new List<string>() { "Chicago", "Miami" };
            var warehouseGuids = new List<Guid>()
            {
                Guid.Parse("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"),
                Guid.Parse("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f")
            };
            #endregion

            var warehouse1 = new Warehouse()
            {
                WareHouseID = warehouseGuids[0],
                Name = warehouseName[0],
                Location = locations[0]
            };

            var warehouse2 = new Warehouse()
            {
                WareHouseID = warehouseGuids[1],
                Name = warehouseName[1],
                Location = locations[1]
            };

            warehouses.Add(warehouse1);
            warehouses.Add(warehouse2);

            modelBuilder.Entity<Warehouse>().HasData(warehouses);

        }
    }
}
