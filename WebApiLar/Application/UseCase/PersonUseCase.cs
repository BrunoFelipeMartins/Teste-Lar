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
            if(!CpfValidator.IsValidCpf(input.cpf))
            throw new ArgumentException("CPF inválido.");

            //var existingPerson = personRepository.findById(input.idPerson);
            //se pessoa igual a null
            //if(existingPerson == null)
            //{
            //    throw new KeyNotFoundException("Pessoa não encontrada para atualização");
           // }

            Person person = new Person(input.idPerson,input.name, input.cpf, input.dateBirth, input.active);
            person = await personRepository.save(person);
            return new PersonOutput(person.idPerson, person.name, person.cpf, person.dateBirth);
        }

        public List<PersonOutput> getList()
        {
            List<Person> personList = this.personRepository.getList();
            List<PersonOutput> PersonListOutput = new List<PersonOutput>();
            foreach(var person in personList)
            {
                PersonOutput personOutput = new PersonOutput(person.idPerson,
                person.name, person.cpf, person.dateBirth, person.active);
                PersonListOutput.Add(personOutput);
            }
            return PersonListOutput;
        }

        public PersonOutput findById(PersonInput input)
        {
            Person person = this.personRepository.findById(input.idPerson);
            return new PersonOutput(person.idPerson, person.name, person.cpf, person.dateBirth, person.active);
        }
    }
}