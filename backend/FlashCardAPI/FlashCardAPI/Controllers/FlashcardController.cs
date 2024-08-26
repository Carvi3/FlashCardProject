using FlashCardAPI.Model;
using FlashCardAPI.ServiceData.IService;
using FlashCardAPI.ServiceData.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FlashcardController : Controller
    {
        private readonly IFlashcardService _cardService;

        public FlashcardController(IFlashcardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("GetAllFlashcards")]
        public async Task<ActionResult<IEnumerable<Flashcard>>> GetAllFlashcards()
        {
            return Ok(await _cardService.GetAllFlashcards());
        }

        [HttpGet("GetAllFlashcardsByDeck/{deckId}")]
        public async Task<ActionResult<IEnumerable<Flashcard>>> GetAllFlashcardsByDeck(Guid deckId)
        {
            return Ok(await _cardService.GetAllFlashcardsByDeckId(deckId));
        }

        /*
        [HttpGet("GetAllFlashcardsByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<Flashcard>>> GetAllFlashcardsByDeck(Guid userId)
        {
            return Ok(await _cardService.GetAllFlashcardsByUserId(userId));
        }
        */

        [HttpPost("createFlashcard")]
        public async Task<ActionResult<Deck>> CreateFlashcard(Flashcard flashcard) { 
            var newCard = await _cardService.InsertFlashcard(flashcard);
            if(newCard != null)
            {
                return Created(string.Empty, newCard);
            }
            throw new Exception("Failed to Create Flashcard @Controller");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlashcard(Guid id)
        {
            await _cardService.DeleteFlashcard(id);
            return Accepted();
        }

        [HttpPut]
        public async Task<ActionResult> PutFlashcard(Flashcard card)
        {
            await _cardService.PutFlashcard(card);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Deck>> UpdateFlashcard(Guid id, Flashcard card)
        {
            var updatedDeck = _cardService.UpdateFlashcard(id, card);
            if (updatedDeck != null)
            {
                return Ok(updatedDeck);
            }
            return NoContent();
        }
    }
}
