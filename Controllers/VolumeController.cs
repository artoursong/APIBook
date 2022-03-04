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
    public class VolumeController : ControllerBase
    {

        public readonly VolumeService volumeService;

        public VolumeController () 
        {
            volumeService = new VolumeService();
        }

        [HttpGet("getvolumebyidbook/{id}")]
        public List<Volume> Get(int id)
        {
            return volumeService.GetAllVolumeOfBook(id);
        }

        [HttpPost]
        public VolumeData Post(Volume volume)
        {
            return volumeService.Post(volume);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return volumeService.Delete(id);
        }
        [HttpGet("{id}")]
        public Volume GetOneVolume(int id) {
            return volumeService.GetOneVolume(id);
        }
    }
}