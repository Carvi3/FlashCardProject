using FlashCardAPI.Model;

namespace FlashCardAPI.ServiceData.IService
{
    public interface IFlashcardService
    {
        //Create
        Task<Flashcard> InsertFlashcard(string question, string? answer, Guid deckId);
        Task PutFlashcard(Flashcard card);
        //Read

        Task<IEnumerable<Flashcard>> GetAllFlashcards();
        Task<IEnumerable<Flashcard>> GetAllFlashcardsByDeckId(Guid deckId);
        Task<IEnumerable<Flashcard>> GetAllFlashcardsByUserId(Guid userId);

        Task<Flashcard> GetFlashcardById(Guid id);
        //Update
        Task<Flashcard> UpdateFlashcard(Guid id, Flashcard flashcard);
        //Delete
        Task DeleteFlashcard(Guid id);
    }
}
