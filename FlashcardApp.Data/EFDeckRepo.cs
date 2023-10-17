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
            return _dataContext.Set<CardDeck>().Where(x => x.DeckId == id).FirstOrDefault();
        }

        public IEnumerable<CardDeck> GetCardDecks()
        {
            return _dataContext.Set<CardDeck>();
        }

        public CardDeck UpdateCardDeck(CardDeck deck)
        {
            _dataContext.Update<CardDeck>(deck);
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