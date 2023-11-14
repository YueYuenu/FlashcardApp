using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/decks")]
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
        public IActionResult GetAllCardDecks()
        {
            return Ok(_deckService
                .GetCardDecks()
                .Select(x => new DeckFlashcardDto(x.DeckName, x.DeckId, x.Flashcards)));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCardDeckById(int id) => Ok(_deckService.GetCardDeckById(id));

        [HttpGet]
        [Route("Search")]
        public IActionResult SearchCardDecks(string query) => Ok(_deckService.SearchCardDecks(query));

        [HttpPost]
        public async Task<IActionResult> CreateCardDeck([FromBody] CardDeck cardDeck)
        {
            if (cardDeck == null) { return BadRequest(); }
            return Ok(await _deckService.CreateCardDeckAsync(cardDeck));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFlashcard(CardDeck cardDeck) => Ok(await _deckService.UpdateCardDeckAsync(cardDeck));

        [HttpDelete]
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