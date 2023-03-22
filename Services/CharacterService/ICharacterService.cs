using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService;

public interface ICharacterService
{
    Task<ServiceResponse<List<Character>>> GetAllCharacters();
    Task<ServiceResponse<Character>> GetCharacterById(int Id);
    Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
    
}