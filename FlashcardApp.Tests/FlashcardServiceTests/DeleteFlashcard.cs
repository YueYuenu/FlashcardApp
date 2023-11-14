using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class DeleteFlashcard : Base
    {
        [Fact]
        public async void Card_gets_deleted()
        {
            //Arrange
            _flashcardRepo.Setup(x => x.GetFlashcardById(2)).Returns(new Flashcard { Id = 2, Question = "question2", Answer = "answer2" });

            //Act
            await _flashcardService.DeleteById(2);

            //Assert
            _flashcardRepo.Verify(x => x.DeleteById(2), Times.Once);
        }
    }
}