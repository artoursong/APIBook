using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookAPI.Models;
using bookAPI.Service;

namespace Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {

        public readonly FollowService followService;

        public FollowController() {
            followService = new FollowService();
        }


        [HttpGet("{id}")]
        public List<int> Get(int id)
        {
            return followService.GetFollows(id);
        }

        [HttpPost]
        public List<int> Post(Follow follow)
        {
            return followService.Post(follow);
        }


        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return followService.Delete(id);
        }

        [HttpGet("allfollow/{id}")]
        public List<FollowBook> GetAll(int id)
        {
            return followService.Get(id);
        }
    }
}