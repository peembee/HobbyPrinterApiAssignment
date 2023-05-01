using AutoMapper;
using HobbyPrinterApi.Data;
using HobbyPrinterApi.Models;
using HobbyPrinterApi.Models.DTO.Hobby_DTO;
using HobbyPrinterApi.Models.DTO.Link_DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HobbyPrinterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkApiController : ControllerBase
    {
        public readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public LinkApiController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        // GET: api/<LinkApiController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinkGetDto>>> Get()
        {
            IEnumerable<Link> linkList = await context.Links.ToListAsync();

            var linkDto = mapper.Map<List<LinkGetDto>>(linkList); // Mapping dto-values 
            return Ok(linkDto);
        }


        // GET api/<LinkApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkGetDto>> Get(int id)
        {
            var link = await context.Links.FirstOrDefaultAsync(l => l.LinkID == id);
            var linkDto = mapper.Map<LinkGetDto>(link);
            return Ok(linkDto);
        }


        // POST api/<LinkApiController>
        [HttpPost]
        public async Task<ActionResult<LinkCreateDto>> Post([FromBody] LinkCreateDto newLinkDto)
        {
            var link = mapper.Map<Link>(newLinkDto);
            await context.Links.AddAsync(link);
            await context.SaveChangesAsync();
            return Ok(newLinkDto);
        }


        // PUT api/<LinkApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LinkUpdateDto updateLink)
        {
            var link = await context.Links.FirstOrDefaultAsync(l => l.LinkID == id);
            mapper.Map(updateLink, link);

            context.Update(link);
            await context.SaveChangesAsync();
            return NoContent();
        }


        // DELETE api/<LinkApiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var link = await context.Links.FirstOrDefaultAsync(l => l.LinkID == id);

            context.Links.Remove(link);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
