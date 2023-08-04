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
            if (flashcard != null)
            {
                if (flashcard.Question == null || flashcard.Answer == null)
                    throw new Exception("Something gave null, please check the fields and try again");
                if (flashcard.Question != string.Empty && flashcard.Answer != string.Empty)
                {
                    await EFFlashcardRepo.CreateFlashcardAsync(flashcard);
                    await EFFlashcardRepo.SaveChangesAsync();
                    return flashcard;
                }
                else throw new Exception("Something went wrong, could not create flashcard. Please check that the Question and Answer fields are not empty");
            }
            else throw new Exception("Something went wrong, could not create flashcard.");
        }

        public IEnumerable<Flashcard> GetFlashcards()
        {
            return EFFlashcardRepo.GetFlashcards();
        }

        public Flashcard GetFlashcardById(int id)
        {
            Flashcard card = EFFlashcardRepo.GetFlashcardById(id);
            if (card != null)
                return card;
            throw new Exception("Something went wrong, card not found"); //TODO make this show on swagger instead of breaking T_T
        }

        public IEnumerable<Flashcard> SearchFlashcards(string query)
        {
            return GetFlashcards().Where(x => x.Question.Contains(query, StringComparison.OrdinalIgnoreCase)
            || x.Answer.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Flashcard> UpdateFlashcardAsync(int id, Flashcard flashcard) //TODO add check for correct id before update attempt?
        {
            id = flashcard.Id;
            Flashcard flashcard1 = GetFlashcardById(id);

            if (flashcard.Question != null && flashcard.Question != string.Empty
                && flashcard.Answer != null && flashcard.Answer != string.Empty)
            {
                flashcard1.Question = flashcard.Question;
                flashcard1.Answer = flashcard.Answer;
                EFFlashcardRepo.UpdateFlashcard(flashcard1);
                await EFFlashcardRepo.SaveChangesAsync();

                return flashcard1;
            }
            else throw new Exception("Something went wrong, could not update flashcard. Please check that the Question and Answer fields are not empty");
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