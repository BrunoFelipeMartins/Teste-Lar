namespace WebApiLar.Infra.Database.Models
{
    public record Person(
        long idPerson, 
        string name, 
        string? cpf, 
        string? dateBirth, 
        string? active);
}