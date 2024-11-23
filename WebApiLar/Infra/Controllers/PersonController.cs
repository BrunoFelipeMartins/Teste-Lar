using WebApiLar.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiLar.Application.DTO;
using WebApiLar.Application.UseCase;

namespace WebApiLar.Infra.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]    
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonOutput>> save(PersonInput input)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        PersonUseCase personUseCase = new PersonUseCase(personRepository);
        return CreatedAtAction("save", await personUseCase.save(input));
    }
    }
}