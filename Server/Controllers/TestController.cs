using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Test> NewData([FromQuery] int id)
        {
            return db.Test.Where(v => v.Id >= id);
        }

        [HttpGet]
        public IEnumerable<Test> GetAll()
        {
            return db.Test.Include(x => x.Question).ThenInclude(x => x.Answer).OrderBy(x => x.Titel);
        }

        [HttpGet]
        public IEnumerable<Test> GetById([FromQuery] int id)
        {
            return db.Test.Where(x => x.Id == id).Include(x => x.Question);
        }

        [HttpGet]
        public IEnumerable<Test> GetByName([FromQuery] string titel)
        {
            return db.Test.Where(x => x.Titel.Contains(titel)).Include(x => x.Question);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Test test)
        {
            try
            {
                await db.Test.AddAsync(test);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Test test)
        {
            try
            {
                db.Test.Update(test);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
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
                List<Test> testList = GetById(id).ToList();
                Test test = testList.First();
                db.Test.Remove(test);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                // log exception here
                return StatusCode(500);
            }
        }
    }
}
