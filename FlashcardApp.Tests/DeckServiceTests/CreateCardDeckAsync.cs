using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.DeckServiceTests
{
    public class CreateCardDeckAsync : Base
    {
        [Fact]
        public async void CardDeck_Name_is_NULL()
        {
            //Arrange
            CardDeck deck = new() { DeckName = null };
            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await _deckService.CreateCardDeckAsync(deck));
        }

        [Fact]
        public async void CardDeck_Name_is_EmptyString()
        {
            //Arrange
            CardDeck deck = new() { DeckName = "" };
            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await _deckService.CreateCardDeckAsync(deck));
        }

        [Fact]
        public async void CardDeck_is_NULL()
        {
            //Arrange

            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await _deckService.CreateCardDeckAsync(null));
        }

        [Fact]
        public async void CardDeck_is_Created()
        {
            //Arrange
            CardDeck card = new() { DeckName = "test deck" };
            //Act
            await _deckService.CreateCardDeckAsync(card);

            //Assert
            _deckRepo.Verify(x => x.CreateCardDeckAsync(card), Times.Once);
            _deckRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}