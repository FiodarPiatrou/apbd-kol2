using Kol2.Data;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Services;

public class DbService:IDbService
{
    private readonly MyDbContext _context;

    public DbService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Character> GetCharacterInfo(int characterId)
    {
        return await _context.Characters.FirstAsync(c => c.Id == characterId);
    }

    public async Task<bool> CharacterExists(int characterId)
    {
        return await _context.Characters.AnyAsync(c=>c.Id==characterId);
    }
}