namespace WebApiLar.Infra.Database.Models
{
    public record Person(long personId, string name, string? cpf, string? dateBirth, string? active);
}