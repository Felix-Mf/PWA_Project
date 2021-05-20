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
    public class QuestionController : ControllerBase
    {
        ApplicationDbContext db;

        public QuestionController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Question> GetAll()
        {
            return db.Question.Include(x => x.Answer);
        }

        [HttpGet]
        public IEnumerable<Question> GetById([FromQuery] int id)
        {
            return db.Question.Where(x => x.Id == id).Include(x => x.Answer);
        }

        [HttpGet]
        public IEnumerable<Question> GetByText([FromQuery] string text)
        {
            return db.Question.Where(x => x.Text.Contains(text)).Include(x => x.Answer);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Question question)
        {
            try
            {
                await db.Question.AddAsync(question);
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
        public async Task<IActionResult> Update(Question question)
        {
            try
            {
                db.Question.Update(question);
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
                List<Question> questionList = GetById(id).ToList();
                Question question = questionList.First();
                db.Question.Remove(question);
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
