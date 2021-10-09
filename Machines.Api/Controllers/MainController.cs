using Machines.BL.Handlers;
using Machines.BL.Models;
using Machines.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Machines_Malfunctions.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {

        public MainController()
        {

        }

        [HttpGet("/api/machines")]
        public List<MachineWithMalfunctionsModel> GetAllMachines()
        {
            return MachineHandler.GetAllMachines();
        }

        [HttpGet("/api/machines/{machineId}")]
        public IActionResult GetSingleMachine(int machineId)
        {
            var response = MachineHandler.GetSingleMachine(machineId);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            return Ok(response.Payload);
        }

        [HttpPost("/api/machines")]
        public IActionResult InsertMachine([FromBody] Machine machine)
        {
            var response = MachineHandler.InsertMachine(machine);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.Errors);
            }

            return Ok();
        }
    }
}
