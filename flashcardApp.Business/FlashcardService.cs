using flashcardApp.Domain.Models;
using FlashcardApp.Domain.Interfaces;

namespace flashcardApp.Business
{
    public class FlashcardService : IFlashcardService
    {
        public IEFFlashcardRepo EFFlashcardRepo { get; }

        public FlashcardService(IEFFlashcardRepo eFFlashcardRepo)
        {
            EFFlashcardRepo = eFFlashcardRepo;
        }

        public async Task<Flashcard> CreateFlashcardAsync(Flashcard flashcard)
        {
            await EFFlashcardRepo.CreateFlashcardAsync(flashcard);
            await EFFlashcardRepo.SaveChangesAsync();
            return flashcard;
        }

        public IEnumerable<Flashcard> GetFlashcards()
        {
            return EFFlashcardRepo.GetFlashcards();
        }

        public Flashcard GetFlashcardById(int id)
        {
            return EFFlashcardRepo.GetFlashcardById(id);
        }

        public Flashcard SearchFlashcards(string query)
        {
            return EFFlashcardRepo.SearchFlashcards(query);
        }

        public async Task<Flashcard> UpdateFlashcardAsync(int id, Flashcard flashcard) //TODO add check for correct id before update attempt
        {
            id = flashcard.Id;
            Flashcard flashcard1 = GetFlashcardById(id);
            if (flashcard1 != null)
            {
                flashcard1.Question = flashcard.Question;
                flashcard1.Answer = flashcard.Answer;
                EFFlashcardRepo.UpdateFlashcard(flashcard1);
                await EFFlashcardRepo.SaveChangesAsync();

                return flashcard1;
            }
            else throw new Exception("something went wrong, could not update flashcard");
        }

        public async Task DeleteById(int id)
        {
            Flashcard flashcardToDelete = EFFlashcardRepo.GetFlashcardById(id);
            if (flashcardToDelete != null)
            {
                EFFlashcardRepo.DeleteById(id);
                await EFFlashcardRepo.SaveChangesAsync();
            }
        }
    }
}