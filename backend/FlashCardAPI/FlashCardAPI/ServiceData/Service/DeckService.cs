﻿using FlashCardAPI.Model;
using FlashCardAPI.RepoData.IRepository;
using FlashCardAPI.ServiceData.IService;

namespace FlashCardAPI.ServiceData.Service
{
    public class DeckService : IDeckService
    {
        private readonly IDeckRepo _deckRepo;

        public DeckService(IDeckRepo deckRepo)
        {
            _deckRepo = deckRepo;
        }

        public Task DeleteDeck(Guid id)
        {
            return _deckRepo.DeleteDeck(id);
        }

        public Task<IEnumerable<Deck>> GetAllDecks()
        {
            return _deckRepo.GetAllDecks();
        }

        public Task<IEnumerable<Deck>> GetAllDecksByUserId(Guid userId)
        {
            return _deckRepo.GetAllDecksByUserId(userId);
        }

        public Task<Deck> GetDeckById(Guid id)
        {
            return _deckRepo.GetDeckById(id);
        }

        public Task<Deck> InsertDeck(Deck deck)
        {
            deck = new Deck(deck.Name, deck.Category, deck.Description, deck.UserId);
            return _deckRepo.InsertDeck(deck);
        }

        public Task PutDeck(Deck deck)
        {
            return _deckRepo.PutDeck(deck);
        }

        public Task<Deck> UpdateDeck(Guid id, Deck deck)
        {
            return _deckRepo.UpdateDeck(id, deck);
        }
    }
}
