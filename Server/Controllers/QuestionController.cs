﻿using Microsoft.AspNetCore.Authorization;
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
            return db.Question;
        }

        [HttpGet]
        public IEnumerable<Question> GetById([FromQuery] int id)
        {
            return db.Question.Where(x => x.Id == id);
        }

        [HttpGet]
        public IEnumerable<Question> GetByText([FromQuery] string text)
        {
            return db.Question.Where(x => x.Text.Contains(text));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Question Question)
        {
            try
            {
                await db.Question.AddAsync(Question);
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
        public async Task<IActionResult> Update(Question Question)
        {
            try
            {
                db.Question.Update(Question);
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
        public async Task<IActionResult> Delete(Question Question)
        {
            try
            {
                db.Question.Remove(Question);
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