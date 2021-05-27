using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PWA_Project.Shared;

namespace PWA_Project.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FileuploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SaveToPhysicalLocation([FromBody] SaveFile saveFile)
        {
            try
            {
                foreach (var file in saveFile.Files)
                {
                    string fileExtenstion = file.FileType.ToLower().Contains("png") ? ".png" : ".jpg";
                    string fileName = Path.Combine(Environment.CurrentDirectory, "Uploads", file.Guid + fileExtenstion);
                    using (var fileStream = System.IO.File.Create(fileName))
                    {
                        await fileStream.WriteAsync(file.Data);
                    }
                }
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
