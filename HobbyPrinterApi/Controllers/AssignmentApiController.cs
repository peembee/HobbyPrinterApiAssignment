using AutoMapper;
using HobbyPrinterApi.Data;
using HobbyPrinterApi.Models.DTO.People_DTO;
using HobbyPrinterApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using HobbyPrinterApi.Models.DTO.Hobby_DTO;
using HobbyPrinterApi.Models.DTO.Link_DTO;

namespace HobbyPrinterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentApiController : ControllerBase
    {
        public readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public AssignmentApiController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //-------------------------------------------
        // GET - Hämta alla personer i systemet
        [HttpGet("api/ Hämta alla personer i systemet")]
        public async Task<ActionResult<IEnumerable<PeopleGetDto>>> Get()
        {
            IEnumerable<People> peopleList = await context.Peoples.ToListAsync();

            var personsDto = mapper.Map<List<PeopleGetDto>>(peopleList); // Mapping dto-values 
            return Ok(personsDto);
        }

        //-------------------------------------------
        // GET: - Hämta alla intressen som är kopplade till en specifik person
        [HttpGet("{id}/ Hämta alla intressen som är kopplade till en specifik person")]
        public async Task<ActionResult<List<HobbyGetDto>>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var hobbys = await context.Hobbys
                        .Where(h => h.FK_PeopleID == id)
                        .ToListAsync();

            return Ok(hobbys);
        }

        //-------------------------------------------
        // GET: - Hämta alla länkar som är kopplade till en specifik person
        [HttpGet("{id}/ Hämta alla länkar som är kopplade till en specifik person")]
        public async Task<ActionResult> GetLinks(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var links = await (from l in context.Links
                               join h in context.Hobbys on l.FK_HobbyID equals h.HobbyID
                               where h.FK_PeopleID == id
                               select l.Url).ToListAsync();

            return Ok(links);
        }


        //-------------------------------------------
        // - Koppla en person till ett nytt intresse
        [HttpPost("{Person id}/ Koppla en person till ett nytt intresse")]
        public async Task<ActionResult<HobbyCreateDto>> Post([FromBody] HobbyCreateDto newHobbyDto)
        {
            var hobby = mapper.Map<Hobby>(newHobbyDto);
            await context.Hobbys.AddAsync(hobby);
            await context.SaveChangesAsync();
            return Ok(newHobbyDto);
        }
        //-------------------------------------------


        // - Lägga in nya länkar för en specifik person och ett specifikt intresse
        [HttpPost("{PeopleId}/ Lägga in nya länkar för en specifik person och ett specifikt intresse")]
        public async Task<ActionResult> PostLink(int PeopleId, string getUrl, int getHobby)
        {
            var hobby = await context.Hobbys.FirstOrDefaultAsync(h => h.FK_PeopleID == PeopleId && h.HobbyID == getHobby);

            if (hobby == null || PeopleId == 0)
            {
                return NotFound();
            }
            var createLink = new Link
            {
                FK_HobbyID = hobby.HobbyID,
                Url = getUrl
            };

            await context.Links.AddAsync(createLink);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
