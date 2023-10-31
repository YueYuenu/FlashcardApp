using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class GetAllCardDecks : Base
    {
        [Fact]
        public void Get_List_of_Decks()
        {
            //Arrange
            List<CardDeck> list = new()
            {
                new CardDeck {DeckId = 1, DeckName = "deck1"},
                new CardDeck {DeckId = 2, DeckName = "deck2"},
                new CardDeck {DeckId = 3, DeckName = "deck3"}
            };

            _deckRepo.Setup(x => x.GetCardDecks()).Returns(list.AsQueryable());
            //Act

            //Assert
            Assert.Equal(3, _deckService.GetCardDecks().Count());
        }
    }
}