using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.BLL
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseDal purchaseDal;
        public PurchaseService(IPurchaseDal purchasedal)
        {
            this.purchaseDal = purchasedal;
        }

        public async Task<Purchase> Add(Purchase purchase)
        {

            return await purchaseDal.Add(purchase);
        }
        public async Task<List<Purchase>> GetAllPurchases()
        {
            return await purchaseDal.GetAllPurchases();
        }

        public async Task<Card> UpdatePresentToPurchase( CardDto cardDto)
        {
            return await purchaseDal.UpdatePresentToPurchase( cardDto);
        }
        public async Task<Purchase> AddPresentToPurchase( CardDto cardDto)
        {
            return await purchaseDal.AddPresentToPurchase( cardDto);
        }

        public async Task<bool> DeletePurchase(int purchaseId)
        {
            return await purchaseDal.DeletePurchase(purchaseId);
        }
        public async Task<Purchase> FindPurchaseById(int Id)
        {
            return await purchaseDal.FindPurchaseById(Id);
        }
        public async Task<List<Purchase>> FindPurchaseByCustomerId(int customerId)
        {
            return await purchaseDal.FindPurchaseByCustomerId(customerId);
        }


        public async Task<Customer> GetCustomerDetails(int purchaseId)
        {
            return await purchaseDal.GetCustomerDetails(purchaseId);
        }
        public async Task<List<Customer>> GetAllCustomersDetails()
        {
            return await purchaseDal.GetAllCustomersDetails();
        }
        public async Task<List<Card>> GetPresentPurchase(int PurchaseId)
        {
            return await purchaseDal.GetPresentPurchase(PurchaseId);
        }

        public async Task<Purchase> UpdatePurchase(Purchase newPurchase, int purchaseId)
        {
            return await purchaseDal.UpdatePurchase(newPurchase, purchaseId);
        }
    }
}
