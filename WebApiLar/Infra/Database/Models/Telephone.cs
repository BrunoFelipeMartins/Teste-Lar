using WebApiLar.Domain.Entity;

namespace WebApiLar.Infra.Database.Models
{
    public record telephone(
        long id, 
        string number,
        string typeTelephone, 
        long idPerson);
}