using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;

namespace FlashcardApp.Data
{
    public class EFDeckRepo : IEFDeckRepo
    {
        private readonly DataContext _dataContext;

        public EFDeckRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CardDeck> CreateCardDeckAsync(CardDeck cardDeck)
        {
            await _dataContext.AddAsync(cardDeck);
            return cardDeck;
        }

        public CardDeck GetCardDeckById(int id)
        {
            if (!_dataContext.Set<CardDeck>().Any(x => x.DeckId == id))
                throw new KeyNotFoundException();
            return _dataContext.Set<CardDeck>().Where(x => x.DeckId == id).FirstOrDefault();
        }

        public CardDeck GetCardDeckByFlashcardId(int id)
        {
            Flashcard card = _dataContext.Set<Flashcard>().Where(x => x.Id == id).FirstOrDefault();
            return _dataContext.Set<CardDeck>().Where(x => x.DeckId == card.DeckId).FirstOrDefault();
        }

        public IEnumerable<CardDeck> SearchCardDecks(string query)
        {
            return GetCardDecks().Where(x => x.DeckName.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<CardDeck> GetCardDecks()
        {
            return _dataContext.Set<CardDeck>();
        }

        public CardDeck UpdateCardDeck(CardDeck deck)
        {
            _dataContext.Update(deck);
            return deck;
        }

        public void DeleteDeckById(int id)
        {
            CardDeck deckToDelete = _dataContext.Set<CardDeck>().Where(x => x.DeckId == id).FirstOrDefault();
            if (deckToDelete != null) { _dataContext.Remove(deckToDelete); }
            //TODO add something in case ID does not exist
        }

        public Task SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }
    }
}