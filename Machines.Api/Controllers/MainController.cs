using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Machines_Malfunctions.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {

        public MainController()
        {

        }

        [HttpGet("/api/")]
        public void Test()
        {

        }
    }
}
