using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APImethods.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;


namespace APImethods.Controllers
{
    [Route("api/smarthome")]

    public class SmarthomeController : Controller

    {

        public SmarthomeController(ISmartHomeRepo devices)
        {
            Devices = devices;
        }

        public ISmartHomeRepo Devices { get; set; }
        public IEnumerable<Smarthome> GetAll()
        {
            return Devices.GetAll();
        }

        [HttpGet("{id}", Name = "GetDevice")]
        public IActionResult GetbById(string id)
        {
            var device = Devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }
            return new ObjectResult(device);
        }


        [HttpPost("{id}")]
        public IActionResult Create([FromBody] Smarthome device)
        {
            if (device == null)
            {
                return BadRequest();
            }
            Devices.Add(device);
            return CreatedAtRoute(
                routeName: "GetDevice", 
                routeValues: new { id = device.Key }, 
                value: device);
        }


        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Smarthome device)
        {
            if (device == null || device.Key != id)
            {
                return BadRequest();
            }

            var smartDevice = Devices.Find(id);
            if (smartDevice == null)
            {
                return NotFound();
            }

            Devices.Update(device);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]

        public void Delete(string id)
        {
            Devices.Remove(id);
        }

    }

}

