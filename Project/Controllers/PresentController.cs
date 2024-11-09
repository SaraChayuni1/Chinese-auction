using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PresentController : ControllerBase
    {

        private readonly IPresentService presentService;
        private readonly IMapper mapper;


        public PresentController(IPresentService presentService, IMapper mapper)
        {
            this.presentService = presentService;
            this.mapper = mapper;

        }
        [HttpPost("/Present/Add")]
        public async Task<Present> Add(PresentDto Present) //להוסיף מתנה לתורם מסוים
        {
            var c = mapper.Map<Present>(Present);
            
            return await presentService.Add(c);
        }
        [HttpPost("/Present/AddToCart")]
        public async Task<Card> AddToCart(Card present, int customerId)//להוסיף מתנה לסל של לקוח מסוים
        {
            return await presentService.AddToCart(present,customerId);
        }
        [HttpGet("/Present/GetAllPresents")]
        public async Task<List<Present>> GetAllPresent()
        {

            return await presentService.GetAllPresent();
        }
        [HttpDelete("/Present/{presentId}")]

        [Authorize(Roles = "Manager")]
        public async Task<bool> DeletePresent(int presentId)
        {
            return await presentService.DeletePresent(presentId);
        }
        [HttpPut("/Present/{presentId}")]
      
        public async Task<Present> UpdatePresent(PresentDto PresentDto, int presentId)

        {
            var c = mapper.Map<Present>(PresentDto);
            c.Id = presentId;
            return await presentService.UpdatePresent(c, presentId);
        }
        [HttpPut("/Present/UpdateWinnerOfPresent/{UpdateWinnerOfPresent}")]
        public async Task<Present> UpdateWinnerOfPresent(PresentDto PresentDto, int presentId)
        {
            var c = mapper.Map<Present>(PresentDto);
            c.Id = presentId;
         
            return await presentService.UpdateWinnerOfPresent(c, presentId);
        }
        [HttpGet("/Present/{FindPresentByName}")]
        public async Task<Present> FindPresentByName(string FindPresentByName)
        {
            return await presentService.FindPresentByName(FindPresentByName);
        }
        [HttpGet("/Present/{FindPresentByDonor}")]
        public async Task<Present> FindPresentByDonor(int FindPresentByDonor)
        {
            return await presentService.FindPresentByDonor(FindPresentByDonor);

        }
        [HttpGet("/Present/{FindPresentByNumCustomer}")]
        public async Task<Present> FindPresentByNumCustomer(int FindPresentByNumCustomer)
        {
            return await presentService.FindPresentByNumCustomer(FindPresentByNumCustomer);

        }
        [HttpGet("/Present/FindPresentByPrice/{FindPresentByPrice}")]
        public async Task<List<Present>> FindPresentByPrice(int FindPresentByPrice)
        {
            return await presentService.FindPresentByPrice(FindPresentByPrice);
        }
        [HttpGet("/Present/FindPresentByCategory/{FindPresentByCategory}")]
        public async Task<List<Present>> FindPresentByCategory(string FindPresentByCategory)
        {
            return await presentService.FindPresentByCategory(FindPresentByCategory);
        }
        
        
    
    }
}

