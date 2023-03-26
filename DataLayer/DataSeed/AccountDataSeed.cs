using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataSeed
{
    public static class AccountDataSeed
    {
        public static void SeedAccount(this ModelBuilder modelBuilder)
        {
            var accounts = new List<Account>();

            var storeGuids = new List<Guid>()
            {
                Guid.Parse("2f7c4295-4f2f-4651-891b-9b61b6e3adac"),
                Guid.Parse("ad6c7bb8-90a3-4f9a-abf8-be36acba1012")
            };

            // Realistic usernames and passwords
            var usernames = new List<string>() { "admin1", "admin2", "johndoe", "amandabrown", "davidlee", "sarahjones" , "bobross", "einstein" };
            var passwords = new List<string>() { "123456", "654321", "12345678", "qwertyuiop", "Football123", "Baseball123" , "bobthebob", "wowsuchmath"};

            // Fixed GUIDs for the accounts
            var guids = new List<Guid>() {
                Guid.Parse("8f7b3e92-3c7e-4b1d-a7a1-1f1c7d2f2a2a"),
                Guid.Parse("1f7d3e82-4c8f-5b2e-b2c0-2f2d8c1e1d1d"),
                Guid.Parse("a5b6c7d8-e9f0-1a2b-3c4d-5e6f7a8b9c0d"),
                Guid.Parse("b4e3c2d1-f0e9-d8c7-b6a5-4193f8271c36"),
                Guid.Parse("7f6e5d4c-3b2a-1f0e-d9c8-7654a3210b1c"),
                Guid.Parse("d1c2b3a4-9e8f-7a6b-5c4d-3f2e1c0d9a8b"),
                Guid.Parse("9fc8a324-fe80-4b48-b106-273d511bf0f4"),
                Guid.Parse("3802d434-b94e-4aab-b4c0-91acfc298c47")
            };

            var accountAdmin1 = new Account()
            {
                AccountID = guids[0],
                Username = usernames[0],
                Password = passwords[0],
                Role = AccountRole.Admin,
                AccountStatus = (int)AccountStatus.Active,
                AdminStoreID = storeGuids[0]
            };
            var accountAdmin2 = new Account()
            {
                AccountID = guids[1],
                Username = usernames[1],
                Password = passwords[1],
                Role = AccountRole.Admin,
                AccountStatus = (int)AccountStatus.Active,
                AdminStoreID = storeGuids[1]
            };
            var accountStaff1 = new Account()
            {
                AccountID = guids[2],
                Username = usernames[2],
                Password = passwords[2],
                Role = AccountRole.Staff,
                AccountStatus = (int)AccountStatus.Active,
                StaffStoreID = storeGuids[0]
            };
            var accountStaff2 = new Account()
            {
                AccountID = guids[3],
                Username = usernames[3],
                Password = passwords[3],
                Role = AccountRole.Staff,
                AccountStatus = (int)AccountStatus.Active,
                StaffStoreID = storeGuids[0]
            };
            var accountStaff3 = new Account()
            {
                AccountID = guids[4],
                Username = usernames[4],
                Password = passwords[4],
                Role = AccountRole.Staff,
                AccountStatus = (int)AccountStatus.Active,
                StaffStoreID = storeGuids[1]
            };
            var accountStaff4 = new Account()
            {
                AccountID = guids[5],
                Username = usernames[5],
                Password = passwords[5],
                Role = AccountRole.Staff,
                AccountStatus = (int)AccountStatus.Active,
                StaffStoreID = storeGuids[1]
            };
            var accountCustomer1 = new Account()
            {
                AccountID = guids[6],
                Username = usernames[6],
                Password = passwords[6],
                Role = AccountRole.Customer,
                AccountStatus = (int)AccountStatus.Active
            };
            var accountCustomer2 = new Account()
            {
                AccountID = guids[7],
                Username = usernames[7],
                Password = passwords[7],
                Role = AccountRole.Customer,
                AccountStatus = (int)AccountStatus.Active
            };


            accounts.Add(accountAdmin1);
            accounts.Add(accountAdmin2);
            accounts.Add(accountStaff1);
            accounts.Add(accountStaff2);
            accounts.Add(accountStaff3);
            accounts.Add(accountStaff4);
            accounts.Add(accountCustomer1);
            accounts.Add(accountCustomer2);

            modelBuilder.Entity<Account>().HasData(accounts);
        }
    }
}
