using FlashCardAPI.Model;
using FlashCardAPI.ServiceData.IService;
using Microsoft.AspNetCore.Mvc;
using Xunit.Sdk;

namespace FlashCardAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DeckController : Controller
    {
        private readonly IDeckService _deckService;

        public DeckController(IDeckService deckService)
        {
            _deckService = deckService;
        }

        [HttpGet("getAllDecks")]
        public async Task<ActionResult<IEnumerable<Deck>>> GetAllDecks()
        {
            return Ok(await _deckService.GetAllDecks());
        }

        [HttpGet("getAllDecks/{userId}")]
        public async Task<ActionResult<IEnumerable<Deck>>> GetAllDecksByUserId(Guid userId)
        {
            return Ok(await _deckService.GetAllDecksByUserId(userId));
        }

        [HttpPost("createDeck")]
        public async Task<ActionResult<Deck>> CreateDeck(string name, string category, string description, Guid userId)
        {
            var newDeck = await _deckService.InsertDeck(name, category, description, userId);
            if(newDeck != null)
            {
                return Created(string.Empty, newDeck);
            }
            throw new Exception("Failed to Create Deck @Controller");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeck(Guid id)
        {
            await _deckService.DeleteDeck(id);
            return Accepted();
        }

        [HttpPut]
        public async Task<ActionResult> PutDeck(Deck deck)
        {
            await _deckService.PutDeck(deck);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Deck>> UpdateDeck(Guid id, Deck deck)
        {
            var updatedDeck = _deckService.UpdateDeck(id, deck);
            if (updatedDeck != null)
            {
                return Ok(updatedDeck);
            }
            throw new Exception();
        }
    }
}
