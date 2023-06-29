﻿using flashcardApp.Domain.Models;

namespace FlashcardApp.Tests.FlashcardService.Tests
{
    public class GetFlashcardById : Usings
    {
        [Fact]
        public void Get_Flashcard_by_Id()
        {
            //Arrange
            _flashcardRepo.Setup(x => x.GetFlashcardById(3)).Returns(new Flashcard() { Id = 3, Question = "", Answer = "" });

            //Act
            Flashcard cardId3 = _flashcardService.GetFlashcardById(3);

            //Assert
            Assert.Equal(3, cardId3.Id);
        }

        [Fact]
        public void Card_returns_null()
        {
            //Arrange
            _flashcardRepo.Setup(x => x.GetFlashcardById(4));

            //Act
            Flashcard cardIsNull = _flashcardService.GetFlashcardById(4);

            //Assert
            Assert.Null(null);
        }
    }
}