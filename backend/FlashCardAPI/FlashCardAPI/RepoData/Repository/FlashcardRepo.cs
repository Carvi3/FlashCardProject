using FlashCardAPI.Contexts;
using FlashCardAPI.Model;
using FlashCardAPI.RepoData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FlashCardAPI.RepoData.Repository
{
    public class FlashcardRepo : IFlashcardRepo
    {
        private readonly UserContext _context;

        public FlashcardRepo(UserContext context)
        {
            _context = context;
        }
        public async Task DeleteFlashcard(Guid id)
        {
            var flashcard = await _context.Flashcard.FindAsync(id);
            if(flashcard != null)
            {
                _context.Flashcard.Remove(flashcard);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Flashcard>> GetAllFlashcards()
        {
            return await _context.Flashcard.ToListAsync();
        }

        public async Task<IEnumerable<Flashcard>> GetAllFlashcardsBydeckId(Guid deckId)
        {
            IEnumerable<Flashcard> flashcards = await GetAllFlashcards();
            flashcards = from flashcard in flashcards
                         where flashcard.DeckId == deckId
                         select flashcard;
            return flashcards;
        }

        public Task<IEnumerable<Flashcard>> GetAllFlashcardsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Flashcard> GetFlashcardById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Flashcard> InsertFlashcard(string question, string? answer, Guid deckId)
        {
            throw new NotImplementedException();
        }

        public Task PutFlashcard(Flashcard flashcard)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateFlashcard(Guid id, Flashcard flashcard)
        {
            throw new NotImplementedException();
        }
    }
}
