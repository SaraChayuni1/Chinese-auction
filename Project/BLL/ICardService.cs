using Project.Models.DTO;
using Project.Models;

namespace Project.BLL
{
    public interface ICardService
    {
        public Task<Card> Add(Card card);
        public Task<List<Card>> GetAllCards();
        public Task<bool> DeleteCard(int cardId);
        public Task<Card> UpdateCard(Card newCard, int cardId);

        public Task<List<Card>> GetCardsByPresentId(int PresentId);
        Task<List<Card>> GetCardsByPurchesId(int PurchesId);
    }
}
