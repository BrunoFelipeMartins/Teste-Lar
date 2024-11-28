using WebApiLar.Domain.Entity.Enum;
namespace WebApiLar.Domain.Entity
{

    public class Person
    {
        public long idPerson { get; protected set; }
        public string name { get; protected set;}
        public string cpf { get; protected set; }
        public string dateBirth { get; protected set; }
        public string active { get; protected set; }
        public ICollection<Telephone> telephones{ get; } = new List<Telephone>();

        public Person(string name = "", string cpf = "", string dateBirth = "", string active = Active.ACTIVE)
        {
            this.name = name;
            this.cpf = cpf;
            this.dateBirth = dateBirth;
            this.active = Active.ACTIVE;
        }

        public Person(long idPerson, string name = "", string cpf = "", string dateBirth = "", string active = Active.ACTIVE)
        {
            this.idPerson = idPerson;
            this.name = name;
            this.cpf = cpf;
            this.dateBirth = dateBirth;
            this.active = Active.ACTIVE;
        }


    }
}