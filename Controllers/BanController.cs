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
    public class BanController : ControllerBase
    {

        public readonly IsBanService banService;

        public BanController() {
            banService = new IsBanService();
        }


        [HttpGet]
        public List<BanData> Get()
        {
            return banService.GetList();
        }

        [HttpPost]
        public bool Post(IsBan data)
        {
            return banService.Post(data);
        }


        [HttpPost("unban/{id}")]
        public List<BanData> UnBan(int id)
        {
            return banService.UnBan(id);
        }

        [HttpPost("banuser/{iduser}")]
        public List<BanData> BanUser(int iduser)
        {
            return banService.BanUser(iduser);
        }

        [HttpPost("notban/{idban}")]
        public List<BanData> NoBan(int idban)
        {
            return banService.NotBan(idban);
        }

        [HttpGet("banned")]
        public List<BanData> Banned()
        {
            return banService.Banned();
        }


    }
}