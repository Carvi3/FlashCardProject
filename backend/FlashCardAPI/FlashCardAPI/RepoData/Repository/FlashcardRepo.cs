using FlashCardAPI.Contexts;
using FlashCardAPI.Exceptions;
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

        public async Task<Flashcard> GetFlashcardById(Guid id)
        {
            Flashcard foundCard = await _context.Flashcard.FindAsync(id);
            return foundCard ?? throw new ContentNotFoundException("There was an error retrieving the flashcard");
        }

        public async Task<Flashcard> InsertFlashcard(string question, string? answer, Guid deckId)
        {
            Flashcard card = _context.Flashcard.Add(new Flashcard(question, answer, deckId)).Entity;
            await _context.SaveChangesAsync();
            return card ?? throw new Exception("Flashcard could not be added");
        }

        public async Task PutFlashcard(Flashcard flashcard)
        {
            _context.Flashcard.Add(flashcard);
            await _context.SaveChangesAsync();
        }

        public async Task<Flashcard> UpdateFlashcard(Guid id, Flashcard flashcard)
        {
            Flashcard changeCard = await _context.Flashcard.FindAsync(id);
            if(changeCard != null)
            {
                changeCard.Id = flashcard.Id;
                changeCard.Question = flashcard.Question;
                changeCard.Answer = flashcard.Answer;
                changeCard.DeckId = flashcard.DeckId;
                await _context.SaveChangesAsync();
                return changeCard;
            }
            throw new Exception("Flashcard was not able to be updated");
        }
    }
}
