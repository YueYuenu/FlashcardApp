global using Moq;
global using Xunit;
using FlashcardApp.Business;
using FlashcardApp.Domain.Interfaces;

namespace FlashcardApp.Tests.FlashcardServiceTests
{
    public class Base
    {
        protected Mock<IEFFlashcardRepo> _flashcardRepo;
        protected Mock<IFlashcardService> _ServiceMock;
        protected FlashcardService _flashcardService;

        protected Base()
        {
            _ServiceMock = new Mock<IFlashcardService>();
            _flashcardRepo = new Mock<IEFFlashcardRepo>();
            _flashcardService = new FlashcardService(_flashcardRepo.Object);
        }
    }
}