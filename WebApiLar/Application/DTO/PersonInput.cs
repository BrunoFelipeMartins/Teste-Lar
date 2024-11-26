using System.ComponentModel.DataAnnotations;
using WebApiLar.Domain.Entity.Enum;

namespace WebApiLar.Application.DTO
{
    public record PersonInput(
        long idPerson, 
        [Required][MinLength(3)] 
        string name = "", 
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [CpfValidation(ErrorMessage = "CPF inválido.")]
        string cpf = "", 
        string dateBirth = "",
        string active = Active.ACTIVE);
}

public class CpfValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var cpf = value as string;
        if (!CpfValidator.IsValidCpf(cpf))
        {
            return new ValidationResult(ErrorMessage);
        }
        return ValidationResult.Success;
    }
}