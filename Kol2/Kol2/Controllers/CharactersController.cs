using Kol2.DTOs;
using Kol2.Models;
using Kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharactersController: ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacterInfo(int characterId)
    {
        if (! await _dbService.CharacterExists(characterId))
        {
            return NotFound($"Character with ID-{characterId} not found");
        }
        
        var character = await _dbService.GetCharacterInfo(characterId);
        var titles = new List<GetCharacterDTO.TitleDTO>();
        var backpackItems = new List<GetCharacterDTO.BackpackItemsDTO>();
        foreach (var title in character.CharacterTitles)
        {
            titles.Add(new GetCharacterDTO.TitleDTO()
            {
                AcquiredAt = title.AcquiredAt,
                Title = title.Title.Name
            });
        }
        foreach (var item in character.Backpacks)
        {
            backpackItems.Add(new GetCharacterDTO.BackpackItemsDTO()
            {
                ItemWeight = item.Item.Weight,
                Name = item.Item.Name,
                Amount = item.Amount
            });
        }
        
        return Ok(new GetCharacterDTO()
        {
            BackpackItems = backpackItems,
            CurrentWeight = character.CurrentWeight,
            FirstName = character.FirstName,
            LastName = character.LastName,
            MaxWeight = character.MaxWeight,
            Titles = titles
        });
    }
}