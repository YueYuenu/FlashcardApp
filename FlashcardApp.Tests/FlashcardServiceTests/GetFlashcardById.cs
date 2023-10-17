using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class GetFlashcardById : Base
    {
        [Fact]
        public void Get_Flashcard_by_Id()
        {
            //Arrange
            _flashcardRepo.Setup(x => x.GetFlashcardById(3)).Returns(new Flashcard() { Id = 3, Question = "test", Answer = "test" });

            //Act
            Flashcard cardId3 = _flashcardService.GetFlashcardById(3);

            //Assert
            Assert.Equal(3, cardId3.Id);
        }

        [Fact]
        public void Card_Returns_Id0_if_Not_Exists()
        {
            //Arrange
            _flashcardRepo.Setup(x => x.GetFlashcardById(4)).Returns(new Flashcard() { Id = 0 });

            //Act
            Flashcard cardId0 = _flashcardService.GetFlashcardById(0);

            //Assert
            Assert.Equal(0, cardId0.Id);
        }
    }
}