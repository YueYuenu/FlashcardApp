using FlashcardApp.Business;
using FlashcardApp.Domain.Interfaces;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class Base
    {
        protected Mock<IEFDeckRepo> _deckRepo;
        protected Mock<IDeckService> _ServiceMock;
        protected DeckService _deckService;

        protected Base()
        {
            _ServiceMock = new Mock<IDeckService>();
            _deckRepo = new Mock<IEFDeckRepo>();
            _deckService = new DeckService(_deckRepo.Object);
        }
    }
}