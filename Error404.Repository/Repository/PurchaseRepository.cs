using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Error404.Model.Model;
using Error404.DatabaseContext.DatabaseContext;
using System.Data.Entity;

namespace Error404.Repository.Repository
{
    public class PurchaseRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Purchase purchase)
        {
            _dbContext.Purchases.Add(purchase);
            return _dbContext.SaveChanges() > 0;
        }

        public List<Purchase> GetAllPurchase()
        {
            var purchases = _dbContext.Purchases.Include(p => p.Supplier).ToList();
            return purchases;
        }

        public List<PurchaseDetails> GetAll()
        {
            var purchaseDetails = _dbContext.PurchaseDetails.Include(p => p.Product).ToList();
            return purchaseDetails;
        }

        public bool Update(PurchaseDetails purchaseDetails)
        {
            PurchaseDetails singleProduct = _dbContext.PurchaseDetails.FirstOrDefault(c => c.Id == purchaseDetails.Id);
            if (singleProduct != null)
            {
                singleProduct.CategoryId = purchaseDetails.CategoryId;
                singleProduct.ProductId = purchaseDetails.ProductId;
                singleProduct.Code = purchaseDetails.Code;
                singleProduct.ManufactureDate = purchaseDetails.ManufactureDate;
                singleProduct.ExpireDate = purchaseDetails.ExpireDate;
                singleProduct.Quantity = purchaseDetails.Quantity;
                singleProduct.UnitPrice = purchaseDetails.UnitPrice;
                singleProduct.TotalPrice = purchaseDetails.TotalPrice;
                singleProduct.PreviousUnitPrice = purchaseDetails.PreviousUnitPrice;
                singleProduct.PreviousMRP = purchaseDetails.PreviousMRP;
                singleProduct.MRP = purchaseDetails.MRP;
                singleProduct.Remarks = purchaseDetails.Remarks;
            }

            return _dbContext.SaveChanges() > 0;
        }


    }
}
