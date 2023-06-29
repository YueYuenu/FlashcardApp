using flashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class CreateFlashcard : Base
    {
        [Fact]
        public async void Card_is_Created()
        {
            //Arrange
            var card = new Flashcard { Id = 1, Question = "question1", Answer = "answer1" };

            //Act
            await _flashcardService.CreateFlashcardAsync(card);

            //Assert
            _flashcardRepo.Verify(x => x.CreateFlashcardAsync(card), Times.Once);
            _flashcardRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}