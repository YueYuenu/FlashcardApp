using flashcardApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace FlashcardApp.Domain.Models
{
    public class CardDeck
    {
        [Key] public int DeckId { get; set; }
        public string DeckName { get; set; }

        public virtual ICollection<Flashcard> Flashcards { get; set; }
    }
}