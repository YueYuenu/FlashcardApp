using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class GetCardDeckByFlashcardId : Base
    {
        [Fact]
        public void Get_CardDeck_By_Flashcard_Id()
        {
            //Arrange
            _deckRepo.Setup(x => x.GetCardDeckByFlashcardId(1)).Returns(new CardDeck() { DeckId = 2, DeckName = "testdeck" });

            //Act
            CardDeck founddeck = _deckService.GetCardDeckByFlashcardId(1);
            //Assert
            Assert.Equal(2, founddeck.DeckId);
        }
    }
}