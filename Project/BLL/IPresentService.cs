using Project.Models;

namespace Project.BLL
{
    public interface IPresentService
    {
        public Task<Present> Add(Present present);
        public Task<Card> AddToCart(Card present, int customerId);
        public Task<Donor> GetPresentDonor(int presentId);
        public Task<List<Present>> GetAllPresent();
        public Task<bool> DeletePresent(int presentId);
        public Task<Present> UpdatePresent(Present newPresent, int presentId);
        public Task<Present> FindPresentByName(string name);
        public Task<Present> FindPresentByDonor(int donorId);
        public Task<Present> FindPresentByNumCustomer(int Amount);
        public Task<List<Present>> FindPresentByPrice(int price);
        public Task<List<Present>> FindPresentByCategory(string CategoryName);
        public Task<Present> UpdateWinnerOfPresent(Present c, int presentId);
    }
}
