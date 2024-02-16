using Microsoft.AspNetCore.Mvc;
using API_Condominio.Data;
using API_Condominio.Extensions;
using API_Condominio.Models;
using API_Condominio.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
namespace API_Condominio.Controllers;

    [ApiController]
    public class ResidentsController : Controller
    {
    [HttpGet("v1/residents")]
    public async Task<IActionResult> GetAsyncCache(
  [FromServices] IMemoryCache cache,
  [FromServices] DataContext context)
    {
        try
        {
            var residents = cache.GetOrCreate("residentCache", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return GetResidents(context);
            });
            return Ok(new ResultViewModel<List<Resident>>(residents));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Resident>>("05X04 - Falha interna no servidor"));
        }
    }
    private List<Resident> GetResidents(DataContext context) => context.Residents.ToList();




    [Authorize(Roles = "admin")]
        [HttpGet("v1/residents/")]
        public async Task<IActionResult> Get([FromServices] DataContext context)
        {

            try
            {
                var blocks = await context.Residents
                .Include(x => x.Sex)
                .Include( x => x.Unit)
                .ThenInclude(x => x.Block)
                .AsNoTracking()
                . ToListAsync();
                return Ok(blocks);
            }
            catch
            {
                return StatusCode(500, "05x04 - Falha Interna no serivodor");
            }
        }


    [Authorize(Roles = "admin")]
    [HttpGet("v1/residents/{id:int}")]
    public async Task<IActionResult> GetId(
        [FromServices] DataContext context,
        [FromRoute] int id)
    {
        try
        {
            var block = await context.Residents
                .Include(x => x.Sex)
                .Include(x => x.Unit)
                .ThenInclude(x => x.Block)
                .FirstOrDefaultAsync(y => y.Id == id);
            if (block == null)
                NotFound("Conteúdo não encontrado");
            return Ok(block);
        }
        catch 
        {
            return StatusCode(500, "05x04 - Falha interna no servidor");
        }
    }



    [Authorize(Roles ="admin")]
    [HttpPost("v1/residents/")]
    public async Task<IActionResult> Post([FromServices] DataContext context, [FromBody] ResidentViewModel model)
    {
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var resident = new Resident
            {
                Name = model.Name,
                Email = model.Email,
                CreationDate = model.CreationDate,
                Excluded = model.Excluded,
                Defaulter = model.Defaulter,
                Phone = model.Phone,
                ExclusionDate = model.ExclusionDate,
                SexId = model.SexId,
                UnitId = model.UnitId,
                Observation = model.Observation,
                Image = model.Image ?? "",
                DisabledPerson = model.DisabledPerson,
                Responsible = model.Responsible
                
                
            };
            await context.Residents.AddAsync(resident);
            await context.SaveChangesAsync();


            return Ok(new ResultViewModel<dynamic>(new
            {
                Nome = model.Name,
                Telefone = model.Phone,
                Email = model.Email,
                Sexo = resident.Sex.Name,
                Responsavel = model.Responsible,
                
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("05X99 - Este E-mail já está cadastrado"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
        }
    }


    [Authorize(Roles = "admin")]
    [HttpPut("v1/residents/{id:int}")]
    public async Task<IActionResult> Put([FromServices] DataContext context,
        [FromBody] ResidentViewModel model, [FromRoute] int id)
    {
        try {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var resident = await context.Residents.FirstOrDefaultAsync(x => x.Id == id);
            if (resident == null)
                return BadRequest(new ResultViewModel<Unit>(ModelState.GetErrors()));
            resident.Name = model.Name;
            resident.Phone = model.Phone;
            resident.Email = model.Email;
            resident.Observation = model.Observation;
            resident.Defaulter = model.Defaulter;
            resident.DisabledPerson = model.DisabledPerson;
            resident.Responsible    = model.Responsible;
            resident.SexId = model.SexId;



            await context.Residents.AddAsync(resident);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<dynamic>(new
            {
                Nome = model.Name,
                Observacao = model.Observation,
                Sexo = resident.Sex.Name,
                Unidade = resident.Unit.NumberUnit.ToString(),
            }));

        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("05X99 - Erro para atualizar os dados do morador"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
        }
    }



    [Authorize(Roles = "admin")]
    [HttpPost("v1/residents/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromServices] DataContext context, [FromRoute] int id)
    {
        try
        {
            var resident = await context.Residents.FirstOrDefaultAsync(x => x.Id ==id);
            if (resident == null)
                return BadRequest(new ResultViewModel<string>("Conteúdo não encontrado"));

            resident.Excluded = true;
            resident.ExclusionDate = DateTime.Now;
            await context.Residents.AddAsync(resident);
            await context.SaveChangesAsync();

            return Created($"v1/residents/{resident.Id}", resident);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "05x13 - Não foi possivel deletar a categoria");
        }
        catch
        {
            return StatusCode(500, "05x14 - falha interna no servidor");
        }
    }

  

}

