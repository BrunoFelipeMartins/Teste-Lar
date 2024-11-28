using System.ComponentModel.DataAnnotations;
using WebApiLar.Domain.Entity.Enum;

namespace WebApiLar.Application.DTO
{
    public record TelephoneInput(long id, string number = "", 
    string typeTelephone = "", long idPerson = 0);
}