using WebApiLar.Application.DTO;
using WebApiLar.Domain.Entity;
using WebApiLar.Domain.Repository;

namespace WebApiLar.Application.UseCase
{
    public class TelephoneUseCase
    {
        private ITelephoneRepository telephoneRepository;

        public TelephoneUseCase(ITelephoneRepository telephoneRepository)
        {
            this.telephoneRepository = telephoneRepository;
        }

        public async Task<TelephoneOutput> save(TelephoneInput input)
        {            
            Telephone telephone = new Telephone(input.id,input.number, input.typeTelephone, input.idPerson);
            telephone = await telephoneRepository.save(telephone);
            return new TelephoneOutput(telephone.id, telephone.number, telephone.typeTelephone, telephone.idPerson);
        }

        public List<TelephoneOutput> getList()
        {
            List<Telephone> telephoneList = this.telephoneRepository.getList();
            List<TelephoneOutput> TelephoneListOutput = new List<TelephoneOutput>();
            foreach(var telephone in telephoneList)
            {
                TelephoneOutput telephoneOutput = new TelephoneOutput(telephone.id,
                telephone.number, telephone.typeTelephone, telephone.idPerson);
                TelephoneListOutput.Add(telephoneOutput);
            }
            return TelephoneListOutput;
        }

        public TelephoneOutput findById(TelephoneInput input)
        {
            Telephone telephone = this.telephoneRepository.findById(input.id);
            return new TelephoneOutput(telephone.id, telephone.number, telephone.typeTelephone, telephone.idPerson);
        }
    }
}