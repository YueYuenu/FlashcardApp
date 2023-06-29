using flashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class DeleteFlashcard : Base
    {
        [Fact]
        public async void Card_gets_deleted()
        {
            //Arrange
            List<Flashcard> list = new()
            {
                new Flashcard {Id = 1,  Question = "question1", Answer = "answer1"},
                new Flashcard {Id = 2,  Question = "question2", Answer = "answer2"},
                new Flashcard {Id = 3,  Question = "question3", Answer = "answer3"}
            };

            _flashcardRepo.Setup(x => x.GetFlashcardById(2)).Returns(new Flashcard { Id = 2, Question = "question2", Answer = "answer2" });
            //Act
            await _flashcardService.DeleteById(2);

            //Assert
            _flashcardRepo.Verify(x => x.DeleteById(2), Times.Once);
        }
    }
}