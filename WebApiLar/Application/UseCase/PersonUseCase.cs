using WebApiLar.Application.DTO;
using WebApiLar.Domain.Entity;
using WebApiLar.Domain.Repository;

namespace WebApiLar.Application.UseCase
{
    public class PersonUseCase
    {
        private IPersonRepository personRepository;

        public PersonUseCase(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        public async Task<PersonOutput> save(PersonInput input)
        {
            Person person = new Person(input.idPerson, input.name, input.cpf, input.dateBirth, input.active);
            person = await this.personRepository.save(person);
            return new PersonOutput(person.idPerson, person.name);
        }
    }
}