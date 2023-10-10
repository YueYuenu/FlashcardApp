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
        Task CreateCardDeckAsync(CardDeck cardDeck);

        /// <summary>
        /// Get List of card Decks
        /// </summary>
        /// <returns></returns>
        IEnumerable<CardDeck> GetCardDecks();

        /// <summary>
        /// Search deck by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CardDeck GetCardDeckById(int id);

        /// <summary>
        /// Update the card deck
        /// </summary>
        /// <param name="deck"></param>
        void UpdateCardDeck(CardDeck deck);

        /// <summary>
        /// Delete card deck
        /// </summary>
        /// <param name="id"></param>
        void DeleteDeckById(int id);

        /// <summary>
        /// Save changes async to database
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}