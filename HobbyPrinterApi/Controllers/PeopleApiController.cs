using AutoMapper;
using HobbyPrinterApi.Data;
using HobbyPrinterApi.Models;
using HobbyPrinterApi.Models.DTO.People_DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HobbyPrinterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleApiController : ControllerBase
    {
        public readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public PeopleApiController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        // GET: api/<PeopleApiController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeopleGetDto>>> Get()
        {
            IEnumerable<People> peopleList = await context.Peoples.ToListAsync();   

            var personsDto = mapper.Map<List<PeopleGetDto>>(peopleList); // Mapping dto-values 
            return Ok(personsDto);
        }


        // GET api/<PeopleApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeopleGetDto>> Get(int id)
        {
            var person = await context.Peoples.FirstOrDefaultAsync(p => p.PeopleID == id);
            var personDto = mapper.Map<PeopleGetDto>(person);
            return Ok(personDto);
        }


        // POST api/<PeopleApiController>
        [HttpPost]
        public async Task<ActionResult<PeopleCreateDto>> Post([FromBody] PeopleCreateDto newPersonDto)
        {
            var person = mapper.Map<People>(newPersonDto);
            await context.Peoples.AddAsync(person);
            await context.SaveChangesAsync();
            return Ok(newPersonDto);
        }


        // PUT api/<PeopleApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PeopleUpdateDto updatePerson)
        {
            var person = await context.Peoples.FirstOrDefaultAsync(p => p.PeopleID == id);
            mapper.Map(updatePerson,person);

            context.Update(person);
            await context.SaveChangesAsync();
            return NoContent();
        }


        // DELETE api/<PeopleApiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await context.Peoples.FirstOrDefaultAsync(p => p.PeopleID==id);

            context.Peoples.Remove(person);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
