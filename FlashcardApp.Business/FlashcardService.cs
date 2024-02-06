using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;

namespace FlashcardApp.Business
{
    public class FlashcardService : IFlashcardService
    {
        public IEFFlashcardRepo EFFlashcardRepo { get; }
        private readonly Random _rand;

        public FlashcardService(IEFFlashcardRepo eFFlashcardRepo)
        {
            EFFlashcardRepo = eFFlashcardRepo;
            _rand = new Random();
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
            try
            {
                Flashcard card = EFFlashcardRepo.GetFlashcardById(id);
                if (card != null)
                    return card;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong, card not found");
            }
            throw new Exception("Something went wrong");
        }

        public IEnumerable<Flashcard> GetFlashcardByDeckId(int id)
        {
            try
            {
                IEnumerable<Flashcard> cards = EFFlashcardRepo.GetFlashcardsByDeckId(id);
                if (cards != null)
                    return cards;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong, cards not found");
            }
            throw new Exception("whoops"); //TODO replace this with something decent
        }

        public IEnumerable<Flashcard> SearchFlashcards(string query)
        {
            return GetFlashcards().Where(x => x.Question.Contains(query, StringComparison.OrdinalIgnoreCase)
            || x.Answer.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Flashcard> UpdateFlashcardAsync(Flashcard flashcard)
        {
            int id = flashcard.Id;
            Flashcard flashcardToEdit = GetFlashcardById(id);

            if (flashcard.Question != null && flashcard.Question != string.Empty
                && flashcard.Answer != null && flashcard.Answer != string.Empty)
            {
                flashcardToEdit.Question = flashcard.Question;
                flashcardToEdit.Answer = flashcard.Answer;
                EFFlashcardRepo.UpdateFlashcard(flashcardToEdit);
                await EFFlashcardRepo.SaveChangesAsync();

                return flashcardToEdit;
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

        public IEnumerable<Flashcard> GetRandomizedCards(int deckId)
        {
            IEnumerable<Flashcard> flashcards = EFFlashcardRepo.GetFlashcardsByDeckId(deckId);
            IEnumerable<Flashcard> randomizedFlashcards = flashcards.OrderBy(_ => _rand.Next()).Take(20).ToList();
            return randomizedFlashcards;
        }
    }
}