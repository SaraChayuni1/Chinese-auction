using Project.DAL;
using Project.Models.DTO;
using Project.Models;

namespace Project.BLL
{
    public class CardService :ICardService
    {
            private readonly ICardDal cardDal;
            public CardService(ICardDal cardDal)
            {
                this.cardDal = cardDal;
            }
            public async Task<Card> Add(Card card)
            {

                return await cardDal.Add(card);
            }


            public async Task<List<Card>> GetAllCards()
            {
                return await cardDal.GetAllCards();
            }

            public async Task<bool> DeleteCard(int CardId)
            {
                return await cardDal.DeleteCard(CardId);
            }

            public async Task<Card> UpdateCard(Card newCard, int cardId)
            {
                return await cardDal.UpdateCard(newCard, cardId);
            }

        public async Task<List<Card>> GetCardsByPurchesId(int PurchesId)
        {
            return await cardDal.GetCardsByPurchesId(PurchesId);
        }

        public async Task<List<Card>> GetCardsByPresentId(int PresentId)
        {

            return await cardDal.GetCardsByPresentId(PresentId);
        }
    }
    
}
