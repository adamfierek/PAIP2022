using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("add/{a:double}/{b:double}")]
        public double Add(double a, double b)
        {
            return a + b;
        }

        [HttpGet("substract/{a:double}/{b:double}")]
        public double Substract(double a, double b)
        {
            return a - b;
        }
    }
}
