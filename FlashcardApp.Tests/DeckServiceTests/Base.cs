using FlashcardApp.Business;
using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class Base
    {
        public List<CardDeck> Decks { get; set; }
        protected Mock<IEFDeckRepo> _deckRepo;
        protected Mock<IDeckService> _ServiceMock;
        protected DeckService _deckService;

        protected Base()
        {
            _ServiceMock = new Mock<IDeckService>();
            _deckRepo = new Mock<IEFDeckRepo>();
            _deckService = new DeckService(_deckRepo.Object);
            Decks = new List<CardDeck>()
            {
                new CardDeck() {DeckName = "test 1", DeckId = 1},
                new CardDeck() {DeckName = "test 2", DeckId = 2},
                new CardDeck() {DeckName = "test 3", DeckId = 3},
                new CardDeck() {DeckName = "test 4", DeckId = 4},
                new CardDeck() {DeckName = "test 5", DeckId = 5},
            };
        }
    }
}