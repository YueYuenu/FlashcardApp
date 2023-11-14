using FlashcardApp.Domain.Models;

namespace FlashcardApp.Domain.Interfaces
{
    public interface IEFDeckRepo
    {
        /// <summary>
        /// Create new Deck
        /// </summary>
        /// <param name="cardDeck"></param>
        /// <returns></returns>
        public Task<CardDeck> CreateCardDeckAsync(CardDeck cardDeck);

        /// <summary>
        /// Get List of card Decks
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CardDeck> GetCardDecks();

        /// <summary>
        /// Search deck by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CardDeck GetCardDeckById(int id);

        /// <summary>
        /// Search for a deck using a Flashcards Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CardDeck GetCardDeckByFlashcardId(int id);

        /// <summary>
        /// Search card decks
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<CardDeck> SearchCardDecks(string query);

        /// <summary>
        /// Update the card deck
        /// </summary>
        /// <param name="deck"></param>
        public CardDeck UpdateCardDeck(CardDeck deck);

        /// <summary>
        /// Delete card deck
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDeckById(int id);

        /// <summary>
        /// Save changes async to database
        /// </summary>
        /// <returns></returns>
        public Task SaveChangesAsync();
    }
}