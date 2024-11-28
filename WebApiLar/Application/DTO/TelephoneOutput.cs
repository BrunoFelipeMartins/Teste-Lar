using WebApiLar.Domain.Entity;

namespace WebApiLar.Application.DTO
{
    public record TelephoneOutput(
        long id, 
        string number = "",
        string typeTelephone = "",
        long idPerson = 0
    );
}