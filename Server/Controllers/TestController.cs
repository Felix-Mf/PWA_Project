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
    public class TestController : ControllerBase
    {
        ApplicationDbContext db;

        public TestController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Test> GetAll()
        {
            return db.Test;
        }

        [HttpGet]
        public IEnumerable<Test> GetById([FromQuery] int id)
        {
            return db.Test.Where(x => x.Id == id);
        }

        [HttpGet]
        public IEnumerable<Test> GetByName([FromQuery] string titel)
        {
            return db.Test.Where(x => x.Titel.Contains(titel));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Test Test)
        {
            try
            {
                await db.Test.AddAsync(Test);
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
        public async Task<IActionResult> Update(Test Test)
        {
            try
            {
                db.Test.Update(Test);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Test Test)
        {
            try
            {
                db.Test.Remove(Test);
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
