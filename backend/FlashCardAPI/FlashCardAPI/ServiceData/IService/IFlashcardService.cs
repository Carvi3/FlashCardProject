using FlashCardAPI.Model;

namespace FlashCardAPI.ServiceData.IService
{
    public interface IFlashcardService
    {
        //Create
        Task<Flashcard> InsertFlashcard(string question, string? answer, Guid deckId);
        Task PutFlashcard(Guid id, string question, string? answer, Guid deckId);
        //Read

        Task<IEnumerable<Flashcard>> GetAllFlashcards();
        Task<IEnumerable<Flashcard>> GetAllFlashcardsBydeckId(Guid deckId);
        Task<IEnumerable<Flashcard>> GetAllFlashcardsByUserId(Guid userId);

        Task<Flashcard> GetFlashcardById(Guid id);
        //Update
        Task<User> UpdateFlashcard(Guid id, Flashcard flashcard);
        //Delete
        Task DeleteFlashcard(Guid id);
    }
}
