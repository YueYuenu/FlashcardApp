using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FlashcardApp.Domain.Models
{
    [ExcludeFromCodeCoverage]
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