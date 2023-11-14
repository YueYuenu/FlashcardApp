namespace FlashcardApp.Tests.DeckServiceTests
{
    public class GetAllCardDecks : Base
    {
        [Fact]
        public void Get_List_of_Decks()
        {
            //Arrange

            _deckRepo.Setup(x => x.GetCardDecks()).Returns(Decks);
            //Act

            //Assert
            Assert.Equal(5, _deckService.GetCardDecks().Count());
        }
    }
}