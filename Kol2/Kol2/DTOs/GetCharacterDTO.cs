using Kol2.Models;

namespace Kol2.DTOs;

public class GetCharacterDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<BackpackItemsDTO> BackpackItems { get; set; }

    

    public ICollection<TitleDTO> Titles { get; set; }

    public class TitleDTO
    {
        public string Title { get; set; }
        public DateTime AcquiredAt { get; set; }
        
    }

    public class BackpackItemsDTO
    {
        public string Name { get; set; }
        public int ItemWeight { get; set; }
        public int Amount { get; set; }
        
        
    }
    
}