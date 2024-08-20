﻿using FlashCardAPI.Model;

namespace FlashCardAPI.RepoData.IRepository
{
    public interface IDeckRepo
    {
        //Create
        Task<Deck> InsertDeck(string name, string category, string description, Guid userId);
        Task PutDeck(Deck deck);
        //Read
        Task<IEnumerable<Deck>> GetAllDecks();
        Task<IEnumerable<Deck>> GetAllDecksByUserId(Guid userId);
        Task<Deck> GetDeckById(Guid id);
        //Update
        Task<Deck> UpdateDeck(Guid id, Deck deck);
        //Delete
        Task DeleteDeck(Guid id);
    }
}
