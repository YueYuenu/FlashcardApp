using System.Diagnostics.CodeAnalysis;

namespace FlashcardApp.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class CardDeck
    {
        public int DeckId { get; set; }
        public string DeckName { get; set; }

        public virtual ICollection<Flashcard> Flashcards { get; set; }
    }
}