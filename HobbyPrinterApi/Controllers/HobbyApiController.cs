using AutoMapper;
using HobbyPrinterApi.Data;
using HobbyPrinterApi.Models;
using HobbyPrinterApi.Models.DTO.Hobby_DTO;
using HobbyPrinterApi.Models.DTO.People_DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HobbyPrinterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyApiController : ControllerBase
    {
        public readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public HobbyApiController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        // GET: api/<HobbyApiController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HobbyGetDto>>> Get()
        {
            IEnumerable<Hobby> hobbyList = await context.Hobbys.ToListAsync();

            var hobbyDto = mapper.Map<List<HobbyGetDto>>(hobbyList); // Mapping dto-values 
            return Ok(hobbyDto);
        }


        // GET api/<HobbyApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HobbyGetDto>> Get(int id)
        {
            var hobby = await context.Hobbys.FirstOrDefaultAsync(h => h.HobbyID == id);
            var hobbyDto = mapper.Map<HobbyGetDto>(hobby);
            return Ok(hobbyDto);
        }


        // POST api/<HobbyApiController>
        [HttpPost]
        public async Task<ActionResult<HobbyCreateDto>> Post([FromBody] HobbyCreateDto newHobbyDto)
        {
            var hobby = mapper.Map<Hobby>(newHobbyDto);
            await context.Hobbys.AddAsync(hobby);
            await context.SaveChangesAsync();
            return Ok(newHobbyDto);
        }


        // PUT api/<HobbyApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HobbyUpdateDto updateHobby)
        {
            var hobby = await context.Hobbys.FirstOrDefaultAsync(h => h.HobbyID == id);
            mapper.Map(updateHobby, hobby);

            context.Update(hobby);
            await context.SaveChangesAsync();
            return NoContent();
        }


        // DELETE api/<HobbyApiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hobby = await context.Hobbys.FirstOrDefaultAsync(h => h.HobbyID== id);

            context.Hobbys.Remove(hobby);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
