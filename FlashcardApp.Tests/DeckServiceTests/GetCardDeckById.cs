using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class GetCardDeckById : Base
    {
        [Fact]
        public void Return_deck_with_id()
        {
            //Arrange
            //Act
            _deckRepo.Setup(x => x.GetCardDeckById(1)).Returns(new CardDeck { DeckId = 1 });

            //Assert
            Assert.Equal(1, _deckService.GetCardDeckById(1).DeckId);
        }

        [Fact]
        public void No_Deck_with_Searched_Id()
        {
            //Arrange

            //Act
            _deckRepo.Setup(x => x.GetCardDeckById(2)).Throws<KeyNotFoundException>();

            //Assert
            Assert.Throws<Exception>(() => _deckService.GetCardDeckById(2));
        }

        [Fact]
        public void Deck_is_null()
        {
            //Arrange
            //Act
            _deckRepo.Setup(x => x.GetCardDeckById(1)).Returns((CardDeck)null);

            //Assert
            Assert.Throws<Exception>(() => _deckService.GetCardDeckById(1));
        }
    }
}