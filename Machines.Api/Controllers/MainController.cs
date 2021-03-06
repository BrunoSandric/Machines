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

namespace Machines.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        //HTTP methods correspond to CRUD 

        //Create - POST
        //Read   - GET
        //Update - PUT
        //Delete - DELETE
        #region Machines

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

        [HttpDelete("/api/machines/{machineId}")]
        public IActionResult DeleteMachine(int machineId)
        {
            var response = MachineHandler.DeleteMachine(machineId);

            if (response.StatusCode == HttpStatusCode.BadRequest) 
            {
                return NotFound(response.Errors);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return StatusCode(500, response.Errors);
            }

            return Ok();
        }

        [HttpPut("/api/machines/{machineId}")]
        public IActionResult UpdateMachine(int machineId, [FromBody] Machine machine)
        {
            machine.id = machineId;
            var response = MachineHandler.UpdateMachine(machine);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.Errors);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return StatusCode(500, response.Errors);
            }

            return Ok();
        }

        #endregion

        #region Malfunctions

        [HttpGet("/api/malfunctions")]
        public IActionResult GetAllMalfunctions([FromQuery] int? page, [FromQuery] int? pageSize)
        {
            var response = MalfunctionHandler.GetAllMalfunctions(page, pageSize);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Payload);
        }

        [HttpGet("/api/malfunctions/{malfunctionId}")]
        public IActionResult GetSingleMalfunction(int malfunctionId)
        {
            var response = MachineHandler.GetSingleMachine(malfunctionId);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            return Ok(response.Payload);
        }

        [HttpPost("/api/malfunctions")]
        public IActionResult InsertMalfunction([FromBody] Malfunction malfunction)
        {
            var response = MalfunctionHandler.InsertMalfunction(malfunction);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Payload);
        }

        [HttpDelete("/api/malfunctions/{malfunctionId}")]
        public IActionResult DeleteMalfunction(int malfunctionId)
        {
            var response = MalfunctionHandler.DeleteMalfunction(malfunctionId);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return StatusCode(500, response.Errors);
            }

            return Ok();
        }

        [HttpPut("/api/malfunctions/{malfunctionId}")]
        public IActionResult UpdateMalfunction(int malfunctionId, [FromBody] Malfunction malfunction)
        {
            malfunction.id = malfunctionId;
            var response = MalfunctionHandler.UpdateMalfunction(malfunction);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.Errors);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return StatusCode(500, response.Errors);
            }

            return Ok();
        }


        #endregion

        #region MalfunctionStatus

        [HttpGet("/api/malfunctionstatuses")]
        public List<MalfunctionStatusModel> GetAllMalfunctionStatuses()
        {
            return MalfunctionStatusHandler.GetAllMalfunctionStatuses();
        }

        #endregion
    }
}
