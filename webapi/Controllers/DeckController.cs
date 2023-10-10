using FlashcardApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private IDeckService _deckService;

        public DeckController(IDeckService deckService)
        {
            _deckService = deckService;
        }

        [HttpGet]
        [Route("GetAllCardDecks")]
        public IActionResult GetAllCardDecks()
        {
            return Ok(_deckService.GetCardDecks());

            //TODO System.InvalidOperationException: Unable to resolve service for type
            //'FlashcardApp.Domain.Interfaces.IDeckService' while attempting to activate
            //'webapi.Controllers.DeckController'.
        }
    }
}