using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/FlashcardController")]
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
        [Route("GetAllFlashcards")]
        public IActionResult GetAllFlashcards()
        {
            return Ok(_flashcardService
                .GetFlashcards()
                .Select(x => new FlashcardDto(x.Id, x.Question, x.Answer, x.DeckId))
            );
        }

        [HttpGet]
        [Route("GetFlashcardById")]
        public IActionResult GetFlashcard(int id)
        {
            return Ok(_flashcardService.GetFlashcardById(id));
        }

        [HttpGet]
        [Route("GetFlashcardByDeckId")]
        public IActionResult GetFlashcardByDeckId(int id)
        {
            return Ok(_flashcardService.GetFlashcardByDeckId(id));
        }

        [HttpGet]
        [Route("SearchFlashcards")]
        public IActionResult SearchFlashcards(string query)
        {
            return Ok(_flashcardService.SearchFlashcards(query));
        }

        [HttpPost]
        [Route("CreateFlashcard")]
        public async Task<IActionResult> CreateFlashcard([FromBody] Flashcard flashcard)
        {
            if (flashcard == null) { return BadRequest(); }
            return Ok(await _flashcardService.CreateFlashcardAsync(flashcard));
        }

        [HttpPut]
        [Route("UpdateFlashcard")]
        public async Task<IActionResult> UpdateFlashcard(Flashcard flashcard)
        {
            return Ok(await _flashcardService.UpdateFlashcardAsync(flashcard));
        }

        [HttpDelete]
        [Route("DeleteFlashcard")]
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