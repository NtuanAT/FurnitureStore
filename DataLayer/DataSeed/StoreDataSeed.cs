using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataSeed
{
    public static class StoreDataSeed
    {
        public static void SeedStore(this ModelBuilder modelBuilder)
        {
            var stores = new List<Store>();

            #region Store Data
            var storename = new List<string>() { "Classy Furniture", "Artisan Furniture" };
            var locations = new List<string>() { "New York", "Los Angeles" };
            var storeGuids = new List<Guid>()
            {
                Guid.Parse("2f7c4295-4f2f-4651-891b-9b61b6e3adac"),
                Guid.Parse("ad6c7bb8-90a3-4f9a-abf8-be36acba1012")
            };
            #endregion

            #region Account Data
            // Realistic usernames and passwords
            var usernames = new List<string>() { "admin1", "admin2", "johndoe", "amandabrown", "davidlee", "sarahjones" };
            var passwords = new List<string>() { "123456", "654321", "12345678", "qwertyuiop", "Football123", "Baseball123" };

            // Fixed GUIDs for the accounts
            var accountGuids = new List<Guid>() {
                Guid.Parse("8f7b3e92-3c7e-4b1d-a7a1-1f1c7d2f2a2a"),
                Guid.Parse("1f7d3e82-4c8f-5b2e-b2c0-2f2d8c1e1d1d"),
                Guid.Parse("a5b6c7d8-e9f0-1a2b-3c4d-5e6f7a8b9c0d"),
                Guid.Parse("b4e3c2d1-f0e9-d8c7-b6a5-4193f8271c36"),
                Guid.Parse("7f6e5d4c-3b2a-1f0e-d9c8-7654a3210b1c"),
                Guid.Parse("d1c2b3a4-9e8f-7a6b-5c4d-3f2e1c0d9a8b")
            };

            var accountAdmin1 = new Account()
            {
                AccountID = accountGuids[0],
                Username = usernames[0],
                Password = passwords[0],
                Role = AccountRole.Admin,
                AccountStatus = (int)AccountStatus.Active
            };
            var accountAdmin2 = new Account()
            {
                AccountID = accountGuids[1],
                Username = usernames[1],
                Password = passwords[1],
                Role = AccountRole.Admin,
                AccountStatus = (int)AccountStatus.Active
            };
            var accountStaff1 = new Account()
            {
                AccountID = accountGuids[2],
                Username = usernames[2],
                Password = passwords[2],
                Role = AccountRole.Staff,
                AccountStatus = (int)AccountStatus.Active
            };
            var accountStaff2 = new Account()
            {
                AccountID = accountGuids[3],
                Username = usernames[3],
                Password = passwords[3],
                Role = AccountRole.Staff,
                AccountStatus = (int)AccountStatus.Active
            };
            var accountStaff3 = new Account()
            {
                AccountID = accountGuids[4],
                Username = usernames[4],
                Password = passwords[4],
                Role = AccountRole.Staff,
                AccountStatus = (int)AccountStatus.Active
            };
            var accountStaff4 = new Account()
            {
                AccountID = accountGuids[5],
                Username = usernames[5],
                Password = passwords[5],
                Role = AccountRole.Staff,
                AccountStatus = (int)AccountStatus.Active
            };
            #endregion


            var store1 = new Store()
            {
                StoreID = storeGuids[0],
                StoreName = storename[0],
                StoreAdminAccountID = accountAdmin1.AccountID,
                //StoreAdmin = accountAdmin1,
                //Staffs = new List<Account> { accountStaff1, accountStaff2 },
                Location = locations[0],
                Status = StoreStatus.Open
            };
            var store2 = new Store()
            {
                StoreID = storeGuids[1],
                StoreName = storename[1],
                StoreAdminAccountID = accountAdmin2.AccountID,
                //StoreAdmin = accountAdmin2,
                //Staffs = new List<Account> { accountStaff3, accountStaff4 },
                Location = locations[1],
                Status = StoreStatus.Open
            };
            stores.Add(store1);
            stores.Add(store2);

            modelBuilder.Entity<Store>().HasData(stores);
        }
    }
}
