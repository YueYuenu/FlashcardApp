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

        public Task CreateCardDeckAsync(CardDeck cardDeck)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeckById(int id)
        {
            throw new NotImplementedException();
        }

        public CardDeck GetCardDeckById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardDeck> GetCardDecks()
        {
            return _dataContext.Set<CardDeck>();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateCardDeck(CardDeck deck)
        {
            throw new NotImplementedException();
        }
    }
}