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
    public class CourseController : ControllerBase
    {
        ApplicationDbContext db;

        public CourseController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Course> GetAll()
        {
            return db.Course.Include(x => x.Test).OrderBy(x => x.Titel);
        }

        [HttpGet]
        public IEnumerable<Course> GetById([FromQuery] int id)
        {
            return db.Course.Where(x => x.Id == id).Include(x => x.Test);
        }

        [HttpGet]
        public IEnumerable<Course> GetByName([FromQuery] string titel)
        {
            return db.Course.Where(x => x.Titel.Contains(titel)).Include(x => x.Test);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Course course)
        {
            try
            {
                await db.Course.AddAsync(course);
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
        public async Task<IActionResult> Update(Course course)
        {
            try
            {
                db.Course.Update(course);
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
                List<Course> courseList = GetById(id).ToList();
                Course course = courseList.First();
                db.Course.Remove(course);
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
