using Project.Models.DTO;
using Project.Models;

namespace Project.DAL
{
    public interface ICardDal
    {
        public Task<Card> Add(Card card);
        public Task<List<Card>> GetAllCards();
        public Task<bool> DeleteCard(int CardId);
        public Task<Card> UpdateCard(Card newCard, int cardId);

        Task<List<Card>> GetCardsByPurchesId(int PurchesId);

        public  Task<List<Card>> GetCardsByPresentId(int PresentId);
    }
}
