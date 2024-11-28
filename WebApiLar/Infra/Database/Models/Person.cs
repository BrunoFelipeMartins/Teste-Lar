namespace WebApiLar.Infra.Database.Models
{
    public record Person(
        long id, 
        string name, 
        string? cpf, 
        string? dateBirth, 
        string? active);
}