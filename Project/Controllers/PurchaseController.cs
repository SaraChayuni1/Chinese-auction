using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;
        private readonly IMapper mapper;


        public PurchaseController(IPurchaseService getpurchaseService, IMapper mapper)
        {
            purchaseService = getpurchaseService;
            this.mapper = mapper;

        }
        [HttpPost("/Purchase/Add")]
        public async Task<Purchase> Add(PurchaseDto purchase)
        {
            var c = mapper.Map<Purchase>(purchase);
            return await purchaseService.Add(c);
        }

        [HttpGet("/Purchase/GetAllPurchases")]
        public async Task<List<Purchase>> GetAllPurchases()
        {
            return await purchaseService.GetAllPurchases();
        }

        [HttpPost("/Purchase/AddPresentToPurchase")]
        public async Task<Purchase> AddPresentToPurchase( CardDto cardDto)
        {
            return await purchaseService.AddPresentToPurchase( cardDto);
        }
        [HttpPut("/Purchase/UpdatePresentToPurchase")]
        public async Task<Card> UpdatePresentToPurchase( CardDto cardDto)
        {
            return await purchaseService.UpdatePresentToPurchase( cardDto);
        }
        [HttpDelete("/Purchase/{purchaseId}")]
        public async Task<bool> DeletePurchase(int purchaseId)
        {
            return await purchaseService.DeletePurchase(purchaseId);
        }
        [HttpGet("/Purchase/FindPurchaseById/{FindPurchaseById}")]
        public async Task<Purchase> FindPurchaseById(int FindPurchaseById)
        {
            return await purchaseService.FindPurchaseById(FindPurchaseById);
        }
        [HttpGet("/Purchase/FindPurchaseByCustomerId/{customerId}")]
        public async Task<List<Purchase>> FindPurchaseByCustomerId(int customerId)
        {
            return await purchaseService.FindPurchaseByCustomerId(customerId);
        }

        [HttpGet("/Purchase/{GetCustomerDetails}")]
        public async Task<Customer> GetCustomerDetails(int GetCustomerDetails)
        {
            return await purchaseService.GetCustomerDetails(GetCustomerDetails);
        }

        [HttpGet("/Purchase/GetAllCustomersDetails")]
        public async Task<List<Customer>> GetAllCustomersDetails()
        {
            return await purchaseService.GetAllCustomersDetails();
        }
        [HttpGet("/Purchase/{GetPresentPurchase}")]
        public async Task<List<Card>> GetPresentPurchase(int GetPresentPurchase)
        {
            return await purchaseService.GetPresentPurchase(GetPresentPurchase);
        }

        [HttpPut("/Purchase/UpdatePurchase/{purchaseId}")]
        public async Task<Purchase> UpdatePurchase(PurchaseDto newPurchase, int purchaseId)
        {
            var c = mapper.Map<Purchase>(newPurchase);
            return await purchaseService.UpdatePurchase(c, purchaseId);
        }
    }
}
