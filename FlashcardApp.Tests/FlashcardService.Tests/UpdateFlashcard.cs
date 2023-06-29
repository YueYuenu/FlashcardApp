using flashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardService.Tests
{
    public class UpdateFlashcard : Usings
    {
        [Fact]
        public async Task Update_existing_FlashcardAsync()
        {
            //Arrange
            Flashcard card = new() { Id = 1, Question = "replace question1", Answer = "replace answer1" };

            _flashcardRepo.Setup(x => x.GetFlashcardById(1)).Returns(new Flashcard { Id = 1, Question = "question1", Answer = "answer1" });

            //Act
            await _flashcardService.UpdateFlashcardAsync(1, card);

            //Assert
            _flashcardRepo.Verify(x => x.UpdateFlashcard(card), Times.Once);
            _flashcardRepo.Verify(x => x.SaveChangesAsync(), Times.Once);
            Assert.Equal("replace question1", card.Question);
        }

        [Fact]
        public async void No_existing_Flashcard_found()
        {
            //Arrange
            Flashcard card = new() { Id = 1, Question = "replace question1", Answer = "replace answer1" };
            //Act
            await _flashcardService.UpdateFlashcardAsync(5, card);

            //Assert
            _flashcardRepo.Verify(x => x.UpdateFlashcard(card), Times.Never);
        }

        [Fact]
        public void Card_Id_Missmatch() //TODO add check for correct id before update attempt
        {
            //Arrange
            //Act
            //Assert
        }
    }
}