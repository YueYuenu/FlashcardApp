using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class DeleteCardDeck : Base
    {
        [Fact]
        public async void CardDeck_gets_deleted()
        {
            //Arrange
            _deckRepo.Setup(x => x.GetCardDeckById(1)).Returns(new CardDeck { DeckId = 1, DeckName = "deck to delete" });

            //Act
            await _deckService.DeleteById(1);

            //Assert
            _deckRepo.Verify(x => x.DeleteDeckById(1), Times.Once);
            _deckRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}