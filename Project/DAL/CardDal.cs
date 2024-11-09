using Project.Models.DTO;
using Project.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Project.DAL
{
    public class CardDal : ICardDal
    {

        private readonly OrdersContext ordersContext;

        public CardDal(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }
        public async Task<Card> Add(Card card)
        {
            try
            {
                await ordersContext.Card.AddAsync(card);
                await ordersContext.SaveChangesAsync();
                return card;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
         
public async Task<List<Card>> GetAllCards()
        {
            try
            {
                List<Card> cards = await ordersContext.Card.Include(c => c.Present).Include(c => c.Purchase).ToListAsync();
                return cards;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteCard(int cardId)
        {
            try
            {
                List<Card> cards = await ordersContext.Card.ToListAsync();
                Card deleteCard = cards.FirstOrDefault(p => p.Id == cardId);
                if (deleteCard == null)
                {
                    return false;
                }
                else
                {
                    ordersContext.Card.Remove(deleteCard);
                    await ordersContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Card> UpdateCard(Card newCard, int cardId)
        {
            try
            {
                Card cardToUpdate = await ordersContext.Card.FirstOrDefaultAsync(p => p.Id == cardId);
                if (cardToUpdate == null)
                {
                    return null;
                }
                else
                {
                    cardToUpdate.PurchaseId = newCard.PurchaseId;
                    cardToUpdate.Amount = newCard.Amount;
                    cardToUpdate.PresentID = newCard.PresentID;
                    ordersContext.Card.Update(cardToUpdate);
                    await ordersContext.SaveChangesAsync();
                    return cardToUpdate;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("UpdatePresent failed");
            }
        }

        public async Task<List<Card>> GetCardsByPurchesId(int PurchesId)
        {
            return await ordersContext.Card.Where(c => c.PurchaseId == PurchesId).ToListAsync();
        }
        public async Task<List<Card>> GetCardsByPresentId(int PresentId)
        {
            List<Card> cards = new();
            List<Purchase> purchases = new();
            cards = await ordersContext.Card.Where(c => c.PresentID == PresentId && c.Purchase.IsDraft == false).ToListAsync();
            return cards;
        }

    }
}

