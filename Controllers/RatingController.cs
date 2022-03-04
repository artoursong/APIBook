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
    public class RatingController : ControllerBase
    {
        public readonly RatingService ratingService;

        public RatingController() {
            ratingService = new RatingService();
        }
        
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return ratingService.Rate_average(id);
        }

        [HttpPost]
        public bool Post(Rating rating)
        {
            return ratingService.Post(rating);
        }
    }
}