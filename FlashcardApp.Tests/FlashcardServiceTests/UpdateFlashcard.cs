using flashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class UpdateFlashcard : Base
    {
        [Fact]
        public async Task Update_existing_FlashcardAsync()
        {
            //Arrange
            Flashcard card = new() { Id = 1, Question = "replace question1", Answer = "replace answer1" };

            _flashcardRepo.Setup(x => x.GetFlashcardById(1)).Returns(new Flashcard { Id = 1, Question = "question1", Answer = "answer1" });

            //Act
            await _flashcardService.UpdateFlashcardAsync(1, card);
            Flashcard Updated = _flashcardService.GetFlashcardById(1);

            //Assert
            _flashcardRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
            Assert.Equal("replace question1", Updated.Question);
        }

        [Fact]
        public async Task Update_info_NULL_check()
        {
            //Arrange
            Flashcard card = new() { Id = 5, Question = null, Answer = null };

            _flashcardRepo.Setup(x => x.GetFlashcardById(1)).Returns(new Flashcard { Id = 1, Question = "question1", Answer = "answer1" });

            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await _flashcardService.UpdateFlashcardAsync(1, card));
        }

        [Fact]
        public async Task Update_info_emptyString_check()
        {
            //Arrange
            Flashcard card = new() { Id = 5, Question = "", Answer = "" };

            _flashcardRepo.Setup(x => x.GetFlashcardById(1)).Returns(new Flashcard { Id = 1, Question = "question1", Answer = "answer1" });

            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await _flashcardService.UpdateFlashcardAsync(1, card));
        }

        [Fact]
        public async void No_existing_Flashcard_found()
        {
            //Arrange
            Flashcard card = new() { Id = 5, Question = "replace question1", Answer = "replace answer1" };

            //Act

            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await _flashcardService.UpdateFlashcardAsync(5, card));
        }
    }
}