using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.BLL
{
    public interface IPurchaseService
    {
        public Task<Purchase> Add(Purchase purchase);
        public Task<List<Purchase>> GetAllPurchases();
        public  Task<Card> UpdatePresentToPurchase(CardDto cardDto);
        public  Task<Purchase> AddPresentToPurchase( CardDto cardDto);
        public Task<bool> DeletePurchase(int purchaseId);
        public Task<Purchase> FindPurchaseById(int Id);
        public Task<List<Purchase>> FindPurchaseByCustomerId(int customerId);
        public Task<Customer> GetCustomerDetails(int purchaseId);
        public Task<List<Customer>> GetAllCustomersDetails();
        public Task<List<Card>> GetPresentPurchase(int PurchaseId);
        public Task<Purchase> UpdatePurchase(Purchase newPurchase, int purchaseId);
    }
}
