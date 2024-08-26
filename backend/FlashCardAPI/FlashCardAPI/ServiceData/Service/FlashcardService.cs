using FlashCardAPI.Model;
using FlashCardAPI.RepoData.IRepository;
using FlashCardAPI.RepoData.Repository;
using FlashCardAPI.ServiceData.IService;

namespace FlashCardAPI.ServiceData.Service
{
    public class FlashcardService : IFlashcardService
    {
        private readonly IFlashcardRepo _flashcardRepo;

        public FlashcardService(IFlashcardRepo flashcardRepo)
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

        public Task<IEnumerable<Flashcard>> GetAllFlashcardsByDeckId(Guid deckId)
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

        public Task<Flashcard> InsertFlashcard(Flashcard flashcard)
        {
            if(flashcard.Question.Length == 0)
            {
                throw new Exception("Question length cannot be 0");
            }
            flashcard = new Flashcard(flashcard.Question, flashcard.Answer, flashcard.DeckId);
            return _flashcardRepo.InsertFlashcard(flashcard);
        }

        public Task PutFlashcard(Flashcard flashcard)
        {
            return _flashcardRepo.PutFlashcard(flashcard);
        }

        public Task<Flashcard> UpdateFlashcard(Guid id, Flashcard flashcard)
        {
            return _flashcardRepo.UpdateFlashcard(id, flashcard);
        }
    }
}
