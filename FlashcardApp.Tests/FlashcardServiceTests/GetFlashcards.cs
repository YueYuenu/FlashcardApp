using FlashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class GetFlashcards : Base
    {
        [Fact]
        public void Get_List_of_Cards()
        {
            //Arrange
            List<Flashcard> list = new()
            {
                new Flashcard {Id = 1,  Question = "question1", Answer = "answer1"},
                new Flashcard {Id = 2,  Question = "question2", Answer = "answer2"},
                new Flashcard {Id = 3,  Question = "question3", Answer = "answer3"}
            };

            _flashcardRepo.Setup(x => x.GetFlashcards()).Returns(list.AsQueryable());
            //Act

            //Assert
            Assert.Equal(3, _flashcardService.GetFlashcards().Count());
        }
    }
}