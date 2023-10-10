using FlashcardApp.Domain.Models;

namespace FlashcardApp.Domain.Interfaces
{
    public interface IDeckService
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
        /// Update the card deck
        /// </summary>
        /// <param name="deck"></param>
        public Task<CardDeck> UpdateCardDeckAsync(CardDeck deck);

        /// <summary>
        /// Delete card deck
        /// </summary>
        /// <param name="id"></param>
        public Task DeleteById(int id);
    }
}