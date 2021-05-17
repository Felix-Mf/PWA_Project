using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PWA_Project.Server.Data;
using PWA_Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_Project.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InputController : ControllerBase
    {
        ApplicationDbContext db;

        public InputController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Input> GetAll()
        {
            return db.Input;
        }

        [HttpGet]
        public IEnumerable<Input> GetById([FromQuery] int id)
        {
            return db.Input.Where(x => x.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Input input)
        {
            try
            {
                await db.Input.AddAsync(input);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Input input)
        {
            try
            {
                db.Input.Update(input);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                List<Input> inputList = GetById(id).ToList();
                Input input = inputList.First();
                db.Input.Remove(input);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }
    }
}
