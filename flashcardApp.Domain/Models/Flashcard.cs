using FlashcardApp.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace flashcardApp.Domain.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        [ForeignKey("DeckId")]
        public virtual CardDeck CardDeck { get; set; }

        public int DeckId { get; set; }
    }
}