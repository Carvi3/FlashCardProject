using FlashCardAPI.Contexts;
using FlashCardAPI.Exceptions;
using FlashCardAPI.Model;
using FlashCardAPI.RepoData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FlashCardAPI.RepoData.Repository
{
    public class DeckRepo : IDeckRepo
    {
        private readonly UserContext _context;

        public DeckRepo(UserContext context)
        {
            _context = context;
        }
        public async Task DeleteDeck(Guid id)
        {
            var deck = await _context.Deck.FindAsync(id);
            if(deck != null)
            {
                _context.Deck.Remove(deck);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Deck>> GetAllDecks()
        {
            return await _context.Deck.ToListAsync();
        }

        public async Task<IEnumerable<Deck>> GetAllDecksByUserId(Guid userId)
        {
            //TODO: Validate that userId exists in service
            IEnumerable<Deck> decks = await GetAllDecks();
            decks = from deck in decks
                    where deck.UserId == userId
                    select deck;
            return decks;
        }

        public async Task<Deck> GetDeckById(Guid id)
        {
            Deck foundDeck = await _context.Deck.FindAsync(id);
            return foundDeck ?? throw new ContentNotFoundException("There was an error retrieving the deck");
        }

        public async Task<Deck> InsertDeck(Deck deck)
        {
            Deck newDeck = _context.Deck.Add(deck).Entity;
            await _context.SaveChangesAsync();
            return newDeck ?? throw new Exception("Deck could not be Added to Database");
        }

        public async Task PutDeck(Deck deck)
        {
            _context.Deck.Add(deck);
            await _context.SaveChangesAsync();
        }

        public async Task<Deck> UpdateDeck(Guid id, Deck deck)
        {
            Deck changeDeck = await _context.Deck.FindAsync(id);
            if(changeDeck != null)
            {
                changeDeck.Id = deck.Id;
                changeDeck.Name = deck.Name;
                changeDeck.Category = deck.Category;
                changeDeck.Description = deck.Description;
                changeDeck.UserId = deck.UserId;
                await _context.SaveChangesAsync();
                return changeDeck;
            }
            throw new Exception("Deck was not able to be updated");
        }
    }
}
