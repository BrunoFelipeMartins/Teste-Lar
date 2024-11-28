using WebApiLar.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiLar.Application.DTO;
using WebApiLar.Application.UseCase;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApiLar.Domain.Entity;

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
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<PersonOutput>> getList()
    {
        PersonUseCase personUseCase = new PersonUseCase(this.personRepository);
        return personUseCase.getList();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PersonOutput> findById(long id)
    {
        PersonUseCase personUseCase = new PersonUseCase(this.personRepository);
        PersonInput personInput = new PersonInput(id, "","","","");
        return personUseCase.findById(personInput);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonOutput>> update(long id, PersonInput input)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != input.idPerson)
        {
            return BadRequest("O ID fornecido na URL não coincide com o ID no corpo da requisição.");
        }

        PersonUseCase personUseCase = new PersonUseCase(personRepository);
        
        try
        {
        var updatedPerson = await personUseCase.save(input);
            return Ok(updatedPerson);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Pessoa não encontrada para atualização.");
        }
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
        PersonOutput personOutput = await personUseCase.save(input);

        return CreatedAtAction(nameof(findById), new {id = personOutput.idPerson}, personOutput);
    }

    [HttpPost("{id}/telephones")]
    public async Task<ActionResult> AddTelephone(long id, Telephone telephone)
    {
        var person = personRepository.findById(id);
        if (person == null) return NotFound();

        person.telephones.Add(telephone);
        await personRepository.save(person);

        return CreatedAtAction(nameof(findById), new { id = person.idPerson }, person);
    }

    [HttpDelete("{personId}/telephones/{telephoneId}")]
    public async Task<ActionResult> RemoveTelephone(long personId, long telephoneId)
    {
        var person = personRepository.findById(personId);
        if (person == null) return NotFound();

        var telephone = person.telephones.FirstOrDefault(t => t.id == telephoneId);
        if (telephone == null) return NotFound();

        person.telephones.Remove(telephone); // Remove o telefone da lista
        await personRepository.save(person);

        return NoContent();
    }
    }
}