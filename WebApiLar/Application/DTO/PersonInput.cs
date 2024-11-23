using System.ComponentModel.DataAnnotations;
using WebApiLar.Domain.Entity.Enum;

namespace WebApiLar.Application.DTO
{
    public record PersonInput(long idPerson, [Required][MinLength(3)] string name = "", 
    string cpf = "", string dateBirth = "",string active = Active.ACTIVE);
}