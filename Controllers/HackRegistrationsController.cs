using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApi.Models;
using DemoApi.Extensions;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackRegistrationsController : ControllerBase
    {
        private IHackRegistration _hack;

        public HackRegistrationsController(IHackRegistration hack)
        {
            _hack = hack;
        }

        // GET: api/HackRegistrations
        [HttpGet]
        public IActionResult GetHackRegistration()
        {
            return Ok(_hack.GetHackRegistrations());
        }

        // GET: api/HackRegistrations/5
        [HttpGet("{id}")]
        public IActionResult GetHackRegistration(int id)
        {
            try
            {
                var data = _hack.GetHackRegistrations(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // PUT: api/HackRegistrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutHackRegistration(int id, HackRegistration hackRegistration)
        {
            try
            {
                hackRegistration.Id = id;
                _hack.UpdateHackRegistration(hackRegistration);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/HackRegistrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostHackRegistration(HackRegistration hackRegistration)
        {
            return Ok(_hack.AddHackRegistration(hackRegistration));
        }

        // DELETE: api/HackRegistrations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHackRegistration(string id)
        {
            try
            {
                string[] Ids = id.Split(';');

                _hack.DeleteHackRegistration(Ids);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
