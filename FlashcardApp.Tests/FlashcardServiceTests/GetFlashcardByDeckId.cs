using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class GetFlashcardByDeckId : Base
    {
        [Fact]
        public void Get_Flashcard_with_deckId() //TODO this is not a good test :/
        {
            //Arrange

            //Act
            _flashcardRepo.Setup(x => x.GetFlashcardsByDeckId(2)).Returns(
                new List<Flashcard>
                {
                    new Flashcard { DeckId = 2},
                    new Flashcard { DeckId = 2},
                    new Flashcard { DeckId = 2},
                    new Flashcard { DeckId = 2},
                });
            var result = _flashcardService.GetFlashcardByDeckId(2);
            //Assert
            Assert.Equal(4, result.Count());
        }

        [Fact]
        public void DeckId_flashcardList_is_NULL()
        {
            //Arrange

            //Act
            _flashcardRepo.Setup(x => x.GetFlashcardsByDeckId(4)).Returns((IEnumerable<Flashcard>)null);

            //Assert
            Assert.Throws<Exception>(() => _flashcardService.GetFlashcardByDeckId(4));
        }

        [Fact]
        public void CarddeckId_does_not_exist()
        {
            //Arrange
            _flashcardRepo.Setup(x => x.GetFlashcardsByDeckId(3)).Throws(new KeyNotFoundException());

            //Act

            //Assert
            Assert.Throws<Exception>(() => _flashcardService.GetFlashcardByDeckId(3));
        }
    }
}