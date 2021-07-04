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
    public class AnswerController : ControllerBase
    {
        ApplicationDbContext db;

        public AnswerController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Answer> NewData([FromQuery] int id)
        {
            return db.Answer.Where(v => v.Id >= id);
        }

        [HttpGet("{Id}")]
        public IEnumerable<Answer> GetAll(int id)
        {
            return db.Answer.Where(x => x.QuestionId == id);
        }

        [HttpGet]
        public IEnumerable<Answer> GetById([FromQuery] int id)
        {
            return db.Answer.Where(x => x.Id == id);
        }

        [HttpGet]
        public IEnumerable<Answer> GetByText([FromQuery] string text)
        {
            return db.Answer.Where(x => x.Text.Contains(text));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Answer answer)
        {
            try
            {
                await db.Answer.AddAsync(answer);
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
        public async Task<IActionResult> Update(Answer answer)
        {
            try
            {
                db.Answer.Update(answer);
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
                List<Answer> answerList = GetById(id).ToList();
                Answer answer = answerList.First();
                db.Answer.Remove(answer);
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
