using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataSeed
{
    public static class InStoreProductDataSeed
    {
        public static void SeedInStoreProduct(this ModelBuilder modelBuilder)
        {
            var inStoreProducts = new List<InStoreProduct>();

            #region Product Data
            var productsGuids = new List<Guid>()
            {
                Guid.Parse("57acf196-c71c-49b0-aad1-a1fe004f23fe"),
                Guid.Parse("f32f6db0-fa3d-44b3-98e3-39b2ffc0afc7"),
                Guid.Parse("8b36a544-4377-40c7-bb36-7471c14fe502"),
                Guid.Parse("bd614703-badc-4d12-970a-27c64b59847b"),
                Guid.Parse("2ed1ddce-f6b7-4f50-8636-954aad785bda"),
                Guid.Parse("0314642e-0eda-473a-9f1e-487acea7b191"),
                Guid.Parse("7f19b793-7023-4751-bcae-b8c25688beef"),
                Guid.Parse("b54d41b5-e213-41ba-8435-b7f3d6234fa7"),
                Guid.Parse("870bd28d-2b95-4e23-b0f9-0db46e924a87"),
                Guid.Parse("c1b0c347-ffd4-466e-8966-0fb02971b4ca")
            };
            var productNames = new List<string>() { "Sofa Set", "Armchair", "Coffee Table", "Bed Frame", "Mattress", "Nightstand", "Dining Table", "Dining Chair", "Japan Cabinet", "Bookcase" };
            var productCategories = new List<string>() { "Living Room Furniture", "Bedroom Furniture", "Dining Room Furniture", "Home Office Furniture" };
            var productPrices = new List<double>() { 1500.00, 500.00, 300.00, 1000.00, 800.00, 200.00, 1200.00, 150.00, 1500.00, 800.00 };

            var productSS = new Product()
            {
                ProductID = productsGuids[0],
                ProductName = productNames[0],
                Category = productCategories[0],
                Price = productPrices[0]
            };
            var productA = new Product()
            {
                ProductID = productsGuids[1],
                ProductName = productNames[1],
                Category = productCategories[0],
                Price = productPrices[1]
            };
            var productCT = new Product()
            {
                ProductID = productsGuids[2],
                ProductName = productNames[2],
                Category = productCategories[0],
                Price = productPrices[2]
            };
            var productBF = new Product()
            {
                ProductID = productsGuids[3],
                ProductName = productNames[3],
                Category = productCategories[1],
                Price = productPrices[3]
            };
            var productM = new Product()
            {
                ProductID = productsGuids[4],
                ProductName = productNames[4],
                Category = productCategories[1],
                Price = productPrices[4]
            };
            var productN = new Product()
            {
                ProductID = productsGuids[5],
                ProductName = productNames[5],
                Category = productCategories[1],
                Price = productPrices[5]
            };
            var productDT = new Product()
            {
                ProductID = productsGuids[6],
                ProductName = productNames[6],
                Category = productCategories[2],
                Price = productPrices[6]
            };
            var productDC = new Product()
            {
                ProductID = productsGuids[7],
                ProductName = productNames[7],
                Category = productCategories[2],
                Price = productPrices[7]
            };
            var productJC = new Product()
            {
                ProductID = productsGuids[8],
                ProductName = productNames[8],
                Category = productCategories[2],
                Price = productPrices[8]
            };
            var productB = new Product()
            {
                ProductID = productsGuids[9],
                ProductName = productNames[9],
                Category = productCategories[3],
                Price = productPrices[9]
            };

            #endregion

            #region InStoreProduct Data
            var inStoreProductGuids = new List<Guid>()
            {
                Guid.Parse("f3c72cc3-d2e8-4296-bf34-712ddfabd5f9"),
                Guid.Parse("6bbd1c61-69cb-4de6-b7f6-4c144b62dc4a"),
                Guid.Parse("90cb0a2d-5da5-4cf4-8e0c-4ecaa1704d4e"),
                Guid.Parse("f7a0dd2a-1da5-4f45-b338-59306e48c802"),
                Guid.Parse("9ec8c30f-d6c1-47ba-9d62-c2128a7e374a"),
                Guid.Parse("ba43d2f9-0763-43fc-9cfc-d37f57f8c7df"),
                Guid.Parse("e94db7d1-c1c9-4019-bd31-0ba7d319b361"),
                Guid.Parse("a88c904a-760d-40a9-879f-3e05c304d307"),
                Guid.Parse("f57d030b-7b23-463d-8041-e33436c62f0e"),
                Guid.Parse("777e83d8-b996-4186-a7b4-4d4a4c9e21a6"),
                Guid.Parse("d2d6bfc8-2c3c-42a6-816e-84a8c08e60b5"),
                Guid.Parse("ee05d814-32c2-47a3-97a3-d6df16d9a72e"),
                Guid.Parse("6b1c6a60-6a1a-4df5-b0e3-8fb9c93ab55e"),
                Guid.Parse("5d5d5c5c-1635-4c12-b5d5-babfbac9d0cc"),
                Guid.Parse("7ee570c1-2b7e-480a-8706-5e6d208fb6b9"),
                Guid.Parse("f3f30c95-8ba6-4bc6-bc27-fa0e99128a8b"),
                Guid.Parse("1f2edbe3-23b8-44aa-a812-66607c7bc09e"),
                Guid.Parse("9b22f0b2-c7d2-466c-9737-0f68b32aa759"),
                Guid.Parse("b0ec7e9d-6d29-47d5-b5bb-1bcb5ed312c5"),
                Guid.Parse("dab37d9c-69f5-4d17-991c-8c4dded6901a"),
                Guid.Parse("3d72d978-9ee9-4e24-a798-01d08d9055f5"),
                Guid.Parse("66b36a90-2d75-4e9f-ae57-ebe0f17aebc4"),
                Guid.Parse("19a69e71-e463-4d11-9e25-d061033b4126")
            };
            var inStoreProductsQuantity = new List<int>() { 5, 3, 10, 2, 20, 5, 10, 7, 0, 10, 2, 5, 15, 3, 3, 1, 10, 5, 0, 2, 1, 8, 4 };
            var inStoreProductStatus = new List<ProductStatus>()
            {
                ProductStatus.Active, ProductStatus.Active,
                ProductStatus.Active,ProductStatus.OutOfStock,
                ProductStatus.Active,ProductStatus.InActive,ProductStatus.Active,
                ProductStatus.Active,ProductStatus.OutOfStock,
                ProductStatus.Active,ProductStatus.Active,ProductStatus.OutOfStock,
                ProductStatus.Active,ProductStatus.InActive,
                ProductStatus.Active,ProductStatus.InActive,
                ProductStatus.Active,ProductStatus.Active,ProductStatus.OutOfStock,
                ProductStatus.Active,ProductStatus.InActive,
                ProductStatus.Active,ProductStatus.InActive
            };
            #endregion

            #region Product Locations (BelongTo)
            var storeGuids = new List<Guid>()
            {
                Guid.Parse("2f7c4295-4f2f-4651-891b-9b61b6e3adac"),
                Guid.Parse("ad6c7bb8-90a3-4f9a-abf8-be36acba1012")
            };

            var warehouseGuids = new List<Guid>()
            {
                Guid.Parse("c4b89d97-95c7-4d97-bf8a-3cb3e2b058e3"),
                Guid.Parse("d1c7f3ab-3f18-46c9-9a0b-25e16f80bf7f")
            };
            #endregion

            var inStoreProduct1 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[0],
                ProductID = productSS.ProductID,
                //Product = productSS,
                Quantity = inStoreProductsQuantity[0],
                Status = inStoreProductStatus[0],
                BelongTo = storeGuids[0]
            };
            var inStoreProduct2 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[1],
                ProductID = productSS.ProductID,
                //Product = productSS,
                Quantity = inStoreProductsQuantity[1],
                Status = inStoreProductStatus[1],
                BelongTo = warehouseGuids[0]
            };
            var inStoreProduct3 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[2],
                ProductID = productA.ProductID,
                //Product = productA,
                Quantity = inStoreProductsQuantity[2],
                Status = inStoreProductStatus[2],
                BelongTo = storeGuids[1]
            };
            var inStoreProduct4 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[3],
                ProductID = productA.ProductID,
                //Product = productA,
                Quantity = inStoreProductsQuantity[3],
                Status = inStoreProductStatus[3],
                BelongTo = warehouseGuids[1]
                
            };
            var inStoreProduct5 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[4],
                ProductID = productCT.ProductID,
                //Product = productCT,
                Quantity = inStoreProductsQuantity[4],
                Status = inStoreProductStatus[4],
                BelongTo = storeGuids[0]
            };
            var inStoreProduct6 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[5],
                ProductID = productCT.ProductID,
                //Product = productCT,
                Quantity = inStoreProductsQuantity[5],
                Status = inStoreProductStatus[5],
                BelongTo = storeGuids[1]
            };
            var inStoreProduct7 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[6],
                ProductID = productCT.ProductID,
                //Product = productCT,
                Quantity = inStoreProductsQuantity[6],
                Status = inStoreProductStatus[6],
                BelongTo = warehouseGuids[0]
            };
            var inStoreProduct8 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[7],
                ProductID = productBF.ProductID,
                //Product = productBF,
                Quantity = inStoreProductsQuantity[7],
                Status = inStoreProductStatus[7],
                BelongTo = warehouseGuids[0]
            };
            var inStoreProduct9 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[8],
                ProductID = productBF.ProductID,
                //Product = productBF,
                Quantity = inStoreProductsQuantity[8],
                Status = inStoreProductStatus[8],
                BelongTo = warehouseGuids[1]
            };
            var inStoreProduct10 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[9],
                ProductID = productM.ProductID,
                //Product = productM,
                Quantity = inStoreProductsQuantity[9],
                Status = inStoreProductStatus[9],
                BelongTo = storeGuids[0]
            };
            var inStoreProduct11 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[10],
                ProductID = productM.ProductID,
                //Product = productM,
                Quantity = inStoreProductsQuantity[10],
                Status = inStoreProductStatus[10],
                BelongTo = storeGuids[1]
            };
            var inStoreProduct12 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[11],
                ProductID = productM.ProductID,
                //Product = productM,
                Quantity = inStoreProductsQuantity[11],
                Status = inStoreProductStatus[11],
                BelongTo = warehouseGuids[1]
            };
            var inStoreProduct13 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[12],
                ProductID = productN.ProductID,
                //Product = productN,
                Quantity = inStoreProductsQuantity[12],
                Status = inStoreProductStatus[12],
                BelongTo = storeGuids[0]
            };
            var inStoreProduct14 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[13],
                ProductID = productN.ProductID,
                //Product = productN,
                Quantity = inStoreProductsQuantity[13],
                Status = inStoreProductStatus[13],
                BelongTo = warehouseGuids[1]
            };
            var inStoreProduct15 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[14],
                ProductID = productDT.ProductID,
                //Product = productDT,
                Quantity = inStoreProductsQuantity[14],
                Status = inStoreProductStatus[14],
                BelongTo = storeGuids[1]
            };
            var inStoreProduct16 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[15],
                ProductID = productDT.ProductID,
                //Product = productDT,
                Quantity = inStoreProductsQuantity[15],
                Status = inStoreProductStatus[15],
                BelongTo = warehouseGuids[0]
            };
            var inStoreProduct17 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[16],
                ProductID = productDC.ProductID,
                //Product = productDC,
                Quantity = inStoreProductsQuantity[16],
                Status = inStoreProductStatus[16],
                BelongTo = storeGuids[0]
            };
            var inStoreProduct18 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[17],
                ProductID = productDC.ProductID,
                //Product = productDC,
                Quantity = inStoreProductsQuantity[17],
                Status = inStoreProductStatus[17],
                BelongTo = warehouseGuids[0]
            };
            var inStoreProduct19 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[18],
                ProductID = productDC.ProductID,
                //Product = productDC,
                Quantity = inStoreProductsQuantity[18],
                Status = inStoreProductStatus[18],
                BelongTo = warehouseGuids[1]
            };
            var inStoreProduct20 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[19],
                ProductID = productJC.ProductID,
                //Product = productJC,
                Quantity = inStoreProductsQuantity[19],
                Status = inStoreProductStatus[19],
                BelongTo = storeGuids[1]
            };
            var inStoreProduct21 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[20],
                ProductID = productJC.ProductID,
                //Product = productJC,
                Quantity = inStoreProductsQuantity[20],
                Status = inStoreProductStatus[20],
                BelongTo = warehouseGuids[1]
            };
            var inStoreProduct22 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[21],
                ProductID = productB.ProductID,
                //Product = productB,
                Quantity = inStoreProductsQuantity[21],
                Status = inStoreProductStatus[21],
                BelongTo = storeGuids[0]
            };
            var inStoreProduct23 = new InStoreProduct()
            {
                InStoreProductID = inStoreProductGuids[22],
                ProductID = productB.ProductID,
                //Product = productB,
                Quantity = inStoreProductsQuantity[22],
                Status = inStoreProductStatus[22],
                BelongTo = warehouseGuids[0]
            };

            inStoreProducts.Add(inStoreProduct1);
            inStoreProducts.Add(inStoreProduct2);
            inStoreProducts.Add(inStoreProduct3);
            inStoreProducts.Add(inStoreProduct4);
            inStoreProducts.Add(inStoreProduct5);
            inStoreProducts.Add(inStoreProduct6);
            inStoreProducts.Add(inStoreProduct7);
            inStoreProducts.Add(inStoreProduct8);
            inStoreProducts.Add(inStoreProduct9);
            inStoreProducts.Add(inStoreProduct10);
            inStoreProducts.Add(inStoreProduct11);
            inStoreProducts.Add(inStoreProduct12);
            inStoreProducts.Add(inStoreProduct13);
            inStoreProducts.Add(inStoreProduct14);
            inStoreProducts.Add(inStoreProduct15);
            inStoreProducts.Add(inStoreProduct16);
            inStoreProducts.Add(inStoreProduct17);
            inStoreProducts.Add(inStoreProduct18);
            inStoreProducts.Add(inStoreProduct19);
            inStoreProducts.Add(inStoreProduct20);
            inStoreProducts.Add(inStoreProduct21);
            inStoreProducts.Add(inStoreProduct22);
            inStoreProducts.Add(inStoreProduct23);


            modelBuilder.Entity<InStoreProduct>().HasData(inStoreProducts);
        }
    }
}
