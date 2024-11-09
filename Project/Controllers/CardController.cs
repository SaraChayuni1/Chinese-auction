using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.Models.DTO;
using Project.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Project.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CardController: ControllerBase
    {
            private readonly ICardService cardService;
            private readonly IMapper mapper;
            public CardController(ICardService cardService, IMapper mapper)
            {
                this.cardService = cardService;
                this.mapper = mapper;
            }

            [HttpPost("/Card/Add")]
            public async Task<Card> Add(CardDto card)
            {
                var c = mapper.Map<Card>(card);
                return await cardService.Add(c);

            }
            [HttpGet("/Card/GetAllCards")]
            public async Task<List<Card>> GetAllCards()
            {
                return await cardService.GetAllCards();
            }
            [HttpDelete("/Card/{CardId}")]
            public async Task<bool> DeleteCard(int CardId)
            {
                return await cardService.DeleteCard(CardId);
            }
            [HttpPut("/Card/{cardId}")]
            public async Task<Card> UpdateCard(Card newCard, int cardId)
            {
                return await cardService.UpdateCard(newCard, cardId);
            }

        [HttpGet("GetCardsByPurchesId/{PurchesId}")]
        public Task<List<Card>> GetCardsByPurchesId(int PurchesId)
        {
            return cardService.GetCardsByPurchesId(PurchesId);
        }

        [HttpGet("GetCardsByPresentId/{PresentId}")]
        public  Task<List<Card>> GetCardsByPresentId(int PresentId)
        {
            return cardService.GetCardsByPresentId(PresentId);
        }
    }
}

