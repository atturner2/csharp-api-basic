using dotnet_rpg.Controllers;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace dotnet_rpg.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> characters = new List<Character>
    {
        new Character(),
        new Character { Id = 1, Name = "Sam" },
    };

   
    public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        
        return characters;
    }

    public async Task<ServiceResponse<Character>> GetCharacterById(int Id)
    {
        //this could return null, we could just allow a nullable character 
        //or we can just write a check which is what we should do
        
        var character = characters.FirstOrDefault(c => c.Id == Id);
        if (character is not null)
            return character;
        
        throw new Exception("Character not found");
        
    }

    public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        characters.Add(newCharacter);
        serviceResponse.Data = characters;        
        return serviceResponse;
    }
}