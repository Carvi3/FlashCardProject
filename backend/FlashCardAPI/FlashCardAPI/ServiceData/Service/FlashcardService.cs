using FlashCardAPI.Model;
using FlashCardAPI.RepoData.Repository;
using FlashCardAPI.ServiceData.IService;

namespace FlashCardAPI.ServiceData.Service
{
    public class FlashcardService : IFlashcardService
    {
        private readonly FlashcardRepo _flashcardRepo;

        public FlashcardService(FlashcardRepo flashcardRepo)
        {
            _flashcardRepo = flashcardRepo;
        }
        public Task DeleteFlashcard(Guid id)
        {
            return _flashcardRepo.DeleteFlashcard(id);
        }

        public Task<IEnumerable<Flashcard>> GetAllFlashcards()
        {
            return _flashcardRepo.GetAllFlashcards();
        }

        public Task<IEnumerable<Flashcard>> GetAllFlashcardsBydeckId(Guid deckId)
        {
            return _flashcardRepo.GetAllFlashcardsBydeckId(deckId);
        }

        public Task<IEnumerable<Flashcard>> GetAllFlashcardsByUserId(Guid userId)
        {
            return _flashcardRepo.GetAllFlashcardsByUserId(userId);
        }

        public Task<Flashcard> GetFlashcardById(Guid id)
        {
            return _flashcardRepo.GetFlashcardById(id);
        }

        public Task<Flashcard> InsertFlashcard(string question, string? answer, Guid deckId)
        {
            return _flashcardRepo.InsertFlashcard(question, answer, deckId);
        }

        public Task PutFlashcard(Guid id, string question, string? answer, Guid deckId)
        {
            return _flashcardRepo.PutFlashcard(id, question, answer, deckId);
        }

        public Task<User> UpdateFlashcard(Guid id, Flashcard flashcard)
        {
            return _flashcardRepo.UpdateFlashcard(id, flashcard);
        }
    }
}
