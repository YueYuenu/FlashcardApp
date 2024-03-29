﻿using FlashcardApp.Domain.Interfaces;
using FlashcardApp.Domain.Models;

namespace FlashcardApp.Business
{
    public class DeckService : IDeckService
    {
        public IEFDeckRepo EFDeckRepo { get; }

        public DeckService(IEFDeckRepo eFDeckRepo)
        {
            EFDeckRepo = eFDeckRepo;
        }

        public async Task<CardDeck> CreateCardDeckAsync(CardDeck cardDeck)
        {
            if (cardDeck != null)
            {
                if (cardDeck.DeckName == null)
                    throw new Exception("Something gave null, please check the field and try again");
                if (cardDeck.DeckName != string.Empty)
                {
                    IEnumerable<CardDeck> match = EFDeckRepo.SearchCardDecks(cardDeck.DeckName);
                    if (match.Any())
                        throw new Exception(
                            "This deckname already exists, please choose a different name.");
                    else
                    {
                        await EFDeckRepo.CreateCardDeckAsync(cardDeck);
                        await EFDeckRepo.SaveChangesAsync();
                        return cardDeck;
                    }
                }
                else throw new Exception("Something went wrong, could not create deck. Please check that the name field is not empty");
            }
            else throw new Exception("Something went wrong, could not create deck.");
        }

        public IEnumerable<CardDeck> GetCardDecks()
        {
            return EFDeckRepo.GetCardDecks();
        }

        public CardDeck GetCardDeckById(int id)
        {
            try
            {
                CardDeck deck = EFDeckRepo.GetCardDeckById(id);
                if (deck != null)
                    return deck;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong, deck not found");
            }
            throw new Exception("Something went wrong, deck not found");
        }

        public CardDeck GetCardDeckByFlashcardId(int id)
        {
            return EFDeckRepo.GetCardDeckByFlashcardId(id);
        }

        public IEnumerable<CardDeck> SearchCardDecks(string query)
        {
            return GetCardDecks().Where(x => x.DeckName.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<CardDeck> UpdateCardDeckAsync(CardDeck card)
        {
            int id = card.DeckId;
            CardDeck deckToEdit = GetCardDeckById(id);

            if (card.DeckName != null && card.DeckName != string.Empty)
            {
                deckToEdit.DeckName = card.DeckName;
                EFDeckRepo.UpdateCardDeck(deckToEdit);
                await EFDeckRepo.SaveChangesAsync();

                return deckToEdit;
            }
            else throw new Exception("Something went wrong, could not update deck. Please check that the name field is not empty");
        }

        public async Task DeleteById(int id)
        {
            CardDeck deckToDelete = EFDeckRepo.GetCardDeckById(id);
            if (deckToDelete != null)
            {
                EFDeckRepo.DeleteDeckById(id);
                await EFDeckRepo.SaveChangesAsync();
            }
        }
    }
}