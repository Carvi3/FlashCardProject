using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlashCardAPI.Model
{
    public class Flashcard
    {

        public Flashcard(string question, Guid deckId)
        {
            Id = Guid.Empty;
            Question = question;
            Answer = string.Empty;
            DeckId = deckId;
        }
        public Flashcard(string question, string answer, Guid deckId)
        {
            Id = Guid.Empty;
            Question = question;
            Answer = answer;
            DeckId = deckId;
        }
        public Flashcard(Guid id, string question, string answer, Guid deckId)
        {
            Id = id;
            Question = question;
            Answer = answer;
            DeckId = deckId;
        }


        [JsonPropertyName("id")]
        [Key]
        public Guid Id { get; set; }

        [JsonPropertyName("problem")]
        public string Question { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [Display(Name = "Deck")]
        public virtual Guid DeckId { get; set; }

        [ForeignKey("DeckId")]
        public virtual Deck Decks { get; set; }
    }
}
