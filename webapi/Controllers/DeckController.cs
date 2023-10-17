using FlashcardApp.Domain.Interfaces;
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

        [HttpGet]
        [Route("GetAllCardDecks")]
        public IActionResult GetAllCardDecks()
        {
            return Ok(_deckService.GetCardDecks());
        }
    }
}