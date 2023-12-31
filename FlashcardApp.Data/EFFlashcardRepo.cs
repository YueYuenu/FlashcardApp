﻿using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;

namespace FlashcardApp.Data
{
    public class EFFlashcardRepo : IEFFlashcardRepo
    {
        private readonly DataContext _dataContext;

        public EFFlashcardRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Flashcard> CreateFlashcardAsync(Flashcard flashcard)
        {
            await _dataContext.AddAsync(flashcard);
            return flashcard;
        }

        public Flashcard GetFlashcardById(int id)
        {
            return _dataContext.Set<Flashcard>().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Flashcard> GetFlashcardsByDeckId(int id)
        {
            if (!_dataContext.Set<CardDeck>().Any(x => x.DeckId == id))
                throw new KeyNotFoundException();
            return _dataContext.Set<Flashcard>().Where(x => x.DeckId.Equals(id)).ToList();
        }

        public IEnumerable<Flashcard> GetFlashcards()
        {
            return _dataContext.Set<Flashcard>();
        }

        public IEnumerable<Flashcard> SearchFlashcards(string query)
        {
            return _dataContext.Set<Flashcard>().Where(x => x.Question.Contains(query) || x.Answer.Contains(query));
            //return _dataContext.Set<Flashcard>().Where(x => x.Question.Contains(query, StringComparison.OrdinalIgnoreCase) || x.Answer.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        public Flashcard UpdateFlashcard(Flashcard flashcard)
        {
            _dataContext.Update(flashcard);
            return flashcard;
        }

        public void DeleteById(int id)
        {
            Flashcard cardToDelete = _dataContext.Set<Flashcard>().Where(x => x.Id == id).FirstOrDefault();
            if (cardToDelete != null) { _dataContext.Remove(cardToDelete); }
            //TODO add something in case ID does not exist
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}