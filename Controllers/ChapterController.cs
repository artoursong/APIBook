using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookAPI.Service;
using bookAPI.Models;

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
        public ChapterData Get(int id)
        {
            return chapterService.Get(id);
        }

        [HttpPost]
        public List<VolumeData> Post(ChapterData chapterData)
        {
            return chapterService.Post(chapterData);
        }

        [HttpPut()]
        public bool Put(ChapterData chapterData)
        {
            return chapterService.Put(chapterData);
        }

        [HttpDelete("{id}")]
        public VolumeData Delete(int id)
        {
            return chapterService.Delete(id);
        }

        [HttpGet("chapterofvolume/{id}")]
        public List<Chapter> GetChapters(int id) 
        {
            return chapterService.GetAllChapterOfVolume(id);
        }
    }
}