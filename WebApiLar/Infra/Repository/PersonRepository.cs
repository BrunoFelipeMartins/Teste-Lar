using WebApiLar.Domain.Entity;
using WebApiLar.Domain.Entity.Enum;
using WebApiLar.Domain.Repository;
using WebApiLar.Infra.Database;

namespace WebApiLar.Infra.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private AppDbContext appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Person> getList()
        {
            List<Person> objectListDomain = new List<Person>();
            List<Database.Models.Person> objectListModel = 
            this.appDbContext.people.Where(x => x.active == Active.ACTIVE).ToList();
            foreach(var item in objectListModel)
            {
                objectListDomain.Add(this.fillObject(item));
            }
            return objectListDomain;
        }

        public Person findById(long id)
        {
            Database.Models.Person? objectModel = this.appDbContext.
            people.Where(x => x.personId == id).FirstOrDefault();

            return this.fillObject(objectModel);
        }
        public async Task<Person> save(Person person)
        {
            Database.Models.Person objectModel = new Database.Models.Person(
                person.idPerson, person.name, person.cpf, person.dateBirth, person.active);
                if(objectModel.personId > 0)
                {
                    this.appDbContext.people.Update(objectModel);
                }else
                {
                    this.appDbContext.people.Add(objectModel);
                }
                await this.appDbContext.SaveChangesAsync();
                return new Person(objectModel.personId, objectModel.name, objectModel.cpf!, objectModel.dateBirth!, objectModel.active!);
        }

        private Person fillObject(Database.Models.Person? model){
            if(model != null){
                long idObject = (long)model.personId;
                string name = (string)model.name;
                string cpf = (string)model.cpf!;
                string date = (string)model.dateBirth!;
                string active = (string)model.active!;
                return new Person(idObject, name, cpf, date, active);
            }
            throw new KeyNotFoundException("Pessoa não encontrada");
        }
    }
}