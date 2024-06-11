using Kol2.Data;
using Kol2.Models;

namespace Kol2.Services;

public interface IDbService
{
    Task<Character> GetCharacterInfo(int characterId);
    Task<bool> CharacterExists(int characterId);
}