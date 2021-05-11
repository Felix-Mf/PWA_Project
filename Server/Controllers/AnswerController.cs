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
    public class AnswerController : ControllerBase
    {
        ApplicationDbContext db;

        public AnswerController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Answer> GetAll()
        {
            return db.Answer;
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
        public async Task<IActionResult> Insert(Answer Answer)
        {
            try
            {
                await db.Answer.AddAsync(Answer);
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
        public async Task<IActionResult> Update(Answer Answer)
        {
            try
            {
                db.Answer.Update(Answer);
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
        public async Task<IActionResult> Delete(Answer Answer)
        {
            try
            {
                db.Answer.Remove(Answer);
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