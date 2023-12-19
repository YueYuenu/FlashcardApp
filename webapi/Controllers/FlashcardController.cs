using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/flashcards")]
    [ApiController]
    public class FlashcardController : ControllerBase
    {
        private readonly IFlashcardService _flashcardService;

        public FlashcardController(IFlashcardService flashcardService)
        {
            _flashcardService = flashcardService;
        }

        public record FlashcardDto(int Id, string Question, string Answer, int DeckId);

        [HttpGet]
        [Route("")]
        public IActionResult GetAllFlashcards()
        {
            return Ok(_flashcardService
                .GetFlashcards()
                .Select(x => new FlashcardDto(x.Id, x.Question, x.Answer, x.DeckId))
            );
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFlashcard(int id) => Ok(_flashcardService.GetFlashcardById(id));

        [HttpGet]
        [Route("DeckId")]
        public IActionResult GetFlashcardByDeckId(int id) => Ok(_flashcardService.GetFlashcardByDeckId(id));

        [HttpGet]
        [Route("Search")]
        public IActionResult SearchFlashcards(string query) => Ok(_flashcardService.SearchFlashcards(query));

        [HttpGet]
        [Route("Randomize")]
        public IActionResult GetRandomizedFlashcards(List<Flashcard> flashcards) => Ok(_flashcardService.GetRandomizedCards(flashcards));

        [HttpPost]
        public async Task<IActionResult> CreateFlashcard([FromBody] Flashcard flashcard)
        {
            if (flashcard == null) { return BadRequest(); }
            return Ok(await _flashcardService.CreateFlashcardAsync(flashcard));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFlashcard(Flashcard flashcard) => Ok(await _flashcardService.UpdateFlashcardAsync(flashcard));

        [HttpDelete]
        public async Task<ActionResult> DeleteFlashcard(int id)
        {
            try
            {
                await _flashcardService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}