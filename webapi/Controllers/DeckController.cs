using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly IDeckService _deckService;

        public DeckController(IDeckService deckService)
        {
            _deckService = deckService;
        }

        public record DeckFlashcardDto(string DeckName, int DeckId, ICollection<Flashcard> Flashcards);

        [HttpGet]
        [Route("GetAllCardDecks")]
        public IActionResult GetAllCardDecks()
        {
            return Ok(_deckService
                .GetCardDecks()
                .Select(x => new DeckFlashcardDto(x.DeckName, x.DeckId, x.Flashcards)));
        } //TODO Fix flascards list so you can actually see which cards are in the deck. atm list is null.

        [HttpGet]
        [Route("GetDeckById")]
        public IActionResult GetCardDeckById(int id)
        {
            return Ok(_deckService.GetCardDeckById(id));
        }

        [HttpPost]
        [Route("CreateFlashcard")]
        public async Task<IActionResult> CreateFlashcard([FromBody] CardDeck cardDeck)
        {
            if (cardDeck == null) { return BadRequest(); }
            return Ok(await _deckService.CreateCardDeckAsync(cardDeck));
        }

        [HttpPut]
        [Route("UpdateCardDeck")]
        public async Task<IActionResult> UpdateFlashcard(CardDeck cardDeck)
        {
            return Ok(await _deckService.UpdateCardDeckAsync(cardDeck));
        }

        [HttpDelete]
        [Route("DeleteCardDeck")]
        public async Task<ActionResult> DeleteFlashcard(int id)
        {
            try
            {
                await _deckService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}