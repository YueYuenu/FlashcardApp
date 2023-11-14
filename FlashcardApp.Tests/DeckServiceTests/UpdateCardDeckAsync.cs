using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class UpdateCardDeckAsync : Base
    {
        [Fact]
        public async void Update_CardDeck_Success()
        {
            //Arrange
            _deckRepo.Setup(x => x.GetCardDeckById(5)).Returns(new CardDeck() { DeckId = 5, DeckName = "to be changed" });
            CardDeck deck = new() { DeckName = "updated", DeckId = 5 };

            //Act
            var tobeupdated = await _deckService.UpdateCardDeckAsync(deck);

            //Assert
            Assert.Equal("updated", tobeupdated.DeckName);
        }

        [Fact]
        public async void Update_CardDeck_NotFound()
        {
            //Arrange
            _deckRepo.Setup(x => x.GetCardDeckById(5)).Returns(new CardDeck() { DeckId = 2, DeckName = "to be changed" });
            CardDeck deck = new() { DeckName = "updated", DeckId = 2 };

            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await _deckService.UpdateCardDeckAsync(deck));
        }

        [Fact]
        public async void DeckName_StringEmpty()
        {
        }
    }
}