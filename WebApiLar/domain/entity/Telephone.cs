
using WebApiLar.Domain.Entity.Enum;

namespace WebApiLar.Domain.Entity
    {
        public class Telephone
        {
            public long id { get; protected set; }
            public string number { get; protected set; }
            public string typeTelephone { get; protected set; }
            public long idPerson { get; protected set; }
            public Person person { get; set; } = null!;

            public Telephone(long id, string number = "", string typeTelephone = TypeTelephone.CELLPHONE, long idPerson = 0)
            {
                this.id = id;
                this.number = number;
                this.typeTelephone = TypeTelephone.CELLPHONE;
                this.idPerson = idPerson;
            }

            public Telephone(string number = "", string typeTelephone = TypeTelephone.CELLPHONE, long idPerson = 0)
            {
                this.number = number;
                this.typeTelephone = TypeTelephone.CELLPHONE;
                this.idPerson = idPerson;
            }

            public Telephone(string number, string typeTelephone, Person person)
            {
                this.number = number;
                this.typeTelephone = typeTelephone;
                this.person = person;
            }

            public static Telephone Create(string number, string typeTelephone, Person person)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Número inválido.");
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            return new Telephone(number, typeTelephone, person);
        }
        }
    }



