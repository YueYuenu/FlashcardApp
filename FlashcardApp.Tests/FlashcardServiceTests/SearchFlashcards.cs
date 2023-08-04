using flashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class SearchFlashcards : Base
    {
        [Fact]
        public void Search_for_multiple_cards()
        {
            //Arrange
            List<Flashcard> list = new()
            {
                new Flashcard {Id = 1,  Question = "question1", Answer = "answer1"},
                new Flashcard {Id = 2,  Question = "question2", Answer = "answer2"},
                new Flashcard {Id = 3,  Question = "question3", Answer = "answer3"},
                new Flashcard {Id = 4 , Question = "shouldNotCount", Answer = "answer4"}
            };

            _flashcardRepo.Setup(x => x.GetFlashcards()).Returns(list.AsQueryable());
            //Act
            List<Flashcard> search = _flashcardService.SearchFlashcards("question").ToList();

            //Assert
            Assert.Equal(3, search.Count);
        }

        [Fact]
        public void Search_for_one_card()
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
            List<Flashcard> search = _flashcardService.SearchFlashcards("question3").ToList();

            //Assert
            Assert.Equal("answer3", search.SingleOrDefault().Answer);
        }

        [Fact]
        public void Search_finds_no_results()
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
            List<Flashcard> search = _flashcardService.SearchFlashcards("question5").ToList();

            //Assert
            Assert.Empty(search);
        }
    }
}