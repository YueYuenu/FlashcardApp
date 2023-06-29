using flashcardApp.Domain.Models;
using FlashcardApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/FlashcardController")]
    [ApiController]
    public class FlashcardController : ControllerBase
    {
        //create card
        //get card(s)
        //get by id
        //search cards?
        //update card
        //delete card
        private readonly IFlashcardService _flashcardService;

        public FlashcardController(IFlashcardService flashcardService)
        {
            _flashcardService = flashcardService;
        }

        [HttpGet]
        [Route("GetAllFlashcards")]
        public IActionResult GetAllFlashcards()
        {
            return Ok(_flashcardService.GetFlashcards());
        }

        [HttpGet]
        [Route("GetFlashcardById")]
        public IActionResult GetFlashcard(int id)
        {
            return Ok(_flashcardService.GetFlashcardById(id));
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
        public async Task<IActionResult> UpdateFlashcard([FromBody] int id, Flashcard flashcard)
        {
            return Ok(await _flashcardService.UpdateFlashcardAsync(id, flashcard));
        }

        [HttpDelete]
        [Route("DeleteFlashcard")]
        public Task DeleteFlashcard(int id)
        {
            return _flashcardService.DeleteById(id);
        }
    }
}