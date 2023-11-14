using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class SearchCardDecks : Base
    {
        [Fact]
        public void Search_result_found()
        {
            //Arrange

            //Act
            _deckRepo.Setup(x => x.GetCardDecks()).Returns(Decks);
            IEnumerable<CardDeck> result = _deckService.SearchCardDecks("3");

            //Assert
            Assert.Equal("test 3", result.SingleOrDefault().DeckName);
        }
    }
}