using flashcardApp.Domain.Models;

namespace FlashcardApp.Domain.Interfaces
{
    public interface IFlashcardService
    {
        /// <summary>
        /// Create new flashcard
        /// </summary>
        /// <param name="id"></param>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public Task<Flashcard> CreateFlashcardAsync(Flashcard flashcard);

        /// <summary>
        /// Get all flashcards
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Flashcard> GetFlashcards();

        /// <summary>
        /// Search flashcard by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Flashcard GetFlashcardById(int id);

        /// <summary>
        /// Search flashcard
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Flashcard> SearchFlashcards(string query);

        /// <summary>
        /// Update/change flashcard
        /// </summary>
        /// <param name="id"></param>
        /// <param name="flashcard"></param>
        /// <returns></returns>
        public Task<Flashcard> UpdateFlashcardAsync(int id, Flashcard flashcard);

        /// <summary>
        /// Delete a flashcard
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteById(int id);
    }
}