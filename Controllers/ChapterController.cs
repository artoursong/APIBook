using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookAPI.Service;

namespace Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        public readonly ChapterService chapterService;

        public ChapterController() 
        {
            chapterService = new ChapterService();
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("convert")]
        public List<string> Convert([FromBody] string[] s) 
        {
            return chapterService.ConvertContent(s);
        }
    }
}