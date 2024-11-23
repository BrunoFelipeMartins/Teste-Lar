using System.ComponentModel.DataAnnotations;
using WebApiLar.Domain.Entity.Enum;

namespace WebApiLar.Application.DTO
{
    public record PersonOutput(long idPerson, string name = "", 
    string cpf = "", string dateBirth = "",string active = Active.ACTIVE);
}