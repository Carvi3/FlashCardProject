using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlashCardAPI.Model
{
    public class Deck
    {
        public Deck() {
            Id = Guid.Empty;
            Name = "";
            Category = "";
            Description = "";
            UserId = Guid.Empty;
        }
        public Deck(string name,string category, string description, Guid userId) {
            Id = Guid.Empty;
            Name = name; 
            Category = category;
            Description = description;
            UserId = userId;
        }
        public Deck(Guid id, string name, string category, string description, Guid userId)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            UserId = userId;
        }

        [JsonPropertyName("id")]
        [Key]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Display(Name = "User")]
        public virtual Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User Users { get; set; }

    }
}
