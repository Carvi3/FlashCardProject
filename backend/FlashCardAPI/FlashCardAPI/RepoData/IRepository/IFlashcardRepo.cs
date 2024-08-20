using FlashCardAPI.Model;

namespace FlashCardAPI.RepoData.IRepository
{
    public interface IFlashcardRepo
    {
        //Create
        Task<Flashcard> InsertFlashcard(string question, string? answer, Guid deckId);
        Task PutFlashcard(Flashcard flashcard);
        //Read

        Task<IEnumerable<Flashcard>> GetAllFlashcards();
        Task<IEnumerable<Flashcard>> GetAllFlashcardsBydeckId(Guid deckId);
        Task<IEnumerable<Flashcard>> GetAllFlashcardsByUserId(Guid userId);

        Task<Flashcard> GetFlashcardById(Guid id);
        //Update
        Task<Flashcard> UpdateFlashcard(Guid id, Flashcard flashcard);
        //Delete
        Task DeleteFlashcard(Guid id);
    }
}
