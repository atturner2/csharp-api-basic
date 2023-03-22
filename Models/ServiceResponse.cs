namespace dotnet_rpg.Models;

//T is the type of the data we want to return
public class ServiceResponse<T>
{ 
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
}