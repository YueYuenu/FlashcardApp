using FlashcardApp.Domain.Models;

namespace FlashcardApp.Domain.Interfaces
{
    public interface IEFFlashcardRepo
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
        /// Get flashcard by its deckId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Flashcard GetFlashcardByDeckId(int id);

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
        public Flashcard UpdateFlashcard(Flashcard flashcard);

        /// <summary>
        /// Delete a flashcard
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(int id);

        /// <summary>
        /// Save changes Async
        /// </summary>
        /// <returns></returns>
        public Task SaveChangesAsync();
    }
}