﻿using Domain.Entities;

namespace Domain.IServices;

public interface IDeckService
{
    //Create
    Task<Deck> InsertDeck(Deck deck);
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
